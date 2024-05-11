using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace Recognizer
{
    public delegate void DrawPointForTheGraphic(int index);
    internal class Dispetcher
    {
        public static DataBase Db { get; set; }
        public static Classificator Classificator { get; set; }
        public static bool IsLoadFirst { get; set; }
        public static Dictionary<string,List<ImageOfPerson>> Persons { get; set; }
        private static int _countOfEtalons;
        private static int _countOfTests;
        private static int _countOfImages;
        static Dispetcher()
        {
            _countOfImages = 40;
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
                    var resultOfScScale = MethodsForConvert.ScScale(new Mat(pathToImage));
                    var resultOfDFT = MethodsForConvert.DFT(new Mat(pathToImage));
                    var resultOfDCT = MethodsForConvert.DCT(new Mat(pathToImage));
                    var reslutOfHistogram = MethodsForConvert.Histogram(new Mat(pathToImage));
                    var resultOfGradient = MethodsForConvert.Gradient(new Mat(pathToImage));
                    SignVector newVector = new SignVector(
                       resultOfScScale.Item1,resultOfDFT.Item1,resultOfDCT.Item1, reslutOfHistogram, resultOfGradient,resultOfScScale.Item2,resultOfDFT.Item2,resultOfDCT.Item2);
                    listOfPerson.Add(new ImageOfPerson(name, new Mat(infoAboutImg.FullName),newVector));
                }
                Persons.Add(name,listOfPerson);
            }
            Db.CountOfImages = countOfImages;
            IsLoadFirst = true;

        }
        public static void StudyOnTheEtalons()
        {
            if (Db.IsNotEmpty())
            {
                var result = Classificator.StudyOnTheEtalons();
                int intervalForDynamic = 5;
                ChartsForm charts = new ChartsForm();
                DynamicResultOfRecognition dynamicRecognition = new DynamicResultOfRecognition(result, _countOfTests, _countOfEtalons, _countOfImages, intervalForDynamic,charts.DrawPointsOnTheGraphic);
                charts.DrawGraphics(result);
                charts.Show();
                dynamicRecognition.Show();
                dynamicRecognition.FillTheResultsOfTheTests();
            }
            else
            {
                MessageBox.Show("База данных не настроена!");
            }
        }
        public static void DefineParamsOfTheModel(int countOfEtalons, int countOfTests)
        {
            _countOfEtalons = countOfEtalons;
            _countOfTests = countOfTests;
            if (Persons == null)
                throw new Exception("База данных не загружена!");
            if (Db.CountOfImages < countOfEtalons + countOfTests || countOfEtalons <= -1 || countOfTests <= -1)
                throw new Exception($"Максимальное количество эталонов и тестовых изображений составляет: {Db.CountOfImages}, Минимальное: 1");
            Db.LoadDataBase(Persons, countOfEtalons,countOfTests); 
        }
        public static void TestModels()
        {
            if (Db.IsNotEmpty())
            {
                var result = Classificator.StudyOnTheTests();
                int intervalForDynamic = 5;
                ChartsForm charts = new ChartsForm();
                DynamicResultOfRecognition dynamicRecognition = new DynamicResultOfRecognition(result, _countOfTests,_countOfEtalons,_countOfImages,intervalForDynamic, charts.DrawPointsOnTheGraphic);
                charts.DrawGraphics(result);
                dynamicRecognition.Show();
                charts.Show();
                dynamicRecognition.FillTheResultsOfTheTests();
            }
            else
            {
                MessageBox.Show("База данных не настроена!");
            }
        }
        public static void CrossValidation()
        {
            int numberOfImagesForClass = 10;
            int cofficient = 5;
            var result = Db.CrossValidation(numberOfImagesForClass);
            var bestResult = result.Item2;
            var allResults = result.Item1;
            foreach (var reslut in allResults)
            {
                ChartsForm charts = new ChartsForm();
                charts.DrawGraphics(reslut,$"количество тестовых: {reslut.CountOfTests}, количество эталонных: {cofficient * numberOfImagesForClass - reslut.CountOfTests}");
                charts.Show();
            }
            ChartsForm Bestcharts = new ChartsForm();
            Bestcharts.DrawGraphics(bestResult);
            Bestcharts.Show();
        }
        public static void DetectFace(string pathToThePhoto)
        {
            if (Db.IsNotEmpty())
            {
                Classificator.RecognizeFace(pathToThePhoto);
            }
            else
            {
                MessageBox.Show("База данных не настроена!");
            }
        }
        public static void TestCascade()
        {
            if (Db.IsNotEmpty())
            {
                var result = Classificator.StudyOfCascade();
                int intervalForDynamic = 20;
                ChartsForm charts = new ChartsForm();
                DynamicResultOfRecognition dynamicRecognition = new DynamicResultOfRecognition(result, _countOfTests, _countOfEtalons, _countOfImages, intervalForDynamic,charts.DrawParallelGraphicPoint);
                charts.DrawParallelGraphic(result);
                charts.Show();
                dynamicRecognition.Show();
                dynamicRecognition.FillTheResultsOfTheTests();

            }
            else
            {
                MessageBox.Show("База данных не настроена!");
            }
        }
        public static void DefineBestParamsOfModel()
        {
            //Начальные значения параметров:
            int l = 2;
            int pDFT = 20;
            int pDCT = 5;
            int histSize = 2;
            int W = 1;
            //Максимальные значения параметров
            int maxl = 12;
            int maxPDFT = 30;
            int maxPDCT = 15;
            int maxHistSize = 256;
            int maxW = 11;
            //Лучшие значения параметров
            int bestl = l;
            int bestPDft = pDFT;
            int bestPDCT = pDCT;
            int bestHistSize = histSize;
            int bestW = W;
            double[] bestResults = new double[5];
            ProgressBarForm form = new ProgressBarForm(11);
            form.Show();
            for (; ; )
            {
                var result = DoParamsOfModelRecognize(l, pDFT, pDCT, histSize, W);
                int len = result.CountOfTests - 1;
                bool[] flags = new bool[5] { false, false, false, false, false };
                if (l <= maxl)
                {
                    flags[0] = true;
                    var currResult = result.ResultOfSeScale[len];
                    if (currResult > bestResults[0])
                    {
                        bestResults[0] = currResult;
                        bestl = l;
                    }
                    l++;
                }
                if (pDFT <= maxPDFT)
                {
                    flags[1] = true;
                    var curResult = result.ResultOfDFT[len];
                    if (curResult > bestResults[1])
                    {
                        bestResults[1] = curResult;
                        bestPDft = pDFT;
                    }
                    pDFT++;
                }
                if (pDCT <= maxPDCT)
                {
                    flags[2] = true;
                    var curResult = result.ResultOfDCT[len];
                    if (curResult > bestResults[2])
                    {
                        bestResults[2] = curResult;
                        bestPDCT = pDCT;
                    }
                    pDCT++;
                }
                if (histSize <= maxHistSize)
                {
                    flags[3] = true;
                    var curResult = result.ResultOfHistogram[len];
                    if (curResult > bestResults[3])
                    {
                        bestResults[3] = curResult;
                        bestHistSize = histSize;
                    }
                    histSize = histSize * 2;
                }
                if (W <= maxW)
                {
                    flags[4] = true;
                    var curResult = result.ResultOfGradient[len];
                    if (curResult > bestResults[4])
                    {
                        bestResults[4] = curResult;
                        bestW = W;
                    }
                    W++;
                }
                var countOfFlags = flags.Where(flag => flag == true).Count();
                if (countOfFlags == 0) break;
                GC.Collect();
                form.IncrementBar();
                Thread.Sleep(1000);
            }
            form.Close();
            MessageBox.Show($"Лучшие параметры методов модели: \nSeScale: {bestl} \nDFT: {bestPDft} \nDCT: {bestPDCT} \nHistogram: {bestHistSize} \nGradient: {bestW}");
        }
        public static ResultOfTest DoParamsOfModelRecognize(int l, int pDFT, int pDCT, int histSize, int W)
        {
            MethodsForConvert.l = l;
            MethodsForConvert.pDct = pDCT;
            MethodsForConvert.pDft = pDFT;
            MethodsForConvert.histSize = histSize;
            MethodsForConvert.W = W;
            LoadDataBase(10);
            DefineParamsOfTheModel(9, 1);
            return Classificator.StudyOnTheTests();
        }
        public static bool TheBaseIsNotEmpty()
        {
            return Persons != null;
        }
    }
}
