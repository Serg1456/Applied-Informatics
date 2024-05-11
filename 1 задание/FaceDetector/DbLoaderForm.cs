using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Face;

namespace FaceDetector
{
    public partial class DbLoaderForm : Form
    {
        PersonBase _base;
        string[] _passToPhotoes;
        OpenFileDialog _openFileDialog;
        public DbLoaderForm()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image files | *.bmp; *.jpg; *.gif; *.png; *.tif";
            _passToPhotoes = new string[8];
            _base = Dispetcher.Base;
            InitializeComponent();
        }
        private void DbLoaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void LoadMainFace_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(0);
        }
        private void mainPartOfFace_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(1);
        }
        private void noseAndEyes_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(2);
        }
        private void Eyes_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(3);
        }
        private void LeftEye_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(4);
        }
        private void RightEye_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(5);
        }
        private void Lips_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(6);
        }
        private void nose_Click(object sender, EventArgs e)
        {
            AddPassToPhotoes(7);
        }
        private void AddPassToPhotoes(int index)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _passToPhotoes[index] = _openFileDialog.FileName;
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (CheckThatAllDataHaveLoaded())
            {
                _base.AddNewPerson(FirstNameInput.Text, SecondNameInput.Text, _passToPhotoes);
                ClearData();
            }
            else
            {
                MessageBox.Show("Не все данные заполнены!");
            }
        }
        private bool CheckThatAllDataHaveLoaded()
        {
            for (int i = 0; i < _passToPhotoes.Length; i++)
            {
                if (_passToPhotoes[i] == null) return false;
            }
            if (FirstNameInput.Text == string.Empty || SecondNameInput.Text == string.Empty) return false;
            return true;
        }
        private void ClearData()
        {
            FirstNameInput.Text = string.Empty;
            SecondNameInput.Text = string.Empty;
            _passToPhotoes = new string[8];
        }

        private void DbLoaderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
