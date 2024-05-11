namespace Recognizer
{
    partial class RecognizeFaceForm
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
            LoadPhotobutton = new Button();
            SuspendLayout();
            // 
            // LoadPhotobutton
            // 
            LoadPhotobutton.Location = new Point(34, 34);
            LoadPhotobutton.Name = "LoadPhotobutton";
            LoadPhotobutton.Size = new Size(161, 23);
            LoadPhotobutton.TabIndex = 0;
            LoadPhotobutton.Text = "Загрузить фото";
            LoadPhotobutton.UseVisualStyleBackColor = true;
            LoadPhotobutton.Click += LoadPhotobutton_Click;
            // 
            // RecognizeFaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228, 85);
            Controls.Add(LoadPhotobutton);
            Name = "RecognizeFaceForm";
            Text = "Распознать лицо";
            FormClosing += RecognizeFaceForm_FormClosing;
            Load += RecognizeFaceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button LoadPhotobutton;
    }
}