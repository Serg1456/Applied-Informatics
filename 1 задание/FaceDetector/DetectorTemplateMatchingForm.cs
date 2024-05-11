using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace FaceDetector
{
    public partial class DetectorTemplateMatchingForm : Form
    {
        OpenFileDialog _openFileDialog;
        DetectorTemplateMatching _detector;
        Mat _image;
        public DetectorTemplateMatchingForm()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image files | *.bmp; *.jpg; *.gif; *.png; *.tif";
            _image = new Mat();
            _detector = new DetectorTemplateMatching();
            InitializeComponent();
        }

        private void LoadPhoto_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _image = CvInvoke.Imread(_openFileDialog.FileName);
            }
        }

        private void Detect_Click(object sender, EventArgs e)
        {
            if (!_image.IsEmpty)
            {
                var resultOfDetection = _detector.DetectPerson(_image);
                if (resultOfDetection != null)
                {
                    CvInvoke.Imshow("Result Of Detection", resultOfDetection.Image);
                }
                else
                {
                    MessageBox.Show("Распознать лицо не удалось");
                }
            }
            else
            {
                MessageBox.Show("Загрузите фото лица");
            }
        }

        private void DetectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void DetectorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
