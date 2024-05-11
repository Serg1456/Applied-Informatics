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
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(int maxValueOfBar)
        {
            InitializeComponent();
            progressBar1.Maximum = maxValueOfBar;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void ProgressBarForm_Load(object sender, EventArgs e)
        {

        }
        public void IncrementBar()
        {
            progressBar1.Increment(1);
        }
    }
}
