using MessagePack;

namespace KinectImageConvertSender
{
    [MessagePackObject(true)]
    public struct ResultStruct
    {
        public string Label { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float Confidence { get; set; }


        public ResultStruct(string _Label, float _PosX, float _PosY,float _Confidence)
        {
            Label = _Label;
            PosX = _PosX;
            PosY = _PosY;
            Confidence = _Confidence;
        }
    }
}
