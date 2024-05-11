using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode
{
    public class ResultOfDifferentAgeEncoding
    {
        public ResultOfEncoding Young { get; set; }
        public ResultOfEncoding Older { get; set; }
        public double Ssim { get; set; }
        public double Correlation { get; set; }
        public ResultOfDifferentAgeEncoding(ResultOfEncoding young, ResultOfEncoding older, double ssim, double correlation)
        {
            Young = young;
            Older = older;
            Ssim = ssim;
            Correlation = correlation;
        }
    }
}
