namespace Barcode
{
    partial class EncodingDifferentAgesInputForm
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
            buttonLoadYoungImage = new Button();
            buttonLoadOlderImage = new Button();
            buttonBuild = new Button();
            SuspendLayout();
            // 
            // buttonLoadYoungImage
            // 
            buttonLoadYoungImage.Location = new Point(166, 71);
            buttonLoadYoungImage.Name = "buttonLoadYoungImage";
            buttonLoadYoungImage.Size = new Size(445, 40);
            buttonLoadYoungImage.TabIndex = 0;
            buttonLoadYoungImage.Text = "Загрузить лицо в раннем возрасте";
            buttonLoadYoungImage.UseVisualStyleBackColor = true;
            buttonLoadYoungImage.Click += buttonLoadYoungImage_Click;
            // 
            // buttonLoadOlderImage
            // 
            buttonLoadOlderImage.Location = new Point(166, 157);
            buttonLoadOlderImage.Name = "buttonLoadOlderImage";
            buttonLoadOlderImage.Size = new Size(445, 40);
            buttonLoadOlderImage.TabIndex = 1;
            buttonLoadOlderImage.Text = "Загрузить лицо в позднем возрасте";
            buttonLoadOlderImage.UseVisualStyleBackColor = true;
            buttonLoadOlderImage.Click += buttonLoadOlderImage_Click;
            // 
            // buttonBuild
            // 
            buttonBuild.Location = new Point(323, 243);
            buttonBuild.Name = "buttonBuild";
            buttonBuild.Size = new Size(131, 40);
            buttonBuild.TabIndex = 2;
            buttonBuild.Text = "Построить";
            buttonBuild.UseVisualStyleBackColor = true;
            buttonBuild.Click += buttonBuild_Click;
            // 
            // EncodingDifferentAgesInputForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 354);
            Controls.Add(buttonBuild);
            Controls.Add(buttonLoadOlderImage);
            Controls.Add(buttonLoadYoungImage);
            Name = "EncodingDifferentAgesInputForm";
            Text = "EncodingDifferentAgesInputForm";
            Load += EncodingDifferentAgesInputForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadYoungImage;
        private Button buttonLoadOlderImage;
        private Button buttonBuild;
    }
}