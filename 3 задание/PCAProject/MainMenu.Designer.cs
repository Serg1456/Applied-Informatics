namespace PCAProject
{
    partial class MainMenu
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
            button1PCAScale = new Button();
            button1PCAShmidt = new Button();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1PCAScale
            // 
            button1PCAScale.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1PCAScale.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1PCAScale.Location = new Point(304, 62);
            button1PCAScale.Name = "button1PCAScale";
            button1PCAScale.Size = new Size(202, 40);
            button1PCAScale.TabIndex = 0;
            button1PCAScale.Text = "Уменьшение размера изображения";
            button1PCAScale.UseVisualStyleBackColor = true;
            button1PCAScale.Click += button1PCAScale_Click;
            // 
            // button1PCAShmidt
            // 
            button1PCAShmidt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1PCAShmidt.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1PCAShmidt.Location = new Point(304, 120);
            button1PCAShmidt.Name = "button1PCAShmidt";
            button1PCAShmidt.Size = new Size(202, 39);
            button1PCAShmidt.TabIndex = 1;
            button1PCAShmidt.Text = "Использование матрицы Грамма-Шмидта";
            button1PCAShmidt.UseVisualStyleBackColor = true;
            button1PCAShmidt.Click += button1PCAShmidt_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(363, 20);
            label1.Name = "label1";
            label1.Size = new Size(53, 30);
            label1.TabIndex = 2;
            label1.Text = "PCA";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(363, 208);
            label2.Name = "label2";
            label2.Size = new Size(86, 30);
            label2.TabIndex = 3;
            label2.Text = "2D PCA";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(304, 250);
            button1.Name = "button1";
            button1.Size = new Size(202, 25);
            button1.TabIndex = 4;
            button1.Text = "Настроить параметры модели";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(304, 293);
            button2.Name = "button2";
            button2.Size = new Size(202, 23);
            button2.TabIndex = 5;
            button2.Text = "Каскадный алгоритм";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(304, 334);
            button3.Name = "button3";
            button3.Size = new Size(202, 23);
            button3.TabIndex = 6;
            button3.Text = "Параллельный алгоритм";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 425);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1PCAShmidt);
            Controls.Add(button1PCAScale);
            Name = "MainMenu";
            Text = "Меню";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1PCAScale;
        private Button button1PCAShmidt;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
