using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer
{
    internal class Classificator
    {
        private List<ImageOfPerson> _etalons;
        private List<ImageOfPerson> _tests;
        private int _countOfEtalonForPerson;
        private int _countOfTestsForPerson;
        public Classificator(Dictionary<string,Person> persons,int countOfEtalonForPerson, int countOfTestsForPerson) 
        {
            _countOfEtalonForPerson = countOfEtalonForPerson;
            _countOfTestsForPerson = countOfTestsForPerson;
            _etalons = persons.Select(person => person.Value.Etalons).SelectMany(etalon => etalon).ToList();
            _tests = persons.Select(person => person.Value.Tests).SelectMany(test => test).ToList();
        }
        public ResultOfTest DoTesting()
        {
            //Правильные результаты:
            int countOfDFT = 0;
            int countOfDCT = 0;
            int countOfSeScale = 0;
            int countOfHistogram = 0;
            int countOfGradient = 0;
            //Суть алгоритма:
            foreach (var test in _tests)
            {
                var resultOfDFTRecognition = GetDFTResultRecognition(test.signVector.DFT);
                var resultOfDCTRecognition = GetDCTResultRecognition(test.signVector.DCT);
                var resultOfSeScaleRecognition = GetSeScaleRecognition(test.signVector.ScScale);
                var resultOfHistogramRecognition = GetHistogramRecognition(test.signVector.Histogram);
                var resultOfGradientRecognition = GetGradientRecognition(test.signVector.Gradient);
                if (resultOfDFTRecognition.Item2.Name == test.Name) countOfDFT++;
                if (resultOfDCTRecognition.Item2.Name == test.Name) countOfDCT++;
                if (resultOfSeScaleRecognition.Item2.Name == test.Name) countOfSeScale++;
                if (resultOfHistogramRecognition.Item2.Name == test.Name) countOfHistogram++;
                if (resultOfGradientRecognition.Item2.Name == test.Name) countOfGradient++;
            }
            int countOfTests = _tests.Count;
            return new ResultOfTest(
                _countOfEtalonForPerson, 
                (double)countOfDFT / countOfTests,
                (double)countOfDCT / countOfTests,
                (double)countOfSeScale / countOfTests,
                (double)countOfHistogram / countOfTests,
                (double)countOfGradient / countOfTests);
        }
        public void RecognizeFace(string pathToPhoto)
        {
            var resultOfDFT = GetDFTResultRecognition(MethodsForConvert.DFT(new Mat(pathToPhoto))); 
            var resultOfDCT = GetDCTResultRecognition(MethodsForConvert.DCT(new Mat(pathToPhoto)));
            var resultOfSeScale = GetSeScaleRecognition(MethodsForConvert.ScScale(new Mat(pathToPhoto),4));
            var resultOfHistogram = GetHistogramRecognition(MethodsForConvert.Histogram(new Mat(pathToPhoto)));
            var resultOfGradient = GetGradientRecognition(MethodsForConvert.Gradient(new Mat(pathToPhoto)));
            List<(double, ImageOfPerson)> resultsOfRecognition = new List<(double, ImageOfPerson)>() {resultOfDFT,resultOfDCT,resultOfSeScale,resultOfHistogram,resultOfGradient};
            var names = resultsOfRecognition.GroupBy(x => x.Item2.Name).OrderByDescending(g => g.Key).Where(g => g.Count() >= 3).ToLookup(f => f).SelectMany(t => t).SelectMany(t => t).ToList();
            if (names.Count() > 0)
            {
                CvInvoke.Imshow("test", names[0].Item2.Img);
            }
        }
        //Методы для определения дистанций
        private (double, ImageOfPerson) GetDFTResultRecognition(double[] resultOfDFT)
        {
            List<(double, ImageOfPerson)> result = new List<(double, ImageOfPerson)>();
            List<double> substracts = new List<double>();
            foreach (var etalon in _etalons)
            {
                for (int i = 0; i < etalon.signVector.DFT.Length; i++)
                    substracts.Add(Math.Abs(resultOfDFT[i] - etalon.signVector.DFT[i]));
                result.Add((substracts.Sum(), etalon));
                substracts.Clear();
            }
            return result.OrderBy(x => x.Item1).ToList()[0];
        }
        private (double, ImageOfPerson) GetDCTResultRecognition(double[] resultOfDCT)
        {
            List<(double, ImageOfPerson)> result = new List<(double, ImageOfPerson)>();
            List<double> substracts = new List<double>();
            foreach (var etalon in _etalons)
            {
                for (int i = 0; i < etalon.signVector.DCT.Length; i++)
                    substracts.Add(Math.Abs(resultOfDCT[i] - etalon.signVector.DCT[i]));
                result.Add((substracts.Sum(), etalon));
                substracts.Clear();
            }
            return result.OrderBy(x => x.Item1).ToList()[0];
        }
        private (double, ImageOfPerson) GetSeScaleRecognition(double[] resultOfSeScale)
        {
            List<(double, ImageOfPerson)> result = new List<(double, ImageOfPerson)>();
            List<double> substracts = new List<double>();
            foreach (var etalon in _etalons)
            {
                for (int i = 0; i < etalon.signVector.ScScale.Length; i++)
                    substracts.Add(Math.Abs(resultOfSeScale[i] - etalon.signVector.ScScale[i]));
                result.Add((substracts.Sum(), etalon));
                substracts.Clear();
            }
            return result.OrderBy(x => x.Item1).ToList()[0];
        }
        private (double, ImageOfPerson) GetHistogramRecognition(double[] resultOfHistogram)
        {
            List<(double, ImageOfPerson)> result = new List<(double, ImageOfPerson)>();
            List<double> substracts = new List<double>();
            foreach (var etalon in _etalons)
            {
                for (int i = 0; i < etalon.signVector.Histogram.Length; i++)
                    substracts.Add(Math.Abs(resultOfHistogram[i] - etalon.signVector.Histogram[i]));
                result.Add((substracts.Sum(), etalon));
                substracts.Clear();
            }
            return result.OrderBy(x => x.Item1).ToList()[0];
        }
        private (double, ImageOfPerson) GetGradientRecognition(double[] resultOfGradient)
        {
            List<(double, ImageOfPerson)> result = new List<(double, ImageOfPerson)>();
            List<double> substracts = new List<double>();
            foreach (var etalon in _etalons)
            {
                for (int i = 0; i < etalon.signVector.Gradient.Length; i++)
                    substracts.Add(Math.Abs(resultOfGradient[i] - etalon.signVector.Gradient[i]));
                result.Add((substracts.Sum(), etalon));
                substracts.Clear();
            }
            return result.OrderBy(x => x.Item1).ToList()[0];
        }

    }
}
