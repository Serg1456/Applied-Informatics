using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetector
{
    public partial class FacialSymmetryForm : Form
    {
        FacialSymmetry _facialSymmetry;
        OpenFileDialog _openFileDialog;
        Mat _image;
        public FacialSymmetryForm()
        {
            _facialSymmetry = new FacialSymmetry();
            _openFileDialog = new OpenFileDialog();
            InitializeComponent();
        }

        private void FacialSymmetryForm_Load(object sender, EventArgs e)
        {

        }

        private void SearchSymmetrialButton_Click(object sender, EventArgs e)
        {
            if (_image != null)
            {
                int N = _image.Cols;
                int M = _image.Rows;
                int X1 = (int)(N * 0.1);
                int X2 = (int)(N - X1);
                int Y1 = (int)(M * 0.1);
                int Y2 = (int)(M - Y1);
                CvInvoke.Imshow("result", _facialSymmetry.SearchSymmetrical(X1, X2, Y1, Y2, _image));
            }
            else
            {
                MessageBox.Show("Загрузите изображение");
            }
        }

        private void LoadSymmetrialButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image = CvInvoke.Imread(_openFileDialog.FileName);
            }
        }

        private void FacialSymmetryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
