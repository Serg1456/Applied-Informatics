using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class RecognitionResult
    {
        public List<Person> Tests { get; set; }
        public List<Person> Etalons { get; set; }
        public double[] Result {  get; set; }
        public RecognitionResult(List<Person> tests, List<Person> etalons, double[] result)
        {
            Tests = tests;
            Etalons = etalons;
            Result = result;
        }
    }
}
