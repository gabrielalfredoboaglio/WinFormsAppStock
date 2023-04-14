namespace WinFormsAppStock.Vistas
{
    partial class StockForm
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
            IdAlumno = new Label();
            txtIdStock = new TextBox();
            button2 = new Button();
            Button1 = new Button();
            button4 = new Button();
            dgvStock = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // IdAlumno
            // 
            IdAlumno.AutoSize = true;
            IdAlumno.Location = new Point(66, 59);
            IdAlumno.Margin = new Padding(4, 0, 4, 0);
            IdAlumno.Name = "IdAlumno";
            IdAlumno.Size = new Size(80, 30);
            IdAlumno.TabIndex = 6;
            IdAlumno.Text = "IdStock";
            // 
            // txtIdStock
            // 
            txtIdStock.Location = new Point(203, 59);
            txtIdStock.Margin = new Padding(4);
            txtIdStock.Name = "txtIdStock";
            txtIdStock.Size = new Size(186, 35);
            txtIdStock.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(544, 59);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(214, 44);
            button2.TabIndex = 8;
            button2.Text = "Eliminar Stock";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // Button1
            // 
            Button1.Location = new Point(544, 177);
            Button1.Margin = new Padding(4);
            Button1.Name = "Button1";
            Button1.Size = new Size(214, 44);
            Button1.TabIndex = 9;
            Button1.Text = "Modificar Stock";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1021, 52);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(304, 88);
            button4.TabIndex = 11;
            button4.Text = "Agregar Stock";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dgvStock
            // 
            dgvStock.AllowDrop = true;
            dgvStock.AllowUserToOrderColumns = true;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(163, 365);
            dgvStock.Margin = new Padding(4);
            dgvStock.Name = "dgvStock";
            dgvStock.RowHeadersWidth = 51;
            dgvStock.RowTemplate.Height = 29;
            dgvStock.Size = new Size(1118, 282);
            dgvStock.StandardTab = true;
            dgvStock.TabIndex = 12;
           
            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1587, 698);
            Controls.Add(dgvStock);
            Controls.Add(button4);
            Controls.Add(Button1);
            Controls.Add(button2);
            Controls.Add(txtIdStock);
            Controls.Add(IdAlumno);
            Name = "StockForm";
            Text = "StockForm";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdAlumno;
        private TextBox txtIdStock;
        private Button button2;
        private Button Button1;
        private Button button4;
        private DataGridView dgvStock;
    }
}