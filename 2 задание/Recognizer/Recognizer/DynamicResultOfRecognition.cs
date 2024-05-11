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
using Emgu.CV;
using Emgu.CV.Structure;
namespace Recognizer
{
    public partial class DynamicResultOfRecognition : Form
    {
        Dictionary<string, PictureBox> boxes;
        Dictionary<string, Chart> charts;

        private ResultOfTest _result;
        private int _currentTestStep;
        private int _currentEtalonStep;
        private int _countOfImages;
        private int _countOfEtalons;
        private int _countOfTests;
        private int _indexOfImage;
        private DrawPointForTheGraphic _currentCharts;
        public DynamicResultOfRecognition(ResultOfTest Result,int countOfTests, int countOfEtalons, int countOfImages, int interval, DrawPointForTheGraphic currentCharts = null)
        {
            InitializeComponent();
            _currentCharts = currentCharts;
            _currentTestStep = 0;
            _currentEtalonStep = 0;
            _countOfImages = countOfImages;
            _countOfEtalons = countOfEtalons;
            _countOfTests = countOfTests;
            timer1.Interval = interval;
            Width = 1500;
            Height = 700;
            _indexOfImage = 0;
            _result = Result;
            BuildForms();
        }
        private void BuildForms()
        {
            boxes = new Dictionary<string, PictureBox>();
            string[] namesOfTest = { "T_Image", "T_DFT", "T_DCT", "T_SeScale" };
            string[] namesOfEtalons = { "E_Image", "E_DFT", "E_DCT", "E_SeScale" };

            //PictureBoxes для тестового изображения
            int yLocation = 100;
            int xLocation = 100;
            foreach (string name in namesOfTest)
            {
                boxes.Add(name, CreateNewPictureBox(new Point(xLocation, yLocation), name));
                xLocation += 150;
            }
            yLocation += 320;
            xLocation = 100;
            foreach (string name in namesOfEtalons)
            {
                boxes.Add(name, CreateNewPictureBox(new Point(xLocation, yLocation), name));
                xLocation += 150;
            }
            charts = new Dictionary<string, Chart>();

            //Здесь остановились (на графиках)
            namesOfTest = new string[] { "T_Histogram", "T_Gradient" };
            namesOfEtalons = new string[] { "E_Histogram", "E_Gradient" };

            yLocation = 100;
            foreach (string name in namesOfTest)
            {
                charts.Add(name, BuildChart(new Point(xLocation, yLocation), name));
                xLocation += 320;
            }
            yLocation += 320;
            xLocation = 700;
            foreach (string name in namesOfEtalons)
            {
                charts.Add(name, BuildChart(new Point(xLocation, yLocation), name));
                xLocation += 320;
            }
        }

        private void NextImageClick(object? sender, EventArgs e)
        {
            var vector = _result.Results;
            var numberOfEtalons = vector[_currentTestStep].DCT.Count;
            if (_currentEtalonStep + 1 == numberOfEtalons)
            {
                _currentTestStep++;
                _currentEtalonStep = 0;
            }
            else
            {
                _currentEtalonStep++;
            }
            FillTheResultsOfTheTests();
        }

        private Chart BuildChart(Point location, string name)
        {
            Chart chart = new Chart();
            ChartArea area = new ChartArea();
            chart.Height = 200;
            chart.Location = location;
            area.Name = name;
            Series series = new Series();
            series.ChartArea = name;
            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            Label info = new Label();
            info.Location = new Point(location.X, location.Y - 25);
            info.Text = name;
            this.Controls.Add(info);
            this.Controls.Add(chart);
            return chart;

        }
        private PictureBox CreateNewPictureBox(Point location, string name)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = name;
            pictureBox.Location = location;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Label info = new Label();
            info.Location = new Point(location.X, location.Y - 25);
            info.Text = name;
            this.Controls.Add(info);
            this.Controls.Add(pictureBox);
            return pictureBox;
        }
        public void FillTheResultsOfTheTests()
        {
            timer1.Start();

        }
        private void BuildHistogram(Chart chart, double[] histogram)
        {
            chart.Series[0].Points.Clear();
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].BorderWidth = 5;
            chart.Series[0].MarkerBorderWidth = 5;
            for (int i = 0; i < histogram.Length; i++)
                chart.Series[0].Points.AddXY(i + 1, histogram[i]);
        }
        private void BuildGradient(Chart chart, double[] gradient)
        {
            chart.Series[0].Points.Clear();
            chart.Series[0].ChartType = SeriesChartType.Spline;
            for (int i = 0; i < gradient.Length; i++)
                chart.Series[0].Points.AddXY(i + 1, gradient[i]);
        }
        private void DynamicResultOfRecognition_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            var vector = _result.Results;
            if (_indexOfImage < _countOfTests * _countOfEtalons * _countOfImages * _countOfImages)
            {
                //Тестовое изображение
                boxes["T_Image"].Image = vector[_currentTestStep].TestImage;
                boxes["T_DFT"].Image = vector[_currentTestStep].TestDFT;
                boxes["T_DCT"].Image = vector[_currentTestStep].TestDCT;
                boxes["T_SeScale"].Image = vector[_currentTestStep].TestSeScale;
                BuildHistogram(charts["T_Histogram"], vector[_currentTestStep].TestHistogram);
                BuildGradient(charts["T_Gradient"], vector[_currentTestStep].TestsGradients);

                //Эталоны
                boxes["E_Image"].Image = vector[_currentTestStep].Images[_currentEtalonStep];
                boxes["E_DFT"].Image = vector[_currentTestStep].DFT[_currentEtalonStep];
                boxes["E_DCT"].Image = vector[_currentTestStep].DCT[_currentEtalonStep];
                boxes["E_SeScale"].Image = vector[_currentTestStep].SeScale[_currentEtalonStep];
                BuildHistogram(charts["E_Histogram"], vector[_currentTestStep].Histogram[_currentEtalonStep]);
                BuildGradient(charts["E_Gradient"], vector[_currentTestStep].Gradient[_currentEtalonStep]);

                var numberOfEtalons = vector[_currentTestStep].DCT.Count;
                if (_currentEtalonStep + 1 == numberOfEtalons)
                {
                    if (_currentCharts != null) _currentCharts(_currentTestStep);
                    _currentTestStep++;
                    _currentEtalonStep = 0;
                }
                else
                {
                    _currentEtalonStep++;
                }
                _indexOfImage++;
            }
        }
    }
}
