using CodigoComun.Models;
using CodigoComun.Modelos.DTO;
using CodigoComun.Negocio;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsAppStock.Vistas
{
    public partial class StockForm : Form
    {
        private readonly StockService _stockService;
        private readonly ArticuloService _articuloService;
        private readonly DepositoService _depositoService;

        public StockForm()
        {
            InitializeComponent();

            // Instanciar servicios y repositorios
            _stockService = new StockService(new StockRepository());
            _articuloService = new ArticuloService();
            _depositoService = new DepositoService();

            CargarStocks();
        }

        private void CargarStocks()
        {
            // Obtener listas de datos necesarias
            List<StockDTO> stocksDeLaBaseDeDatos = _stockService.ObtenerTodosLosStocks();
            List<ArticuloDTO> articulos = _articuloService.ObtenerTodosLosArticulos();
            List<DepositoDTO> depositos = _depositoService.ObtenerTodosLosDepositos();

            // Limpiar y configurar grilla
            dgvStock.Columns.Clear();
            dgvStock.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { Name = "IdArticulo", HeaderText = "IdArticulo" },
                new DataGridViewTextBoxColumn { Name = "IdDeposito", HeaderText = "IdDeposito" },
                new DataGridViewTextBoxColumn { Name = "NombreArticulo", HeaderText = "NombreArticulo" },
                new DataGridViewTextBoxColumn { Name = "NombreDeposito", HeaderText = "NombreDeposito" },
                new DataGridViewTextBoxColumn { Name = "CodigoArticulo", HeaderText = "CodigoArticulo" }
            });

            dgvStock.Rows.Clear();

            foreach (var stockDTO in stocksDeLaBaseDeDatos)
            {
                // Obtener datos relacionados para mostrar en la grilla
                string nombreArticulo = articulos.FirstOrDefault(a => a.Id == stockDTO.IdArticulo)?.Nombre;
                string nombreDeposito = depositos.FirstOrDefault(d => d.Id == stockDTO.IdDeposito)?.Nombre;
                string codigoArticulo = articulos.FirstOrDefault(a => a.Id == stockDTO.IdArticulo)?.Codigo;

                // Agregar fila a la grilla
                int rowIndex = dgvStock.Rows.Add(stockDTO.Id, stockDTO.IdArticulo, stockDTO.IdDeposito, nombreArticulo, nombreDeposito, codigoArticulo);
                dgvStock.Rows[rowIndex].Tag = stockDTO;
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStock.Text))
            {
                MessageBox.Show("Debe ingresar un ID válido.");
                return;
            }

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
            if (string.IsNullOrEmpty(txtIdStock.Text))
            {
                MessageBox.Show("Por favor ingrese un ID válido", "ID vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdStockAmodificar = Convert.ToInt32(txtIdStock.Text);

            StockABM stocksABMModoModificacion = new StockABM(IdStockAmodificar);
            stocksABMModoModificacion.Show();
        }


    }
}


