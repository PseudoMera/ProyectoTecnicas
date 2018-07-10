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
    public partial class AdminTeacherList : Form
    {
        public AdminTeacherList()
        {
            InitializeComponent();
        }
           
        //Minimizes form
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AdminTeacherList_Load(object sender, EventArgs e)
        {

        }

        //Eliminar button
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro que desea realizar esta accion?", "Eliminar", MessageBoxButtons.YesNo);

            //Implement here the actual delete
            if (dialog == DialogResult.Yes)
            {
                
            }
        }

        //Add professor button
        private void button2_Click(object sender, EventArgs e)
        {
            AddProfesor profesor = new AddProfesor();
            profesor.Show();
        }

        //Edit button
        private void button4_Click(object sender, EventArgs e)
        {

            //Implement here the actual edit
            //Before the dialogbox pops out
            DialogResult dialog = MessageBox.Show("Esta seguro que desea realizar esta accion?", "Editar", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {

            }
        }

        //Exit button
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro de que desea salir?", "Salir", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.Show();
            }

        }
    }
}
