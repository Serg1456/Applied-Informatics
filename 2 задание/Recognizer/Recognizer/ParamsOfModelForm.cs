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
            int countOfEtalons = 0;
            int countOfTests = 0;
            try
            {
                countOfEtalons = Convert.ToInt32(countOfEtalonsTextBox.Text);
                countOfTests = 10 - countOfEtalons;
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
            Dispetcher.DefineParamsOfTheModel(countOfEtalons,countOfTests);
            MessageBox.Show("Модель настроена успешно!");
            Hide();
        }

        private void ParamsOfModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
