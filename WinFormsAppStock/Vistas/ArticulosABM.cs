using CodigoComun.Modelos;
using CodigoComun.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsAppStock.Vistas
{
    public partial class ArticulosABM : Form
    {

        public bool EstoyModificando { get; set; }

        private readonly ArticuloServices articuloService;
        public ArticulosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
            articuloService = new ArticuloServices();
        }


        public ArticulosABM(int idArticuloAModificar)
        {
            InitializeComponent();
            CargarDatosArticuloParaModificar(idArticuloAModificar);
            EstoyModificando = true;
            articuloService = new ArticuloServices();
        }

        private void CargarDatosArticuloParaModificar(int idArticuloAModificar)
        {
            Articulo articuloConDatosDeLaBaseDeDatos = articuloService.GetArticuloPorId(idArticuloAModificar);

            txtNombre.Text = articuloConDatosDeLaBaseDeDatos.Nombre;
            txtMarca.Text = articuloConDatosDeLaBaseDeDatos.Marca;
            txtMinimoStock.Text = articuloConDatosDeLaBaseDeDatos.MinimoStock.ToString();
            txtProveedor.Text = articuloConDatosDeLaBaseDeDatos.Proveedor;
            txtPrecio.Text = articuloConDatosDeLaBaseDeDatos.Precio.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (EstoyModificando == true)
            {
                ModificarArticulo();
            }
            else
            {
                this.AgregarArticulo();
            }


        }

    

        private void AgregarArticulo()
        {
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.Nombre = txtNombre.Text;
            nuevoArticulo.Marca = txtMarca.Text;
            nuevoArticulo.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
            nuevoArticulo.Proveedor = txtProveedor.Text;
            nuevoArticulo.Precio = Convert.ToDecimal(txtPrecio.Text);
            nuevoArticulo.Codigo = txtCodigo.Text;

            ArticuloServices articuloServices = new ArticuloServices();
            string mensaje = articuloServices.AgregarArticulo(nuevoArticulo);

            if (mensaje == "Articulo Agregado")
            {
                MessageBox.Show("Articulo agregado correctamente a la base de datos.");
            }
            else if (mensaje == null) // Manejar mensaje nulo
            {
                MessageBox.Show("Ocurrió un error al agregar el Articulo a la base de datos.");
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }


        private void ModificarArticulo()
        {
            Articulo ArticuloAModificar = new Articulo();
            ArticuloAModificar.Id = Convert.ToInt32(txtPrecio.Text); // ID del artículo a modificar obtenido del campo txtPrecio
            ArticuloAModificar.Nombre = txtNombre.Text;
            ArticuloAModificar.Marca = txtMarca.Text;
            ArticuloAModificar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
            ArticuloAModificar.Proveedor = txtProveedor.Text;
            ArticuloAModificar.Precio = Convert.ToDecimal(txtPrecio.Text);

            ArticuloServices articuloServices = new ArticuloServices();
            string mensaje = articuloServices.ActualizarArticulo(ArticuloAModificar);

            if (mensaje == "Articulo Actualizado")
            {
                MessageBox.Show("Articulo modificado con exito");
                this.Close(); // cierra la ventana después de modificar el artículo
            }
            else
            {
                MessageBox.Show("Error modificando articulo");
            }

        }
    }
}