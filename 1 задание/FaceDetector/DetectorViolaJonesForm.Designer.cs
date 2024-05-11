namespace FaceDetector
{
    partial class DetectorViolaJonesForm
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
            LoadPhoto = new Button();
            Detect = new Button();
            SuspendLayout();
            // 
            // LoadPhoto
            // 
            LoadPhoto.Location = new Point(101, 174);
            LoadPhoto.Margin = new Padding(5, 6, 5, 6);
            LoadPhoto.Name = "LoadPhoto";
            LoadPhoto.Size = new Size(360, 46);
            LoadPhoto.TabIndex = 1;
            LoadPhoto.Text = "Загрузить изображение";
            LoadPhoto.UseVisualStyleBackColor = true;
            LoadPhoto.Click += LoadPhoto_Click;
            // 
            // Detect
            // 
            Detect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Detect.Location = new Point(101, 720);
            Detect.Margin = new Padding(5, 6, 5, 6);
            Detect.Name = "Detect";
            Detect.Size = new Size(249, 88);
            Detect.TabIndex = 2;
            Detect.Text = "Детектировать";
            Detect.UseVisualStyleBackColor = true;
            Detect.Click += Detect_Click;
            // 
            // DetectorViolaJonesForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(Detect);
            Controls.Add(LoadPhoto);
            Margin = new Padding(5, 6, 5, 6);
            Name = "DetectorViolaJonesForm";
            Text = "Детектировать с помощью Виолы-Джонса";
            FormClosing += DetectorViolaJonesForm_FormClosing;
            Load += DetectorViolaJonesForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button LoadPhoto;
        private Button Detect;
    }
}