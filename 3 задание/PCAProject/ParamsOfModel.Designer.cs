namespace PCAProject
{
    partial class ParamsOfModel
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
            label1 = new Label();
            numberOfParamsInput = new TextBox();
            confirmButton = new Button();
            numberOfReductionInput = new TextBox();
            label2 = new Label();
            noReductionButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Количество эталонов";
            // 
            // numberOfParamsInput
            // 
            numberOfParamsInput.Location = new Point(83, 53);
            numberOfParamsInput.Margin = new Padding(2, 2, 2, 2);
            numberOfParamsInput.Name = "numberOfParamsInput";
            numberOfParamsInput.Size = new Size(129, 23);
            numberOfParamsInput.TabIndex = 1;
            // 
            // confirmButton
            // 
            confirmButton.Location = new Point(90, 225);
            confirmButton.Margin = new Padding(2, 2, 2, 2);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(110, 20);
            confirmButton.TabIndex = 2;
            confirmButton.Text = "Подтвердить";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // numberOfReductionInput
            // 
            numberOfReductionInput.Location = new Point(83, 135);
            numberOfReductionInput.Margin = new Padding(2, 2, 2, 2);
            numberOfReductionInput.Name = "numberOfReductionInput";
            numberOfReductionInput.Size = new Size(129, 23);
            numberOfReductionInput.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 98);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 4;
            label2.Text = "Параметр редукции";
            // 
            // noReductionButton
            // 
            noReductionButton.Location = new Point(83, 180);
            noReductionButton.Name = "noReductionButton";
            noReductionButton.Size = new Size(129, 23);
            noReductionButton.TabIndex = 5;
            noReductionButton.Text = "Без редукции";
            noReductionButton.UseVisualStyleBackColor = true;
            noReductionButton.Click += noReductionButton_Click;
            // 
            // ParamsOfModel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 328);
            Controls.Add(noReductionButton);
            Controls.Add(label2);
            Controls.Add(numberOfReductionInput);
            Controls.Add(confirmButton);
            Controls.Add(numberOfParamsInput);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ParamsOfModel";
            Text = "Параметры модели";
            FormClosing += ParamsOfModel_FormClosing;
            Load += ParamsOfModel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox numberOfParamsInput;
        private Button confirmButton;
        private TextBox numberOfReductionInput;
        private Label label2;
        private Button noReductionButton;
    }
}