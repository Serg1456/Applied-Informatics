using Accord.Math;
using Accord.Statistics.Filters;
using Emgu.CV;
using Emgu.CV.CvEnum;
using PCAProject._1DPCA;
using System;
using System.Collections.Generic;
using System.IO;

namespace PCAProject
{
    internal class PCAEigenFace
    {

        private int numComponents;
        private Mat mean;
        private Mat diffs;
        private Mat covariance;
        private Mat eigenvalues;
        private Mat eigenvectors;
        private Mat eigenfaces;
        private Mat projections;
        private int[] labels;
        private double[,] printedEigenVectors;
        private double[] printedEigenValues;
        private double[,] printedCovarianceMatrix;
        private List<Mat> printedEigenFaces;
        private Projection3DClassVisualResult[] projections3D;

        internal void Train(List<Person> train, int numComponents)
        {
            this.numComponents = numComponents;
            CalcMean(train); //Высчитываем среднее лицо
            CalcDiff(train); //Высчитываем расстояния остальных лиц до среднего лица
            CalcCovariance(); //Вычисляем матрицу ковариации размера (кол-во изображений * кол-во изображений)
            CalcEigen(); //Вычисление собственных векторов и собственных чисел размера (кол-во изображений * кол-во изображений)
            CalcEigenFaces();
            CalcProjections(train);
        }
        private void CalcProjections(List<Person> train)
        {
            labels = new int[train.Count]; // Каждому label соответствует одно изображение.
            projections = new Mat(this.numComponents, train.Count, DepthType.Cv64F, 1); //Проекции.
            for (int j = 0; j < diffs.Cols; j++) //Идём по столбцам.
            {
                Mat diff = diffs.Col(j);
                Mat w/*k x 1*/ = this.Mul(eigenfaces.T(), diff); // U=(6400 x k)t, Ut=k x 6400 * diff= 6400 x 1 = w=k x 1
                w.CopyTo(projections.Col(j));
                labels[j] = train[j].Label;
            }
            Get3DProjections(train, 5);
        }
        private void Get3DProjections(List<Person> train,int countOfPersonsToProject) //Получение трёхмерных проекций (Здесь остановились)
        {
            var countOfImages = train.Count;
            var personsToProjectLabelIndexes = GetPersonsToProjectLabelIndexes(countOfPersonsToProject,countOfImages/10); //Генерируем случайные номера label в количестве countOfPersonsToProject.
            var personsToProjectColors = GetColorsOfPersonsToProjection(countOfPersonsToProject); //Генерируем случайные цвета, для каждого label.
            var personsToProject = GetPersonsToProject(train,countOfPersonsToProject,personsToProjectLabelIndexes); //Получаем самих Person, в соответсвии с генерируемыми номерами labels.
            var projectionTo3DOfEachPerson = GetProjectionTo3DOfEachPerson(countOfPersonsToProject,personsToProjectLabelIndexes); //Получаем проекции данных Persons в 3д подпространство
            Projection3DClassVisualResult[] resultOfProjections = new Projection3DClassVisualResult[countOfPersonsToProject];
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                resultOfProjections[i] = new Projection3DClassVisualResult(personsToProject[i], personsToProjectColors[i], projectionTo3DOfEachPerson[i]);
            }
            projections3D = resultOfProjections;
        }
        private double[][][] GetProjectionTo3DOfEachPerson(int countOfPersonsToProject, int[] personsToProjectLabelIndexes) //Здесь остановились!
        {
            double[][][] projectionsNumber = new double[countOfPersonsToProject][][]; //Проекции для каждого класса
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                var indexexOfCurrPerson = labels.Select((e,index) => { if (e == personsToProjectLabelIndexes[i]) return index; return -1; }).Where(e => e != -1).ToArray();
                projectionsNumber[i] = new double[indexexOfCurrPerson.Length][]; //Проекции для определённого класса (на каждое изображение)
                for (int j = 0; j < indexexOfCurrPerson.Length; j++)
                {
                    var tResult = projections.Col(indexexOfCurrPerson[j]);
                    var tValueResult = new double[3];
                    for (int k = 0; k < 3; k++)
                    {
                        tValueResult[k] = Convert.ToDouble(tResult.GetData().GetValue(k, 0));
                    }
                    projectionsNumber[i][j] = tValueResult;
                }
            }
            return projectionsNumber;
        }
        private Person[][] GetPersonsToProject(List<Person> train,int countOfPersonsToProject, int[] personsToProjectLabelIndexes) //Классы (Person), которые соответствуют, выбранным индексам
        {
            Person[][] persons = new Person[countOfPersonsToProject][];
            for (int i = 0; i < countOfPersonsToProject; i++)
            {
                persons[i] = train.Where(person => person.Label == personsToProjectLabelIndexes[i]).ToArray();
                foreach (var person in persons[i]) person.Data = ReturnImageToUsuallForm(person.Data);
            }
            return persons;
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
        public VisualResult GetVisualResult
        {
            get { return new VisualResult(printedEigenValues, printedEigenFaces,projections3D); }
        }
        private Mat Mul(Mat a, Mat b) //Умножение двух матриц (с помощью OpenCV)
        {
            Mat c = new Mat(a.Rows, b.Cols, DepthType.Cv64F, 1);
            CvInvoke.Gemm(a, b, 1, new Mat(), 1, c);
            return c;
        }
        private void CalcEigenFaces()
        {
            Mat evt = eigenvectors.T(); //Транспонируем собственные вектора
            //Получаем признаковые компоненты
            int k = numComponents > 0 ? numComponents : evt.Cols; 
            numComponents = k;

            //Получаем количество собственных векторов, равное количеству компонент.
            Mat ev_k = new Mat(evt.Rows, k, DepthType.Cv64F, 1);
            // Mat ev_k = evt.ColRange(0, k);
            for (int j = 0; j < ev_k.Cols; j++)
            {
                evt.Col(j).CopyTo(ev_k.Col(j));
            }

            eigenfaces = this.Mul(diffs, ev_k);
            // k =3
            // 1 9 7
            // 4 5 8
            // 7 8 0
            // 6 1 7
            for (int j = 0; j < eigenfaces.Cols; j++)
            {
                Mat ef = eigenfaces.Col(j);
                // Normalização L2 = Yi = Xi / sqrt(sum(Xi)^2)), onde i = 0, ... rows-1
                CvInvoke.Normalize(ef, ef);
            }

            PrintEigenFaces();
        }
        private void PrintEigenFaces()
        {
            printedEigenFaces = new List<Mat>();
            for (int j = 0; j < eigenfaces.Cols; j++)
            {
                Mat y = new Mat(eigenfaces.Rows, 1, eigenfaces.Depth, eigenfaces.NumberOfChannels);
                eigenfaces.Col(j).CopyTo(y.Col(0));
                SaveImage(y);
            }
        }
        private void CalcEigen() //Вычисление собственных чисел и собственных векторов
        {
            eigenvalues = new Mat();
            eigenvectors = new Mat();
            CvInvoke.Eigen(covariance, eigenvalues, eigenvectors); //Вычисление собственных векторов и собственных чисел с помощью OpenCV
            PrintEigenValues();
        }
        private void PrintEigenValues() //Получаем собственные значения в процетном соотношении
        {
            // Soma os eigenvalues
            //Сумма всех собственных векторов
            double sum = 0;
            printedEigenValues = new double[eigenvalues.Rows];
            for (int i = 0; i < eigenvalues.Rows; i++)
            {
                //sum += eigenvalues.get(i, 0)[0];
                sum += eigenvalues.GetDoubleValue(i, 0);
            }

            // Calcula o percentual de contribuição de cada eigenvalue na explicação dos dados.
            //Рассчёт в процентном соотношении для каждого собственного значения.
            for (int i = 0; i < eigenvalues.Rows; i++)
            {
                //double v = eigenvalues.get(i, 0)[0];
                double v = eigenvalues.GetDoubleValue(i, 0);
                double percentual = v / sum * 100;
                printedEigenValues[i] = percentual;
            }
            printedEigenValues = printedEigenValues.Take(20).ToArray();
        }
        private void CalcCovariance() //Вычисление матрицы ковариации (в классическом виде D(T)*D)
        {
            covariance = this.Mul(diffs.T(), diffs);
        }
        private void CalcDiff(List<Person> train)
        {
            Mat sample = train[0].Data;
            // 1 9 7
            // 4 5 8
            // 7 8 0
            // 6 1 7
            diffs = new Mat(sample.Rows, train.Count, sample.Depth, sample.NumberOfChannels);
            for (int i = 0; i < diffs.Rows; i++)
            {
                for (int j = 0; j < diffs.Cols; j++)
                {
                    //double mv = mean.get(i, 0)[0];
                    double mv = mean.GetDoubleValue(i, 0);
                    Mat data = train[j].Data;
                    //double pv = data.get(i, 0)[0];
                    double pv = data.GetDoubleValue(i, 0);
                    double v = pv - mv;
                    //diffs.put(i, j, v);
                    diffs.SetDoubleValue(i, j, v);
                }
            }
        }
        private void CalcMean(List<Person> train) //Вычисляем среднее лицо
        {
            Mat sample = train[0].Data; //Берём пример изображения (эталонное изображение, в соответсвии с которым будем делать новую форму изображения).
            mean = Mat.Zeros(/*6400*/sample.Rows, /*1*/sample.Cols, /*CvType.CV_64FC1*/sample.Depth, sample.NumberOfChannels); //Создаём пустое изображение, с такими характеристиками и заполняем его нулями.

            /// Begin Calculado na mão
            //Собираем сумму всех признаков для каждого лица
            train.ForEach(person => {
                Mat data = person.Data;
                for (int i = 0; i < mean.Rows; i++)
                {
                    //double mv = mean.get(i, 0)[0]; // Obtém o valor da célula no primeiro canal.
                    //double pv = data.get(i, 0)[0]; // Obtém o valor da célula no primeiro canal.
                    double mv = mean.GetDoubleValue(i, 0); // Obtém o valor da célula no primeiro canal.
                    double pv = data.GetDoubleValue(i, 0); // Obtém o valor da célula no primeiro canal.
                    mv += pv;
                    //mean.put(i, 0, mv);
                    mean.SetDoubleValue(i, 0, mv);
                }
            });

            int M = train.Count;
            for (int i = 0; i < mean.Rows; i++)
            {
                //double mv = mean.get(i, 0)[0]; // Obtém o valor da célula no primeiro canal.
                double mv = mean.GetDoubleValue(i, 0); // Obtém o valor da célula no primeiro canal.
                mv /= M;
                //mean.put(i, 0, mv);
                mean.SetDoubleValue(i, 0, mv);
            }
            /// End Calculado na mão

            // Begin OpenCV
            // 1 9 7
            // 4 5 8
            // 7 8 0
            // 6 1 7
            //		Mat src = new Mat(sample.rows(), train.size(), sample.type());
            //		for (int i = 0; i < train.size(); i++) {
            //			train.get(i).getData().col(0).copyTo(src.col(i));
            //		}
            //		
            //		Mat mean2 = Mat.zeros(sample.rows(), sample.cols(), sample.type());
            //		Core.reduce(src, mean2, /*0=linha, 1=coluna*/1, Core.REDUCE_AVG, mean.type());
            // End OpenCV
            var a = 54;
        }
        private void SaveImage(Mat image)
        {
            //Собственные лица:

            // [1,2,3,4,5]t
            // 1 2
            // 2 3
            Mat dst = new Mat();
            CvInvoke.Normalize(image, dst, 0, 255, NormType.MinMax, DepthType.Cv8U);
            // 6400 x 1
            // 80 x 80
            dst = dst.Reshape(1, (int)Math.Sqrt(mean.Rows));
            dst = dst.T();
            printedEigenFaces.Add(dst);
        }
        private Mat ReturnImageToUsuallForm(Mat image)
        {
            Mat dst = new Mat();
            CvInvoke.Normalize(image, dst, 0, 255, NormType.MinMax, DepthType.Cv8U);
            dst = dst.Reshape(1, (int)Math.Sqrt(mean.Rows));
            dst = dst.T();
            return dst;
        }
    }
}