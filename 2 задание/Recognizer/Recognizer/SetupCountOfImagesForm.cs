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
    public partial class SetupCountOfImagesForm : Form
    {
        public SetupCountOfImagesForm()
        {
            InitializeComponent();
        }

        private void SetupCountOfImagesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Confirmbutton_Click(object sender, EventArgs e)
        {
            var countOfPerson = Convert.ToInt32(countOfPersonTextArea.Text);
            if (countOfPerson >= 3 && countOfPerson <= 13)
            {
                Dispetcher.LoadDataBase(Convert.ToInt32(countOfPersonTextArea.Text));
                MessageBox.Show("База данных успешно загружена!");
            }
            else
            {
                MessageBox.Show("Количество изображений должно быть в границах от 3 до 10");
            }
            Hide();
        }

        private void SetupCountOfImagesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
