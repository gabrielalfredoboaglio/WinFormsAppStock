namespace WinFormsAppStock.Vistas
{
    partial class StockABM
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
            Id = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtIdStock = new TextBox();
            txtCantidad = new TextBox();
            txtIdComboboxArticulo = new ComboBox();
            txtComboBoxDeposito = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(142, 64);
            Id.Margin = new Padding(4, 0, 4, 0);
            Id.Name = "Id";
            Id.Size = new Size(31, 30);
            Id.TabIndex = 6;
            Id.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 136);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 30);
            label1.TabIndex = 7;
            label1.Text = "idArticulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 210);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 30);
            label2.TabIndex = 8;
            label2.Text = "idDeposito";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 292);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 30);
            label3.TabIndex = 9;
            label3.Text = "Cantidad";
            // 
            // txtIdStock
            // 
            txtIdStock.Location = new Point(297, 64);
            txtIdStock.Margin = new Padding(4);
            txtIdStock.Name = "txtIdStock";
            txtIdStock.Size = new Size(186, 35);
            txtIdStock.TabIndex = 10;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(297, 287);
            txtCantidad.Margin = new Padding(4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(186, 35);
            txtCantidad.TabIndex = 11;
            // 
            // txtIdComboboxArticulo
            // 
            txtIdComboboxArticulo.FormattingEnabled = true;
            txtIdComboboxArticulo.Location = new Point(283, 136);
            txtIdComboboxArticulo.Name = "txtIdComboboxArticulo";
            txtIdComboboxArticulo.Size = new Size(212, 38);
            txtIdComboboxArticulo.TabIndex = 12;
            // 
            // txtComboBoxDeposito
            // 
            txtComboBoxDeposito.FormattingEnabled = true;
            txtComboBoxDeposito.Location = new Point(283, 207);
            txtComboBoxDeposito.Name = "txtComboBoxDeposito";
            txtComboBoxDeposito.Size = new Size(212, 38);
            txtComboBoxDeposito.TabIndex = 13;
            // 
            // button2
            // 
            button2.Location = new Point(548, 391);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(260, 44);
            button2.TabIndex = 18;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // StockABM
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 479);
            Controls.Add(button2);
            Controls.Add(txtComboBoxDeposito);
            Controls.Add(txtIdComboboxArticulo);
            Controls.Add(txtCantidad);
            Controls.Add(txtIdStock);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Id);
            Name = "StockABM";
            Text = "StockABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Id;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtIdStock;
        private TextBox txtCantidad;
        private ComboBox txtIdComboboxArticulo;
        private ComboBox txtComboBoxDeposito;
        private Button button2;
    }
}