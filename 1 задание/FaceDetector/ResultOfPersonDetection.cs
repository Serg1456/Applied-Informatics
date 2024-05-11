using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetector
{
    internal class ResultOfPersonDetection
    {
        public Mat Image { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public ResultOfPersonDetection(Mat image, string firstName, string secondName)
        {
            Image = image;
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}
