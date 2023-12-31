using MessagePack;
using Microsoft.Azure.Kinect.Sensor;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.InteropServices;
using UnityEasyNet;
using static KinectImageConvertSender.FilePath;
using BitmapData = System.Drawing.Imaging.BitmapData;
using Image = Microsoft.Azure.Kinect.Sensor.Image;

namespace KinectImageConvertSender
{
    public partial class Form1 : Form
    {
        #region 外部のスクリプトで取得用
        private static Form1 _form1Instance;
        public static Form1 Form1Instance
        {
            get
            {
                return _form1Instance;
            }
            private set
            {
                _form1Instance = value;
            }
        }
        public int GetRightMask
        {
            get
            {
                return (int)RightMask.Value;
            }
        }
        public int GetLeftMask
        {
            get
            {
                return (int)LeftMask.Value;
            }
        }
        public int GetTopMask
        {
            get
            {
                return (int)TopMask.Value;
            }
        }
        public int GetBottomMask
        {
            get
            {
                return (int)BottomMask.Value;
            }
        }

        public double GetPositionOffsetX
        {
            get
            {
                return (double)PositionOffsetX.Value;
            }
        }
        public double GetPositionOffsetY
        {
            get
            {
                return (double)PositionOffsetY.Value;
            }
        }
        #endregion

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


        public Form1()
        {
            Form1.Form1Instance = this;

            //コンポーネントの初期化
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            //デバッグ用
            AllocConsole();
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

        }

        DateTime preFrame;

        //Kinectのデータ更新
        private async Task KinectUpdate()
        {
            preFrame = DateTime.Now;
            while (loop)
            {
                //画像認識を15FPSに制限
                if ((DateTime.Now - preFrame).Milliseconds < 67)
                {
                    this.Update();
                    continue;
                }
                else
                {
                    preFrame = DateTime.Now;
                }

                //データの取得
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





                    #endregion

                    #region Maskを描画する

                    //背景用のbitmap
                    Bitmap bg_bitmap = BitmapConverter.ToBitmap(outDst);

                    //描画先とするImageオブジェクトを作成する
                    Bitmap canvas = new Bitmap(bg_bitmap.Width, bg_bitmap.Height);
                    Graphics graphics = Graphics.FromImage(canvas);

                    graphics.DrawImage(bg_bitmap, 0, 0, bg_bitmap.Width, bg_bitmap.Height);

                    //半透明のBrashを作成する
                    SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));

                    //Left
                    if (LeftMask.Text != "")
                    {
                        int leftMask = int.Parse(LeftMask.Text);
                        graphics.FillRectangle(semiTransBrush, 0, 0, leftMask, bg_bitmap.Height);
                    }

                    //Right
                    if (RightMask.Text != "")
                    {
                        int rightMask = int.Parse(RightMask.Text);
                        graphics.FillRectangle(semiTransBrush, bg_bitmap.Width - rightMask, 0, rightMask, bg_bitmap.Height);
                    }
                    //Top
                    if (TopMask.Text != "")
                    {
                        int topMask = int.Parse(TopMask.Text);
                        graphics.FillRectangle(semiTransBrush, 0, 0, bg_bitmap.Width, topMask);
                    }
                    //Bottom
                    if (BottomMask.Text != "")
                    {
                        int bottomMask = int.Parse(BottomMask.Text);
                        graphics.FillRectangle(semiTransBrush, 0, bg_bitmap.Height - bottomMask, bg_bitmap.Width, bottomMask);
                    }

                    bg_bitmap.Dispose();
                    semiTransBrush.Dispose();
                    graphics.Dispose();

                    //表示
                    resultBitmapBox.Image = canvas;
                    #endregion

                    /*                    //デバッグ
                                        Cv2.ImShow("result", outDst);*/

                    //画像として保存するパスを作成
                    var TempImageFilePath = Path.Combine(assetsPath, "TempImage", $"{saveFileIndex}.jpeg");

                    //保存
                    outDst.SaveImage(TempImageFilePath);

