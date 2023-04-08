using CodigoComun.Modelos;
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

namespace WinFormsAppStock.Vistas
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
            CargarDatos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.TipoOperacion = "Agregar";
            stockABM.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.TipoOperacion = "Actualizar";
            stockABM.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el Id del Stock a eliminar
            int idStock = Convert.ToInt32(txtIdStock.Text);

            // Instanciar un objeto Stock
            Stock stock = new Stock();

            // Llamar al método EliminarEnDb del objeto Stock, pasando el Id del Stock a eliminar
            int resultado = stock.EliminarEnDb();

            if (resultado != -1)
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show("El registro de stock ha sido eliminado correctamente.");
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show("Ha ocurrido un error al eliminar el registro de stock.");
            }
        }

        private void CargarDatos()
        {
            try
            {
                // Crear un objeto Stock para obtener los datos
                Stock stock = new Stock();

                // Obtener todos los registros de la tabla Stocks
                List<Stock> listaStocks = stock.ObtenerTodosLosStocks();

                // Crear un objeto DataTable y agregar las columnas necesarias
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("ArticuloGuardado", typeof(string));
                dt.Columns.Add("DepositoDondeEstaGuardado", typeof(string));
                dt.Columns.Add("Cantidad", typeof(decimal));

                // Agregar los registros a la DataTable
                foreach (Stock s in listaStocks)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = s.Id;
                    dr["ArticuloGuardado"] = s.ArticuloGuardado == null ? null : s.ArticuloGuardado.Nombre;
                    dr["DepositoDondeEstaGuardado"] = s.DepositoDondeEstaGuardado == null ? null : s.DepositoDondeEstaGuardado.Nombre;
                    dr["Cantidad"] = s.Cantidad;
                    dt.Rows.Add(dr);
                }

                // Asignar el DataSource del DataGridView
                dgvStock.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }



    }
}

