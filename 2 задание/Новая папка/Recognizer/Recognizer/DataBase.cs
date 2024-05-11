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
        public void LoadDataBase(Dictionary<string, List<ImageOfPerson>> persons, int countOfEtalons)
        {
            Persons = new Dictionary<string, Person>();
            var countOfTests = CountOfImages - countOfEtalons;
            foreach (var person in persons) 
            {
                var etalons = new ImageOfPerson[countOfEtalons];
                var test = new ImageOfPerson[countOfTests];
                for (int i = 0; i < countOfEtalons; i++) etalons[i] = person.Value[i];
                for (int i = countOfEtalons; i < CountOfImages; i++) test[i - countOfEtalons] = person.Value[i];
                Persons.Add(person.Key, new Person(person.Key, etalons, test));
            }
            Classificator = new Classificator(Persons,countOfEtalons,countOfTests);
            _isСonfigured = true;
        }
        public List<ResultOfTest> DoTesting(Dictionary<string, List<ImageOfPerson>> persons) //Нужно доделать
        {
            List<ResultOfTest> resultsOfTests = new List<ResultOfTest>();
            for (int i = 0; i < CountOfImages - 1; i++)
            {
                LoadDataBase(persons, i + 1);
                resultsOfTests.Add(Classificator.DoTesting());
            }
            return resultsOfTests;
        }
        
    }
}
