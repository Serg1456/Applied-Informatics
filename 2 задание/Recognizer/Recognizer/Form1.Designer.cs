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
            ConfigureModelsParamsbutton = new Button();
            label1 = new Label();
            TestModelStudyButton = new Button();
            button1 = new Button();
            DefineBestParamsOfModel = new Button();
            buttonTestParralelModel = new Button();
            label2 = new Label();
            label3 = new Label();
            DetectFaceButton = new Button();
            SuspendLayout();
            // 
            // ConfigureModelsParamsbutton
            // 
            ConfigureModelsParamsbutton.Location = new Point(329, 128);
            ConfigureModelsParamsbutton.Name = "ConfigureModelsParamsbutton";
            ConfigureModelsParamsbutton.Size = new Size(230, 29);
            ConfigureModelsParamsbutton.TabIndex = 1;
            ConfigureModelsParamsbutton.Text = "Настроить параметры модели";
            ConfigureModelsParamsbutton.UseVisualStyleBackColor = true;
            ConfigureModelsParamsbutton.Click += ConfigureModelsParamsbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(134, 80);
            label1.Name = "label1";
            label1.Size = new Size(680, 28);
            label1.TabIndex = 4;
            label1.Text = "Программа для моделирования систем распознавания людей по лицам";
            // 
            // TestModelStudyButton
            // 
            TestModelStudyButton.BackgroundImageLayout = ImageLayout.Center;
            TestModelStudyButton.Location = new Point(23, 297);
            TestModelStudyButton.Name = "TestModelStudyButton";
            TestModelStudyButton.Size = new Size(299, 23);
            TestModelStudyButton.TabIndex = 5;
            TestModelStudyButton.Text = "Тестировать модель на обучающей выборке";
            TestModelStudyButton.UseVisualStyleBackColor = true;
            TestModelStudyButton.Click += TestModelButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(36, 343);
            button1.Name = "button1";
            button1.Size = new Size(272, 29);
            button1.TabIndex = 6;
            button1.Text = "Тестировать модель на тестовой выборке";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DefineBestParamsOfModel
            // 
            DefineBestParamsOfModel.Location = new Point(12, 394);
            DefineBestParamsOfModel.Name = "DefineBestParamsOfModel";
            DefineBestParamsOfModel.Size = new Size(421, 29);
            DefineBestParamsOfModel.TabIndex = 7;
            DefineBestParamsOfModel.Text = "Подбор параметров, обеспечивающий результат близкий к 100%";
            DefineBestParamsOfModel.UseVisualStyleBackColor = true;
            DefineBestParamsOfModel.Click += DefineBestParamsOfModel_Click;
            // 
            // buttonTestParralelModel
            // 
            buttonTestParralelModel.Location = new Point(516, 297);
            buttonTestParralelModel.Name = "buttonTestParralelModel";
            buttonTestParralelModel.Size = new Size(300, 29);
            buttonTestParralelModel.TabIndex = 8;
            buttonTestParralelModel.Text = "Тестировать модель на тестовой выборке\r\n";
            buttonTestParralelModel.UseVisualStyleBackColor = true;
            buttonTestParralelModel.Click += buttonTestParralelModel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 263);
            label2.Name = "label2";
            label2.Size = new Size(192, 21);
            label2.TabIndex = 9;
            label2.Text = "Тестирование признаков.";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(516, 263);
            label3.Name = "label3";
            label3.Size = new Size(281, 21);
            label3.TabIndex = 10;
            label3.Text = "Тестирование параллельной системы.";
            // 
            // DetectFaceButton
            // 
            DetectFaceButton.BackgroundImageLayout = ImageLayout.Center;
            DetectFaceButton.Location = new Point(516, 343);
            DetectFaceButton.Name = "DetectFaceButton";
            DetectFaceButton.Size = new Size(299, 23);
            DetectFaceButton.TabIndex = 11;
            DetectFaceButton.Text = "Распознать лицо";
            DetectFaceButton.UseVisualStyleBackColor = true;
            DetectFaceButton.Click += DetectFaceButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 520);
            Controls.Add(DetectFaceButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonTestParralelModel);
            Controls.Add(DefineBestParamsOfModel);
            Controls.Add(button1);
            Controls.Add(TestModelStudyButton);
            Controls.Add(label1);
            Controls.Add(ConfigureModelsParamsbutton);
            Name = "Form1";
            Text = "Меню";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ConfigureModelsParamsbutton;
        private Label label1;
        private Button TestModelStudyButton;
        private Button button1;
        private Button DefineBestParamsOfModel;
        private Button buttonTestParralelModel;
        private Label label2;
        private Label label3;
        private Button DetectFaceButton;
    }
}
