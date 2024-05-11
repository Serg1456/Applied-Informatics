using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCAProject
{
    public partial class ParamsOfModel : Form
    {
        public ParamsOfModel()
        {
            InitializeComponent();
        }

        private void ParamsOfModel_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfEtalons = Convert.ToInt32(numberOfParamsInput.Text);
                int numberOfParamsReduction = 0;
                if (!(numberOfEtalons > 0 && numberOfEtalons < 10))
                {
                    MessageBox.Show("Количество эталонов должно быть в диапазоне от 0 до 10");
                    return;
                }
                if (numberOfReductionInput.Enabled) { 
                numberOfParamsReduction = Convert.ToInt32(numberOfReductionInput.Text);
                if (!(numberOfParamsReduction >= 20 && numberOfParamsReduction <= 70))
                    {
                        MessageBox.Show("Параметр редукции должен быть от 1 до 70");
                        return;
                    }
                }
                else
                {
                    numberOfParamsReduction = 0;
                }
                Dispetcher.NumberOfEtalons = numberOfEtalons;
                Dispetcher.ParametrReduction = numberOfParamsReduction;
                MessageBox.Show("Модель настроена успешно!");
                Hide();
            }
            catch
            {
                MessageBox.Show("Входные данные имели неверный формат");
            }
        }

        private void ParamsOfModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void noReductionButton_Click(object sender, EventArgs e)
        {
            var state = numberOfReductionInput.Enabled;
            if (state) 
            {
                numberOfReductionInput.Enabled = false;
                noReductionButton.Text = "С редукцией";
            }
            else
            {
                numberOfReductionInput.Enabled = true;
                noReductionButton.Text = "Без редукции";
            }
        }
    }
}
