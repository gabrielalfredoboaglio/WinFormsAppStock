using CodigoComun.Modelos.DTO;
using CodigoComun.Models;
using CodigoComun.Negocio;
using CodigoComun.Repository;
using System;
using System.Windows.Forms;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositoABM : Form
    {

        public bool EstoyModificando { get; set; }

        public DepositoABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }

        public DepositoABM(int idDepositoAModificar)
        {
            InitializeComponent();
            CargarDatosDepositoParaModificar(idDepositoAModificar);
            EstoyModificando = true;
        }

        private void CargarDatosDepositoParaModificar(int idDepositoAModificar)
        {
            DepositoService depositoServices = new DepositoService();
            DepositoDTO depositoConDatosDeLaBaseDeDatos = depositoServices.ObtenerDepositoPorId(idDepositoAModificar);

            if (depositoConDatosDeLaBaseDeDatos != null)
            {
                txtIdDeposito.Text = depositoConDatosDeLaBaseDeDatos.Id.ToString();
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
            DepositoService depositoServices = new DepositoService();

            // Crear un objeto DepositoDTO y establecer sus propiedades
            DepositoDTO depositoAModificar = new DepositoDTO();
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

            // Llamar al método ModificarDeposito y pasar el objeto DepositoDTO como argumento
            DepositoDTO resultado = depositoServices.ModificarDeposito(depositoAModificar);

            // Manejar el resultado de la actualización
            if (!resultado.HuboError)
            {
                MessageBox.Show(resultado.Mensaje);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (EstoyModificando)
            {
                ModificarDeposito();
            }
            else
            {
                DepositoDTO depositoDTOAAgregar = new DepositoDTO();
                depositoDTOAAgregar.Nombre = txtNombre.Text;
                depositoDTOAAgregar.Direccion = txtDireccion.Text;
                depositoDTOAAgregar.Capacidad = Convert.ToDecimal(txtCapacidad.Text);

                DepositoService depositoServices = new DepositoService();
                var resultado = depositoServices.AgregarDeposito(depositoDTOAAgregar);

                if (!resultado.HuboError)
                {
                    MessageBox.Show(resultado.Mensaje);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje);
                }
            }
        }

        public DepositoDTO AgregarDeposito(DepositoDTO depositoDTOAAgregar)
        {
            DepositoRepository depositoRepository = new DepositoRepository();

            try
            {
                // Obtener un objeto Deposito a partir del objeto DepositoDTO
                var deposito = depositoDTOAAgregar.GetDeposito(depositoDTOAAgregar);

                // Agregar el nuevo depósito a la base de datos
                int resultado = depositoRepository.AddDeposito(deposito);

                // Manejar el resultado de la operación
                if (resultado == 1)
                {
                    depositoDTOAAgregar.Mensaje = "Depósito agregado correctamente a la base de datos.";
                    return depositoDTOAAgregar;
                }
                else
                {
                    depositoDTOAAgregar.HuboError = true;
                    depositoDTOAAgregar.Mensaje = "Error al agregar el depósito a la base de datos.";
                    return depositoDTOAAgregar;
                }
            }
            catch (Exception ex)
            {
                depositoDTOAAgregar.HuboError = true;
                depositoDTOAAgregar.Mensaje = $"Hubo una excepción dando de alta el depósito: {ex.Message}";
                return depositoDTOAAgregar;
            }
        }

    }
}






