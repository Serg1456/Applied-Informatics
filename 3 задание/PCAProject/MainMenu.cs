namespace PCAProject
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            //Dispetcher.LoadDataBase(10); Изменим данные, готовые к загрузке
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1PCAScale_Click(object sender, EventArgs e)
        {
            Dispetcher.PCAScale();
        }

        private void button1PCAShmidt_Click(object sender, EventArgs e)
        {
            Dispetcher.PCAGrammShidt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispetcher.DefineParamsOfTheModel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispetcher.DoParallel2DPCAAlgorithm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispetcher.DoCascade2DPCAAlgorithm();
        }
    }
}
