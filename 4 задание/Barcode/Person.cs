using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Emgu.CV.Dai.OpenVino;

namespace Barcode
{
    public class Person
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public Mat Image { get; set; }
        public Person(Mat image,string id = "0", string label = "0")
        {
            Id = id;
            Label = label;
            Image = new Mat();
            CvInvoke.Resize(image, Image, new Size(92, 112));
            //Image.ConvertTo(Image, DepthType.Cv64F, 1, 0);
        }
    }
}
