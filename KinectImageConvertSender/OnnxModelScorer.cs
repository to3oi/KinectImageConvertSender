using Microsoft.ML;
using Microsoft.ML.Data;
using ObjectDetection.DataStructures;

namespace ObjectDetection
{
    class OnnxModelScorer
    {
        private readonly string modelLocation;
        private readonly MLContext mlContext;


        public OnnxModelScorer(string modelLocation, MLContext mlContext)
        {
            this.modelLocation = modelLocation;
            this.mlContext = mlContext;
        }

        public struct ImageNetSettings
        {
            public const int imageHeight = 416;
            public const int imageWidth = 416;
        }

        public struct TinyYoloModelSettings
        {
            // input tensor name
            public const string ModelInput = "data";

            // output tensor name
            public const string ModelOutput = "model_outputs0";
        }

        private ITransformer LoadModel(string modelLocation)
        {
            // Create IDataView from empty list to obtain input data schema
            var data = mlContext.Data.LoadFromEnumerable(new List<ImageNetData>());

            // Define scoring pipeline
            var pipeline = mlContext.Transforms.LoadImages
                (outputColumnName: "data", imageFolder: "", inputColumnName: nameof(ImageNetData.ImagePath))
                          .Append(mlContext.Transforms.ResizeImages(outputColumnName: "data", imageWidth: ImageNetSettings.imageWidth, imageHeight: ImageNetSettings.imageHeight, inputColumnName: "data"))
                          .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "data"))
                          .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { TinyYoloModelSettings.ModelOutput }, inputColumnNames: new[] { TinyYoloModelSettings.ModelInput }));

            // Fit scoring pipeline
            var model = pipeline.Fit(data);

            return model;
        }

        private IEnumerable<float[]> PredictDataUsingModel(IDataView testData, ITransformer model)
        {
            IDataView scoredData = model.Transform(testData);

            IEnumerable<float[]> probabilities = scoredData.GetColumn<float[]>(TinyYoloModelSettings.ModelOutput);

            return probabilities;
        }

        public IEnumerable<float[]> Score(IDataView data)
        {
            var model = LoadModel(modelLocation);

            return PredictDataUsingModel(data, model);
        }
    }
}

