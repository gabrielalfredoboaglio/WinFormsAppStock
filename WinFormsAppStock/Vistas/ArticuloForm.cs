using CodigoComun.Modelos;
using CodigoComun.Negocio;
using CodigoComun.Repository;
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
    public partial class ArticuloForm : Form
    {
        public ArticuloForm()
        {
            InitializeComponent();
            CargarArticulos();
        }
        private void CargarArticulos()
        {
            ArticuloService articuloServices = new ArticuloService();
            List<Articulo> articulos = articuloServices.ObtenerTodosLosArticulos();
            dgvArticulos.DataSource = articulos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloABM articulosABM = new ArticuloABM();
            articulosABM.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el Id del Articulo a eliminar
            int idArticulo = Convert.ToInt32(txtIdArticulo.Text);

            // Instanciar un objeto ArticuloRepository
            ArticuloRepository articuloRepository = new ArticuloRepository();

            // Llamar al método EliminarEnDb del objeto ArticuloRepository, pasando el Id del Articulo a eliminar
            int resultado = articuloRepository.EliminarEnDb(idArticulo);

            if (resultado != -1)
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show("El Articulo ha sido eliminado correctamente");
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show("Ha ocurrido un error al eliminar el Articulo");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int IdArticuloAmodificar = Convert.ToInt32(txtIdArticulo.Text);

            ArticuloABM articulosABMModoModificacion = new ArticuloABM(IdArticuloAmodificar);
            articulosABMModoModificacion.Show();
        }

      
    }
}
