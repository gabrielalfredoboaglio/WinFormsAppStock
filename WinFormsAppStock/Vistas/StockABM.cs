using CodigoComun.Modelos;
using CodigoComun.Negocio;
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

namespace WinFormsAppStock.Vistas
{
    public partial class StockABM : Form
    {

  
        public string TipoOperacion { get; set; }
        public bool EstoyModificando { get; set; }
        public int IdStockAModificar { get; set; }


        public StockABM()
        {

            InitializeComponent();
            CargarComboBoxes();

        }


        public StockABM(int idStockAModificar)
        {
            InitializeComponent();
            CargarComboBoxes();
            CargarDatosStockParaModificar(idStockAModificar);


            // Obtener el registro de stock existente y cargar los datos en los controles del formulario
            Stock stockExistente = new Stock().GetStockPorId(IdStockAModificar);
            txtIdComboboxArticulo.SelectedValue = stockExistente.ArticuloGuardado.Id;
            txtComboBoxDeposito.SelectedValue = stockExistente.DepositoDondeEstaGuardado.Id;
            txtCantidad.Text = stockExistente.Cantidad.ToString();
        }


        private void CargarComboBoxes()
        {
            // Cargar los datos de los ComboBoxes
            txtIdComboboxArticulo.DataSource = new ArticuloServices().ObtenerTodosLosArticulos();
            txtIdComboboxArticulo.DisplayMember = "Nombre";
            txtIdComboboxArticulo.ValueMember = "Id";

            txtComboBoxDeposito.DataSource = new Deposito().GetTodosLosDepositos();
            txtComboBoxDeposito.DisplayMember = "Nombre";
            txtComboBoxDeposito.ValueMember = "Id";
        }



        private void CargarDatosStockParaModificar(int idStockAModificar)
        {
            Stock stockAuxiliar = new Stock();

            Stock stockConDatosDeLaBaseDeDatos = stockAuxiliar.GetStockPorId(idStockAModificar);

            // Cargar los datos del stock en los controles de formulario correspondientes
            txtCantidad.Text = stockConDatosDeLaBaseDeDatos.Cantidad.ToString();
            txtIdComboboxArticulo.SelectedValue = stockConDatosDeLaBaseDeDatos.ArticuloGuardado.Id;
            txtComboBoxDeposito.SelectedValue = stockConDatosDeLaBaseDeDatos.DepositoDondeEstaGuardado.Id;
        }







        private void AgregarStock()
        {
            Stock nuevoStock = new Stock();
            nuevoStock.IdDeposito = Convert.ToInt32(txtComboBoxDeposito.SelectedValue);
            nuevoStock.IdArticulo = Convert.ToInt32(txtIdComboboxArticulo.SelectedValue);
            nuevoStock.ArticuloGuardado = new Articulo() { Id = nuevoStock.IdArticulo };
            nuevoStock.DepositoDondeEstaGuardado = new Deposito() { Id = nuevoStock.IdDeposito };
            decimal cantidad;
            if (decimal.TryParse(txtCantidad.Text, out cantidad))
            {
                // La conversión fue exitosa, la variable "cantidad" contiene el valor convertido
                nuevoStock.Cantidad = cantidad;

                // Resto del código para agregar el nuevo stock
            }
            else
            {
                // La conversión falló, la cadena de caracteres no tiene un formato válido
                MessageBox.Show("La cantidad ingresada no es válida");
            }


            // Agrega el nuevo registro de stock a la base de datos
            int resultado = nuevoStock.AgregarEnDb();
            if (resultado >= 1)
            {
                MessageBox.Show("Registro de stock agregado correctamente a la base de datos.");
            }
            else
            {
                MessageBox.Show("Error al agregar el registro de stock a la base de datos.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarStock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificarStock();

        }
        private void ModificarStock()
        {
            // Crear un objeto Articulo y establecer su propiedad Id
            Articulo articulo = new Articulo();
            articulo.Id = Convert.ToInt32(txtIdComboboxArticulo.SelectedValue);

            // Crear un objeto Stock y establecer sus propiedades
            Stock stockAModificar = new Stock();
            stockAModificar.IdDeposito = Convert.ToInt32(txtComboBoxDeposito.SelectedValue);
            stockAModificar.IdArticulo = articulo.Id;
            stockAModificar.ArticuloGuardado = articulo;
            stockAModificar.DepositoDondeEstaGuardado = new Deposito() { Id = stockAModificar.IdDeposito };

            // Verificar que el campo "txtIdStockModificar" tenga un valor válido
            if (!int.TryParse(txtIdStockModificar.Text, out int idStock))
            {
                MessageBox.Show("El valor en el campo de ID de stock no es válido.");
                return;
            }
            stockAModificar.Id = idStock;

            // Convertir el valor de "txtCantidad" en un número decimal
            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad))
            {
                MessageBox.Show("El valor en el campo de cantidad no es válido.");
                return;
            }
            stockAModificar.Cantidad = cantidad;

            // Actualizar el registro en la base de datos
            if (stockAModificar.ActualizarEnDb(stockAModificar) > 0)

            {
                MessageBox.Show("El stock se ha modificado correctamente.");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al modificar el stock.");
            }
        }
    }
}






