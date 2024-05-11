using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    internal class ImageOfPerson
    {
        public string Name { get; set; }
        public Mat Img { get; set; }
        public SignVector signVector { get; private set; }
        public ImageOfPerson(string name,Mat img,SignVector vector)
        {
            Name = name;
            Img = img;
            signVector = vector;
        }

    }
}
