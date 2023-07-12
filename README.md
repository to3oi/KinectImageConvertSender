# KinectImageConvertSender
Kinectからの赤外線・深度データをOpenCVで加工して物体検出モデルで座標を探し、UDPで送信するソフトウェアです。

物体検出で以下のリポジトリを使用、変更しています。
https://github.com/dotnet/machinelearning-samples/tree/main/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx

プロジェクト名は本来、OpenCVでの加工までを担うソフトウェアを想定していたことから`KinectImageConvertSender`になっています。

# 開発期間
2023/6/19 ~
# 開発環境
| Tools	                                  | Version | 
| --------------------------------------- | ------- | 
| Microsoft Visual Studio Community 2022  | 17.6.4  | 

| PakageName	                  | Version        | 
| ----------------------------- | -------------- | 
| MessagePack                   | 2.5.124        | 
| Microsoft.Azure.Kinect.Sensor | 1.4.1          | 
| Microsoft.ML                  | 2.0.1          | 
| Microsoft.ML.ImageAnalytics   | 2.0.1          | 
| Microsoft.ML.OnnxTransformer  | 2.0.1          | 
| Microsoft.ML.OnnxRuntime.Gpu  | 1.14.0         | 
| OpenCvSharp4                  | 4.7.0.20230115 | 
| OpenCvSharp4.Extensions       | 4.7.0.20230115 | 
| OpenCvSharp4.runtime.win      | 4.7.0.20230115 | 
| OpenCvSharp4.Windows          | 4.7.0.20230115 | 
| OpenCvSharp4.WpfExtensions    | 4.7.0.20230115 | 
