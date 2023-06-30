﻿namespace KinectImageConvertSender
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using ObjectDetection.YoloParser;
    using ObjectDetection.DataStructures;
    using ObjectDetection;
    using Microsoft.ML;
    using System.Diagnostics;

    public class ImageRecognition
    {
        string assetsRelativePath;
        string assetsPath;
        string modelFilePath;
        string imagesFolder;
        string loadImageRecognition;
        string tempImages;
        string outputFolder;


        public ImageRecognition()
        {
            assetsRelativePath = @"../../../../assets";
            assetsPath = GetAbsolutePath(assetsRelativePath);
            //var modelFilePath = Path.Combine(assetsPath, "Model", "TinyYolo2_model.onnx");
            modelFilePath = Path.Combine(assetsPath, "Model", "model.onnx");
            imagesFolder = Path.Combine(assetsPath, "images");
            loadImageRecognition = Path.Combine(assetsPath, "ImageRecognition");
            tempImages = Path.Combine(assetsPath, "TempImage");
            outputFolder = Path.Combine(assetsPath, "images", "output");

        }


        public List<ResultStruct> ImageRecognitionToFilePath(string ImageFilePath)
        {
            // Initialize MLContext
            MLContext mlContext = new MLContext();
            List<ResultStruct> results = new List<ResultStruct>();

            try
            {
                // Load Data
                IEnumerable<ImageNetData> images = ImageNetData.ReadFromFile(ImageFilePath);
                IDataView imageDataView = mlContext.Data.LoadFromEnumerable(images);

                // Create instance of model scorer
                var modelScorer = new OnnxModelScorer(ImageFilePath, modelFilePath, mlContext);

                // Use model to score data
                IEnumerable<float[]> probabilities = modelScorer.Score(imageDataView);

                // Post-process model output
                YoloOutputParser parser = new YoloOutputParser();

                var boundingBoxes =
                    probabilities
                    .Select(probability => parser.ParseOutputs(probability))
                    //.5Fが表示するスコアの値
                    .Select(boxes => parser.FilterBoundingBoxes(boxes, 5, .5F));

                //基本的にimages.Countは1のはずなので複数回回す意味はないが2以上になったときに最後に処理した(indexが大きい最新のもの)の値を返すのに使用
                for (var i = 0; i < images.Count(); i++)
                {
                    string imageFileName = images.ElementAt(i).Label;
                    IList<YoloBoundingBox> detectedObjects = boundingBoxes.ElementAt(i);
                    results = DrawBoundingBox(detectedObjects);
                }

                //画像認識済みの画像ファイルを移動
                string newFilePath = Path.Combine(tempImages, Path.GetFileName(ImageFilePath));
                File.Move(ImageFilePath, newFilePath);

                //以降描画処理
                // Draw bounding boxes for detected objects in each of the images
                /*                for (var i = 0; i < images.Count(); i++)
                                {
                                    string imageFileName = images.ElementAt(i).Label;
                                    IList<YoloBoundingBox> detectedObjects = boundingBoxes.ElementAt(i);

                                    DrawBoundingBox(imagesFolder, outputFolder, imageFileName, detectedObjects);

                                    LogDetectedObjects(imageFileName, detectedObjects);
                                }
                            }
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return results;

        }
        string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }

        void DrawBoundingBox(string inputImageLocation, string outputImageLocation, string imageName, IList<YoloBoundingBox> filteredBoundingBoxes)
        {
            Image image = Image.FromFile(Path.Combine(inputImageLocation, imageName));

            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;

            foreach (var box in filteredBoundingBoxes)
            {
                // Get Bounding Box Dimensions
                var x = (uint)Math.Max(box.Dimensions.X, 0);
                var y = (uint)Math.Max(box.Dimensions.Y, 0);
                var width = (uint)Math.Min(originalImageWidth - x, box.Dimensions.Width);
                var height = (uint)Math.Min(originalImageHeight - y, box.Dimensions.Height);

                // Resize To Image
                x = (uint)originalImageWidth * x / OnnxModelScorer.ImageNetSettings.imageWidth;
                y = (uint)originalImageHeight * y / OnnxModelScorer.ImageNetSettings.imageHeight;
                width = (uint)originalImageWidth * width / OnnxModelScorer.ImageNetSettings.imageWidth;
                height = (uint)originalImageHeight * height / OnnxModelScorer.ImageNetSettings.imageHeight;

                // Bounding Box Text
                string text = $"{box.Label} ({(box.Confidence * 100).ToString("0")}%)";

                using (Graphics thumbnailGraphic = Graphics.FromImage(image))
                {
                    thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Define Text Options
                    Font drawFont = new Font("Arial", 12, FontStyle.Bold);
                    SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);

                    // Define BoundingBox options
                    Pen pen = new Pen(box.BoxColor, 3.2f);
                    SolidBrush colorBrush = new SolidBrush(box.BoxColor);

                    // Draw text on image 
                    thumbnailGraphic.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                    thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);

                    // Draw bounding box on image
                    thumbnailGraphic.DrawRectangle(pen, x, y, width, height);

                    //認識した座標を出力
                    var posX = x + width / 2;
                    var posY = y + width / 2;
                }
            }

            if (!Directory.Exists(outputImageLocation))
            {
                Directory.CreateDirectory(outputImageLocation);
            }

            image.Save(Path.Combine(outputImageLocation, imageName));
        }

        List<ResultStruct> DrawBoundingBox(IList<YoloBoundingBox> filteredBoundingBoxes)
        {

            List<ResultStruct> results = new List<ResultStruct>();
            var originalImageHeight = 576;
            var originalImageWidth = 640;

            foreach (var box in filteredBoundingBoxes)
            {
                // Get Bounding Box Dimensions
                var x = (uint)Math.Max(box.Dimensions.X, 0);
                var y = (uint)Math.Max(box.Dimensions.Y, 0);
                var width = (uint)Math.Min(originalImageWidth - x, box.Dimensions.Width);
                var height = (uint)Math.Min(originalImageHeight - y, box.Dimensions.Height);

                // Resize To Image
                x = (uint)originalImageWidth * x / OnnxModelScorer.ImageNetSettings.imageWidth;
                y = (uint)originalImageHeight * y / OnnxModelScorer.ImageNetSettings.imageHeight;
                width = (uint)originalImageWidth * width / OnnxModelScorer.ImageNetSettings.imageWidth;
                height = (uint)originalImageHeight * height / OnnxModelScorer.ImageNetSettings.imageHeight;


                //認識した座標を出力
                var posX = x + width / 2;
                var posY = y + width / 2;
                results.Add(new ResultStruct(box.Label, posX, posY, box.Confidence));
                /*
                                    // Bounding Box Text
                                    string text = $"{box.Label} ({(box.Confidence * 100).ToString("0")}%)";

                                    using (Graphics thumbnailGraphic = Graphics.FromImage(image))
                                    {
                                        thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
                                        thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
                                        thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                                        // Define Text Options
                                        Font drawFont = new Font("Arial", 12, FontStyle.Bold);
                                        SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
                                        SolidBrush fontBrush = new SolidBrush(Color.Black);
                                        Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);

                                        // Define BoundingBox options
                                        Pen pen = new Pen(box.BoxColor, 3.2f);
                                        SolidBrush colorBrush = new SolidBrush(box.BoxColor);

                                        // Draw text on image 
                                        thumbnailGraphic.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                                        thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);

                                        // Draw bounding box on image
                                        thumbnailGraphic.DrawRectangle(pen, x, y, width, height);

                                        //認識した座標を出力
                                        var posX = x + width / 2;
                                        var posY = y + width / 2;
                                        //1console.writeline($"{box.Label} and its Confidence score: {box.Confidence}  Position x :{posX} y:{posY}");
                                    }*/
            }
            return results;
        }


        void LogDetectedObjects(string imageName, IList<YoloBoundingBox> boundingBoxes)
        {

            foreach (var box in boundingBoxes)
            {
            }

        }

    }
}