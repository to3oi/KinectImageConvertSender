using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using System;
namespace KinectImageConvertSender
{
    public class SendMessage
    {
        [MessagePackObject(true)]
        public class MyClass
        {
            public List<ResultStruct> result = new List<ResultStruct>() { new ResultStruct { Label = "test", PosX = 0, PosY = 0, Confidence = 0.5f } };
            // シリアル化させたくない場合には、[IgnoreMember]を付ける。
        }
    }
}
