namespace FaceDetector
{
    partial class DbLoaderForm
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
            components = new System.ComponentModel.Container();
            FirstNameInput = new TextBox();
            SecondNameInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            bindingSource1 = new BindingSource(components);
            LoadMainFace = new Button();
            label3 = new Label();
            mainPartOfFace = new Button();
            noseAndEyes = new Button();
            Eyes = new Button();
            Lips = new Button();
            nose = new Button();
            LeftEye = new Button();
            RightEye = new Button();
            Add = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // FirstNameInput
            // 
            FirstNameInput.Location = new Point(58, 65);
            FirstNameInput.Name = "FirstNameInput";
            FirstNameInput.Size = new Size(167, 23);
            FirstNameInput.TabIndex = 0;
            // 
            // SecondNameInput
            // 
            SecondNameInput.Location = new Point(58, 133);
            SecondNameInput.Name = "SecondNameInput";
            SecondNameInput.Size = new Size(167, 23);
            SecondNameInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 47);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "Имя:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 115);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 3;
            label2.Text = "Фамилия:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LoadMainFace
            // 
            LoadMainFace.Location = new Point(367, 93);
            LoadMainFace.Name = "LoadMainFace";
            LoadMainFace.Size = new Size(188, 23);
            LoadMainFace.TabIndex = 4;
            LoadMainFace.Text = "Основная часть лица №1";
            LoadMainFace.UseVisualStyleBackColor = true;
            LoadMainFace.Click += LoadMainFace_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 65);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 5;
            label3.Text = "Информация о лице";
            // 
            // mainPartOfFace
            // 
            mainPartOfFace.Location = new Point(367, 132);
            mainPartOfFace.Name = "mainPartOfFace";
            mainPartOfFace.Size = new Size(188, 23);
            mainPartOfFace.TabIndex = 6;
            mainPartOfFace.Text = "основная часть лица №2";
            mainPartOfFace.UseVisualStyleBackColor = true;
            mainPartOfFace.Click += mainPartOfFace_Click;
            // 
            // noseAndEyes
            // 
            noseAndEyes.FlatStyle = FlatStyle.System;
            noseAndEyes.Location = new Point(367, 171);
            noseAndEyes.Name = "noseAndEyes";
            noseAndEyes.Size = new Size(131, 23);
            noseAndEyes.TabIndex = 7;
            noseAndEyes.Text = "Нос и глаза";
            noseAndEyes.UseVisualStyleBackColor = true;
            noseAndEyes.Click += noseAndEyes_Click;
            // 
            // Eyes
            // 
            Eyes.Location = new Point(367, 210);
            Eyes.Name = "Eyes";
            Eyes.Size = new Size(131, 23);
            Eyes.TabIndex = 8;
            Eyes.Text = "Оба глаза";
            Eyes.UseVisualStyleBackColor = true;
            Eyes.Click += Eyes_Click;
            // 
            // Lips
            // 
            Lips.Location = new Point(367, 327);
            Lips.Name = "Lips";
            Lips.Size = new Size(131, 23);
            Lips.TabIndex = 9;
            Lips.Text = "Губы";
            Lips.UseVisualStyleBackColor = true;
            Lips.Click += Lips_Click;
            // 
            // nose
            // 
            nose.Location = new Point(367, 366);
            nose.Name = "nose";
            nose.Size = new Size(131, 23);
            nose.TabIndex = 10;
            nose.Text = "Нос";
            nose.UseVisualStyleBackColor = true;
            nose.Click += nose_Click;
            // 
            // LeftEye
            // 
            LeftEye.Location = new Point(367, 249);
            LeftEye.Name = "LeftEye";
            LeftEye.Size = new Size(131, 23);
            LeftEye.TabIndex = 11;
            LeftEye.Text = "Левый глаз";
            LeftEye.UseVisualStyleBackColor = true;
            LeftEye.Click += LeftEye_Click;
            // 
            // RightEye
            // 
            RightEye.Location = new Point(367, 288);
            RightEye.Name = "RightEye";
            RightEye.Size = new Size(131, 23);
            RightEye.TabIndex = 12;
            RightEye.Text = "Правый глаз";
            RightEye.UseVisualStyleBackColor = true;
            RightEye.Click += RightEye_Click;
            // 
            // Add
            // 
            Add.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Add.Location = new Point(58, 327);
            Add.Name = "Add";
            Add.Size = new Size(154, 62);
            Add.TabIndex = 13;
            Add.Text = "Добавить";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // DbLoaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(Add);
            Controls.Add(RightEye);
            Controls.Add(LeftEye);
            Controls.Add(nose);
            Controls.Add(Lips);
            Controls.Add(Eyes);
            Controls.Add(noseAndEyes);
            Controls.Add(mainPartOfFace);
            Controls.Add(label3);
            Controls.Add(LoadMainFace);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SecondNameInput);
            Controls.Add(FirstNameInput);
            Name = "DbLoaderForm";
            Text = "Загрузка изображения в БД";
            FormClosing += DbLoaderForm_FormClosing;
            Load += DbLoaderForm_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstNameInput;
        private TextBox SecondNameInput;
        private Label label1;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private BindingSource bindingSource1;
        private Button LoadMainFace;
        private Label label3;
        private Button mainPartOfFace;
        private Button noseAndEyes;
        private Button Eyes;
        private Button Lips;
        private Button nose;
        private Button LeftEye;
        private Button RightEye;
        private Button Add;
    }
}