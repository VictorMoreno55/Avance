using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EL_QUE_SEA
{
    public partial class Form1 : Form
    {
        Acciones Acciones = new Acciones();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Acciones.ExportarExcel())
                MessageBox.Show("Exportando con exito...");
            else
                MessageBox.Show("Fallo el exportando..-");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            dgDatos.DataSource = Acciones.Mostrar();
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            if (Acciones.ImportarExcel())
                MessageBox.Show("Importado con exito...");
            else
                MessageBox.Show("Fallo al Importar..-");
        }
    }
}
