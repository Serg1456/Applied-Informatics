using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    internal class SignVector
    {
        public double[] ScScale { get; set; }
        public double[] DFT { get; set; }
        public double[] DCT { get; set; }
        public double[] Histogram { get; set; }
        public double[] Gradient { get; set; }
        public SignVector(double[] scScale, double[] dFT, double[] dCT, double[] histogram, double[] gradient)
        {
            ScScale = scScale;
            DFT = dFT;
            DCT = dCT;
            Histogram = histogram;
            Gradient = gradient;
        }
    }
}
