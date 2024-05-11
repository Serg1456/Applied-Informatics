using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class Person //Предполагается по умолчанию (до применения методов ConvertDataToRow, ConvertDataToClumn), что размерности данных не менялись
    {
        public int Id { private set; get; }
        public int Label { private set; get; }
        public Mat Data { set; get; }
        public Person(int id, int label, Mat data)
        {
            Id = id;
            Label = label;
            Data = data;
        }
        public static Person FromFile(string file)
        {
            var filename = Path.GetFileNameWithoutExtension(file);
            var fileparts = filename.Split("_");
            Mat data = CvInvoke.Imread(file, ImreadModes.Grayscale);
            data.ConvertTo(data, DepthType.Cv64F, 1, 0);
            return new Person(Convert.ToInt32(fileparts[0]), Convert.ToInt32(fileparts[1]), data);
        }
        public Person ConvertDataToRow()
        {
            var dst = new Mat();
            var size = new Size(80, 80);
            CvInvoke.Resize(Data, dst, size, 0, 0, Inter.Linear);
            dst = dst.T().Reshape(1, dst.Cols * dst.Rows);
            dst.ConvertTo(dst, DepthType.Cv64F, 1, 0);
            return new Person(Id, Label, dst);
        }
        public Person ConvertDataToColumn()
        {
            var dst = new Mat();
            var size = new Size(80, 80);
            CvInvoke.Resize(Data, dst, size, 0, 0, Inter.Linear);
            dst = dst.Reshape(1, dst.Cols * dst.Rows);
            dst.ConvertTo(dst, DepthType.Cv64F, 1, 0);
            return new Person(Id, Label, dst);
        }
        public Person RightPerson()
        {
            var dst =  new Mat();
            CvInvoke.Normalize(Data, dst, 0, 255, NormType.MinMax, DepthType.Cv8U);
            return new Person(Id,Label, dst);
        }
    }
}
