namespace Recognizer
{
    public partial class Form1 : Form
    {
        ParamsOfModelForm _paramsOfModel;
        SetupCountOfImagesForm _setupCountOfImagesForm;
        ChartsForm _chartForm;
        OpenFileDialog _fileDialog;
        public Form1()
        {
            _paramsOfModel = new ParamsOfModelForm();
            _setupCountOfImagesForm = new SetupCountOfImagesForm();
            InitializeComponent();
            _fileDialog = new OpenFileDialog();
        }

        private void LoadDbbutton_Click(object sender, EventArgs e)
        {
            _setupCountOfImagesForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dispetcher.LoadDataBase(10);
        }

        private void ConfigureModelsParamsbutton_Click(object sender, EventArgs e)
        {
            _paramsOfModel.Show();
        }

        private void TestModelButton_Click(object sender, EventArgs e)
        {
            Dispetcher.StudyOnTheEtalons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispetcher.TestModels();
        }

        private void DefineBestParamsOfModel_Click(object sender, EventArgs e)
        {
            Dispetcher.DefineBestParamsOfModel();
        }

        private void buttonTestParralelModel_Click(object sender, EventArgs e)
        {
            Dispetcher.TestCascade();
        }

        private void DetectFaceButton_Click(object sender, EventArgs e)
        {
            if (_fileDialog.ShowDialog() == DialogResult.Cancel) return;
            Dispetcher.DetectFace(_fileDialog.FileName);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
