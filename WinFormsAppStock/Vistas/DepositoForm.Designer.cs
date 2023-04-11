namespace WinFormsAppStock.Vistas
{
    partial class DepositoForm
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
            IdDeposito = new Label();
            txtIdDeposito = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            dgvDepositos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDepositos).BeginInit();
            SuspendLayout();
            // 
            // IdDeposito
            // 
            IdDeposito.AutoSize = true;
            IdDeposito.Location = new Point(63, 59);
            IdDeposito.Margin = new Padding(4, 0, 4, 0);
            IdDeposito.Name = "IdDeposito";
            IdDeposito.Size = new Size(123, 30);
            IdDeposito.TabIndex = 7;
            IdDeposito.Text = "IdDepositos";
            // 
            // txtIdDeposito
            // 
            txtIdDeposito.Location = new Point(269, 59);
            txtIdDeposito.Margin = new Padding(4);
            txtIdDeposito.Name = "txtIdDeposito";
            txtIdDeposito.Size = new Size(186, 35);
            txtIdDeposito.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(628, 52);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(214, 44);
            button2.TabIndex = 9;
            button2.Text = "Eliminar Deposito";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(628, 159);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(214, 44);
            button3.TabIndex = 10;
            button3.Text = "Modificar Deposito";
            button3.UseVisualStyleBackColor = true;
            //button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1115, 52);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(304, 88);
            button1.TabIndex = 11;
            button1.Text = "Agregar Deposito";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dgvDepositos
            // 
            dgvDepositos.AllowUserToAddRows = false;
            dgvDepositos.AllowUserToDeleteRows = false;
            dgvDepositos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepositos.Location = new Point(195, 317);
            dgvDepositos.Margin = new Padding(4);
            dgvDepositos.Name = "dgvDepositos";
            dgvDepositos.ReadOnly = true;
            dgvDepositos.RowHeadersWidth = 51;
            dgvDepositos.RowTemplate.Height = 29;
            dgvDepositos.Size = new Size(1138, 282);
            dgvDepositos.TabIndex = 12;
            // 
            // DepositoForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1631, 692);
            Controls.Add(dgvDepositos);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtIdDeposito);
            Controls.Add(IdDeposito);
            Name = "DepositoForm";
            Text = "DepositoForm";
            ((System.ComponentModel.ISupportInitialize)dgvDepositos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdDeposito;
        private TextBox txtIdDeposito;
        private Button button2;
        private Button button3;
        private Button button1;
        private DataGridView dgvDepositos;
    }
}