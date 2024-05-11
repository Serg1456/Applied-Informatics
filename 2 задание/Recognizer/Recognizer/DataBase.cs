using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace Recognizer
{
    internal class DataBase
    {
        private bool _isСonfigured;
        public Classificator Classificator { private set; get; }
        public Dictionary<string, Person> Persons;
        private Dictionary<string, List<ImageOfPerson>> _persons;
        private int _countOfEtalons;
        private int _countOfTests;
        public int CountOfImages { get; set; }
        public DataBase()
        {
            _isСonfigured = false;
            Persons = new Dictionary<string, Person>();
        }
        public bool IsNotEmpty()
        {
            return _isСonfigured;
        }
        public void LoadDataBase(Dictionary<string, List<ImageOfPerson>> persons, int countOfEtalons, int countOfTests)
        {
            _countOfEtalons = countOfEtalons;
            _countOfTests = countOfTests;
            Persons = new Dictionary<string, Person>();
            _persons = persons;
            foreach (var person in persons) 
            {
                var etalons = new ImageOfPerson[countOfEtalons];
                var test = new ImageOfPerson[countOfTests];
                for (int i = 0; i < countOfEtalons; i++) etalons[i] = person.Value[i];
                for (int i = countOfEtalons; i < countOfEtalons + countOfTests; i++) test[i - countOfEtalons] = person.Value[i];
                Persons.Add(person.Key, new Person(person.Key, etalons, test));
            }
            Dispetcher.Classificator = new Classificator(Persons,countOfEtalons,countOfTests);
            _isСonfigured = true;
        }
        public (List<ResultOfTest>,ResultOfTest) CrossValidation(int maxCountOfImages)
        {
            List<ResultOfTest> resultsOfCrossValidationTests = new List<ResultOfTest>();
            ResultOfTest bestResult = null;
            Dispetcher.LoadDataBase(maxCountOfImages);
            _persons = Dispetcher.Persons;
            int countOfEtalons = maxCountOfImages - 1;
            int countOfTestImages = 1;
            double max = 0;
            foreach (var person in _persons)
            {
                LoadDataBase(_persons, countOfEtalons, countOfTestImages);
                var resultOfTestValidation = Dispetcher.Classificator.StudyOnTheTests();
                resultsOfCrossValidationTests.Add(resultOfTestValidation);
                var len = resultOfTestValidation.CountOfTests - 1;
                var dft = resultOfTestValidation.ResultOfDFT[len];
                var dct = resultOfTestValidation.ResultOfDCT[len];
                var seScale = resultOfTestValidation.ResultOfSeScale[len];
                var histogram = resultOfTestValidation.ResultOfHistogram[len];
                var resultOfGradient = resultOfTestValidation.ResultOfGradient[len];
                var sum = dft + dct + seScale + histogram + resultOfGradient;
                if (sum > max)
                {
                    max = sum;
                    bestResult = resultOfTestValidation;
                }
                countOfEtalons--;
                countOfTestImages++;
                if (countOfEtalons <= 0 || countOfTestImages > maxCountOfImages - 1) break;
            }
            return (resultsOfCrossValidationTests, bestResult);
        }
        //public ResultOfTest StudyOnEtalons()
        //{
        //    //List<ResultOfTest> resultsOfTest = new List<ResultOfTest>();
        //    //List<ImageOfPerson>[] variantsOfEtalons = new List<ImageOfPerson>[_countOfEtalons];
        //    //for (int i = 0; i < _countOfEtalons; i++) variantsOfEtalons[i] = new List<ImageOfPerson>();
        //    //foreach (var person in _persons) 
        //    //{
        //    //    for (int i = 0; i < _countOfEtalons; i++)
        //    //    {
        //    //        List<ImageOfPerson> current = new List<ImageOfPerson>();
        //    //        for (int j = 0; j <= i; j++) current.Add(person.Value[j]);
        //    //        variantsOfEtalons[i].AddRange(current);
        //    //    }
        //    //}
        //    //for (int i = 0; i < variantsOfEtalons.Length; i++)
        //    //{
        //    //    resultsOfTest.Add(Dispetcher.Classificator.StudyOnTheEtalons(variantsOfEtalons[i]));
        //    //}
        //    //return resultsOfTest;
        //    return Dispetcher.Classificator.StudyOnTheEtalons();
        //}
    }
}
