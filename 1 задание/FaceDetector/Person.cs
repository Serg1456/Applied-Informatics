using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Threading.Tasks;

namespace FaceDetector
{
    internal class Person
    {
        public Mat[] Etalons { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public Person(Mat[] etalons, string firstName, string secondName)
        {
            Etalons = etalons;
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}
