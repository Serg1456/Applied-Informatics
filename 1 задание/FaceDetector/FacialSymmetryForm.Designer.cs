namespace FaceDetector
{
    partial class FacialSymmetryForm
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
            LoadSymmetrialButton = new Button();
            SearchSymmetrialButton = new Button();
            SuspendLayout();
            // 
            // LoadSymmetrialButton
            // 
            LoadSymmetrialButton.Location = new Point(101, 174);
            LoadSymmetrialButton.Margin = new Padding(5, 6, 5, 6);
            LoadSymmetrialButton.Name = "LoadSymmetrialButton";
            LoadSymmetrialButton.Size = new Size(360, 46);
            LoadSymmetrialButton.TabIndex = 0;
            LoadSymmetrialButton.Text = "Загрузить лицо";
            LoadSymmetrialButton.UseVisualStyleBackColor = true;
            LoadSymmetrialButton.Click += LoadSymmetrialButton_Click;
            // 
            // SearchSymmetrialButton
            // 
            SearchSymmetrialButton.Location = new Point(101, 748);
            SearchSymmetrialButton.Margin = new Padding(5, 6, 5, 6);
            SearchSymmetrialButton.Name = "SearchSymmetrialButton";
            SearchSymmetrialButton.Size = new Size(360, 46);
            SearchSymmetrialButton.TabIndex = 1;
            SearchSymmetrialButton.Text = "Найти линии симметрии лица";
            SearchSymmetrialButton.UseVisualStyleBackColor = true;
            SearchSymmetrialButton.Click += SearchSymmetrialButton_Click;
            // 
            // FacialSymmetryForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(SearchSymmetrialButton);
            Controls.Add(LoadSymmetrialButton);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FacialSymmetryForm";
            Text = "Определить линии симетрии лица";
            FormClosing += FacialSymmetryForm_FormClosing;
            Load += FacialSymmetryForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button LoadSymmetrialButton;
        private Button SearchSymmetrialButton;
    }
}