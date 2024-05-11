namespace Recognizer
{
    partial class SetupCountOfImagesForm
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
            Confirmbutton = new Button();
            countOfPersonTextArea = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // Confirmbutton
            // 
            Confirmbutton.Location = new Point(185, 108);
            Confirmbutton.Name = "Confirmbutton";
            Confirmbutton.Size = new Size(133, 23);
            Confirmbutton.TabIndex = 0;
            Confirmbutton.Text = "Подтвердить";
            Confirmbutton.UseVisualStyleBackColor = true;
            Confirmbutton.Click += Confirmbutton_Click;
            // 
            // countOfPersonTextArea
            // 
            countOfPersonTextArea.Location = new Point(201, 60);
            countOfPersonTextArea.Name = "countOfPersonTextArea";
            countOfPersonTextArea.Size = new Size(100, 23);
            countOfPersonTextArea.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 42);
            label1.Name = "label1";
            label1.Size = new Size(213, 15);
            label1.TabIndex = 2;
            label1.Text = "Количество изображений (от 3 до 10)";
            // 
            // SetupCountOfImagesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 202);
            Controls.Add(label1);
            Controls.Add(countOfPersonTextArea);
            Controls.Add(Confirmbutton);
            Name = "SetupCountOfImagesForm";
            Text = "Выбрать количество изображений";
            FormClosing += SetupCountOfImagesForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Confirmbutton;
        private TextBox countOfPersonTextArea;
        private Label label1;
    }
}