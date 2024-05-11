using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace FaceDetector
{
    internal class PersonBase
    {
        public List<Person> Persons { get; private set; }
        private int _index;
        private string _pathToData;
        public PersonBase()
        {
            _index = 0;
            _pathToData = "../../../Data";
            Persons = new List<Person>();
            LoadPersons();
        }
        public void AddNewPerson(string firstName, string secondName, string[] pathToTheFiles)
        {
            AddNewPersonInTheList(firstName,secondName,pathToTheFiles);
            AddNewPersonInTheData(firstName,secondName, pathToTheFiles);
        }
        private void AddNewPersonInTheList(string firstName, string secondName, string[] pathToTheFiles) 
        {
            Mat[] maps = new Mat[pathToTheFiles.Length];
            for (int i = 0; i < pathToTheFiles.Length; i++)
            {
                maps[i] = new Mat();
                maps[i] = CvInvoke.Imread(pathToTheFiles[i]);
            }
            Persons.Add(new Person(maps, firstName, secondName));
        }
        private void AddNewPersonInTheData(string firstName, string secondName, string[] pathToTheFiles)
        {
            _index++;
            var pathToNewPerson = _pathToData + $"//{_index}";
            var pathToNewPesonImage = pathToNewPerson + "//img";
            var pathToNewPersonInfo = pathToNewPerson + $"//info.txt";
            Directory.CreateDirectory(pathToNewPerson);
            Directory.CreateDirectory(pathToNewPesonImage);
            StreamWriter newInfoUser = new StreamWriter(pathToNewPersonInfo);
            newInfoUser.WriteLine(firstName + " " + secondName);
            newInfoUser.Close();
            for (int i = 0; i < pathToTheFiles.Length; i++)
            {
                FileInfo file = new FileInfo(pathToTheFiles[i]);
                file.CopyTo(pathToNewPesonImage + i + file.Extension);
            }
        }
        private void LoadPersons()
        {
            string[] personsInfo = Directory.GetDirectories(_pathToData);
            foreach (string personInfo in personsInfo)
            {
                _index++;
                string userInfo = personInfo + "//info.txt";
                string[] partsOfFace = Directory.GetFiles(personInfo + "//img");
                StreamReader reader = new StreamReader(userInfo,Encoding.Default);
                string[] firstNameAndSecondName = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                AddNewPersonInTheList(firstNameAndSecondName[0], firstNameAndSecondName[1], partsOfFace);
            }
            //string[] nameAndSecondName = (files[0] + "/info.txt");
        }
    }
}
