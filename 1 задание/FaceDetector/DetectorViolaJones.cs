using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetector
{
    internal class DetectorViolaJones
    {
        CascadeClassifier _faceCascade;
        public DetectorViolaJones() 
        {
            _faceCascade = new CascadeClassifier("../../../sources/haarcascade_frontalface_default.xml");
        }
        public Mat DetectFaces(Mat photo)
        {
            Mat resultOfColorConversion = new Mat();
            CvInvoke.CvtColor(photo, resultOfColorConversion, ColorConversion.Bgr2Gray);
            var faces = _faceCascade.DetectMultiScale(resultOfColorConversion, 1.3, 5);
            foreach (var face in faces)
            {
                CvInvoke.Rectangle(photo, face, new MCvScalar(0, 255, 0), 2);
            }
            return photo;
        }
    }
}
