namespace Recognizer
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
            LoadDbbutton = new Button();
            ConfigureModelsParamsbutton = new Button();
            TestModelbutton = new Button();
            RecognizeFacebutton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // LoadDbbutton
            // 
            LoadDbbutton.Location = new Point(285, 146);
            LoadDbbutton.Name = "LoadDbbutton";
            LoadDbbutton.Size = new Size(230, 30);
            LoadDbbutton.TabIndex = 0;
            LoadDbbutton.Text = "Загрузить БД ORL";
            LoadDbbutton.UseVisualStyleBackColor = true;
            LoadDbbutton.Click += LoadDbbutton_Click;
            // 
            // ConfigureModelsParamsbutton
            // 
            ConfigureModelsParamsbutton.Location = new Point(285, 194);
            ConfigureModelsParamsbutton.Name = "ConfigureModelsParamsbutton";
            ConfigureModelsParamsbutton.Size = new Size(230, 29);
            ConfigureModelsParamsbutton.TabIndex = 1;
            ConfigureModelsParamsbutton.Text = "Настроить параметры модели";
            ConfigureModelsParamsbutton.UseVisualStyleBackColor = true;
            ConfigureModelsParamsbutton.Click += ConfigureModelsParamsbutton_Click;
            // 
            // TestModelbutton
            // 
            TestModelbutton.Location = new Point(285, 282);
            TestModelbutton.Name = "TestModelbutton";
            TestModelbutton.Size = new Size(230, 23);
            TestModelbutton.TabIndex = 2;
            TestModelbutton.Text = "Протестировать модель";
            TestModelbutton.UseVisualStyleBackColor = true;
            TestModelbutton.Click += TestModelbutton_Click;
            // 
            // RecognizeFacebutton
            // 
            RecognizeFacebutton.Location = new Point(285, 242);
            RecognizeFacebutton.Name = "RecognizeFacebutton";
            RecognizeFacebutton.Size = new Size(230, 23);
            RecognizeFacebutton.TabIndex = 3;
            RecognizeFacebutton.Text = "Распознать лицо";
            RecognizeFacebutton.UseVisualStyleBackColor = true;
            RecognizeFacebutton.Click += RecognizeFacebutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(65, 80);
            label1.Name = "label1";
            label1.Size = new Size(671, 28);
            label1.TabIndex = 4;
            label1.Text = "Программа для модеирования систем распознования людей по лицам";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(RecognizeFacebutton);
            Controls.Add(TestModelbutton);
            Controls.Add(ConfigureModelsParamsbutton);
            Controls.Add(LoadDbbutton);
            Name = "Form1";
            Text = "Меню";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadDbbutton;
        private Button ConfigureModelsParamsbutton;
        private Button TestModelbutton;
        private Button RecognizeFacebutton;
        private Label label1;
    }
}
