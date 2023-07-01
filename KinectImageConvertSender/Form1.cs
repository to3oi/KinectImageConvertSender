using MessagePack;
using Microsoft.Azure.Kinect.Sensor;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEasyNet;
using static KinectImageConvertSender.FilePath;
using BitmapData = System.Drawing.Imaging.BitmapData;
using Image = Microsoft.Azure.Kinect.Sensor.Image;

namespace KinectImageConvertSender
{
    public partial class Form1 : Form
    {
        //画像処理関係
        private int _depthDistanceMin = 500;
        private int _depthDistanceMax = 1500;
        private int _depthThresholdMaxColor = 200;

        private int _irDistanceMin = 500;
        private int _irDistanceMax = 1500;
        private int _irThresholdMaxColor = 255;

        private int _depthThresholdMin = 254;
        private int _depthThresholdMax = 255;

        private int _irThresholdMin = 254;
        private int _irThresholdMax = 255;

        //UDP関係
        private bool _isUDPSend = false;
        private UDPSender UDPSender;
        private string _ipAdressText = "localhost";
        private int _port = 12001; //適当な値


        //Kinectを扱う変数
        Device kinect;
        //Depth画像のBitmap
        Bitmap depthBitmap;
        //IR画像のBitmap
        Bitmap irBitmap;
        //(追加)Kinectの画像取得の可否
        bool loop = true;

        uint saveFileIndex = 0;
        ImageRecognition imageRecognition;

        //デバッグ用
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        //デバッグ用
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
        public Form1()
        {
            //コンポーネントの初期化
            InitializeComponent();

            //Kinectの接続が必要
#if false

            InitKinect();
            //Kinectの設定情報に基づいてBitmap関連情報を初期化
            InitBitmap();

            //IPv4のアドレスを取得して表示
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    PCViewIpAdress.Text = ip.ToString();
                    break;
                }
            }

            imageRecognition = new ImageRecognition();