                    //非同期で画像認識を実行
                    _ = Task.Run(() => ImageRecognition(TempImageFilePath));

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
            foreach (ResultStruct resultStruct in results)
            {
                Console.WriteLine($"{resultStruct.Label} : {resultStruct.Confidence}");
                Console.WriteLine($"pos x {resultStruct.PosX}");
                Console.WriteLine($"pos y {resultStruct.PosY}");
            }
            Console.WriteLine("--------------------------");

            //送信
            if (_isUDPSend)
            {
                byte[] serializedData = MessagePackSerializer.Serialize(results);
                //座標の最大値 640 x 576 で送信する
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
        private void Form1_Load(object sender, EventArgs e)
        {
            //値を読み込み
            TopMask.Text = Properties.Settings.Default.TopMask.ToString();
            BottomMask.Text = Properties.Settings.Default.BottomMask.ToString();
            LeftMask.Text = Properties.Settings.Default.LeftMask.ToString();
            RightMask.Text = Properties.Settings.Default.RightMask.ToString();
            PositionOffsetX.Text = Properties.Settings.Default.PositionOffsetX.ToString();
            PositionOffsetY.Text = Properties.Settings.Default.PositionOffsetY.ToString();
            GetConnectIP.Text = Properties.Settings.Default.GetConnectIP;
        }

        //アプリ終了時にKinect終了
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            loop = false;

            //値を保存
            Properties.Settings.Default.TopMask = int.Parse(TopMask.Text);
            Properties.Settings.Default.BottomMask = int.Parse(BottomMask.Text);
            Properties.Settings.Default.LeftMask = int.Parse(LeftMask.Text);
            Properties.Settings.Default.RightMask = int.Parse(RightMask.Text);
            Properties.Settings.Default.PositionOffsetX = double.Parse(PositionOffsetX.Text);
            Properties.Settings.Default.PositionOffsetY = double.Parse(PositionOffsetY.Text);
            Properties.Settings.Default.GetConnectIP = GetConnectIP.Text;

            Properties.Settings.Default.Save();

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

        private void KinectRun_Click(object sender, EventArgs e)
        {
            InitKinect();

            //Kinectの設定情報に基づいてBitmap関連情報を初期化
            InitBitmap();

            //画像認識のクラスを初期化
            imageRecognition = new ImageRecognition();

            //データ取得
            //TODO:キャンセルと再実行可能なら再実行する処理
            Task t = KinectUpdate();
        }

        #region デバッグ
        //デバッグ用
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        //デバッグ用
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private void DebugSender_Click(object sender, EventArgs e)
        {
            //デバッグ用
            AllocConsole();
            //デバッグ
            Task tsl = TestSendLoop();
        }


        //デバッグ
        double time = 0;
        private async Task TestSendLoop()
        {
            this.Show();
            stopwatch.Start();
            while (loop)
            {
                if (_isUDPSend)
                {
                    TimeSpan deltaTime = GetDeltaTime();

                    time += deltaTime.TotalSeconds; // 現在の時間を取得（秒単位）
                    Console.WriteLine($"time = {time}");

                    double angle = 2 * Math.PI * time / 60; // 時間を角度に変換
                    Console.WriteLine($"angle = {angle}");

                    double dx = Math.Cos(angle); // x座標
                    double dy = Math.Sin(angle); // y座標

                    dx = (dx + 1) / 2;
                    dy = (dy + 1) / 2;
                    dx *= 500;
                    dy *= 500;

                    Console.WriteLine($"dx = {dx},dy = {dy}");


                    List<ResultStruct> results = new List<ResultStruct>(){
                    new ResultStruct{ Label = "Cross", PosX = (int)Math.Round(dx), PosY = (int)Math.Round(dy), Confidence = 0.8f }
                    };


                    byte[] serializedData = MessagePackSerializer.Serialize(results);
                    UDPSender.Send(serializedData);

                }
                //表示を更新
                this.Update();
                await Task.Delay(TimeSpan.FromSeconds(0.25f));
            }
        }

        private static Stopwatch stopwatch = new Stopwatch();
        private static TimeSpan lastFrameTime;
        public static TimeSpan GetDeltaTime()
        {
            TimeSpan currentTime = stopwatch.Elapsed;
            TimeSpan deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;

            return deltaTime;
        }
        #endregion
    }
}