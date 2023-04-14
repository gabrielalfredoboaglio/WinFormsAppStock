namespace WinFormsAppStock.Vistas
{
    partial class ArticuloForm
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
            IdArticulo = new Label();
            txtIdArticulo = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            dgvArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            SuspendLayout();
            // 
            // IdArticulo
            // 
            IdArticulo.AutoSize = true;
            IdArticulo.Location = new Point(119, 33);
            IdArticulo.Margin = new Padding(4, 0, 4, 0);
            IdArticulo.Name = "IdArticulo";
            IdArticulo.Size = new Size(103, 30);
            IdArticulo.TabIndex = 7;
            IdArticulo.Text = "IdArticulo";
            // 
            // txtIdArticulo
            // 
            txtIdArticulo.Location = new Point(274, 33);
            txtIdArticulo.Margin = new Padding(4);
            txtIdArticulo.Name = "txtIdArticulo";
            txtIdArticulo.Size = new Size(186, 35);
            txtIdArticulo.TabIndex = 8;
           
            // 
            // button2
            // 
            button2.Location = new Point(725, 33);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(214, 44);
            button2.TabIndex = 9;
            button2.Text = "Eliminar Articulo ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(725, 150);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(214, 44);
            button3.TabIndex = 10;
            button3.Text = "Modificar Articulo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1228, 33);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(304, 88);
            button1.TabIndex = 11;
            button1.Text = "Agregar Articulo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvArticulos
            // 
            dgvArticulos.AllowUserToAddRows = false;
            dgvArticulos.AllowUserToDeleteRows = false;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Location = new Point(274, 377);
            dgvArticulos.Margin = new Padding(4);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.ReadOnly = true;
            dgvArticulos.RowHeadersWidth = 51;
            dgvArticulos.RowTemplate.Height = 29;
            dgvArticulos.Size = new Size(857, 289);
            dgvArticulos.TabIndex = 12;
            // 
            // ArticulosForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1716, 850);
            Controls.Add(dgvArticulos);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtIdArticulo);
            Controls.Add(IdArticulo);
            Name = "ArticulosForm";
            Text = "ArticulosForm";
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdArticulo;
        private TextBox txtIdArticulo;
        private Button button2;
        private Button button3;
        private Button button1;
        private DataGridView dgvArticulos;
    }
}