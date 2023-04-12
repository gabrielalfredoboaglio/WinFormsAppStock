using CodigoComun.Models;
using CodigoComun.Negocio;
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
            DepositoServices depositoServices = new DepositoServices();
            Deposito depositoConDatosDeLaBaseDeDatos = depositoServices.ObtenerDepositoPorId(idDepositoAModificar);

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
            DepositoServices depositoServices = new DepositoServices();

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
            int resultado = depositoServices.ModificarDeposito(depositoAModificar);

            if (resultado == 1)
            {
                Console.WriteLine("Depósito modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Error modificando depósito.");
            }


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
            DepositoServices depositoServices = new DepositoServices();

            Deposito nuevoDeposito = new Deposito();
            nuevoDeposito.Nombre = txtNombre.Text;
            nuevoDeposito.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            nuevoDeposito.Direccion = txtDireccion.Text;

            // Agrega el nuevo depósito a la base de datos
            int resultado = depositoServices.AddDeposito(nuevoDeposito);
            if (resultado >= 1)
            {
                MessageBox.Show("Depósito agregado correctamente a la base de datos.");
            }
            else
            {
                MessageBox.Show("Error al agregar el depósito a la base de datos.");
            }
        }
    }
    }






