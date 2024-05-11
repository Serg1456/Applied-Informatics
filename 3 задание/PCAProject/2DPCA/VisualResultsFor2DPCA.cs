using Emgu.CV;
using PCAProject._2DPCA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public partial class VisualResultsFor2DPCA : Form
    {
        List<PictureBox> _boxForReconstructionFaces;
        List<PictureBox> _boxesFor3dGraphicFaces;
        PictureBox _originalFace;
        Graph3D _graph3d1;
        public VisualResultsFor2DPCA()
        {
            InitializeComponent();
        }

        private void VisualResultsFor2DPCA_Load(object sender, EventArgs e)
        {
            Size = new Size(1800, 1000);
        }
        public void DrawResults(string name,VisualResult result)
        {
            Text = name;
            var lastCoordinate = DrawReconstructFaces(result.ReconstructionResults);
            lastCoordinate.X += 250;
            BuildLabel($"Проекция в трёхмерное подпространство {result.Projections.Length} случайных классов: ",lastCoordinate);
            lastCoordinate.Y += 50;
            Initialize3DGraphic(lastCoordinate);
            Draw3DGraphiceFaces(result.Projections);
            lastCoordinate.X += _graph3d1.Width + 100;
            DrawFacesFor3dGraphic(result, lastCoordinate.X, lastCoordinate.Y);
        }
        private void Initialize3DGraphic(Point position)
        {
            _graph3d1 = new Plot3D.Graph3D();
            _graph3d1.AxisX_Color = Color.DarkBlue;
            _graph3d1.AxisX_Legend = "X";
            _graph3d1.AxisY_Color = Color.DarkGreen;
            _graph3d1.AxisY_Legend = "Y";
            _graph3d1.AxisZ_Color = Color.DarkRed;
            _graph3d1.AxisZ_Legend = "Z";
            _graph3d1.BackColor = Color.White;
            _graph3d1.BorderColor = Color.FromArgb(180, 180, 180);
            _graph3d1.Location = position;
            _graph3d1.Name = "graph3d1";
            _graph3d1.PolygonLineColor = Color.Black;
            _graph3d1.Raster = eRaster.Labels;
            _graph3d1.Size = new Size(600, 600);
            _graph3d1.TabIndex = 2;
            _graph3d1.TopLegendColor = Color.FromArgb(200, 200, 150);
            _graph3d1.SetColorScheme(new Color[] { }, 10);
            Controls.Add(_graph3d1);
        }
        private void Draw3DGraphiceFaces(Projection3DClassVisualResult[] projections) //Здесь остановились
        {
            List<cScatter> points = new List<cScatter>();
            //Тестируем
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
            _graph3d1.SetScatterPoints(points.ToArray(), eNormalize.Separate);
        }
        private Point DrawReconstructFaces(ReconstructionResult result)
        {
            int startX = 50;
            int startY = 100;
            var originalImage = result.Person.Data;
            BuildLabel("Результаты реконструкции:", new Point(startX, startY));
            int dx = originalImage.Rows + 30;
            int dy = originalImage.Cols + 50;
            var images = result.ReconstructionFaces;
            var tY = startY;
            var tX = startX;  
            startY += 50;
            int indexOfImage = 0;
            _boxForReconstructionFaces = new List<PictureBox>(); 
            for (int i = 0; i < images.Length; i++)
            {
                if (indexOfImage < 5)
                {
                    BuildLabel($"{images[i].ParamOfReduction}",new Point(startX,startY),10);
                    var newPictureBox = DrawPictureBox(new Point(startX, startY + 20)); 
                    newPictureBox.Image = images[i].Image;
                    _boxForReconstructionFaces.Add(newPictureBox);
                    startX += dx;
                    indexOfImage++;
                }
                else
                {
                    startY += dy;
                    startX = tX;
                    BuildLabel($"{images[i].ParamOfReduction}", new Point(startX, startY), 10);
                    var newPictureBox = DrawPictureBox(new Point(startX, startY + 20));
                    newPictureBox.Image = images[i].Image;
                    _boxForReconstructionFaces.Add(newPictureBox);
                    startX += dx;
                    indexOfImage = 0;
                }
            }
            startX += dx;
            startY = tY;
            BuildLabel("Оригинальное изображение: ",new Point(startX, startY + 50),12);
            _originalFace = DrawPictureBox(new Point(startX, startY + 70));
            _originalFace.Image = originalImage.ToBitmap();
            return new Point(startX, startY);
        }
        private void DrawFacesFor3dGraphic(VisualResult result,int startX, int startY)
        {
            _boxesFor3dGraphicFaces = new List<PictureBox>();
            var dy = startY;
            for (int i = 0; i < result.Projections.Length; i++)
            {
                var color = result.Projections[i].Color;
                var newImage = result.Projections[i].Persons[0].Data;
                var forImage = DrawPictureBox(new Point(startX, dy));
                var forColor = DrawPictureBox(new Point(startX + newImage.Rows + 20, dy));
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
        private void BuildLabel(string text, Point location, int fontSize = 20)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", fontSize);
            label.Location = location;
            label.AutoSize = true;
            this.Controls.Add(label);
        }
        private PictureBox DrawPictureBox(Point location)
        {
            PictureBox box = new PictureBox();
            box.Location = location;
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(box);
            return box;
        }
        
    }
}
