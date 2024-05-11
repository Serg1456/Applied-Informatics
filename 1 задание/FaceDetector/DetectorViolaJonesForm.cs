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
    public partial class DetectorViolaJonesForm : Form
    {
        DetectorViolaJones _detectorViolaJones;
        OpenFileDialog _openFileDialog;
        Mat _image;
        public DetectorViolaJonesForm()
        {
            _image = new Mat();
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image files | *.bmp; *.jpg; *.gif; *.png; *.tif";
            _detectorViolaJones = new DetectorViolaJones();
            InitializeComponent();
        }

        private void DetectorViolaJonesForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadPhoto_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image = CvInvoke.Imread(_openFileDialog.FileName);
            }
        }

        private void DetectorViolaJonesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Detect_Click(object sender, EventArgs e)
        {
           CvInvoke.Imshow("Result Of Detection",_detectorViolaJones.DetectFaces(_image));
        }
    }
}
