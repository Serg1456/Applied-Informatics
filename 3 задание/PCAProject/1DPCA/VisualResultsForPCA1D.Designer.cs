namespace PCAProject
{
    partial class VisualResultsForPCA1D
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            EigenValuesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)EigenValuesChart).BeginInit();
            SuspendLayout();
            // 
            // EigenValuesChart
            // 
            chartArea1.Name = "ChartArea1";
            EigenValuesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            EigenValuesChart.Legends.Add(legend1);
            EigenValuesChart.Location = new Point(32, 79);
            EigenValuesChart.Name = "EigenValuesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            EigenValuesChart.Series.Add(series1);
            EigenValuesChart.Size = new Size(403, 405);
            EigenValuesChart.TabIndex = 0;
            EigenValuesChart.Text = "chart1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 39);
            label1.Name = "label1";
            label1.Size = new Size(266, 37);
            label1.TabIndex = 1;
            label1.Text = "Собственные числа:";
            // 
            // VisualResultsForPCA1D
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 580);
            Controls.Add(label1);
            Controls.Add(EigenValuesChart);
            Name = "VisualResultsForPCA1D";
            Text = "1DPCA-результат";
            Load += ResultForGraphics_Load;
            ((System.ComponentModel.ISupportInitialize)EigenValuesChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart EigenValuesChart;
        private Label label1;
    }
}