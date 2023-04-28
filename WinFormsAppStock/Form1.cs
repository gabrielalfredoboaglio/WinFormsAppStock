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
            ArticuloForm articulosForm = new ArticuloForm();
            articulosForm.Show();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            DepositoForm depositoForm = new DepositoForm();
            depositoForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }
    }
}