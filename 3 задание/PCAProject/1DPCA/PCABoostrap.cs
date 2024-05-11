using System;
using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using PCAProject._1DPCA;

namespace PCAProject
{
	internal delegate Person loadPerson(string file);
    internal class PCABoostrap
    {

		private readonly PCAEigenFace eigenFaceModel;
		
        public PCABoostrap(PCAEigenFace eigenFaceModel)
        {
			this.eigenFaceModel = eigenFaceModel;
		}
		internal VisualResult PcaSeScaleMethod(int p)
		{
            var persons = this.LoadDatasetFromDir(@"..\..\..\ORL", Person.fromFileSeScale);
			eigenFaceModel.Train(persons, p);
			return eigenFaceModel.GetVisualResult;
        }
		internal VisualResult PcaGrammSmidtMethod(int p)
        {
			var persons = this.LoadDatasetFromDir(@"..\..\..\ORL",Person.fromFileGrammShmidt);
		    eigenFaceModel.Train(persons, p);
			return eigenFaceModel.GetVisualResult;
        }

        private List<Person> LoadDatasetFromDir(string path, loadPerson typeOfLoad)
        {
			var data = new List<Person>();
			foreach (var file in Directory.GetFiles(path, "*.jpg"))
			{
				var person = typeOfLoad(file); //Пока для процедуры грамма-шмидта (в дальнейшем, возможно, будет делегат).
				data.Add(person);
			}
			return data;
		}
		
    }
}