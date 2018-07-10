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
    public partial class AddProfesor : Form
    {
        public AddProfesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddProfesor_Load(object sender, EventArgs e)
        {

        }

        //Save button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro que desea guardar estos datos?", "Guardar", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Exit button
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
