namespace Recognizer
{
    public partial class Form1 : Form
    {
        ParamsOfModelForm _paramsOfModel;
        RecognizeFaceForm _recognizeFaceForm;
        SetupCountOfImagesForm _setupCountOfImagesForm;
        ChartsForm _chartForm;
        public Form1()
        {
            _paramsOfModel = new ParamsOfModelForm();
            _recognizeFaceForm = new RecognizeFaceForm();
            _setupCountOfImagesForm = new SetupCountOfImagesForm();
            InitializeComponent();
        }

        private void LoadDbbutton_Click(object sender, EventArgs e)
        {
            _setupCountOfImagesForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureModelsParamsbutton_Click(object sender, EventArgs e)
        {
            _paramsOfModel.Show();
        }

        private void RecognizeFacebutton_Click(object sender, EventArgs e)
        {
            if (Dispetcher.Db.IsNotEmpty())
            {
                _recognizeFaceForm.Show();
            }
            else
            {
                MessageBox.Show("База данных не загружена или не настроена");
            }
        }

        private void TestModelbutton_Click(object sender, EventArgs e)
        {
            if (Dispetcher.TheBaseIsNotEmpty())
            {
                if (Dispetcher.IsLoadFirst)
                {
                    _chartForm = new ChartsForm();
                    _chartForm.DrawGraphics(Dispetcher.DoTesting());
                    Dispetcher.IsLoadFirst = false;
                }
                _chartForm.Show();
            }
            else
            {
                MessageBox.Show("База данных не загружена");
            }
        }
    }
}
