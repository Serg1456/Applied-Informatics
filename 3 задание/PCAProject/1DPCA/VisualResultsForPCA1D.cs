using Emgu.CV;
using PCAProject._1DPCA;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

using delRendererFunction = Plot3D.Graph3D.delRendererFunction;
using cPoint3D = Plot3D.Graph3D.cPoint3D;
using eRaster = Plot3D.Graph3D.eRaster;
using cScatter = Plot3D.Graph3D.cScatter;
using eNormalize = Plot3D.Graph3D.eNormalize;
using eSchema = Plot3D.ColorSchema.eSchema;
using Accord.Statistics.Distributions.Univariate;
using Plot3D;
using System.Collections;
using System.Drawing.Drawing2D;
using Accord.Statistics.Kernels;

namespace PCAProject
{
    public partial class VisualResultsForPCA1D : Form
    {
        List<PictureBox> _boxesForEigenFaces; 
        List<PictureBox> _boxesFor3dGraphicFaces;
        VisualResult _result;
        Plot3D.Graph3D graph3d1;
        private int _lastDxPosition;
        private int _lastXPosition;
        private int _fontSize;
        public VisualResultsForPCA1D(VisualResult result)
        {
            _result = result;
            if (result.PrintedEigenFaces[0].Rows > 20)
            {
                _fontSize = 20;
                _lastDxPosition = 65;
            }
            else
            {
                _fontSize = 15;
                _lastDxPosition = 150;
            }
            _boxesForEigenFaces = new List<PictureBox>();
            InitializeComponent();
            Size = new Size(1900, 1000);
            DrawEigenValuesResult();
            DrawEigenFaces(4);
            Draw3DResult();
        }
        private void Draw3DResult()
        {
            _lastXPosition += _lastDxPosition;
            BuildLabel(new Point(_lastXPosition, 39),$"Проекция в трёхмерное подпространство {_result.Three3DProjections.Length} случайных классов: ");
            Initialize3DGraphic(_lastXPosition);
            Draw3DGraphiceFaces();
            _lastXPosition += graph3d1.Width + 40;
            DrawFacesFor3dGraphic(_lastXPosition,79);
        }
        private void DrawFacesFor3dGraphic(int startX, int startY)
        {
            _boxesFor3dGraphicFaces = new List<PictureBox>();
            var dy = startY;
            for (int i = 0; i < _result.Three3DProjections.Length; i++)
            {
                var color = _result.Three3DProjections[i].Color;
                var newImage = _result.Three3DProjections[i].Persons[0].Data;
                var forImage = CreateNewPictureBox(new Point(startX, dy));
                var forColor = CreateNewPictureBox(new Point(startX + newImage.Rows + 20, dy));
                _boxesFor3dGraphicFaces.Add(forImage);
                _boxesFor3dGraphicFaces.Add(forColor);
                //Устанавливаем фото:
                forImage.Image = newImage.ToBitmap();
                //Устанавливаем bitmap цвета изображения:
                forColor.Image = new Bitmap(20, 20);
                Graphics g = Graphics.FromImage(forColor.Image);
                Brush brush = new SolidBrush(color);
                g.FillRectangle(brush, 1, 1, 20, 20);
                forColor.Refresh();
                dy += newImage.Cols + 20;
            }
            
        }
        private void Draw3DGraphiceFaces() //Здесь остановились
        {
            List<cScatter> points = new List<cScatter>();
            //Тестируем
            var projections = _result.Three3DProjections;
            for (int i = 0; i < projections.Length; i++) 
            {
                var curProj = projections[i];
                var middlePoint = new cScatter(curProj.MeanClassValue[0], curProj.MeanClassValue[1], curProj.MeanClassValue[2], new HatchBrush(HatchStyle.Cross, curProj.Color));
                points.Add(middlePoint);
                for (int j = 0; j < curProj.Projections.Length; j++)
                {
                    var points3d = curProj.Projections[j];
                    points.Add(new cScatter(points3d[0], points3d[1], points3d[2], new SolidBrush(curProj.Color)));
                }
            }
            graph3d1.SetScatterPoints(points.ToArray(), eNormalize.Separate);          
        }
        private void Initialize3DGraphic(int position)
        {
            graph3d1 = new Plot3D.Graph3D();
            graph3d1.AxisX_Color = Color.DarkBlue;
            graph3d1.AxisX_Legend = "X";
            graph3d1.AxisY_Color = Color.DarkGreen;
            graph3d1.AxisY_Legend = "Y";
            graph3d1.AxisZ_Color = Color.DarkRed;
            graph3d1.AxisZ_Legend = "Z";
            graph3d1.BackColor = Color.White;
            graph3d1.BorderColor = Color.FromArgb(180, 180, 180);
            graph3d1.Location = new Point(position, 79);
            graph3d1.Name = "graph3d1";
            graph3d1.PolygonLineColor = Color.Black;
            graph3d1.Raster = eRaster.Labels;
            graph3d1.Size = new Size(600, 600);
            graph3d1.TabIndex = 2;
            graph3d1.TopLegendColor = Color.FromArgb(200, 200, 150);
            graph3d1.SetColorScheme(new Color[] {}, 10);
            Controls.Add(graph3d1);
        }
        private void ResultForGraphics_Load(object sender, EventArgs e)
        {
            EigenValuesChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
        private void DrawEigenValuesResult()
        {
            EigenValuesChart.Series[0].LegendText = "Собственные числа";
            var eigenValues = _result.Eigenvalues;
            for (int i = 0; i < eigenValues.Length; i++)
                EigenValuesChart.Series[0].Points.AddXY(i + 1, eigenValues[i]);
        }
        private void DrawEigenFaces(int yperiod)
        {
            _boxesForEigenFaces = new List<PictureBox>();
            //Описываем стартовую локацию:
            var startX = 500;
            var startY = 39;
            Point startPositionOfLabel = new Point(startX, startY);
            BuildLabel(startPositionOfLabel, "Собственные лица:");
            var dx =  startX;
            var dy = 79; 
            for (int i = 1; i <= _result.PrintedEigenFaces.Count; i++)
            {
                _boxesForEigenFaces.Add(CreateNewPictureBox(new Point(dx, dy)));
                dx += _result.PrintedEigenFaces[0].Rows + _result.PrintedEigenFaces[0].Rows/10;
                if (i % yperiod == 0)
                {
                    dy += _result.PrintedEigenFaces[0].Cols + 20;
                    _lastXPosition = dx - _result.PrintedEigenFaces[0].Rows / 10;
                    dx = startX;
                }
                _boxesForEigenFaces[i-1].Image = _result.PrintedEigenFaces[i-1].ToBitmap();
            }

        }
        private void BuildLabel(Point location,string text)
        {
            Label label = new Label();
            label.Location = location;
            label.Text = text;
            label.Font = new Font("Segoe UI",_fontSize);
            label.AutoSize = true;
            this.Controls.Add(label);
        }
        private PictureBox CreateNewPictureBox(Point location)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = location;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Label info = new Label();
            info.Location = new Point(location.X, location.Y - 25);
            this.Controls.Add(info);
            this.Controls.Add(pictureBox);
            return pictureBox;
        }
    }
}
