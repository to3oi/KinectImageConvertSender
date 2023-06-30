using ObjectDetection.YoloParser;
using ObjectDetection.DataStructures;
using ObjectDetection;
using Microsoft.ML;

namespace KinectImageConvertSender
{
    public class ImageRecognition
    {
        string assetsRelativePath;
        string assetsPath;
        string modelFilePath;

        public ImageRecognition()
        {
            assetsRelativePath = @"../../../../assets";
            assetsPath = GetAbsolutePath(assetsRelativePath);
            //var modelFilePath = Path.Combine(assetsPath, "Model", "TinyYolo2_model.onnx");
            modelFilePath = Path.Combine(assetsPath, "Model", "model.onnx");
        }


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
                var modelScorer = new OnnxModelScorer(_imageFilePath, modelFilePath, mlContext);

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

/*                //画像認識済みの画像ファイルを移動
                string newFilePath = Path.Combine(tempImagesFolder, Path.GetFileName(_imageFilePath));
                File.Move(_imageFilePath, newFilePath);*/
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
                var posY = y + height / 2;
                results.Add(new ResultStruct(box.Label, posX, posY, box.Confidence));
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