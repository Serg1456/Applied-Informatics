using Emgu.CV.Flann;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Recognizer
{
    public partial class ChartsForm : Form
    {
        private List<Chart> _charts;
        private Chart _parallelChart;
        private ResultOfTest _results;

        public ChartsForm()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {
            Width = 1500;
            Height = 1000;
        }
        public void DrawParallelGraphic(ResultOfTest results)
        {
            _results = results;
            string nameOfChartArea = "area";
            int x = 50;
            int y = 100;
            Chart chart = new Chart();
            Legend legend = new Legend();
            ChartArea area = new ChartArea();
            chart.Height = 700;
            chart.Width = 1200;
            legend.Name = "Parallel";
            chart.Location = new Point(x, y);
            area.Name = nameOfChartArea;
            area.AxisX.Title = "Количество тестовых изображений"; //Количество эталонов
            area.AxisY.Title = "Количество распознаных изображений (%)";
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.ChartArea = nameOfChartArea;
            series.BorderWidth = 5;
            series.Name = "Parallel";
            chart.ChartAreas.Add(area);
            chart.Legends.Add(legend);
            chart.Series.Add(series);
            this.Controls.Add(chart);
            _parallelChart = chart;
        }
        public void DrawParallelGraphicPoint(int index)
        {
            _parallelChart.Series[0].Points.AddXY(index + 1, _results.ResultOfCascade[index]);
        }
        public void DrawGraphics(ResultOfTest results, string name = "Результат распознавания")
        {
            Text = name;
            _charts = BuildEmptyGraphics(new string[] { "DFT", "DCT", "SeScale", "Histogram", "Gradient" });
            _results = results;
        }
        private List<Chart> BuildEmptyGraphics(string[] names)
        {
            string nameOfChartArea = "area";
            int x = 50;
            int y = 100;
            List<Chart> charts = new List<Chart>();
            for (int i = 0; i < names.Length; i++)
            {
                Chart chart = new Chart();
                Legend legend = new Legend();
                ChartArea area = new ChartArea();
                chart.Height = 350;
                chart.Width = 500;
                legend.Name = names[i];
                chart.Location = new Point(x, y);
                area.Name = nameOfChartArea + i;
                area.AxisX.Title = "Количество тестовых изображений"; //Количество эталонов
                area.AxisY.Title = "Количество распознаных изображений (%)";
                Series series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.ChartArea = nameOfChartArea + i;
                series.BorderWidth = 5;
                series.Name = names[i];
                chart.ChartAreas.Add(area);
                chart.Legends.Add(legend);
                chart.Series.Add(series);
                charts.Add(chart);
                this.Controls.Add(chart);
                x += 500;
                if ((i + 1) % 3 == 0)
                {
                    x = 50;
                    y += 400;
                }
            }
            return charts;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        public void DrawPointsOnTheGraphic(int index)
        {
            _charts[0].Series[0].Points.AddXY(index + 1, _results.ResultOfDFT[index] * 100);
            _charts[1].Series[0].Points.AddXY(index + 1, _results.ResultOfDCT[index] * 100);
            _charts[2].Series[0].Points.AddXY(index + 1, _results.ResultOfSeScale[index] * 100);
            _charts[3].Series[0].Points.AddXY(index + 1, _results.ResultOfHistogram[index] * 100);
            _charts[4].Series[0].Points.AddXY(index + 1, _results.ResultOfGradient[index] * 100);
        }

        private void ChartsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                
        }
    }
}
