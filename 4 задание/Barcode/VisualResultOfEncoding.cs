using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode
{
    public partial class VisualResultOfEncoding : Form
    {
        public VisualResultOfEncoding()
        {
            InitializeComponent();
            Size = new Size(1500, 1000);
            Text = "Результат";
        }

        private void VisualResultOfEncoding_Load(object sender, EventArgs e)
        {

        }
        public void DrawResultOfDifferentAges(ResultOfDifferentAgeEncoding resultOfDifferentAges)
        {
            int startX = 100;
            int startY = 50;
            var ssim = resultOfDifferentAges.Ssim;
            var corr = resultOfDifferentAges.Correlation;
            var youngImage = resultOfDifferentAges.Young.OriginalPerson.Image.ToBitmap();
            var olderImage = resultOfDifferentAges.Older.OriginalPerson.Image.ToBitmap();
            var youngBarCode = resultOfDifferentAges.Young.Barcode;
            var olderBarcode = resultOfDifferentAges.Older.Barcode;
            DrawImageBox("Изображение лица в молодом возрасте: ", 100, 50, 20, youngImage);
            DrawImageBox("Штрих-код лица в молодом возрасте: ", 800, 50, 20, youngBarCode);
            DrawImageBox("Изображение лица в позднем возрасте: ", 100, 350, 20, olderImage);
            DrawImageBox("Штрих-код лица в позднем возрасте: ",800,350,20,olderBarcode);
            BuildLabel($"SSIM: {ssim} ", new Point(1250, 150), 15);
            BuildLabel($"Корреляция: {corr}", new Point(1250, 250), 15);
            //BuildLabel("Изображение лица в молодом возрасте: ", new Point(startX, startY));
            //var youngBox = BuildPictureBox(new Point(startX, startY + 20));
            //youngBox.Image = youngImage;
            //startX += 200;
            //BuildLabel("Штрих-код лица в молодом возрасте: ", new Point(startX, startY));
            //var youngBarCodeBox = BuildPictureBox(new Point(startX, startY + 20));
            //youngBarCodeBox.Image = youngBarCode;
            //startX = 100;
            //startY += 300;
            //BuildLabel("Изображение лица в позднем возрасте: ", new Point(startX, startY));
            //var olderBox = BuildPictureBox(new Point(startX, startY + 20));
            //olderBox.Image = olderImage;
            //startX += 200;
            //BuildLabel("Штрих-код лица в позднем возрасте: ", new Point(startX, startY));
            //var olderBarCodeBox = BuildPictureBox(new Point(startX, startY + 20));
            //olderBarCodeBox.Image = olderBarcode;
        }
        private void DrawImageBox(string text,int startX,int startY, int delta,Bitmap Image)
        {
            BuildLabel(text, new Point(startX, startY));
            var youngBox = BuildPictureBox(new Point(startX, startY + delta));
            youngBox.Image = Image;
        }
        public void DrawResultOfEncoding(ResultOfEncoding resultOfEncoding)
        {
            var startX = 100;
            var startY = 100;
            var originalImage = resultOfEncoding.OriginalPerson.Image;
            var EAN8 = resultOfEncoding.Barcode;
            BuildLabel("Исходное изображение: ", new Point(startX, startY));
            var boxForOriginalImage = BuildPictureBox(new Point(startX, startY + 20));
            startX += 300;
            BuildLabel("Штрих-код в формате EAN8",new Point(startX, startY));
            var boxForEAN8Code = BuildPictureBox(new Point(startX, startY + 20));
            boxForOriginalImage.Image = originalImage.ToBitmap();
            boxForEAN8Code.Image = EAN8;
        }
        private void BuildLabel(string text, Point location, int fontSize = 10)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", fontSize);
            label.Location = location;
            label.AutoSize = true;
            this.Controls.Add(label);
        }
        private PictureBox BuildPictureBox(Point location)
        {
            PictureBox pictureBox=  new PictureBox();
            pictureBox.Location=location;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pictureBox);
            return pictureBox;
        }
    }
}
