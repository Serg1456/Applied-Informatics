using Emgu.CV;
using Emgu.CV.Quality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode
{
    internal static class Calculator
    {
        public static ResultOfDifferentAgeEncoding CalculateFacesInDifferentAges(Person young, Person older)
        {
            var firstResul = BarcodeConverter.EncodeEightFaceConverter(young);
            var secondResult = BarcodeConverter.EncodeEightFaceConverter(older);
            var ssim = CalculateSSIMBetweenTwoImages(young.Image, older.Image);
            var correlation = CalculateCorrelationBetweenTwoImages(young.Image,older.Image);
            return new ResultOfDifferentAgeEncoding(firstResul, secondResult, ssim, correlation);
        }
        private static double CalculateSSIMBetweenTwoImages(Mat first, Mat second) 
        {
            QualitySSIM ssimCalculator = new QualitySSIM(first);
            var ssim = ssimCalculator.Compute(second).V0;
            return ssim;
        }
        private static double CalculateCorrelationBetweenTwoImages(Mat first, Mat second)
        {
            Mat corr = new Mat();
            CvInvoke.MatchTemplate(first, second, corr,Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);
            return corr.GetValue(0, 0);
        }
    }
}
