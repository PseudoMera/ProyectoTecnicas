using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cerrar sesión", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) ;
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditarDatos dts = new EditarDatos();
            dts.ShowDialog();
        }
    }
}
