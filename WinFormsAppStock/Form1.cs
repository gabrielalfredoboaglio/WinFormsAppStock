using CodigoComun.Modelos;
using WinFormsAppStock.Vistas;

namespace WinFormsAppStock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticulosForm articulosForm = new ArticulosForm();
            articulosForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepositoForm depositoForm = new DepositoForm();
            depositoForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }
    }
}