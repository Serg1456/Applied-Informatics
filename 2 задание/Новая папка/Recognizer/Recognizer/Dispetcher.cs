using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace Recognizer
{
    internal class Dispetcher
    {
        public static DataBase Db { get; set; }
        private static Classificator _classificator;
        public static bool IsLoadFirst { get; set; }
        private static Dictionary<string,List<ImageOfPerson>> Persons { get; set; }
        static Dispetcher()
        {
            Db = new DataBase();
        }
        public static void LoadDataBase(int countOfImages)
        {
            Persons = new Dictionary<string, List<ImageOfPerson>>();
            string pathToTheDataBase = "../../../DB_ORL";
            var directory = new DirectoryInfo(pathToTheDataBase);
            var personsInfo = directory.GetDirectories();
            var countOfPersons = personsInfo.Count();
            for (int i = 0; i < countOfPersons; i++)
            {
                var currentInfoAboutPerson = personsInfo[i];
                var name = currentInfoAboutPerson.Name;
                var imagesOfPerson = currentInfoAboutPerson.GetFiles();
                var listOfPerson = new List<ImageOfPerson>();
                for (int j = 0; j < countOfImages; j++)
                {
                    var infoAboutImg = imagesOfPerson[j];
                    var pathToImage = infoAboutImg.FullName;
                    SignVector newVector = new SignVector(
                        MethodsForConvert.ScScale(new Mat(pathToImage), 4),
                        MethodsForConvert.DFT(new Mat(pathToImage)),
                        MethodsForConvert.DCT(new Mat(pathToImage)),
                        MethodsForConvert.Histogram(new Mat(pathToImage)),
                        MethodsForConvert.Gradient(new Mat(pathToImage))
                        );
                    listOfPerson.Add(new ImageOfPerson(name, new Mat(infoAboutImg.FullName),newVector));
                }
                Persons.Add(name,listOfPerson);
            }
            Db.CountOfImages = countOfImages;
            IsLoadFirst = true;

        }
        public static void DefineParamsOfTheModel(int countOfEtalons)
        {
            if (Persons == null)
                throw new Exception("База данных не загружена!");
            if (Db.CountOfImages < countOfEtalons || countOfEtalons <= 0)
                throw new Exception($"Максимальное количество эталонов составляет: {Db.CountOfImages - 1}, Минимальное: 1");
            Db.LoadDataBase(Persons, countOfEtalons); 
        }
        public static void RecognizeFace(string pathToFace)
        {
            _classificator = Db.Classificator;
            _classificator.RecognizeFace(pathToFace);
        }
        public static List<ResultOfTest> DoTesting()
        {
            return Db.DoTesting(Persons);
        }
        public static  bool TheBaseIsNotEmpty()
        {
            return Persons != null;
        }
    }
}
