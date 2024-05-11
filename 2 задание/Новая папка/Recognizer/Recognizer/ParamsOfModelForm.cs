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
    public partial class ParamsOfModelForm : Form
    {
        public ParamsOfModelForm()
        {
            InitializeComponent();
        }

        private void Acceptbutton_Click(object sender, EventArgs e)
        {
            var countOfEtalons = Convert.ToInt32(countOfEtalonsTextBox.Text);
            Dispetcher.DefineParamsOfTheModel(countOfEtalons);
            MessageBox.Show("Модель настроена успешно!");
        }

        private void ParamsOfModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
