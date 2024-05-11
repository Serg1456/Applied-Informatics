using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace Barcode
{
    public class ResultOfEncoding
    {
        public Bitmap Barcode { get; set; }
        public Person OriginalPerson { get; set; }
        public ResultOfEncoding(Bitmap barcode, Person originalPerson)
        {
            Barcode = new Bitmap(barcode,new Size(barcode.Width * 2,barcode.Height*2));
            OriginalPerson = originalPerson;
        }
    }
}
