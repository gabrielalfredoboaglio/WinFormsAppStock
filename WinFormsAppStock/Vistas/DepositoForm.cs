using CodigoComun.Modelos;
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
            Deposito depositoAuxiliar = new Deposito();
            List<Deposito> depositoDeLaBaseDeDatos = depositoAuxiliar.GetTodosLosDepositos();
            dgvDepositos.DataSource = depositoDeLaBaseDeDatos;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DepositosABM depositosABM = new DepositosABM();
            depositosABM.Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            {
                {
                    int IdDepositoAmodificar = Convert.ToInt32(txtIdDeposito.Text);

                    DepositosABM depositosABMModoModificacion = new DepositosABM(IdDepositoAmodificar);
                    depositosABMModoModificacion.Show();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            DepositosABM depositosABM = new DepositosABM();
            depositosABM.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Obtener el Id del Deposito a eliminar
            int idDeposito = Convert.ToInt32(txtIdDeposito.Text);

            // Instanciar un objeto Deposito
            Deposito deposito = new Deposito();

            // Llamar al método EliminarEnDb del objeto Deposito, pasando el Id del Deposito a eliminar
            int resultado =deposito.EliminarEnDb(idDeposito);

            if (resultado != -1)
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show("El Deposito ha sido eliminado correctamente");
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show("Ha ocurrido un error al eliminar el Deposito");
            }
        }
    }
}
