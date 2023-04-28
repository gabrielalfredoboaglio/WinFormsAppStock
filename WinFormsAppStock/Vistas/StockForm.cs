using CodigoComun.Modelos;
using CodigoComun.Models;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Stock = CodigoComun.Models.Stock;
using CodigoComun.Negocio;
using CodigoComun.Modelos.DTO;

namespace WinFormsAppStock.Vistas
{
    public partial class StockForm : Form
    {


        public StockForm()
        {
            InitializeComponent();
            CargarStocks();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }
        private void CargarStocks()
        {
            StockRepository stockRepository = new StockRepository();
            StockService stockServices = new StockService(stockRepository);
            List<StockDTO> stocksDeLaBaseDeDatos = stockServices.ObtenerTodosLosStocks();
            dgvStock.DataSource = stocksDeLaBaseDeDatos;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            // Obtener el Id del Stock a eliminar
            int idStock = Convert.ToInt32(txtIdStock.Text);

            // Crear una instancia de StockRepository
            StockRepository stockRepo = new StockRepository();

            // Crear una instancia de StockService, pasándole el objeto StockRepository
            StockService stockService = new StockService(stockRepo);

            // Llamar al método EliminarStock del objeto StockService, pasando el Id del Stock a eliminar
            StockDTO resultado = stockService.EliminarStock(idStock);

            if (!resultado.HuboError)
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show(resultado.Mensaje);
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show(resultado.Mensaje);
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }

    }
}


