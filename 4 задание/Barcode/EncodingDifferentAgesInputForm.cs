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

namespace Barcode
{
    public partial class EncodingDifferentAgesInputForm : Form
    {
        private OpenFileDialog _dialog;
        private Person _youngPerson;
        private Person _olderPerson;
        public EncodingDifferentAgesInputForm()
        {
            _youngPerson = null;
            _olderPerson = null;
            InitializeComponent();
            _dialog = new OpenFileDialog();
            Text = "Введите лица";
        }

        private void EncodingDifferentAgesInputForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (_youngPerson != null && _olderPerson != null)
            {
                Dispetcher.BuildEANFromDifferentAges(_youngPerson,_olderPerson);    
            }
            else
            {
                MessageBox.Show("Для начала загрузите изображения");
            }
        }

        private void buttonLoadYoungImage_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = _dialog.FileName;
            _youngPerson = new Person(new Mat($"{fileName}", Emgu.CV.CvEnum.ImreadModes.Grayscale));
        }

        private void buttonLoadOlderImage_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = _dialog.FileName;
            _olderPerson = new Person(new Mat($"{fileName}", Emgu.CV.CvEnum.ImreadModes.Grayscale));
        }
    }
}
