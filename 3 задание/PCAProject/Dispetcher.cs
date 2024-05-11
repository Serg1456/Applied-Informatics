using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using PCAProject._2DPCA;

namespace PCAProject
{
    internal class Dispetcher
    {
        private static PCABoostrap bootStrapt;
        private static _2DPCABootstrap bootStrapFor2DPCA;
        private static ParamsOfModel paramsOfModel;
        private static int numberOfEtalons;
        private static int parametrReduction;
        
        public static  void LoadDataBaseFor2DPCA()
        {

        }
        public static void DefineParamsOfTheModel()
        {
            paramsOfModel.Show();
        }
        static Dispetcher()
        {
            paramsOfModel = new ParamsOfModel();
            bootStrapt = new PCABoostrap(new PCAEigenFace());
            bootStrapFor2DPCA = new _2DPCABootstrap(new _2DPCAEigenFaceParallel(), new _2DPCAEigenFaceCascade());
            //Значения по умолчанию.
            NumberOfEtalons = 9; 
            parametrReduction = 20; 
        }
        public static void DoParallel2DPCAAlgorithm()
        {
           var result = bootStrapFor2DPCA.DoParallelAlgorithm();
           VisualRecognitionForm visualRecognitionResult = new VisualRecognitionForm();
           visualRecognitionResult.Draw2DResultOfRecognition(result.Item1,"Результат параллельного алгоритма");
           visualRecognitionResult.Show();
           VisualResultsFor2DPCA visualResultFor2DRecognition = new VisualResultsFor2DPCA();
           visualResultFor2DRecognition.DrawResults("Результат параллельного алгоритма", result.Item2);
           visualResultFor2DRecognition.Show();
        }
        public static void DoCascade2DPCAAlgorithm()
        {
            var result = bootStrapFor2DPCA.DoCascadeAlgorithm();
            VisualRecognitionForm visualRecognitionResult = new VisualRecognitionForm();
            visualRecognitionResult.Draw2DResultOfRecognition(result.Item1,"Результат каскадного алгоритма");
            visualRecognitionResult.Show();
            VisualResultsFor2DPCA visualResultFor2DRecognition = new VisualResultsFor2DPCA();
            visualResultFor2DRecognition.DrawResults("Результат каскадного алгоритма", result.Item2);
            visualResultFor2DRecognition.Show();
        }
        //Реализация по одному из принципов.
        public static void PCAScale() //Реализация метода PCAScale
        {
            var realVisualResult = bootStrapt.PcaSeScaleMethod(20);
            VisualResultsForPCA1D visualResults = new VisualResultsForPCA1D(realVisualResult);
            visualResults.Show();
        }
        //Здесь всё делаем по-новому
        public static void PCAGrammShidt() //Реализация метода PCAGrammShidt
        {
            var realVisualResult = bootStrapt.PcaGrammSmidtMethod(20);
            VisualResultsForPCA1D visualResults = new VisualResultsForPCA1D(realVisualResult);
            visualResults.Show();
        }
        public static int NumberOfEtalons
        {
            get
            {
                return numberOfEtalons;
            }
            set
            {
                numberOfEtalons = value;
                bootStrapFor2DPCA.DefineTestAndEtalonsFromData();
            }
        }
        public static int ParametrReduction
        {
            get
            {
                return parametrReduction;
            }
            set
            {
                parametrReduction = value;
            }
        }
    }
}
