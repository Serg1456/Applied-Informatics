using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.StructuredLight;
using Emgu.CV.Reg;

namespace Recognizer
{
    internal static class MethodsForConvert
    {
        //Sc-scale
        public static double[] ScScale(Mat src, int l)
        {
            CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            Image<Gray, byte> face = src.ToImage<Gray, byte>();
            int M = face.Cols;
            int N = face.Rows;
            int n = N / l;
            int m = M / l;
            var resultArray = new double[m * n];
            int counter = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    resultArray[counter++] = MiddleOfSquare(face, (i - 1) * l, i * l, (j - 1) * l, j * l, l);
                }
            }
            return resultArray;
        }
        private static double MiddleOfSquare(Image<Gray, byte> face, int leftRowPos, int RightRowPos, int leftColumnPos, int RightColumnPos, int l)
        {
            double summ = 0;
            for (int i = leftRowPos; i < RightRowPos; i++)
            {
                for (int j = leftColumnPos; j < RightColumnPos; j++)
                {
                    summ += face[i, j].Intensity;
                }
            }
            return (summ / (l * l));
        }
        //DFT
        public static double[] DFT(Mat src)
        {
            //Делаем изображение в оттенках серого
            //Делаем изображение в оттенках серого
            CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            //Находим оптимальные размеры для реализации DFT
            var optimalRows = CvInvoke.GetOptimalDFTSize(src.Rows);
            var optimalCols = CvInvoke.GetOptimalDFTSize(src.Cols);
            var s0 = new MCvScalar(0, 0, 0);
            //Подгоняем размеры изображения под DFT
            Mat padded = new Mat();
            CvInvoke.CopyMakeBorder(src, padded, 0, optimalRows - src.Rows, 0, optimalCols - src.Cols, BorderType.Constant, new MCvScalar(0, 0, 0));
            //Производим манипуляции для отделения комплексной и вещественной части изображения
            var plane0 = new Mat();
            padded.ConvertTo(plane0, DepthType.Cv32F);
            var planes = new VectorOfMat();
            var complexI = new Mat();
            var plane1 = Mat.Zeros(padded.Rows, padded.Cols, DepthType.Cv32F, padded.NumberOfChannels);
            planes.Push(plane0);
            planes.Push(plane1);
            CvInvoke.Merge(planes, complexI);
            //Производим быстрое преобразование фурье
            CvInvoke.Dft(complexI, complexI);
            //Разделяем канал с вещественной и мнимой частями
            CvInvoke.Split(complexI, planes);
            //Находим абсолютное значение
            var resul1 = new Mat();
            var result2 = new Mat();
            CvInvoke.CartToPolar(planes[0], planes[1], resul1, result2);
            var mag = resul1;
            //Логарифмируем значение, чтобы по итогу получить чёрно-белое изображение
            var m1 = Mat.Ones(mag.Rows, mag.Cols, mag.Depth, mag.NumberOfChannels);
            CvInvoke.Add(mag, m1, mag);
            CvInvoke.Log(mag, mag);
            //Делаем циклический сдвиг
            mag = new Mat(mag, new Rectangle(0, 0, mag.Cols & -2, mag.Rows & -2));
            int cx = mag.Cols / 2;
            int cy = mag.Rows / 2;
            Mat q0 = new Mat(mag, new Rectangle(0, 0, cx, cy));
            Mat q1 = new Mat(mag, new Rectangle(cx, 0, cx, cy));
            Mat q2 = new Mat(mag, new Rectangle(0, cy, cx, cy));
            Mat q3 = new Mat(mag, new Rectangle(cx, cy, cx, cy));
            Mat tmp = new Mat();
            q0.CopyTo(tmp);
            q3.CopyTo(q0);
            tmp.CopyTo(q3);
            q1.CopyTo(tmp);
            q2.CopyTo(q1);
            tmp.CopyTo(q2);
            //Проверяем
            mag.ConvertTo(mag, DepthType.Cv8U);
            //Нормализуем изображение в оотенки серого
            CvInvoke.Normalize(mag, mag, 0, 255, NormType.MinMax, DepthType.Cv8U);
            return GetDiagonalVector(GetAreaOfImage(plane0, 60));
        }
        private static double[,] GetAreaOfImage(Mat img, int p)
        {
            double[,] result = new double[p, p];
            var startPosX = img.Rows / 2 - p / 2;
            var startPoxY = img.Cols / 2 - p / 2;
            Image<Gray, byte> image = img.ToImage<Gray, byte>();
            for (int x = startPosX; x < p + startPosX; x++)
                for (int y = startPoxY; y < p + startPoxY; y++)
                    result[x - startPosX, y - startPoxY] = image[x, y].Intensity;
            return result;
        }
        private static double[,] GetLeftSquareOfImage(Mat img, int p)
        {
            double[,] result = new double[p, p];
            Image<Gray, byte> image = img.ToImage<Gray, byte>();
            var startPosX = 0;
            var startPoxY = 0;
            for (int x = startPosX; x < p + startPosX; x++)
                for (int y = startPoxY; y < p + startPoxY; y++)
                    result[x - startPosX, y - startPoxY] = image[x, y].Intensity;
            return result;
        }
        private static double[] GetSquareVector(double[,] C)
        {
            int p = 0;
            var result = new double[C.GetLength(0) * C.GetLength(1)];
            for (int x = 0; x < C.GetLength(0); x++)
                for (int y = 0; y < C.GetLength(1); y++)
                    result[p++] = C[x, y];
            return result;
        }
        private static double[] GetDiagonalVector(double[,] C)
        {
            int tek = -1;
            int p = C.GetLength(0);
            var line = new double[p * (p + 1) / 2];
            for (int y = 0; y < p; y++)
                for (int k = y; k > -1; k--)
                {
                    tek++;
                    line[tek] = C[y - k, k];
                }
            return line;
        }
        //DCT
        public static double[] DCT(Mat src)
        {
            CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            var resultOfConvert = new Mat();
            src.ConvertTo(resultOfConvert, DepthType.Cv32F);
            CvInvoke.Dct(resultOfConvert, resultOfConvert, DctType.Forward);
            return GetDiagonalVector(GetLeftSquareOfImage(resultOfConvert, 8));
        }
        //Histogram
        public static double[] Histogram(Mat src)
        {
            CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            VectorOfMat vou = new VectorOfMat();
            vou.Push(src);
            int histSize = 64;
            float[] range = { 0, 256 };
            bool accumulate = false;
            Mat grayHist = new Mat();
            CvInvoke.CalcHist(vou, new int[] { 0 }, null, grayHist, new int[] { histSize }, range, accumulate);
            var test = grayHist.GetData();
            int N = src.Rows;
            int M = src.Cols;
            double[] histogram = new double[histSize];
            for (int i = 0; i < histSize; i++)
            {
                histogram[i] = (Single)test.GetValue(i, 0) / (N * M);
            }
            return histogram;
        }

        //Gradient
        public static double[] Gradient(Mat src)
        {
            CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            int W = 1;
            var img = src.ToImage<Gray, byte>();
            int startRow = img.Rows / 2;
            int endRow = img.Rows - startRow;
            int toUpRow = startRow / W;
            int endUpRow = endRow / W ;
            int counter = Math.Min(toUpRow, endUpRow);
            double[] resultOfGradient = new double[counter - 1];
            double summ = 0;
            for (int i = 0; i < counter - 1; i++)
            {
                var sumDown = GetBorderOfGradient(img, i * W + startRow, (i + 1) * W + startRow - 1);
                var sumUp = GetBorderOfGradient(img, startRow - (i + 1) * W, startRow - i * W - 1);  
                int rowLen = sumDown.GetLength(0);
                int columnLen = sumDown.GetLength(1);
                for (int x = 0; x < rowLen; x++)
                    for (int y = 0; y < columnLen; y++)
                    {
                        var value = Math.Abs(sumDown[x, y] - sumUp[rowLen - 1 - x, y]);
                        resultOfGradient[i] += value;
                        summ += value;
                    }
            }
            return resultOfGradient;
        }
        private static double[,] GetBorderOfGradient(Image<Gray,byte> img,int startRowPos, int endRowPos)
        {
            var numberOfCols = img.Cols;
            var result = new double[endRowPos - startRowPos + 1,numberOfCols];
            for (int i = startRowPos; i <= endRowPos; i++)
                for (int j = 0; j < numberOfCols; j++)
                    result[i - startRowPos, j] = img[i, j].Intensity;
            return result;
        } 
    }
}
