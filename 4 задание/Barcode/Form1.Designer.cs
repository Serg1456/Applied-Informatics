namespace Barcode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BuildEAN8ForFaceButton = new Button();
            BuildEAN8BarcodeFromDifferentAges = new Button();
            SuspendLayout();
            // 
            // BuildEAN8ForFaceButton
            // 
            BuildEAN8ForFaceButton.Location = new Point(228, 145);
            BuildEAN8ForFaceButton.Margin = new Padding(5, 6, 5, 6);
            BuildEAN8ForFaceButton.Name = "BuildEAN8ForFaceButton";
            BuildEAN8ForFaceButton.Size = new Size(914, 46);
            BuildEAN8ForFaceButton.TabIndex = 0;
            BuildEAN8ForFaceButton.Text = "Построить EAN8 штрих-код по изображению лица";
            BuildEAN8ForFaceButton.UseVisualStyleBackColor = true;
            BuildEAN8ForFaceButton.Click += BuildEAN8ForFaceButton_Click;
            // 
            // BuildEAN8BarcodeFromDifferentAges
            // 
            BuildEAN8BarcodeFromDifferentAges.Location = new Point(228, 232);
            BuildEAN8BarcodeFromDifferentAges.Name = "BuildEAN8BarcodeFromDifferentAges";
            BuildEAN8BarcodeFromDifferentAges.Size = new Size(914, 40);
            BuildEAN8BarcodeFromDifferentAges.TabIndex = 1;
            BuildEAN8BarcodeFromDifferentAges.Text = "Построить EAN8 штрих-коды, SSIM, корреляцию по изображению лица в разных возрастах";
            BuildEAN8BarcodeFromDifferentAges.UseVisualStyleBackColor = true;
            BuildEAN8BarcodeFromDifferentAges.Click += BuildEAN8BarcodeFromDifferentAges_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(BuildEAN8BarcodeFromDifferentAges);
            Controls.Add(BuildEAN8ForFaceButton);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Меню";
            ResumeLayout(false);
        }

        #endregion

        private Button BuildEAN8ForFaceButton;
        private Button BuildEAN8BarcodeFromDifferentAges;
    }
}
