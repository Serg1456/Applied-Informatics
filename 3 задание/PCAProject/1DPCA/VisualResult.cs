using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCAProject._1DPCA
{
    public class VisualResult
    {
        public double[] Eigenvalues { get; set; }
        public List<Mat> PrintedEigenFaces { get; set; }
        public Projection3DClassVisualResult[] Three3DProjections { get; set; }
        public VisualResult(double[] eigenvalues, List<Mat> printedEigenFaces,Projection3DClassVisualResult[] three3DProjections)
        {
            Eigenvalues = eigenvalues;
            PrintedEigenFaces = printedEigenFaces;
            Three3DProjections = three3DProjections;
        }
    }
}
