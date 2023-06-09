﻿using CodigoComun.Modelos.DTO;
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
            List<DepositoDTO> depositoDeLaBaseDeDatos = depositoServices.ObtenerTodosLosDepositos();
            dgvDepositos.DataSource = depositoDeLaBaseDeDatos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepositoABM depositosABM = new DepositoABM();
            depositosABM.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDeposito.Text))
            {
                MessageBox.Show("Por favor ingrese un ID de depósito válido.");
                return;
            }

            int IdDepositoAmodificar = Convert.ToInt32(txtIdDeposito.Text);
            DepositoABM depositosABMModoModificacion = new DepositoABM(IdDepositoAmodificar);
            depositosABMModoModificacion.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            DepositoABM depositosABM = new DepositoABM();
            depositosABM.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Validar que se haya ingresado un Id válido
            if (string.IsNullOrWhiteSpace(txtIdDeposito.Text))
            {
                MessageBox.Show("Debe ingresar un Id de Depósito válido.");
                return;
            }

            // Obtener el Id del Depósito a eliminar
            int idDeposito = Convert.ToInt32(txtIdDeposito.Text);

            // Instanciar un objeto DepositoServices
            DepositoService depositoServices = new DepositoService();

            // Llamar al método EliminarDeposito del objeto DepositoServices, pasando el Id del Depósito a eliminar
            DepositoDTO resultado = depositoServices.EliminarDeposito(idDeposito);

            if (resultado.Mensaje == "Depósito eliminado correctamente")
            {
                // Mostrar un mensaje de confirmación
                MessageBox.Show(resultado.Mensaje);
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show(resultado.Mensaje);
            }
        }


    }
}
