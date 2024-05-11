using Emgu.CV;

namespace FaceDetector
{
    public partial class MenuForm : Form
    {
        DbLoaderForm _dbLoaderForm;
        DetectorTemplateMatchingForm _detectorForm;
        DetectorViolaJonesForm _detectorViolaJonesForm;
        FacialSymmetryForm _facialSymmetryForm;
        public MenuForm()
        {
            _dbLoaderForm = new DbLoaderForm();
            _detectorForm = new DetectorTemplateMatchingForm();
            _detectorViolaJonesForm = new DetectorViolaJonesForm();
            _facialSymmetryForm = new FacialSymmetryForm();
            InitializeComponent();
        }
        private void AddNewUserButton_Click(object sender, EventArgs e)
        {
            _dbLoaderForm.Show();
        }
        private void DetectUserTemplateMatchingButton_Click(object sender, EventArgs e)
        {
            _detectorForm.Show();
        }
        private void DetectUserViolaJons_Click(object sender, EventArgs e)
        {
            _detectorViolaJonesForm.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void FacialSymmetry_Click(object sender, EventArgs e)
        {
            _facialSymmetryForm.Show();
        }
    }
}
