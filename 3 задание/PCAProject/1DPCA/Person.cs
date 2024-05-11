using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.IO;

namespace PCAProject
{
    public class Person : IComparable<Person>
    {
        public int Id { private set; get; }
        public int Label { private set; get; }
        public Mat Data { set; get; }

        internal static Person fromFileGrammShmidt(string file)
        {
			var filename = Path.GetFileNameWithoutExtension(file);
            var fileparts = filename.Split("_");

            var person = new Person() //Устанавливаем название для индентификации личности
            {
                Id = Convert.ToInt32(fileparts[0]),
                Label = Convert.ToInt32(fileparts[1])
            };

			var image_data = CvInvoke.Imread(file, ImreadModes.Grayscale); //Переводим файл в изображение 

			var dst = new Mat(); //Новое изображение (увеличенное)

			var size = new Size(80, 80); //Размер для увеличенного изображения

			CvInvoke.Resize(image_data, dst, size, 0, 0, Inter.Linear); //Изменяем размер исходного

            // De imagem com 8 bits, sem sinal, 1 canal
            dst = dst.T().Reshape(1, dst.Cols * dst.Rows); 
            person.Data = new Mat();

			// Para imagem com 64 bits, com sinal e ponto flutuante, 1 canal
			dst.ConvertTo(person.Data, DepthType.Cv64F, 1, 0); //Для простоты дальнейших вычислений переводим всё в 64 битный канал, а не 8-битный

            return person;

		}
        internal static Person fromFileSeScale(string file)
        {
            var filename = Path.GetFileNameWithoutExtension(file);
            var fileparts = filename.Split("_");

            var person = new Person() //Устанавливаем название для индентификации личности
            {
                Id = Convert.ToInt32(fileparts[0]),
                Label = Convert.ToInt32(fileparts[1])
            };

            var image_data = CvInvoke.Imread(file, ImreadModes.Grayscale); //Переводим файл в изображение 

            var dst = new Mat(); //Новое изображение (увеличенное)

            var size = new Size(20, 20); //Размер для увеличенного изображения

            CvInvoke.Resize(image_data, dst, size, 0, 0, Inter.Linear); //Изменяем размер исходного

            // De imagem com 8 bits, sem sinal, 1 canal
            dst = dst.T().Reshape(1, dst.Cols * dst.Rows); //Переводим изображение в одномерное

            person.Data = new Mat();

            // Para imagem com 64 bits, com sinal e ponto flutuante, 1 canal
            dst.ConvertTo(person.Data, DepthType.Cv64F, 1, 0); //Для простоты дальнейших вычислений переводим всё в 64 битный канал, а не 8-битный

            return person;
        }
        public int CompareTo(Person other)
        {
            return this.Id - other.Id;
        }
    }
}