using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace login
{
    public partial class AdminStudentsMenu : Form
    {
        int index = 0;
        List<Estudiante> estudiantesDisponibles = new List<Estudiante>();
        public AdminStudentsMenu()
        {
            InitializeComponent();
        }

        //Return the admin menu and exit the adminstudentsmenu
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMenu admin = new AdminMenu();
            admin.Show();        
        }

        //Ver estudiante button    
        private void button1_Click(object sender, EventArgs e)
        {
            //The button won't work unless the user has selected an item from the list
            
                this.Close();
            string elementos = dgvInformacion.Rows.Count.ToString();
            dgvInformacion.RowCount = 10;
                AdminSubjectsList ASL = new AdminSubjectsList();
            MessageBox.Show(dgvInformacion.Rows.Count.ToString(), "Delete", MessageBoxButtons.YesNo);
            ASL.usuarioActual = dgvInformacion.Rows[index].Cells[4].Value.ToString();
              
                //ASL.usuarioActual = "bant";
              
                ASL.Show();
           
        }

        //Borrar button
        private void button2_Click(object sender, EventArgs e)
        {
            //Here were are taking the index of the element the user clicks on

            //You should take the index and delete the element if this button is clicked
            
                DialogResult dialog = MessageBox.Show("Quiere eliminar este elemento?", "Delete", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    //You should implement the delete element here, I already did the If for you :)
                    //All you have to do is use the RemoveAt method the list has
                }
                

        }

        private void AdminStudentsMenu_Load(object sender, EventArgs e)
        {
            Datos data = new Datos();
            data.cargarEstudiantes();
            estudiantesDisponibles = data.obtenerEstudiantes();
            int counter = 0;
          //  var informacion = new BindingList<Estudiante>(estudiantesDisponibles);
            //dgvInformacion.DataSource = informacion;
           
            foreach (Estudiante mat in estudiantesDisponibles)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.id;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.nombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.apellido;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.carrera;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.cantidadMaterias;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.usuario;
                nuevaFila.Cells.Add(nuevaCelda);
                dgvInformacion.Rows.Add(nuevaFila);
                counter++;
            }     
        }

        //Minimize button
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //This allow us to move the app while holding the left mouse button
        Point lastPoint;
        private void AdminStudentsMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AdminStudentsMenu_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void dgvEstudiante_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvInformacion.CurrentCell.RowIndex;
        }
    }
}
