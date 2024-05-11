using Emgu.CV;
namespace Barcode
{
    public partial class Form1 : Form
    {
        private OpenFileDialog _dialog;
        public Form1()
        {
            InitializeComponent();
            _dialog = new OpenFileDialog();
        }

        private void BuildEAN8ForFaceButton_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = _dialog.FileName;
            Dispetcher.BuildEANEightFromFace(new Person(new Mat($"{fileName}", Emgu.CV.CvEnum.ImreadModes.Grayscale)));
        }

        private void BuildEAN8BarcodeFromDifferentAges_Click(object sender, EventArgs e)
        {
            EncodingDifferentAgesInputForm form = new EncodingDifferentAgesInputForm();
            form.Show();
        }
    }
}
