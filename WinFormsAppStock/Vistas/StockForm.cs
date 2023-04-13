using CodigoComun.Modelos;
using CodigoComun.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock = CodigoComun.Models.Stock;

namespace WinFormsAppStock.Vistas
{
    public partial class StockForm : Form
    {
      

        public StockForm()
        {
            InitializeComponent();

        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockABM stockABM = new StockABM();
            stockABM.Show();
        }

      
        }
    }


