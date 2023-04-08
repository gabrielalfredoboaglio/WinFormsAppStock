namespace WinFormsAppStock.Vistas
{
    partial class ArticulosABM
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
            txtIdArticulo = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtMarca = new TextBox();
            label4 = new Label();
            txtMinimoStock = new TextBox();
            Proveedor = new Label();
            txtProveedor = new TextBox();
            Precio = new Label();
            txtPrecio = new TextBox();
            button1 = new Button();
            label5 = new Label();
            txtCodigo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 61);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 30);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // txtIdArticulo
            // 
            txtIdArticulo.Location = new Point(261, 61);
            txtIdArticulo.Margin = new Padding(4);
            txtIdArticulo.Name = "txtIdArticulo";
            txtIdArticulo.Size = new Size(133, 35);
            txtIdArticulo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 146);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(89, 30);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(261, 143);
            txtNombre.Margin = new Padding(4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(264, 35);
            txtNombre.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 226);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 6;
            label3.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(261, 223);
            txtMarca.Margin = new Padding(4);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(264, 35);
            txtMarca.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 294);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(133, 30);
            label4.TabIndex = 8;
            label4.Text = "MinimoStock";
            // 
            // txtMinimoStock
            // 
            txtMinimoStock.Location = new Point(261, 289);
            txtMinimoStock.Margin = new Padding(4);
            txtMinimoStock.Name = "txtMinimoStock";
            txtMinimoStock.Size = new Size(264, 35);
            txtMinimoStock.TabIndex = 9;
            // 
            // Proveedor
            // 
            Proveedor.AutoSize = true;
            Proveedor.Location = new Point(102, 363);
            Proveedor.Margin = new Padding(4, 0, 4, 0);
            Proveedor.Name = "Proveedor";
            Proveedor.Size = new Size(107, 30);
            Proveedor.TabIndex = 10;
            Proveedor.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(261, 358);
            txtProveedor.Margin = new Padding(4);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(264, 35);
            txtProveedor.TabIndex = 11;
            // 
            // Precio
            // 
            Precio.AutoSize = true;
            Precio.Location = new Point(111, 446);
            Precio.Margin = new Padding(4, 0, 4, 0);
            Precio.Name = "Precio";
            Precio.Size = new Size(70, 30);
            Precio.TabIndex = 12;
            Precio.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(261, 446);
            txtPrecio.Margin = new Padding(4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(264, 35);
            txtPrecio.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(78, 705);
            button1.Name = "button1";
            button1.Size = new Size(131, 40);
            button1.TabIndex = 22;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(111, 531);
            label5.Name = "label5";
            label5.Size = new Size(79, 30);
            label5.TabIndex = 23;
            label5.Text = "Codigo";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(261, 531);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(255, 35);
            txtCodigo.TabIndex = 24;
            // 
            // ArticulosABM
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1825, 945);
            Controls.Add(txtCodigo);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(txtPrecio);
            Controls.Add(Precio);
            Controls.Add(txtProveedor);
            Controls.Add(Proveedor);
            Controls.Add(txtMinimoStock);
            Controls.Add(label4);
            Controls.Add(txtMarca);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtIdArticulo);
            Controls.Add(label1);
            Name = "ArticulosABM";
            Text = "ArticulosABM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdArticulo;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtMarca;
        private Label label4;
        private TextBox txtMinimoStock;
        private Label Proveedor;
        private TextBox txtProveedor;
        private Label Precio;
        private TextBox txtPrecio;
        private Button button1;
        private Label label5;
        private TextBox txtCodigo;
    }
}