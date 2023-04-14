namespace WinFormsAppStock.Vistas
{
    partial class DepositoABM
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
            label2 = new Label();
            txtCapacidad = new TextBox();
            txtIdDeposito = new TextBox();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 30);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 103);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 4;
            label2.Text = "Capacidad";
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(177, 103);
            txtCapacidad.Margin = new Padding(4);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(264, 35);
            txtCapacidad.TabIndex = 5;
            // 
            // txtIdDeposito
            // 
            txtIdDeposito.Location = new Point(177, 37);
            txtIdDeposito.Margin = new Padding(4);
            txtIdDeposito.Name = "txtIdDeposito";
            txtIdDeposito.Size = new Size(134, 35);
            txtIdDeposito.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(177, 179);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(264, 35);
            txtNombre.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(177, 266);
            txtDireccion.Margin = new Padding(4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(264, 35);
            txtDireccion.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 184);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 30);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 269);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 30);
            label4.TabIndex = 11;
            label4.Text = "Direccion";
            // 
            // button1
            // 
            button1.Location = new Point(46, 377);
            button1.Name = "button1";
            button1.Size = new Size(131, 40);
            button1.TabIndex = 22;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DepositosABM
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(txtIdDeposito);
            Controls.Add(txtCapacidad);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DepositosABM";
            Text = "DepositosABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCapacidad;
        private TextBox txtIdDeposito;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}