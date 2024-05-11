using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Quality;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using Aspose.BarCode;
using Aspose.BarCode.Generation;
using System.Diagnostics.Metrics;

using NetBarcode;

namespace Barcode
{
    internal static class BarcodeConverter
    {
        static int counter = 0;
        //Методы, касающиеся обработки непосредственно одного лица.
        public static ResultOfEncoding EncodeEightFaceConverter(Person person)
        {
            int L = 7;
            int H = 23;
            int M = person.Image.Height;
            double scale = 9.5;
            (int A,int T) parameters = CalculateParams(L, H, M);
            parameters.A = 8;
            parameters.T = 56;
            double[] d = CalculateGradient(person.Image, parameters.T, H);
            double[] normalizeD = NormalizeGradientValues(d);
            double[] quantalizationValues = CalculateQuantalizationValues(L, normalizeD, parameters.A, scale);
            var result = CalcualteEANEightBarcode(quantalizationValues);
            //C:\\Users\\Molecule\\image\\test\\t{counter}
            result.SaveImageFile($@"../../../image/test/t{counter}");
            Bitmap barcode = new Bitmap($@"../../../image/test/t{counter}");
            counter++;
            return new ResultOfEncoding(barcode, person);
        }
        private static (int,int) CalculateParams(int L, int H, int M)
        {
            int A = (int)(((M - H) / L)* 0.64921348314);
            int T =  L * A;
            return (A,T);
        }
        private static double[] CalculateGradient(Mat image,int T, int H)
        {
            int startY = 58;
            double[] d = new double[T];
            for (int t = 0; t < T; t++)
            {
                double[][] L = CalculateBorder(image, startY, H);
                double[][] R = CalculateBorder(image, startY + H, H).Reverse().ToArray();
                d[t] = CalculateGradientValue(L, R);
                startY++;
            }
            return d;
        }
        private static double[][] CalculateBorder(Mat image, int startY, int H)
        {
            int width = image.Width;
            double[][] border = new double[H][];
            for (int i = startY; i < startY + H; i++)
            {
                border[i - startY] = new double[width];
                for (int j = 0; j < width; j++)
                {
                    border[i - startY][j] = image.GetValue(i, j);
                }
            }
            return border;
        }
        private static double CalculateGradientValue(double[][] L, double[][] R) 
        {
            double d = 0;
            int countOfRows = L.Length;
            int countOfElements = R[0].Length;
            for (int i = 0; i < countOfRows; i++)
                for (int j = 0; j < countOfElements; j++)
                    d += Math.Abs(L[i][j] - R[i][j]);
            return d;
        }
        private static double[] NormalizeGradientValues(double[] d)
        {
            double[] normalizeD = new double[d.Length];
            double maxValue = d.Max();
            for (int i = 0; i < d.Length; i++)
                normalizeD[i] = d[i] / maxValue;
            return normalizeD;
        }
        private static double[] CalculateQuantalizationValues(int L,double[] normalizeD,int A, double scale)
        {
            double[] d = new double[L];
            for (int l = 1; l <= L; l++)
            {
                double k = scale / A;
                double sum = 0;
                for (int j = 0; j < A; j++)
                    sum += normalizeD[A * (l-1) + j];
                d[l-1] = Math.Truncate(k*sum);
            }
            return d;
        }
        private static NetBarcode.Barcode CalcualteEANEightBarcode(double[] quantalizationValues)
        {
            int[] quantalizationValuesInt = quantalizationValues.Select(v => Convert.ToInt32(v)).ToArray();
            var lastValue = CalculateLastValue(quantalizationValuesInt);
            Array.Resize(ref quantalizationValuesInt, quantalizationValuesInt.Length + 1);
            quantalizationValuesInt[quantalizationValuesInt.Length - 1] = lastValue;
            string stringQuantalization = new String(quantalizationValuesInt.Select(v => Convert.ToString(v)).SelectMany(v => v).ToArray());
            return new NetBarcode.Barcode(stringQuantalization,NetBarcode.Type.EAN8,true); // default: Code128
            var generator = new BarcodeGenerator(EncodeTypes.EAN8);
            generator.CodeText = stringQuantalization;
            //return generator.GenerateBarCodeImage();
        }
        private static int CalculateLastValue(int[] quantalizationValues) 
        {
            int summEven = 0;
            int summOdd = 0;
            for (int i = quantalizationValues.Length - 1; i > -1; i--)
                if ((i + 1) % 2 == 0) summEven += quantalizationValues[i];
                else summOdd += quantalizationValues[i];
            int summResult = summOdd * 3 + summEven;
            int result = 10 - (summResult % 10);
            return result;
        }
    }
}
