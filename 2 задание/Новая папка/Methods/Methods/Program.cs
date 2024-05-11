using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections;
using System.Drawing;



namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sc_Scale test = new Sc_Scale(4);
            //Путь к БД: "../../../test/3_1.jpg"
            Mat src = CvInvoke.Imread("../../../1.pgm");
            CvInvoke.Imshow("test1", src);
            Mat src2 = CvInvoke.Imread("../../../test/8_1.jpg");
            Mat src3 = CvInvoke.Imread("../../../test/11_2.jpg");
            Mat src4 = CvInvoke.Imread("../../../test/87_9.jpg");
            Mat src5 = CvInvoke.Imread("../../../test/91_10.jpg");
            Mat src6 = CvInvoke.Imread("../../../test/7_1.jpg");
            Mat src7 = CvInvoke.Imread("../../../test/3_1.jpg");
            //CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            //Mat testResult = new Mat();
            //src.ConvertTo(testResult, DepthType.Cv32F);
            //CvInvoke.Dct(testResult, testResult, DctType.Forward);
            //CvInvoke.Imshow("test", testResult);
            var result1 = MethodsForConvert.Gradient(src,1);
            var result2 = MethodsForConvert.Gradient(src2,1);
            var result3 = MethodsForConvert.Gradient(src3, 1);
            var result4 = MethodsForConvert.Gradient(src4, 1);   
            var result5 = MethodsForConvert.Gradient(src5, 1);
            var result6 = MethodsForConvert.Gradient(src6, 1);
            var result7 = MethodsForConvert.Gradient(src7, 1);
            double difference1 = Math.Abs(result1 - result2);
            double difference2 = Math.Abs(result1 - result3);
            double difference3 = Math.Abs(result1 - result4); 
            double difference4 = Math.Abs(result1 - result5);
            double difference5 = Math.Abs(result1 - result6); 
            double difference6 = Math.Abs(result1 - result7);
            //for (int i = 0; i < result1.Length; i++)
            //{
            //    difference1 += Math.Abs(result1[i] - result2[i]);
            //    difference2 += Math.Abs(result1[i] - result3[i]);
            //    difference3 += Math.Abs(result1[i] - result4[i]);
            //    difference4 += Math.Abs(result1[i] - result5[i]);
            //    difference5 += Math.Abs(result1[i] - result6[i]);
            //    difference6 += Math.Abs(result1[i] - result7[i]);
            //}
            var a = 34;
            //CvInvoke.Imshow("test1", src);
            //CvInvoke.CvtColor(src, src, ColorConversion.Bgr2Gray);
            //var optimalRows = CvInvoke.GetOptimalDFTSize(src.Rows); 
            //var optimalCols = CvInvoke.GetOptimalDFTSize(src.Cols);
            //var s0 = new MCvScalar(0, 0, 0);
            //Mat padded = new Mat();
            //CvInvoke.CopyMakeBorder(src, padded, 0, optimalRows - src.Rows, 0, optimalCols - src.Cols, BorderType.Constant, new MCvScalar(0, 0, 0));
            //var plane0 = new Mat();
            //padded.ConvertTo(plane0, DepthType.Cv32F);
            //var planes = new VectorOfMat();
            //var complexI = new Mat();
            //var plane1 = Mat.Zeros(padded.Rows, padded.Cols, DepthType.Cv32F,padded.NumberOfChannels);
            //planes.Push(plane0);
            //planes.Push(plane1);
            //CvInvoke.Merge(planes, complexI);
            //CvInvoke.Dft(complexI, complexI);
            //CvInvoke.Split(complexI, planes);
            //var resul1 = new Mat();
            //var result2 = new Mat();
            //CvInvoke.CartToPolar(planes[0], planes[1], resul1, result2);
            //var mag = resul1;
            //var m1 = Mat.Ones(mag.Rows,mag.Cols,mag.Depth,mag.NumberOfChannels);
            //CvInvoke.Add(mag, m1, mag);
            //CvInvoke.Log(mag, mag);
            //mag = new Mat(mag, new Rectangle(0,0,mag.Cols & -2,mag.Rows & - 2));
            //int cx = mag.Cols / 2;
            //int cy = mag.Rows / 2;
            //Mat q0 = new Mat(mag,new Rectangle(0,0,cx,cy));
            //Mat q1 = new Mat(mag, new Rectangle(cx, 0, cx, cy));
            //Mat q2 = new Mat(mag, new Rectangle(0, cy, cx, cy));
            //Mat q3 = new Mat(mag, new Rectangle(cx, cy, cx, cy));
            //Mat tmp = new Mat();
            //q0.CopyTo(tmp);
            //q3.CopyTo(q0);
            //tmp.CopyTo(q3);
            //q1.CopyTo(tmp);
            //q2.CopyTo(q1);
            //tmp.CopyTo(q2);
            //mag.ConvertTo(mag, DepthType.Cv8U);
            //CvInvoke.Normalize(mag, mag, 0, 255, NormType.MinMax, DepthType.Cv8U);
            //CvInvoke.Imshow("test", mag);

            //Mat padded = new Mat();                     //expand input image to optimal size
            //int m = CvInvoke.GetOptimalDFTSize(I.Rows);
            //int n = CvInvoke.GetOptimalDFTSize(I.Cols); // on the border add zero values
            //CvInvoke.CopyMakeBorder(I, padded, 0, m - I.Rows, 0, n - I.Cols, BorderType.Constant, new MCvScalar(0,0,0));
            //VectorOfMat planes = new VectorOfMat();
            //padded.ConvertTo(padded, DepthType.Cv32F);
            //planes.Push(padded);
            //planes.Push(Mat.Zeros(padded.Rows,padded.Cols, DepthType.Cv32F,padded.NumberOfChannels));

            //Mat complexI = new Mat();
            //CvInvoke.Merge(planes, complexI);
            //CvInvoke.Dft(complexI, complexI);
            //Mat result = new Mat();
            //Mat result1 = new Mat();
            //CvInvoke.Split(complexI, planes);
            //CvInvoke.CartToPolar(planes[0], planes[1], result, result1);
            //Mat magI = result;
            //Mat matOfOnes = Mat.Ones(magI.Rows, magI.Cols, magI.Depth, magI.NumberOfChannels);
            //CvInvoke.Add(matOfOnes, magI, magI);
            //CvInvoke.Log(magI, magI);
            //CvInvoke.Normalize(magI, magI, 0, 255, NormType.MinMax,DepthType.Cv8U);
            //CvInvoke.Imshow("test", magI);
            CvInvoke.WaitKey();
        }
    }
}
