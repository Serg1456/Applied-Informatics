using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace Recognizer
{
    internal class Person
    {
        public ImageOfPerson[] Etalons;
        public ImageOfPerson[] Tests;
        public string Name;
        public Person(string name,ImageOfPerson[] etalons, ImageOfPerson[] tests)
        {
            Name = name;
            Etalons = etalons;
            Tests = tests;
        }

    }
}
