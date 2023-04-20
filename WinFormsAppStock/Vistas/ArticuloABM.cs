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
    public partial class ArticuloABM : Form
    {
        public bool EstoyModificando { get; set; }

        private readonly ArticuloService articuloService;
        public ArticuloABM()
        {
            InitializeComponent();
            EstoyModificando = false;
            articuloService = new ArticuloService();
        }

        public ArticuloABM(int idArticuloAModificar)
        {
            InitializeComponent();
            CargarDatosArticuloParaModificar(idArticuloAModificar);
            EstoyModificando = true;
            articuloService = new ArticuloService();
        }

        private void CargarDatosArticuloParaModificar(int idArticuloAModificar)
        {
            ArticuloService articuloService = new ArticuloService();
            Articulo articuloConDatosDeLaBaseDeDatos = articuloService.GetArticuloPorId(idArticuloAModificar);

            if (articuloConDatosDeLaBaseDeDatos != null)
            {
                txtIdArticulo.Text = articuloConDatosDeLaBaseDeDatos.Id.ToString(); // <--- agregado
                txtNombre.Text = articuloConDatosDeLaBaseDeDatos.Nombre;
                txtMarca.Text = articuloConDatosDeLaBaseDeDatos.Marca;
                txtMinimoStock.Text = articuloConDatosDeLaBaseDeDatos.MinimoStock.ToString();
                txtProveedor.Text = articuloConDatosDeLaBaseDeDatos.Proveedor;
                txtPrecio.Text = articuloConDatosDeLaBaseDeDatos.Precio.ToString();
                txtCodigo.Text = articuloConDatosDeLaBaseDeDatos.Codigo; // <--- agregado
            }
            else
            {
                MessageBox.Show("No se pudo cargar el artículo para modificar.");
            }
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

            ArticuloService articuloServices = new ArticuloService();
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
            Articulo articuloAModificar = new Articulo();
            articuloAModificar.Id = Convert.ToInt32(txtIdArticulo.Text);
            articuloAModificar.Nombre = txtNombre.Text;
            articuloAModificar.Marca = txtMarca.Text;
            articuloAModificar.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
            articuloAModificar.Proveedor = txtProveedor.Text;
            articuloAModificar.Precio = Convert.ToDecimal(txtPrecio.Text);

            ArticuloService articuloServices = new ArticuloService();
            string mensaje = articuloServices.ActualizarArticulo(articuloAModificar);

            if (mensaje == "Articulo Actualizado")
            {
                MessageBox.Show("Articulo modificado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error modificando articulo");
            }
        }

    }
}