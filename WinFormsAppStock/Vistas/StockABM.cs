
using CodigoComun.Modelos;
using CodigoComun.Models;
using CodigoComun.Negocio;
using CodigoComun.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using CodigoComun.Modelos.DTO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deposito = CodigoComun.Models.Deposito;
using Stock = CodigoComun.Models.Stock;

namespace WinFormsAppStock.Vistas
{
    public partial class StockABM : Form
    {
        private readonly StockService _stockService;

        public StockABM()
        {
            InitializeComponent();
            _stockService = new StockService(new StockRepository());
            CargarComboBoxes();

        }

        public StockABM(int idStockAModificar)
        {
            InitializeComponent();
            _stockService = new StockService(new StockRepository());
            CargarDatosStockParaModificar(idStockAModificar);

        }
        private void CargarDatosStockParaModificar(int idStockAModificar)
        {
            StockDTO stockConDatosDeLaBaseDeDatos = _stockService.ObtenerStockPorId(idStockAModificar);

            txtIdComboboxArticulo.Text = stockConDatosDeLaBaseDeDatos.IdArticulo.ToString();
            txtComboBoxDeposito.Text = stockConDatosDeLaBaseDeDatos.IdDeposito.ToString();
            txtCantidad.Text = stockConDatosDeLaBaseDeDatos.Cantidad.ToString();

        }



        private void CargarComboBoxes()
        {
            // Cargar los datos de los ComboBoxes
            txtIdComboboxArticulo.DataSource = new ArticuloService().ObtenerTodosLosArticulos();
            txtIdComboboxArticulo.DisplayMember = "Nombre";
            txtIdComboboxArticulo.ValueMember = "Id";

            txtComboBoxDeposito.DataSource = new DepositoService().ObtenerTodosLosDepositos();
            txtComboBoxDeposito.DisplayMember = "Nombre";
            txtComboBoxDeposito.ValueMember = "Id";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Stock nuevoStock = new Stock();
            nuevoStock.IdDeposito = Convert.ToInt32(txtComboBoxDeposito.SelectedValue);
            nuevoStock.IdArticulo = Convert.ToInt32(txtIdComboboxArticulo.SelectedValue);
            nuevoStock.ArticuloGuardado = new Articulo() { Id = (int)nuevoStock.IdArticulo };
            nuevoStock.DepositoDondeEstaGuardado = new Deposito() { Id = (int)nuevoStock.IdDeposito };
            decimal cantidad;
            if (decimal.TryParse(txtCantidad.Text, out cantidad))
            {
                // La conversión fue exitosa, la variable "cantidad" contiene el valor convertido
                nuevoStock.Cantidad = cantidad;

                // Convertir el objeto Stock a StockDTO
                StockDTO stockDTO = new StockDTO
                {
                    IdArticulo = nuevoStock.IdArticulo,
                    IdDeposito = nuevoStock.IdDeposito,
                    Cantidad = nuevoStock.Cantidad
                };

                // Agrega el nuevo registro de stock a la base de datos
                StockDTO resultado = _stockService.AgregarStock(stockDTO);
                if (!resultado.HuboError)
                {
                    MessageBox.Show(resultado.Mensaje);
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // La conversión falló, la cadena de caracteres no tiene un formato válido
                MessageBox.Show("La cantidad ingresada no es válida");
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            btnAgregar_Click(sender, e);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener los datos del Stock a modificar
            int idStockAModificar = Convert.ToInt32(txtIdStockModificar.Text);
            decimal cantidad;
            if (decimal.TryParse(txtCantidad.Text, out cantidad))
            {
                // Obtener el StockDTO del Stock a modificar
                StockDTO stockAModificar = _stockService.ObtenerStockPorId(idStockAModificar);

                // Obtener el Id de Articulo y el Id de Deposito correspondientes al Stock que se está modificando
                int idArticulo = (int)stockAModificar.IdArticulo;
                int idDeposito = (int)stockAModificar.IdDeposito;

                // Convertir el objeto Stock a StockDTO
                StockDTO stockDTO = new StockDTO
                {
                    Id = idStockAModificar,
                    IdArticulo = idArticulo,
                    IdDeposito = idDeposito,
                    Cantidad = cantidad
                };

                // Modificar el registro de stock en la base de datos
                StockDTO resultado = _stockService.ActualizarStock(stockDTO);
                if (!resultado.HuboError)
                {
                    MessageBox.Show(resultado.Mensaje);
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La cantidad ingresada no es válida");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            btnModificar_Click(sender, e);
        }
    }
}








