using CodigoComun.Models;
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
    public partial class DepositoForm : Form
    {
        public DepositoForm()
        {
            InitializeComponent();
            CargarDepositos();

        }

        private void CargarDepositos()
        {
            DepositoService depositoServices = new DepositoService();
            List<Deposito> depositoDeLaBaseDeDatos = depositoServices.ObtenerTodosLosDepositos();
            dgvDepositos.DataSource = depositoDeLaBaseDeDatos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepositoABM depositosABM = new DepositoABM();
            depositosABM.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                {
                    int IdDepositoAmodificar = Convert.ToInt32(txtIdDeposito.Text);

                    DepositoABM depositosABMModoModificacion = new DepositoABM(IdDepositoAmodificar);
                    depositosABMModoModificacion.Show();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            DepositoABM depositosABM = new DepositoABM();
            depositosABM.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Obtener el Id del Deposito a eliminar
            int idDeposito = Convert.ToInt32(txtIdDeposito.Text);

            // Instanciar un objeto DepositoServices
            DepositoService depositoServices = new DepositoService();

            // Llamar al método EliminarDeposito del objeto DepositoServices, pasando el Id del Deposito a eliminar
            string resultado = depositoServices.EliminarDeposito(idDeposito);

            if (resultado == "Articulo eliminado correctamente")
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show(resultado);
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show(resultado);
            }
        }
    }
    }
