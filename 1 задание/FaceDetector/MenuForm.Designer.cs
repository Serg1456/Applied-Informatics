namespace FaceDetector
{
    partial class MenuForm
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
            AddNewUserButton = new Button();
            DetectUserTemplateMatchingButton = new Button();
            DetectUserViolaJons = new Button();
            FacialSymmetry = new Button();
            SuspendLayout();
            // 
            // AddNewUserButton
            // 
            AddNewUserButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            AddNewUserButton.Location = new Point(72, 190);
            AddNewUserButton.Margin = new Padding(5, 6, 5, 6);
            AddNewUserButton.Name = "AddNewUserButton";
            AddNewUserButton.Size = new Size(667, 266);
            AddNewUserButton.TabIndex = 0;
            AddNewUserButton.Text = "Загрузить нового пользователя";
            AddNewUserButton.UseVisualStyleBackColor = true;
            AddNewUserButton.Click += AddNewUserButton_Click;
            // 
            // DetectUserTemplateMatchingButton
            // 
            DetectUserTemplateMatchingButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DetectUserTemplateMatchingButton.Location = new Point(1073, 190);
            DetectUserTemplateMatchingButton.Margin = new Padding(5, 6, 5, 6);
            DetectUserTemplateMatchingButton.Name = "DetectUserTemplateMatchingButton";
            DetectUserTemplateMatchingButton.Size = new Size(667, 266);
            DetectUserTemplateMatchingButton.TabIndex = 1;
            DetectUserTemplateMatchingButton.Text = "Детектировать лицо с помощью Template Matching";
            DetectUserTemplateMatchingButton.UseVisualStyleBackColor = true;
            DetectUserTemplateMatchingButton.Click += DetectUserTemplateMatchingButton_Click;
            // 
            // DetectUserViolaJons
            // 
            DetectUserViolaJons.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DetectUserViolaJons.Location = new Point(1073, 592);
            DetectUserViolaJons.Margin = new Padding(5, 6, 5, 6);
            DetectUserViolaJons.Name = "DetectUserViolaJons";
            DetectUserViolaJons.Size = new Size(667, 266);
            DetectUserViolaJons.TabIndex = 2;
            DetectUserViolaJons.Text = "Детектировать лица с помощью детектора Виолы-Джонса";
            DetectUserViolaJons.UseVisualStyleBackColor = true;
            DetectUserViolaJons.Click += DetectUserViolaJons_Click;
            // 
            // FacialSymmetry
            // 
            FacialSymmetry.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            FacialSymmetry.Location = new Point(1073, 994);
            FacialSymmetry.Margin = new Padding(5, 6, 5, 6);
            FacialSymmetry.Name = "FacialSymmetry";
            FacialSymmetry.Size = new Size(667, 266);
            FacialSymmetry.TabIndex = 3;
            FacialSymmetry.Text = "Определить линии симметрии лица\r\n";
            FacialSymmetry.UseVisualStyleBackColor = true;
            FacialSymmetry.Click += FacialSymmetry_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1812, 1342);
            Controls.Add(FacialSymmetry);
            Controls.Add(DetectUserViolaJons);
            Controls.Add(DetectUserTemplateMatchingButton);
            Controls.Add(AddNewUserButton);
            Margin = new Padding(5, 6, 5, 6);
            Name = "MenuForm";
            Text = "Меню";
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button AddNewUserButton;
        private Button DetectUserTemplateMatchingButton;
        private Button DetectUserViolaJons;
        private Button FacialSymmetry;
    }
}
