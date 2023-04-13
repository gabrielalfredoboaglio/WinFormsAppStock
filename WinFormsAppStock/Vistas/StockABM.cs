
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
        }


        private void CargarComboBoxes()
        {
            // Cargar los datos de los ComboBoxes
            txtIdComboboxArticulo.DataSource = new ArticuloServices().ObtenerTodosLosArticulos();
            txtIdComboboxArticulo.DisplayMember = "Nombre";
            txtIdComboboxArticulo.ValueMember = "Id";

            txtComboBoxDeposito.DataSource = new DepositoServices().ObtenerTodosLosDepositos();
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

                // Agrega el nuevo registro de stock a la base de datos
                int resultado = _stockService.AgregarStock(nuevoStock);
                if (resultado >= 1)
                {
                    MessageBox.Show("Registro de stock agregado correctamente a la base de datos.");
                }
                else
                {
                    MessageBox.Show("Error al agregar el registro de stock a la base de datos.");
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
    }
}








