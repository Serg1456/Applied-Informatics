using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCAProject
{
    public partial class NumberResultOfPCA1D : Form
    {
        PCA1DResult _result;
        public NumberResultOfPCA1D(PCA1DResult result)
        {
            _result = result;
            InitializeComponent();
            FillCovariationMatrix();
            FillEigenVectors();
            FillEigenValues();
        }
        private void dataGridViewCovarriationMatrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void VisualResultOfPCA1D_Load(object sender, EventArgs e)
        {
          
        }
        private void FillEigenValues()
        {
            var eigenValues = _result.EigenValues;
            var rowsOfEigenValues = eigenValues.Length;
            dataGridViewEigenValues.RowCount = rowsOfEigenValues;
            dataGridViewEigenValues.ColumnCount = 1;
            for (int i = 0; i < rowsOfEigenValues; i++)
                dataGridViewEigenValues[0, i].Value = Math.Round(eigenValues[i], 4);
        }
        private void FillCovariationMatrix()
        {
            var covariationMatrix = _result.CovarianceMatrix;
            var rowsOfCovariationMatrix = covariationMatrix.GetLength(0);
            var columsOfCovariationMatrix = covariationMatrix.GetLength(1);
            dataGridViewCovarriationMatrix.ColumnCount = columsOfCovariationMatrix;
            dataGridViewCovarriationMatrix.RowCount = rowsOfCovariationMatrix;
            for (int i = 0; i < rowsOfCovariationMatrix; i++)
                for (int j = 0; j < columsOfCovariationMatrix; j++)
                    dataGridViewCovarriationMatrix[j, i].Value = Math.Round(covariationMatrix[i, j],4);
        }
        private void FillEigenVectors()
        {
            var eigenVectors = _result.EigenVectors;
            var rowsOfEigenVectors = eigenVectors.GetLength(0);
            var columsOfEigenVectors = eigenVectors.GetLength(1);
            dataGridViewEigenVectors.ColumnCount = columsOfEigenVectors;
            dataGridViewEigenVectors.RowCount = rowsOfEigenVectors;
            for (int i = 0; i < rowsOfEigenVectors; i++)
                for (int j = 0; j < columsOfEigenVectors; j++)
                    dataGridViewEigenVectors[j, i].Value = Math.Round(eigenVectors[i, j], 4);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
