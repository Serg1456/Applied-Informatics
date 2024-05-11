using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAProject._2DPCA
{
    public class Projection3DClassVisualResult
    {
        public Person[] Persons { get; set; } //Классы, которым соответствует наши 10 изображений
        public Color Color { get; set; } //Один из пяти цветов, который будет соотвествовать классу
        public double[][] Projections { get; set; } //Проекции в 3хмерное подпространство
        public double[] MeanClassValue { get; set; } //Среднее значение в новом трёхмерном пространстве
        public Projection3DClassVisualResult(Person[] persons, Color color, double[][] projections)
        {
            Persons = persons;
            Color = color;
            Projections = projections;
            MeanClassValue = GetMeanClassValue();
        }
        private double[] GetMeanClassValue()
        {
            MeanClassValue = new double[3];
            for (int i = 0; i < Projections.Length; i++)
                for (int j = 0; j < 3; j++)
                    MeanClassValue[j] += Projections[i][j];
            for (int j = 0; j < 3; j++)
                MeanClassValue[j] = MeanClassValue[j] / Projections.Length;
            return MeanClassValue;
        }
    }
}