            //(追加)初期化が終わったのでデータ取得開始
            Task kl = KinectLoop();
#endif
            //デバッグ用
            AllocConsole();
            //デバッグ
            Task tsl = TestSendLoop();
        }


        private async Task TestSendLoop()
        {
            this.Show();
            while (loop)
            {
                /*MessagePackTest
                List<ResultStruct> results = new List<ResultStruct>()
                { 
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                    new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } };
                
                
                byte[] serializedData = MessagePackSerializer.Serialize(results);
                // デシリアライズ
                List<ResultStruct> deserializedList = MessagePackSerializer.Deserialize<List<ResultStruct>>(serializedData);
                
                foreach (var result in deserializedList)
                {
                    Console.WriteLine($"{result.Label},{result.PosX},{result.PosY},{result.Confidence}");
                }*/

                if (_isUDPSend)
                {
                    List<ResultStruct> results = new List<ResultStruct>()
            {
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } ,
                new ResultStruct{ Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } };


                    byte[] serializedData = MessagePackSerializer.Serialize(results);
                    UDPSender.Send(serializedData);
                }

                //表示を更新
                this.Update();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        //(追加)Kinectからデータを取得して表示するメソッド
        private async Task KinectLoop()
        {
            //loopがtrueの間はデータを取り続ける
            while (loop)
            {
                //kinectから新しいデータをもらう
                using (Capture capture = await Task.Run(() => kinect.GetCapture()).ConfigureAwait(true))
                {
                    #region Depth
                    //Depth画像を取得
                    Image depthImage = capture.Depth;
                    //Depth画像の各ピクセルの値(奥行)のみを取得
                    ushort[] depthArray = depthImage.GetPixels<ushort>().ToArray();
                    //depthBitmapの各画素に値を書き込む準備
                    BitmapData bitmapData = depthBitmap.LockBits(new Rectangle(0, 0, depthBitmap.Width, depthBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    unsafe
                    {
                        //各ピクセルの値へのポインタ
                        byte* pixels = (byte*)bitmapData.Scan0;
                        int index;
                        int depth;
                        //一ピクセルずつ処理
                        for (int i = 0; i < depthArray.Length; i++)
                        {
                            depth = 255 - (int)(255 * (depthArray[i] - _depthDistanceMin) / _depthDistanceMax);
                            if (depth < 0)
                            {
                                depth = 0;
                            }
                            else if (depth > _depthThresholdMaxColor)
                            {
                                depth = 255;
                            }
                            index = i * 4;
                            pixels[index++] = (byte)depth;
                            pixels[index++] = (byte)depth;
                            pixels[index++] = (byte)depth;
                            pixels[index++] = 255;
                        }
                    }
                    //書き込み終了
                    depthBitmap.UnlockBits(bitmapData);
                    depthImage.Dispose();
                    //pictureBoxに画像を貼り付け
                    depthBitmapBox.Image = depthBitmap;

                    #endregion

                    #region IR
                    //IR画像を取得
                    Image irImage = capture.IR;
                    //IR画像の各ピクセルの値(奥行)のみを取得
                    ushort[] irArray = irImage.GetPixels<ushort>().ToArray();
                    //irBitmapの各画素に値を書き込む準備
                    BitmapData irData = irBitmap.LockBits(new Rectangle(0, 0, irBitmap.Width, irBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                    unsafe
                    {
                        //各ピクセルの値へのポインタ
                        byte* pixels = (byte*)irData.Scan0;
                        int index;
                        int ir;
                        //一ピクセルずつ処理
                        for (int i = 0; i < irArray.Length; i++)
                        {
                            ir = 255 - (int)(255 * (irArray[i] - _irDistanceMin) / _irDistanceMax);
                            if (ir < 0)
                            {
                                ir = 0;
                            }
                            else if (ir > _irThresholdMaxColor)
                            {
                                ir = 255;
                            }
                            index = i * 4;
                            pixels[index++] = (byte)ir;
                            pixels[index++] = (byte)ir;
                            pixels[index++] = (byte)ir;
                            pixels[index++] = 255;
                        }
                    }
                    //書き込み終了
                    irBitmap.UnlockBits(bitmapData);
                    irImage.Dispose();
                    //pictureBoxに画像を貼り付け
                    irBitmapBox.Image = irBitmap;

                    #endregion

                    #region Mask
                    //深度カメラの処理
                    Mat depthMat = new Mat();
                    depthMat = BitmapConverter.ToMat(depthBitmap);
                    depthMat.Reshape(1);

                    //深度カメラの画像のチャンネル数とタイプを変更
                    Mat tempDepthMatGray = new Mat();
                    Cv2.CvtColor(depthMat, tempDepthMatGray, ColorConversionCodes.RGB2GRAY);
                    depthMat.Dispose();
                    Mat tempDepthMatBit = new Mat();
                    Cv2.Threshold(tempDepthMatGray, tempDepthMatBit, _depthThresholdMin, _depthThresholdMax, ThresholdTypes.Binary);
                    tempDepthMatGray.Dispose();

                    //IRカメラの処理
                    Mat irMat = new Mat();
                    irMat = BitmapConverter.ToMat(irBitmap);
                    irMat.Reshape(1);

                    //IRカメラの画像のチャンネル数とタイプを変更
                    Mat tempIrMatGray = new Mat();
                    Cv2.CvtColor(irMat, tempIrMatGray, ColorConversionCodes.RGB2GRAY);
                    irMat.Dispose();
                    Mat tempIrMatBit = new Mat();
                    Cv2.Threshold(tempIrMatGray, tempIrMatBit, _irThresholdMin, _irThresholdMax, ThresholdTypes.BinaryInv);
                    tempIrMatGray.Dispose();

                    //マスクをかける
                    Mat outDst = new Mat();
                    Cv2.BitwiseAnd(tempDepthMatBit, tempDepthMatBit, outDst, tempIrMatBit);

                    resultBitmapBox.Image = BitmapConverter.ToBitmap(outDst);

                    #endregion

                    //デバッグ
                    Cv2.ImShow("result", outDst);

                    //画像として保存するパスを作成
                    var TempImageFilePath = Path.Combine(assetsPath, "TempImage", $"{saveFileIndex}.jpeg");

                    //保存
                    outDst.SaveImage(TempImageFilePath);

                    //非同期で画像認識を実行
                    Task.Run(() => ImageRecognition(TempImageFilePath));

                    if (saveFileIndex <= 100)
                    {
                        saveFileIndex++;
                    }
                    else
                    {
                        saveFileIndex = 0;
                    }

                    tempDepthMatBit.Dispose();
                    tempIrMatBit.Dispose();
                    capture.Dispose();
                }
                //表示を更新
                this.Update();
            }
            //ループが終了したらKinectも停止
            kinect.StopCameras();
        }

        /// <summary>
        /// 引数のパスに存在する画像を画像認識にかける関数
        /// </summary>
        /// <param name="TempImageFilePath"></param>
        private void ImageRecognition(string TempImageFilePath)
        {
            List<ResultStruct> results = imageRecognition.ImageRecognitionToFilePath(TempImageFilePath);

            //デバッグ用
            Console.WriteLine("--------------------------");
            foreach (ResultStruct resultStruct in result)
            {
                Console.WriteLine($"{resultStruct.Label} : {resultStruct.Confidence} : pos {resultStruct.PosX},{resultStruct.PosY}");
            }
            Console.WriteLine("--------------------------");

            //送信
            if (_isUDPSend)
            {
                byte[] serializedData = MessagePackSerializer.Serialize(results);
                UDPSender.Send(serializedData);
            }
        }


        //Bitmap画像に関する初期設定
        private void InitBitmap()
        {
            //Depth画像の横幅(width)と縦幅(height)を取得
            int width = kinect.GetCalibration().DepthCameraCalibration.ResolutionWidth;
            int height = kinect.GetCalibration().DepthCameraCalibration.ResolutionHeight;

            //PictureBoxに貼り付けるBitmap画像を作成。サイズはkinectのDepth画像と同じ
            depthBitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            irBitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        //Kinectの初期化
        private void InitKinect()
        {
            kinect = Device.Open(0);
            kinect.StartCameras(new DeviceConfiguration
            {
                ColorFormat = Microsoft.Azure.Kinect.Sensor.ImageFormat.ColorBGRA32,
                ColorResolution = ColorResolution.R720p,
                DepthMode = DepthMode.NFOV_Unbinned,
                SynchronizedImagesOnly = true,
                CameraFPS = FPS.FPS30
            });
        }

        //アプリ終了時にKinect終了
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            loop = false;
        }

        //UPDの接続を開始する
        private void UDPConectStart_Click(object sender, EventArgs e)
        {
            _ipAdressText = GetConnectIP.Text;
            ConnectViewIpAdress.Text = _ipAdressText.ToString();
            ConnectViewPort.Text = _port.ToString();
            UDPSender = new UDPSender(_ipAdressText, _port);
            _isUDPSend = true;
        }
    }
}