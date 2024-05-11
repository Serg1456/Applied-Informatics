using Emgu.CV;
using Emgu.CV.CvEnum;
using PCAProject._2DPCA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace PCAProject
{
    public partial class VisualRecognitionForm : Form
    {
        PictureBox testImage;
        PictureBox etalonImage;
        Chart resultChart;
        private List<PCAProject._2DPCA.Person> test;
        private List<PCAProject._2DPCA.Person> etalon;
        private int testCounter;
        private int etalonCounter;
        private double[] results;
        public VisualRecognitionForm()
        {
            InitializeComponent();
            Size = new Size(1500, 1200);
        }

        private void VisualRecognitionForm_Load(object sender, EventArgs e)
        {

        }
        public void Draw2DResultOfRecognition(RecognitionResult result,string text)
        {
            Text = text;
            BuildLabel("Тестовое изображение: ", new Point(100, 150));
            testImage = DrawPictureBox(new Point(100, 200));
            BuildLabel("Эталонное изображение: ", new Point(100, 450));
            etalonImage = DrawPictureBox(new Point(100, 500));
            BuildChart(new Point(400, 200));
            etalon = result.Etalons;
            test = result.Tests;
            results = result.Result;
            timer.Interval = 10;
            testCounter = 0;
            etalonCounter = 0;
            testImage.Image = test[0].Data.ToBitmap();
            timer.Start();
            //var test = result.Tests;
            //var etalons = result.Etalons;
            //var results = result.Result;
            //for (int i = 0; i < results.Length; i++)
            //{
            //    testImage.Image = test[i].Data.ToBitmap();
            //    for (int j = 0; j < etalons.Count; j++)
            //    {
            //        etalonImage.Image = etalons[j].Data.ToBitmap();
            //    }
            //    resultChart.Series[0].Points.AddXY(i + 1, results[i]);
            //}
        }
        private void BuildChart(Point location)
        {
            //Здесь остановились:
            resultChart = new Chart();
            ChartArea area = new ChartArea();
            area.AxisX.Name = "Количество изображений";
            area.AxisY.Name = "Процент распознования";
            Legend legend = new Legend();
            Series series = new Series();
            series.Name = "Результат распознования";
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 8;
            resultChart.Name = "RecognitionResult";
            resultChart.Location = location;
            resultChart.Size = new Size(1000, 800);
            resultChart.TabIndex = 0;
            resultChart.Series.Add(series);
            resultChart.Legends.Add(legend);
            resultChart.ChartAreas.Add(area);
            this.Controls.Add(resultChart);
        }
        private PictureBox DrawPictureBox(Point location)
        {
            PictureBox newImage = new PictureBox();
            newImage.Location = location;
            newImage.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(newImage);
            return newImage;
        }
        private void BuildLabel(string text, Point location)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.Location = location;
            this.Controls.Add(label);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (etalonCounter == etalon.Count)
            {
                    resultChart.Series[0].Points.AddXY(testCounter + 1, results[testCounter]);
                    testCounter++;
                    if (testCounter == test.Count)
                    {
                        timer.Stop();
                        return;
                    }
                    etalonCounter = 0;
                    testImage.Image = test[testCounter].Data.ToBitmap();
                    etalonImage.Image = etalon[etalonCounter++].Data.ToBitmap();
            }
            else
            {
                etalonImage.Image = etalon[etalonCounter++].Data.ToBitmap();
            }
        }
    }
}
