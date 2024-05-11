using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class VisualResult
    {
        public Projection3DClassVisualResult[] Projections { get; set; }
        public ReconstructionResult ReconstructionResults { get; set; }
        public VisualResult(Projection3DClassVisualResult[] projections,ReconstructionResult reconstructionResults)
        {
            Projections = projections;
            ReconstructionResults = reconstructionResults;
        }
    }
}
