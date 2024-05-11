using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recognizer
{
    public partial class RecognizeFaceForm : Form
    {
        OpenFileDialog _fileDialog;
        public RecognizeFaceForm()
        {
            _fileDialog = new OpenFileDialog();
            InitializeComponent();
        }

        private void LoadPhotobutton_Click(object sender, EventArgs e)
        {
            if (_fileDialog.ShowDialog() == DialogResult.Cancel) return;
            Dispetcher.RecognizeFace(_fileDialog.FileName);
        }

        private void RecognizeFaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void RecognizeFaceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
