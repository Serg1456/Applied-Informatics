using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.XPhoto;

namespace FaceDetector
{
    internal class FacialSymmetry
    {
        private int N; //Ширина изображения
        private int M; //Высота изображения
        private Image<Bgr, byte> img;
        private Mat photo;
        public FacialSymmetry()
        {

        }
        public Mat SearchSymmetrical(int x1, int x2, int y1, int y2, Mat photo)
        {
            N = photo.Cols;
            M = photo.Rows;
            this.photo = photo;
            img = photo.ToImage<Bgr, byte>();
            var centre = DetermineLine(2, 12, x1, x2, y1, y2, N, 5);
            var left = DetermineLine(1, 8, x1, centre, y1, y2, centre, 2, centre);
            var right = DetermineLine(1, 8, centre, x2, y1, y2, N, 2, N);
            CvInvoke.Imshow("test", photo);
            return photo;
        }
        private int DetermineLine(int percentOfdx, int percentOfW, int X1, int X2, int Y1, int Y2, int N, int brushCoff, int limiter = -1)
        {
            int W = 0;
            Dictionary<int, double> dxt = new Dictionary<int, double>();
            var dx = (int)(N * (double)percentOfdx / 100);
            W = (int)(N * (double)percentOfW / 100);
            var x1 = (X1 + W);
            var x2 = x1 + dx + W;
            int xt = x2;
            if (limiter == -1)
            {
                limiter = N - x2 - W;
            }
            else
            {
                limiter = limiter - W;
            }
            while (xt < limiter)
            {
                var L = CalculateL(xt, W, Y1, Y2);
                var R = CalculateR(xt, W, Y1, Y2);
                dxt.Add(xt, CalculateAbsBetweenLAndR(L, R));
                xt = xt + dx + W;
            }
            int minXt = 0;
            double minValue = double.MaxValue;
            foreach (var x in dxt)
            {
                if (x.Value < minValue)
                {
                    minValue = x.Value;
                    minXt = x.Key;
                }
            }
            System.Drawing.Point loc = new System.Drawing.Point(minXt, Y1);
            System.Drawing.Rectangle box = new System.Drawing.Rectangle(loc, new System.Drawing.Size(5, Y2 - Y1 + 1));
            CvInvoke.Rectangle(photo, box, new MCvScalar(0, 255, 0), brushCoff);
            return minXt;
        }
        private double CalculateAbsBetweenLAndR(double[,] L, double[,] R)
        {
            double summ = 0;
            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    summ += Math.Abs(L[i, j] - R[i, j]);
                }
            }
            return summ;
        }
        private double[,] CalculateL(int xt, int w, int Y1, int Y2)
        {
            var YDistance = Y2 - Y1 + 1;
            var result = new double[w, YDistance];
            for (int i = 1; i <= w; i++)
            {
                for (int j = Y1; j <= Y2; j++)
                {
                    result[i - 1, j - Y1] = img[j, xt - i].Green + img[j, xt - i].Red + img[j, xt - i].Blue;
                }
            }
            return result;
        }
        private double[,] CalculateR(int xt, int w, int Y1, int Y2)
        {
            var YDistance = Y2 - Y1 + 1;
            var result = new double[w, YDistance];
            for (int i = 1; i <= w; i++)
            {
                for (int j = Y1; j <= Y2; j++)
                {
                    result[i - 1, j - Y1] = img[j, xt + i].Green + img[j, xt + i].Red + img[j, xt + i].Blue;
                }
            }
            return result;
        }
    }
}
