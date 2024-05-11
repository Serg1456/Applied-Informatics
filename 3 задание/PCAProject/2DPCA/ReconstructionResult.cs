using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class ReconstructionFace
    {
        public Bitmap Image { get; set; }
        public int ParamOfReduction { get; set; }
        public ReconstructionFace(Bitmap image, int paramOfReduction) 
        {
            Image = image;
            ParamOfReduction = paramOfReduction;
        } 

    }
    public class ReconstructionResult
    {
        public Person Person { get; set; }
        public ReconstructionFace[] ReconstructionFaces { get; set; }
        public ReconstructionResult(Person person, ReconstructionFace[] reconstructionFaces) 
        {
            Person = person; 
            ReconstructionFaces = reconstructionFaces;
        }
    }
}
