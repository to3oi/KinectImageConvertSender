using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML.Data;

namespace ObjectDetection.DataStructures
{
    public class ImageNetData
    {
        [LoadColumn(0)]
        public string ImagePath;

        [LoadColumn(1)]
        public string Label;

        public static IEnumerable<ImageNetData> ReadFromFile(string imageFolder)
        {
            yield return new ImageNetData { ImagePath = imageFolder, Label = Path.GetFileName(imageFolder) };

            /*Directory
            .GetFiles(imageFolder)
            //絶対パスが返ってくる
            .Where(filePath => Path.GetExtension(filePath) != ".md")
            .Select(filePath => new ImageNetData { ImagePath = filePath, Label = Path.GetFileName(filePath) });*/
        }
    }
}