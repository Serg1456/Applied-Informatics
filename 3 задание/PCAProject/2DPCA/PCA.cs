using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class PCAResult
    {
        public Mat Mean { get; set; }
        public Mat Diffs { get; set; }
        public Mat Covariance { get; set; }
        public Mat Eigenvalues { get; set; }
        public Mat Eigenvectors { get; set; }
        public Mat Eigenfaces { get; set; }
        public PCAResult(Mat mean, Mat diffs, Mat covariance, Mat eigenvalues, Mat eigenvectors, Mat eigenfaces)
        {
            Mean = mean;
            Diffs = diffs;
            Covariance = covariance;
            Eigenvalues = eigenvalues;
            Eigenvectors = eigenvectors;
            Eigenfaces = eigenfaces;
        }
    }
    internal class PCA
    {
        private int numComponents;
        private Mat mean;
        private Mat diffs;
        private Mat covariance;
        private Mat eigenvalues;
        private Mat eigenvectors;
        private Mat eigenfaces;
        public PCAResult Run(List<Person> train, int numComponents)
        {
            this.numComponents = numComponents;
            CalcMean(train); //Высчитываем среднее лицо
            CalcDiff(train); //Высчитываем расстояния остальных лиц до среднего лица
            CalcCovariance(); //Вычисляем матрицу ковариации размера (кол-во изображений * кол-во изображений)
            CalcEigen(); //Вычисление собственных векторов и собственных чисел размера (кол-во изображений * кол-во изображений)
            CalcEigenFaces();
            return new PCAResult(mean,diffs, covariance, eigenvalues,eigenvectors,eigenfaces);
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
        }
        private void CalcEigen() //Вычисление собственных чисел и собственных векторов
        {
            eigenvalues = new Mat();
            eigenvectors = new Mat();
            CvInvoke.Eigen(covariance, eigenvalues, eigenvectors); //Вычисление собственных векторов и собственных чисел с помощью OpenCV
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
    }
}
