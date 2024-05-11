using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    internal class _2DPCABootstrap
    {
        Dictionary<int,List<Person>> data;
        List<Person> etalons;
        List<Person> test;
        _2DPCAEigenFaceParallel eigenFaceParallel;
        _2DPCAEigenFaceCascade eigenFaceCascade;
        public _2DPCABootstrap(_2DPCAEigenFaceParallel eigenFaceParallel, _2DPCAEigenFaceCascade eigenFaceCascade)
        {
            this.eigenFaceParallel = eigenFaceParallel;
            this.eigenFaceCascade = eigenFaceCascade;
            LoadDatasetFromDir(@"..\..\..\ORL");
        }
        private void LoadDatasetFromDir(string path)
        {
            data = new Dictionary<int, List<Person>>();
            foreach (var file in Directory.GetFiles(path, "*.jpg"))
            {
                var person = Person.FromFile(file); //Пока для процедуры грамма-шмидта (в дальнейшем, возможно, будет делегат).
                if (data.ContainsKey(person.Label))
                    data[person.Label].Add(person);
                else
                {
                    data.Add(person.Label, new List<Person>());
                    data[person.Label].Add(person);
                }
            }
        }
        public void DefineTestAndEtalonsFromData()
        {
            test = new List<Person>();
            etalons = new List<Person>();
            var numberOfEtalons = Dispetcher.NumberOfEtalons;
            foreach (var list in data) 
            { 
               etalons.AddRange(list.Value.Take(numberOfEtalons));
               test.AddRange(list.Value.Skip(numberOfEtalons));
            }
        }
        public (RecognitionResult,VisualResult) DoParallelAlgorithm()
        {
            eigenFaceParallel.Run(etalons, Dispetcher.ParametrReduction);
            var recognitionResult =  eigenFaceParallel.ClassifyTestImages(test);
            var visualReslut = eigenFaceParallel.GetVisualResults();
            return (recognitionResult,visualReslut);
        }
        public (RecognitionResult,VisualResult) DoCascadeAlgorithm() 
        {
            eigenFaceCascade.Run(etalons, Dispetcher.ParametrReduction);
            var recognitionResult = eigenFaceCascade.ClassifyTestImages(test);
            var visualReslut = eigenFaceCascade.GetVisualResults();
            return (recognitionResult, visualReslut);
        }
    }
}
