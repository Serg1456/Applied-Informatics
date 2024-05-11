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
        public ChartsForm()
        {
            InitializeComponent();
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {
            Width = 1500;
            Height = 1000;
        }
        public void DrawGraphics(List<ResultOfTest> results)
        {
            List<Chart> charts = BuildEmptyGraphics(new string[] { "DFT", "DCT", "SeScale", "Histogram", "Gradient" });
            for (int i = 0; i < results.Count; i++)
            {
                charts[0].Series[0].Points.AddXY(results[i].CountOfEtalons, results[i].ResultOfDFT * 100);
                charts[1].Series[0].Points.AddXY(results[i].CountOfEtalons, results[i].ResultOfDCT * 100);
                charts[2].Series[0].Points.AddXY(results[i].CountOfEtalons, results[i].ResultOfSeScale * 100);
                charts[3].Series[0].Points.AddXY(results[i].CountOfEtalons, results[i].ResultOfHistogram * 100);
                charts[4].Series[0].Points.AddXY(results[i].CountOfEtalons, results[i].ResultOfGradient * 100);
            }
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
                legend.Name = names[i];
                chart.Location = new Point(x, y);
                area.Name = nameOfChartArea + i;
                area.AxisX.Title = "Количество эталонов"; //Количество эталонов
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
                x += 400;
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

        private void ChartsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
