using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Filters;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace PCAProject._2DPCA
{
    internal class _2DPCAEigenFaceParallel
    {
        private int numComponentsRows;
        private int numComponentsCols; 
        private Mat mean;
        private List<Person> etalon;
        private Mat[] diffs;
        private Mat covarianceRows;
        private Mat covarianceCols;
        private Mat eigenValuesRows;
        private Mat eigenVectorsRows;
        private Mat eigenValuesCols;
        private Mat eigenVectorsCols;
        private Mat eigenFacesRows;
        private Mat eigenFacesCols;
        private Person[] projections;
        public _2DPCAEigenFaceParallel()
        {

        }
        public void Run(List<Person> train, int numComponents)
        {
            this.numComponentsRows = numComponents;
            this.numComponentsCols = numComponents;
            etalon = train;
            CalcMean(train);
            CalcDiff(train);
            CalcCovarianceRows();
            CalcCovarianceCols();
            CalcEigenRows();
            CalcEigenCols();
            CalcEigenFacesRows();
            CalcEigenFacesCols();
            CalcProjections(train);
        }
        private void CalcProjections(List<Person> train)
        {
            int K = diffs.Length;
            projections = new Person[K];
            for (int i = 0; i < K; i++)
            {
                Person originalPerson = train[i];
                Mat diffData = diffs[i];
                Mat first = Mul(eigenFacesRows, diffData);
                Mat second = Mul(first, eigenFacesCols);
                projections[i] = new Person(originalPerson.Id, originalPerson.Label, second);
            }
        }
        private void CalcEigenFacesRows()
        {
            Mat evt = eigenVectorsRows;
            int k = numComponentsRows > 0 ? numComponentsRows : evt.Rows;
            numComponentsRows = k;
            eigenFacesRows = new Mat(numComponentsRows, mean.Rows, DepthType.Cv64F, mean.NumberOfChannels);
            for (int i = 0; i < numComponentsRows; i++)
                evt.Row(i).CopyTo(eigenFacesRows.Row(i));
            //for (int i = 0; i < numComponentsRows; i++)
            //{
            //    Mat ef = eigenFacesRows.Col(i);
            //    CvInvoke.Normalize(ef, ef);
            //}
        }
        private void CalcEigenFacesCols()
        {
            Mat evt = eigenVectorsCols.T();
            int k = numComponentsCols > 0 ? numComponentsCols : evt.Cols;
            numComponentsCols = k;
            eigenFacesCols = new Mat(mean.Cols, numComponentsCols, DepthType.Cv64F, mean.NumberOfChannels);
            for (int i = 0; i < numComponentsCols; i++)
                evt.Col(i).CopyTo(eigenFacesCols.Col(i));
            //for (int i = 0; i < numComponentsCols; i++)
            //{
            //    Mat ef = eigenFacesCols.Col(i);
            //    CvInvoke.Normalize(ef, ef);
            //}
        }
        private void CalcEigenRows() //Вычисление собственных чисел и собственных векторов
        {
            eigenValuesRows = new Mat();
            eigenVectorsRows = new Mat();
            CvInvoke.Eigen(covarianceRows, eigenValuesRows, eigenVectorsRows);
        }
        private void CalcEigenCols()
        {
            eigenValuesCols = new Mat();
            eigenVectorsCols = new Mat();
            CvInvoke.Eigen(covarianceCols, eigenValuesCols, eigenVectorsCols);
        }
        private void CalcCovarianceCols()
        {
            covarianceCols = new Mat(mean.Cols, mean.Cols, mean.Depth, mean.NumberOfChannels);
            for (int i = 0; i < diffs.Length; i++)
            {
                Mat currData = diffs[i];
                Mat cov = Mul(currData.T(), currData);
                for (int l = 0; l < cov.Rows; l++)
                    for (int k = 0; k < cov.Cols; k++)
                    {
                        double cr = covarianceCols.GetValue(l, k);
                        double c = cov.GetValue(l, k);
                        cr += c;
                        covarianceCols.SetValue(l, k, cr);
                    }
                //Далее считаем суммы ковариации матрицы строка
            }
        }
        private void CalcCovarianceRows() //Вычисление матрицы ковариации (в классическом виде D(T)*D)
        {
            covarianceRows = new Mat(mean.Rows, mean.Rows, mean.Depth, mean.NumberOfChannels);
            for (int i = 0; i < diffs.Length; i++)
            {
                Mat currData = diffs[i];
                Mat cov = Mul(currData, currData.T());
                for (int l = 0; l < cov.Rows; l++)
                    for (int k = 0; k < cov.Cols; k++)
                    {
                        double cr = covarianceRows.GetValue(l, k);
                        double c = cov.GetValue(l, k);
                        cr += c;
                        covarianceRows.SetValue(l, k, cr);
                    }
                //Далее считаем суммы ковариации матрицы строка
            }
        }
        private void CalcMean(List<Person> train)
        {
            Mat sample = train[0].Data;
            mean = Mat.Zeros(sample.Rows, sample.Cols, sample.Depth, sample.NumberOfChannels);
            //Вычисляем сумму признаков всех изображений
            foreach (var person in train)
            {
                var data = person.Data;
                for (int i = 0; i < data.Rows; i++)
                    for (int j = 0; j < data.Cols; j++)
                    {
                        double mv = mean.GetValue(i, j);
                        double pv = data.GetValue(i, j);
                        mv += pv;
                        mean.SetValue(i, j, mv);
                    }
            }
            //Пробегаем по всем вычисленным суммам и находим среднее значение
            int K = train.Count;
            for (int i = 0; i < mean.Rows; i++)
                for (int j = 0; j < mean.Cols; j++)
                {
                    double mv = mean.GetDoubleValue(i, j);
                    mv = mv / K;
                    mean.SetDoubleValue(i, j, mv);
                }
        }
        private void CalcDiff(List<Person> train)
        {
            int K = train.Count;
            diffs = new Mat[K];
            for (int i = 0; i < K; i++)
            {
                Mat data = train[i].Data;
                diffs[i] = new Mat(data.Rows, data.Cols, data.Depth, data.NumberOfChannels);
                for (int l = 0; l < mean.Rows; l++)
                    for (int k = 0; k < mean.Cols; k++)
                    {
                        double dataValue = data.GetValue(l, k);
                        double meanValue = mean.GetValue(l, k);
                        double diffValue = dataValue - meanValue;
                        diffs[i].SetDoubleValue(l, k, diffValue);
                    }
            }
        }
        private Mat Mul(Mat a, Mat b) //Умножение двух матриц (с помощью OpenCV)
        {
            Mat c = new Mat(a.Rows, b.Cols, DepthType.Cv64F, 1);
            CvInvoke.Gemm(a, b, 1, new Mat(), 1, c);
            return c;
        }
        public RecognitionResult ClassifyTestImages(List<Person> test)
        {
            int countOfTestImages = test.Count;
            double[] recognitionResult = new double[countOfTestImages];
            double countOfRigtRecognition = 0;
            double countOfAllRecognition = 0;

            for (int i = 0; i < countOfTestImages; i++)
            {
                Person person = test[i];
                Mat diff = new Mat();
                Mat data = person.Data;
                CvInvoke.Subtract(data, mean, diff);
                Mat first = Mul(eigenFacesRows, diff);
                Mat projection = Mul(first, eigenFacesCols);
                int detectedLabel = GetMinDistance(projection);
                countOfAllRecognition++;
                recognitionResult[i] = (detectedLabel == person.Label ? ++countOfRigtRecognition : countOfRigtRecognition) / countOfAllRecognition * 100;
            }

            List<Person> outputTest = new List<Person>();
            for (int i = 0; i < test.Count; i++)
                outputTest.Add(test[i].RightPerson());
            List<Person> outputEtalon = new List<Person>();
            for (int i = 0; i < etalon.Count; i++)
                outputEtalon.Add(etalon[i].RightPerson());
            return new RecognitionResult(outputTest, outputEtalon, recognitionResult);
        }
        private int GetMinDistance(Mat newPerson)
        {
            var minDistance = double.MaxValue;
            var minLabel = 0;
            for (int i = 0; i < projections.Length; i++)
            {
                var basePerson = projections[i].Data;
                var baseLabel = projections[i].Label;
                Mat diff = new Mat();
                double distance = 0;
                CvInvoke.Subtract(newPerson, basePerson, diff);
                for (int l = 0; l < diff.Rows; l++)
                    for (int k = 0; k < diff.Cols; k++)
                    {
                        double val = diff.GetValue(l, k);
                        distance += val * val;
                    }
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minLabel = baseLabel;
                }
            }
            return minLabel;
        }
        //Получение визуальных результатов:
        public VisualResult GetVisualResults()
        {
            return new VisualResult(Get3DProjections(5), GetReconstructionResult());
        }
        //3Д - результаты
        private Projection3DClassVisualResult[] Get3DProjections(int countOfPersonsToProjection)
        {
            //Получаем labels изображений для проекции:
            var personsToProjectLabelIndexes = GetPersonsToProjectLabelIndexes(countOfPersonsToProjection, etalon.Count / Dispetcher.NumberOfEtalons);
            //Получаем цвета для проекции:
            var personsToProjectColors = GetColorsOfPersonsToProjection(countOfPersonsToProjection);
            //Получаем проекции для каждого Person:
            var personsToProject = GetPersonsToProject(etalon, countOfPersonsToProjection, personsToProjectLabelIndexes);
            //Получаем проекции в 3д пространство
            var projectionTo3DOfEachPerson = GetProjectionTo3DOfEachPerson(countOfPersonsToProjection, personsToProjectLabelIndexes);
            Projection3DClassVisualResult[] result = new Projection3DClassVisualResult[countOfPersonsToProjection];
            for (int i = 0; i < countOfPersonsToProjection; i++) 
            {
                result[i] = new Projection3DClassVisualResult(personsToProject[i], personsToProjectColors[i], projectionTo3DOfEachPerson[i]);
            }
            return result;

        }
        private int[] GetPersonsToProjectLabelIndexes(int countOfPersonsToProject, int countOfImagesForPersons) //Случайный номер каждого класса
        {
            Random numberGenerator = new Random();
            var numbersUsed = new HashSet<int>();
            var personsToProjectLabelIndexes = new int[countOfPersonsToProject];
            var counter = 0;
            while (counter < countOfPersonsToProject)
            {
                var newIndexOfPerson = numberGenerator.Next(1, countOfImagesForPersons + 1);
                if (!numbersUsed.Contains(newIndexOfPerson))
                {
                    numbersUsed.Add(newIndexOfPerson);
                    personsToProjectLabelIndexes[counter++] = newIndexOfPerson;
                }
            }
            return personsToProjectLabelIndexes;
        }
        private Color[] GetColorsOfPersonsToProjection(int countOfPersonsToProject) //Цвет для каждого класса
        {
            var usedColors = new Color[countOfPersonsToProject];
            int counter = 0;
            Random generator = new Random();
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                usedColors[i] = Color.FromArgb(generator.Next(0, 256), generator.Next(0, 256), generator.Next(0, 256));
            }
            return usedColors;
        }
        private Person[][] GetPersonsToProject(List<Person> train, int countOfPersonsToProject, int[] personsToProjectLabelIndexes) //Классы (Person), которые соответствуют, выбранным индексам
        {
            Person[][] persons = new Person[countOfPersonsToProject][];
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                persons[i] = train.Where(person => person.Label == personsToProjectLabelIndexes[i]).ToArray();
                for (int j = 0; j < persons[i].Length; j++)
                    persons[i][j] = persons[i][j].RightPerson();
            }
            return persons;
        }
        private double[][][] GetProjectionTo3DOfEachPerson(int countOfPersonsToProject, int[] personsToProjectLabelIndexes) //Здесь остановились!
        {
            double[][][] projectionsNumber = new double[countOfPersonsToProject][][]; //Проекции для каждого класса
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                var projection = projections.Where(p => p.Label == personsToProjectLabelIndexes[i]).ToArray();
                projectionsNumber[i] = new double[projection.Length][];
                for (int j = 0; j < projection.Length; j++)
                {
                    projectionsNumber[i][j] = new double[3];
                    projectionsNumber[i][j][0] = projection[j].Data.GetValue(0, 0);
                    projectionsNumber[i][j][1] = projection[j].Data.GetValue(0, 1);
                    projectionsNumber[i][j][2] = projection[j].Data.GetValue(0, 2);
                }
            }
            return projectionsNumber;
        }
        //Результаты реконструции
        private ReconstructionResult GetReconstructionResult()
        {
            //Генерируем person, которого будем реконструировать.
            Random generator = new Random();
            int randomPerson = generator.Next(0,etalon.Count);
            var projection = projections[randomPerson];
            var originalPerson = etalon.Where(p => p.Id == projection.Id).ToArray()[0];
            var indexOfOriginalPerson = etalon.Select((p, i) => { if (p.Id == projection.Id) return i; return 0; }).Where(p => p != 0).ToArray()[0];
            var test = diffs[indexOfOriginalPerson];

            //Генерируем параметры, в зависимости от которых и будет происходить реконструкция.
            int numberOfParamsReduction = 10;
            var rowParamsOfReduction = ParamsOfReduction(numberOfParamsReduction, numComponentsRows);
            var colParamsOfReduction = ParamsOfReduction(numberOfParamsReduction, numComponentsCols);
           
            //Генерируем реконструкцию в зависимости от сгенерированных параметров. (Здесь остановились - далее код писать будем от сюда).
            var data = projection.Data;
            Mat rowReverse = eigenFacesRows.T();
            Mat colReverse = eigenFacesCols.T();
            ReconstructionFace[] faces = new ReconstructionFace[numberOfParamsReduction];
            for (int i = 0; i < numberOfParamsReduction; i++)
            {
                //Создаём новое изображение выделением квадрата
                var newProjection = Mat.Zeros(data.Rows, data.Cols, data.Depth, data.NumberOfChannels);
                for (int row = 0; row < rowParamsOfReduction[i]; row++)
                    for (int col = 0; col < colParamsOfReduction[i]; col++)
                        newProjection.SetValue(row, col,(double)data.GetValue(row,col));

                //Проецируем новое изображение
                Mat first = Mul(newProjection, colReverse);
                Mat second = Mul(rowReverse, first);
                Mat withMean = new Mat();
                CvInvoke.Add(second, mean, withMean,null,DepthType.Cv64F);
                Mat newImage = new Mat();
                //CvInvoke.Add(second, mean, second);
                //Конвертируем новое изображение в правильный формат:
                CvInvoke.Normalize(withMean, newImage, 0, 255, NormType.MinMax, DepthType.Cv8U);
                faces[i] = new ReconstructionFace(newImage.ToBitmap(), rowParamsOfReduction[i] * colParamsOfReduction[i]);
            }
            return new ReconstructionResult(originalPerson.RightPerson(),faces);

        }
        private int[] ParamsOfReduction(int numberOfParamsReduction, int numComponents)
        {
            int[] paramsOfReduction = new int[numberOfParamsReduction];
            int reductionDegree = numComponents / numberOfParamsReduction;
            paramsOfReduction[0] = reductionDegree;
            for (int i = 1; i < numberOfParamsReduction - 1; i++)
                paramsOfReduction[i] = paramsOfReduction[i - 1] + reductionDegree;
            paramsOfReduction[numberOfParamsReduction - 1] = numComponents;
            return paramsOfReduction;

        }
    }
}
