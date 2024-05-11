namespace Recognizer
{
    partial class ParamsOfModelForm
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
            Acceptbutton = new Button();
            countOfEtalonsTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // Acceptbutton
            // 
            Acceptbutton.Location = new Point(60, 111);
            Acceptbutton.Name = "Acceptbutton";
            Acceptbutton.Size = new Size(129, 23);
            Acceptbutton.TabIndex = 0;
            Acceptbutton.Text = "Подтвердить";
            Acceptbutton.UseVisualStyleBackColor = true;
            Acceptbutton.Click += Acceptbutton_Click;
            // 
            // countOfEtalonsTextBox
            // 
            countOfEtalonsTextBox.Location = new Point(60, 68);
            countOfEtalonsTextBox.Name = "countOfEtalonsTextBox";
            countOfEtalonsTextBox.Size = new Size(129, 23);
            countOfEtalonsTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 41);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 2;
            label1.Text = "Количество эталонов:";
            // 
            // ParamsOfModelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 203);
            Controls.Add(label1);
            Controls.Add(countOfEtalonsTextBox);
            Controls.Add(Acceptbutton);
            Name = "ParamsOfModelForm";
            Text = "Параметры модели";
            FormClosing += ParamsOfModelForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Acceptbutton;
        private TextBox countOfEtalonsTextBox;
        private Label label1;
    }
}