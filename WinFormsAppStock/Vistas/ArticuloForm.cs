﻿using CodigoComun.Modelos.DTO;
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
            List<ArticuloDTO> articulosDTO = articuloServices.ObtenerTodosLosArticulos();
            dgvArticulos.DataSource = articulosDTO;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloABM articulosABM = new ArticuloABM();
            articulosABM.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(txtIdArticulo.Text);
            ArticuloService articuloService = new ArticuloService();
            ArticuloDTO resultado = articuloService.EliminarArticulo(idArticulo);

            if (resultado.Mensaje == "Articulo eliminado correctamente")
            {
                MessageBox.Show("El articulo se eliminó correctamente.");
            }
            else
            {
                MessageBox.Show("Hubo un error al eliminar el articulo.");
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
