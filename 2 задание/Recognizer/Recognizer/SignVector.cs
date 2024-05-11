using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public class SignVector
    {
        public double[] ScScale { get; set; }
        public Bitmap ScScaleImage { get; set; }
        public double[] DFT { get; set; }
        public Bitmap DFTimage { get; set; }
        public double[] DCT { get; set; }
        public Bitmap DCTImage { get; set; }
        public double[] Histogram { get; set; }
        public double[] Gradient { get; set; }
        public SignVector(double[] scScale, double[] dFT, double[] dCT, double[] histogram, double[] gradient, Bitmap scScaleImage, Bitmap dFTimage,Bitmap dCTImage)
        {
            ScScale = scScale;
            DFT = dFT;
            DCT = dCT;
            Histogram = histogram;
            Gradient = gradient;
            ScScaleImage = scScaleImage;
            DFTimage = dFTimage;
            DCTImage = dCTImage;
        }
    }
}
