namespace FaceDetector
{
    partial class DetectorTemplateMatchingForm
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
            LoadPhoto.Location = new Point(59, 87);
            LoadPhoto.Name = "LoadPhoto";
            LoadPhoto.Size = new Size(210, 23);
            LoadPhoto.TabIndex = 0;
            LoadPhoto.Text = "Загрузить изображение";
            LoadPhoto.UseVisualStyleBackColor = true;
            LoadPhoto.Click += LoadPhoto_Click;
            // 
            // Detect
            // 
            Detect.FlatStyle = FlatStyle.System;
            Detect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Detect.Location = new Point(59, 360);
            Detect.Name = "Detect";
            Detect.Size = new Size(145, 44);
            Detect.TabIndex = 1;
            Detect.Text = "Детектировать";
            Detect.UseVisualStyleBackColor = true;
            Detect.Click += Detect_Click;
            // 
            // DetectorTemplateMatchingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Detect);
            Controls.Add(LoadPhoto);
            Name = "DetectorTemplateMatchingForm";
            Text = "Обнаружить лицо c помощью Template Matching";
            FormClosing += DetectorForm_FormClosing;
            Load += DetectorForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button LoadPhoto;
        private Button Detect;
    }
}