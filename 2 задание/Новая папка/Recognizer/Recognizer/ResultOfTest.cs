using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public class ResultOfTest
    {
        public int CountOfEtalons { get; set; }
        public double ResultOfDFT { get; set; }
        public double ResultOfDCT { get; set; }
        public double ResultOfSeScale { get; set; }
        public double ResultOfHistogram { get; set; }
        public double ResultOfGradient { get; set; }
        public ResultOfTest(int countOfEtalons, double resultOfDFT, double resultOfDCT, double resultOfSeScale, double resultOfHistogram, double resultOfGradient)
        {
            CountOfEtalons = countOfEtalons;
            ResultOfDFT = resultOfDFT;
            ResultOfDCT = resultOfDCT;
            ResultOfSeScale = resultOfSeScale;
            ResultOfHistogram = resultOfHistogram;
            ResultOfGradient = resultOfGradient;
        }
    }
}
