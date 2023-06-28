namespace KinectImageConvertSender
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    //AzureKinectSDKの読み込み
    using Microsoft.Azure.Kinect.Sensor;
    //(追加)AzureKinectとSystemの変数名の曖昧さをなくすため下記を追加
    using Image = Microsoft.Azure.Kinect.Sensor.Image;
    using BitmapData = System.Drawing.Imaging.BitmapData;
    using PixelFormat = System.Drawing.Imaging.PixelFormat;
    using OpenCvSharp;
    using UnityEasyNet;
    using System.Net;
    using OpenCvSharp.Extensions;
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
        //private string _ipAdressText = "10.208.0.146";
        //private string _ipAdressText = "127.0.0.1";
        //private string _ipAdressText = "192.168.0.0";
        //private string _ipAdressText = "192.168.3.33";
        //private string _ipAdressText = "192.168.3.33";
        private int _port = 12001; //適当な値


        //Kinectを扱う変数
        Device kinect;
        //Depth画像のBitmap
        Bitmap depthBitmap;
        //IR画像のBitmap
        Bitmap irBitmap;
        //(追加)Kinectの画像取得の可否
        bool loop = true;
        public Form1()
        {
            InitializeComponent();
            InitKinect();
            //Kinectの設定情報に基づいてBitmap関連情報を初期化
            InitBitmap();

            //IPv4のアドレスを取得して表示
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //mLocalIPAddress.text = ip.ToString();
                    PCViewIpAdress.Text = ip.ToString();
                    break;
                }
            }

            //(追加)初期化が終わったのでデータ取得開始
            Task t = KinectLoop();
        }
        //(追加)Kinectからデータを取得して表示するメソッド
        private async Task KinectLoop()
        {
            //loopがtrueの間はデータを取り続ける
            while (loop)
            {
                ////カラー画像を取得して保存
                //var transform = kinect.GetCalibration().CreateTransformation();
                //var colorWidth = kinect.GetCalibration().ColorCameraCalibration.ResolutionWidth;
                //var colorHeight = kinect.GetCalibration().ColorCameraCalibration.ResolutionHeight;

                //using (var transformedDepth = new Image(ImageFormat.Depth16, colorWidth, colorHeight, colorWidth * sizeof(UInt16)))
                //kinectから新しいデータをもらう
                using (Capture capture = await Task.Run(() => kinect.GetCapture()).ConfigureAwait(true))
                {
                    //transform.DepthImageToColorCamera(capture, transformedDepth);


                    /*//カラー画像を取得
                    unsafe
                    {
                        var colorImage = capture.Color;

                        //画像のメモリのアドレスを取得
                        //ColorのBitmap作成
                        using (System.Buffers.MemoryHandle pin = colorImage.Memory.Pin())
                        {

                            //Bitmap画像を作成
                            var colorBitmap = new System.Drawing.Bitmap(
                                 colorImage.WidthPixels, //カラー画像の横幅
                                 colorImage.HeightPixels,//カラー画像の縦幅
                                 colorImage.StrideBytes, //横一列のバイト数(width*4)
                                 System.Drawing.Imaging.PixelFormat.Format32bppArgb,//カラーフォーマット(RGBA)
                                 (IntPtr)pin.Pointer); //各ピクセルの色情報
                            //ファイルに保存
                            //colorBitmap.Save(@"保存したいパス\" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            resultBitmapBox.Image = colorBitmap;
                            colorImage.Dispose();
                            pin.Dispose();

                        }
                    }*/


                    //Depth画像を取得
                    Image depthImage = capture.Depth;
                    //Depth画像の各ピクセルの値(奥行)のみを取得
                    ushort[] depthArray = depthImage.GetPixels<ushort>().ToArray();
                    //depthBitmapの各画素に値を書き込む準備
                    BitmapData bitmapData = depthBitmap.LockBits(new Rectangle(0, 0, depthBitmap.Width, depthBitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    unsafe
                    {
                        //各ピクセルの値へのポインタ
                        byte* pixels = (byte*)bitmapData.Scan0;
                        int index;
                        int depth;
                        //一ピクセルずつ処理
                        for (int i = 0; i < depthArray.Length; i++)
                        {
                            //500～5000mmを0～255に変換
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




                    //IR画像を取得
                    Image irImage = capture.IR;
                    //Depth画像の各ピクセルの値(奥行)のみを取得
                    ushort[] irArray = irImage.GetPixels<ushort>().ToArray();
                    //depthBitmapの各画素に値を書き込む準備
                    BitmapData irData = irBitmap.LockBits(new Rectangle(0, 0, irBitmap.Width, irBitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    unsafe
                    {
                        //各ピクセルの値へのポインタ
                        byte* pixels = (byte*)irData.Scan0;
                        int index;
                        int ir;
                        //一ピクセルずつ処理
                        for (int i = 0; i < irArray.Length; i++)
                        {
                            //500～5000mmを0～255に変換
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

                    //----------------------------------------------------------------------------------------------------------//


                    //以下マスク処理
                    //深度カメラの処理
                    Mat depthMat = new Mat();
                    depthMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(depthBitmap);
                    depthMat.Reshape(1);

                    //深度カメラの画像のチャンネル数とタイプを変更
                    Mat tempDepthMatGray = new Mat();
                    Cv2.CvtColor(depthMat, tempDepthMatGray, ColorConversionCodes.RGB2GRAY);
                    depthMat.Dispose();
                    Mat tempDepthMatBit = new Mat();
                    Cv2.Threshold(tempDepthMatGray, tempDepthMatBit, _depthThresholdMin, _depthThresholdMax,
                        ThresholdTypes.Binary);
                    tempDepthMatGray.Dispose();

                    //IRカメラの処理
                    Mat irMat = new Mat();
                    irMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(irBitmap);
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



                    //最終結果はoutDst
                    Console.WriteLine(outDst.Type());
                    //変換チェック
                    //エンコード
                    ImageEncodingParam encodingParam = new ImageEncodingParam(ImwriteFlags.PngBilevel, 0);
                    var buffer = new byte[outDst.Rows * outDst.Cols * outDst.Channels()];
                    Cv2.ImEncode(".png", outDst, out buffer, encodingParam);


                    //デコード
                    Mat res = Cv2.ImDecode(buffer, ImreadModes.AnyColor);
                    //ここでbufferをUDPで送信すればよき
                    if (_isUDPSend)
                    {
                        UDPSender.Send(buffer);
                    }

                    //チェック用
                    Cv2.ImShow("result", res);

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
        //Kinectの初期化(Form1コンストラクタから呼び出す)
        private void InitKinect()
        {
            //0番目のKinectと接続
            kinect = Device.Open(0);
            //Kinectの各種モードを設定して動作開始(設定内容自体は今回は特に考えなくてOK)
            kinect.StartCameras(new DeviceConfiguration
            {
                ColorFormat = ImageFormat.ColorBGRA32,
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