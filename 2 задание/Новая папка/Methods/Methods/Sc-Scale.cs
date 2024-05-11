using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Sc_Scale
    {
        private int _l;
        public Sc_Scale(int l) 
        {
            _l = l;
        }
        public Image<Bgr, byte> Use(Mat photo) 
        {
            Image<Bgr, byte> face = photo.ToImage<Bgr,byte>();
            CvInvoke.Imshow("test",face);
            int M = face.Cols;
            int N = face.Rows;
            int n = N / _l;
            int m = M / _l;
            byte[,,] resultArray = new byte[n,m,3];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    var resultOfMiddle = MiddleOfSquare(face, (i - 1) * _l, i * _l, (j - 1) * _l, j * _l);
                    resultArray[i - 1,j - 1,0] = resultOfMiddle;
                    resultArray[i - 1, j - 1, 1] = resultOfMiddle;
                    resultArray[i - 1, j - 1, 2] = resultOfMiddle;
                }
            }
            return new Image<Bgr, byte>(resultArray);
        }
        private byte MiddleOfSquare(Image<Bgr, byte> face, int leftRowPos, int RightRowPos, int leftColumnPos, int RightColumnPos)
        {
            double summ = 0;
            for (int i = leftRowPos; i < RightRowPos; i++)
            {
                for (int j = leftColumnPos; j < RightColumnPos; j++)
                {
                    summ += face[i,j].Green;
                }
            }
            return (byte)(summ/(_l*_l));
        }
    }
}
