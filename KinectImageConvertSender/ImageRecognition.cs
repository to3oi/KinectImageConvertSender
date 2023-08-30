﻿using ObjectDetection.CustomVisionParser;
using ObjectDetection.DataStructures;
using ObjectDetection;
using Microsoft.ML;
using static KinectImageConvertSender.FilePath;
namespace KinectImageConvertSender
{
    /// <summary>
    /// 画像認識を実行するためのクラス
    /// </summary>
    public class ImageRecognition
    {
        public ImageRecognition() { }


        public List<ResultStruct> ImageRecognitionToFilePath(string _imageFilePath)
        {
            // Initialize MLContext
            MLContext mlContext = new MLContext();
            List<ResultStruct> results = new List<ResultStruct>();

            try
            {
                // Load Data
                IEnumerable<ImageNetData> images = ImageNetData.ReadFromFile(_imageFilePath);
                IDataView imageDataView = mlContext.Data.LoadFromEnumerable(images);

                // Create instance of model scorer
                var modelScorer = new OnnxModelScorer(modelFilePath, mlContext);

                // Use model to score data
                IEnumerable<float[]> probabilities = modelScorer.Score(imageDataView);

                // Post-process model output
                CustomVisionOutputParser parser = new CustomVisionOutputParser();

                var boundingBoxes =
                    probabilities
                    .Select(probability => parser.ParseOutputs(probability))
                    //.5Fが表示するスコアの値
                    .Select(boxes => parser.FilterBoundingBoxes(boxes, 5, .5F));

                //基本的にimages.Countは1のはずなので複数回回す意味はないが2以上になったときに最後に処理した(indexが大きい最新のもの)の値を返すのに使用
                for (var i = 0; i < images.Count(); i++)
                {
                    string imageFileName = images.ElementAt(i).Label;
                    IList<CustomVisionBoundingBox> detectedObjects = boundingBoxes.ElementAt(i);
                    results = CalculateBoundingBox(detectedObjects);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return results;

        }

        //KinectのDepth,IRのサイズ(固定値)
        int originalImageHeight = 576;
        int originalImageWidth = 640;
        /*
            +---------------------- x
            | 
            | 
            | 
            | 
            | 
            | 
            |
            y
         */
        List<ResultStruct> CalculateBoundingBox(IList<CustomVisionBoundingBox> filteredBoundingBoxes)
        {

            List<ResultStruct> results = new List<ResultStruct>();
            Form1 form1 = Form1.Form1Instance;
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
                float posX = x + width / 2;
                float posY = y + height / 2;

                float resPosX = posX;
                float resPosY = posY;

                //Offsetで調整した値を反映
                //X
                if (form1.GetLeftOffset != "" && form1.GetRightOffset != "")
                {
                    int rightOffset = int.Parse(form1.GetRightOffset);
                    int leftOffset = int.Parse(form1.GetLeftOffset);

                    if (posX <= leftOffset ||
                     originalImageHeight - rightOffset <= posX)
                    {
                        //右のOffsetの範囲を越していたらresultsに追加しないで終了
                        continue;
                    }
                    resPosX = (float)(posX - leftOffset) * (float)(originalImageWidth / (float)(originalImageWidth - (float)(rightOffset + leftOffset)));

                }

                if (form1.GetTopOffset != "" && form1.GetBottomOffset != "")
                {
                    int topOffset = int.Parse(form1.GetTopOffset);
                    int bottomOffset = int.Parse(form1.GetBottomOffset);
                    if (posY <= topOffset ||
                     originalImageHeight - bottomOffset <= posY)
                    {
                        //下のOffsetの範囲を越していたらresultsに追加しないで終了
                        continue;
                    }
                    resPosY = (float)(posY - topOffset) * (float)(originalImageHeight / (float)(originalImageHeight - (float)(topOffset + bottomOffset)));
                }
                results.Add(new ResultStruct(box.Label, resPosX, resPosY, box.Confidence));
            }

            return results;
        }
    }
}