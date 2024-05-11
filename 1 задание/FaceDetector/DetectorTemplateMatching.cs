using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetector
{
    internal class DetectorTemplateMatching
    {
        private PersonBase _baseOfPerson;
        public DetectorTemplateMatching()
        {
            _baseOfPerson = Dispetcher.Base;
        }
        public ResultOfPersonDetection DetectPerson(Mat image)
        {
            var persons = _baseOfPerson.Persons; //Получаем список с пользователями, у которых есть эталоны.
            var countOfPerson = persons.Count; //Получаем количество таких пользователей
            for (int i = 0; i < countOfPerson; i++) //Пробегаем по всем пользователям
            {
                var etalons = persons[i].Etalons; //Получаем список эталонов очередного пользователя
                Mat result = new Mat(); //Переменная куда будем складывать результат преобразования методов
                for (int j = 0; j < etalons.Length; j++)
                {
                    var etalon = etalons[j]; //Получаем очередной эталон
                    CvInvoke.MatchTemplate(image, etalon, result, TemplateMatchingType.CcoeffNormed); //Вызываем метод Template Matching, который находит совпадение с
                    //эталоном и возвращает часть исходного изображение, которое совпала с
                    //эталоном в оттенках серого
                    CvInvoke.Threshold(result, result, 0.6, 1, ThresholdType.ToZero); //Накладываем фильтр на изобржание,
                    //если значение интенсивности пикселя больше чем 0.8, то заменяет это значение на 1  
                    var matches = result.ToImage<Gray, byte>(); //Промежуточная конвертация в явное изображение
                    //(до этого это был объект класса Mat,который тоже содержал изображение, но с ним работать сложнее)
                    //Проходим по пикселями получивашегося изображения
                    for (int row = 0; row < matches.Rows; row++)
                    {
                        for (int column = 0; column < matches.Cols; column++)
                        {
                            //Проверяем является ли интенсивность пикселя для нас верной (т.е равняется 1)
                            if (matches[row, column].Intensity == 1)
                            {
                                //Если интенсивность хотя бы одного пикселя является верной, то отмечаем её область и возвращаем результат, который выводит имя и фамилию того
                                //кто попал на изображение, а также выводим исходное изображение с той областью, которую удалось распознать
                                System.Drawing.Point loc = new System.Drawing.Point(column, row);
                                System.Drawing.Rectangle box = new System.Drawing.Rectangle(loc, etalon.Size);
                                CvInvoke.Rectangle(image, box, new MCvScalar(0, 255, 0), 1);
                                return new ResultOfPersonDetection(image, persons[i].FirstName, persons[i].SecondName);
                            }
                        }
                    }
                }
            }
            return null; //Если лица не удалось распознать возвращаем null 
        }
    }
}
