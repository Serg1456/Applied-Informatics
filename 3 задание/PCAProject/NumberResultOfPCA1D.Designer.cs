namespace PCAProject
{
    partial class NumberResultOfPCA1D
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
            dataGridViewCovarriationMatrix = new DataGridView();
            dataGridViewEigenVectors = new DataGridView();
            dataGridViewEigenValues = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCovarriationMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEigenVectors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEigenValues).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCovarriationMatrix
            // 
            dataGridViewCovarriationMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCovarriationMatrix.Location = new Point(20, 84);
            dataGridViewCovarriationMatrix.Name = "dataGridViewCovarriationMatrix";
            dataGridViewCovarriationMatrix.RowTemplate.Height = 25;
            dataGridViewCovarriationMatrix.Size = new Size(516, 461);
            dataGridViewCovarriationMatrix.TabIndex = 0;
            dataGridViewCovarriationMatrix.CellContentClick += dataGridViewCovarriationMatrix_CellContentClick;
            // 
            // dataGridViewEigenVectors
            // 
            dataGridViewEigenVectors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEigenVectors.Location = new Point(579, 84);
            dataGridViewEigenVectors.Name = "dataGridViewEigenVectors";
            dataGridViewEigenVectors.RowTemplate.Height = 25;
            dataGridViewEigenVectors.Size = new Size(516, 461);
            dataGridViewEigenVectors.TabIndex = 1;
            // 
            // dataGridViewEigenValues
            // 
            dataGridViewEigenValues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEigenValues.Location = new Point(1138, 84);
            dataGridViewEigenValues.Name = "dataGridViewEigenValues";
            dataGridViewEigenValues.RowTemplate.Height = 25;
            dataGridViewEigenValues.Size = new Size(148, 461);
            dataGridViewEigenValues.TabIndex = 2;
            dataGridViewEigenValues.CellContentClick += dataGridView2_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 56);
            label1.Name = "label1";
            label1.Size = new Size(244, 25);
            label1.TabIndex = 3;
            label1.Text = "Ковариационная матрица.\r\n";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(579, 56);
            label2.Name = "label2";
            label2.Size = new Size(206, 25);
            label2.TabIndex = 4;
            label2.Text = "Собственные вектора.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1138, 56);
            label3.Name = "label3";
            label3.Size = new Size(188, 25);
            label3.TabIndex = 5;
            label3.Text = "Собственные числа.";
            // 
            // VisualResultOfPCA1D
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1328, 669);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewEigenValues);
            Controls.Add(dataGridViewEigenVectors);
            Controls.Add(dataGridViewCovarriationMatrix);
            Name = "VisualResultOfPCA1D";
            Text = "VisualResultOfPCA1D";
            Load += VisualResultOfPCA1D_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCovarriationMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEigenVectors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEigenValues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCovarriationMatrix;
        private DataGridView dataGridViewEigenVectors;
        private DataGridView dataGridViewEigenValues;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}