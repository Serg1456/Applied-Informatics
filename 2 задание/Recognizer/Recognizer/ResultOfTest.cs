using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    public class VisualResultOfRecognize
    {
        public Bitmap TestDFT { get; set; }
        public Bitmap TestDCT { get; set; }
        public Bitmap TestSeScale { get; set; }
        public Bitmap TestImage { get; set; }
        public double[] TestHistogram { get; set; }
        public double[] TestsGradients { get; set; } 
        public List<Bitmap> Images { get; set; }
        public List<Bitmap> DFT { get; set; }
        public List<Bitmap> DCT { get; set; }
        public List<Bitmap> SeScale { get; set; }
        public List<double[]> Histogram { get; set; }
        public List<double[]> Gradient { get; set; }
        public VisualResultOfRecognize(List<Bitmap> dFT, List<Bitmap> dCT, List<Bitmap> seScale, List<double[]> gradient, List<double[]> histogram, Bitmap testSeScale,Bitmap testDCT, Bitmap testDFT, double[] testHistogram, double[] testsGradients, List<Bitmap> images, Bitmap testImage)
        {
            DFT = dFT;
            DCT = dCT;
            SeScale = seScale;
            Gradient = gradient;
            Histogram = histogram;
            TestSeScale = testSeScale;
            TestDCT = testDCT;
            TestDFT = testDFT;
            TestHistogram = testHistogram;
            TestsGradients = testsGradients;
            Images = images;
            TestImage = testImage;
        }
    }
    public class ResultOfTest
    {
        public List<VisualResultOfRecognize> Results { get; set; }
        public int CountOfTests { get; set; }
        public double[] ResultOfDFT { get; set; }
        public double[] ResultOfDCT { get; set; }
        public double[] ResultOfSeScale { get; set; }
        public double[] ResultOfHistogram { get; set; }
        public double[] ResultOfGradient { get; set; }
        public double[] ResultOfCascade { get; set; }
        public ResultOfTest(int countOfEtalons, double[] resultOfDFT, double[] resultOfDCT, double[] resultOfSeScale, double[] resultOfHistogram, double[] resultOfGradient, List<VisualResultOfRecognize> results)
        {
            CountOfTests = countOfEtalons;
            ResultOfDFT = resultOfDFT;
            ResultOfDCT = resultOfDCT;
            ResultOfSeScale = resultOfSeScale;
            ResultOfHistogram = resultOfHistogram;
            ResultOfGradient = resultOfGradient;
            Results = results;
        }
    }
}
