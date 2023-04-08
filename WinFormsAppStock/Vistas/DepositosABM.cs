using CodigoComun.Modelos;
using System;
using System.Windows.Forms;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositosABM : Form
    {

        public bool EstoyModificando { get; set; }

        public DepositosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }

        public DepositosABM(int idDepositoAModificar)
        {
            InitializeComponent();
            CargarDatosDepositoParaModificar(idDepositoAModificar);
            EstoyModificando = true;
        }

        private void CargarDatosDepositoParaModificar(int idDepositoAModificar)
        {
            Deposito depositoAuxiliar = new Deposito();
            Deposito depositoConDatosDeLaBaseDeDatos = depositoAuxiliar.GetDepositoPorId(idDepositoAModificar);

            if (depositoConDatosDeLaBaseDeDatos != null)
            {
                txtIdDeposito.Text = depositoConDatosDeLaBaseDeDatos.Id.ToString(); // <--- agregado
                txtNombre.Text = depositoConDatosDeLaBaseDeDatos.Nombre;
                txtDireccion.Text = depositoConDatosDeLaBaseDeDatos.Direccion;
                txtCapacidad.Text = depositoConDatosDeLaBaseDeDatos.Capacidad.ToString();
            }
            else
            {
                MessageBox.Show("No se pudo cargar el depósito para modificar.");
            }
        }

        private void ModificarDeposito()
        {
            // Crear un objeto Deposito y establecer sus propiedades
            Deposito depositoAModificar = new Deposito();
            depositoAModificar.Nombre = txtNombre.Text;
            depositoAModificar.Direccion = txtDireccion.Text;
            depositoAModificar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);

            // Verificar que el campo "txtIdDeposito" tenga un valor válido
            int idDeposito = 0;
            if (!int.TryParse(txtIdDeposito.Text, out idDeposito))
            {
                MessageBox.Show("El valor en el campo de ID de depósito no es válido.");
                return;
            }

            depositoAModificar.Id = idDeposito;

            // Llamar al método ActualizarEnDb y pasar el objeto Deposito como argumento
            Deposito depositoAuxiliar = new Deposito();
            int resultado = depositoAuxiliar.ActualizarEnDb(depositoAModificar);

            // Manejar el resultado de la actualización
            if (resultado == 1)
            {
                MessageBox.Show("Depósito modificado con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error modificando depósito.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarDeposito();
            }
            else
            {
                this.AgregarDeposito();
            }
        }
        private void AgregarDeposito()
        {
            Deposito nuevoDeposito = new Deposito();
            nuevoDeposito.Nombre = txtNombre.Text;
            nuevoDeposito.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            nuevoDeposito.Direccion = txtDireccion.Text;

            // Agrega el nuevo profesor a la base de datos
            int resultado = nuevoDeposito.AgregarEnDb();
            if (resultado >= 1)
            {
                MessageBox.Show("Profesor agregado correctamente a la base de datos.");
            }
            else
            {
                MessageBox.Show("Error al agregar el profesor a la base de datos.");
            }
        }
    }
}






