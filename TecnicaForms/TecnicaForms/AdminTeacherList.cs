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
        public int index = 0;
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
            Datos data = new Datos();
            data.cargarProfesores();
            List<Profesor> profesores = new List<Profesor>();
          
            profesores = data.obtenerProfesor();
            int counter = 0;
            string val = profesores.Count.ToString();
            foreach (Profesor profe in profesores)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = profe.id;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = profe.nombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = profe.cantidadMaterias.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                dgvProfesores.Rows.Add(nuevaFila);
            }
        }

        //Eliminar button
        private void button3_Click(object sender, EventArgs e)
        {

            Datos data = new Datos();

            Profesor aEliminar = new Profesor();
            List<Profesor> profesores = new List<Profesor>();
            data.cargarProfesores();
            profesores = data.obtenerProfesor();
            aEliminar = profesores.Find(x => x.id == dgvProfesores.Rows[index].Cells[0].Value.ToString());
            if (aEliminar.cantidadMaterias > 0)
            {
                MessageBox.Show("Ya el profesor tiene asignaturas asignadas, con lo cual no puede borrarla.");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Estas seguro que desea eliminar al profesor?", "Salir", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    data.elimiarProfesor(aEliminar);
                }
                dgvProfesores.Rows.Clear();
                dgvProfesores.Refresh();
                data.cargarProfesores();

                profesores = data.obtenerProfesor();
                int counter = 0;
                string val = profesores.Count.ToString();
                foreach (Profesor profe in profesores)
                {
                    DataGridViewRow nuevaFila = new DataGridViewRow();
                    DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = profe.id;
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = profe.nombre;
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = profe.cantidadMaterias.ToString();
                    nuevaFila.Cells.Add(nuevaCelda);
                    dgvProfesores.Rows.Add(nuevaFila);
                }
            }
        }

        //Add professor button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProfesor profesor = new AddProfesor();
            profesor.Show();
        }

        //Edit button
        private void button4_Click(object sender, EventArgs e)
        {

            //Implement here the actual edit
            //Before the dialogbox pops out
            this.Hide();
            Datos data = new Datos();
            data.cargarProfesores();
            List<Profesor> profes = new List<Profesor>();
            profes = data.obtenerProfesor();
            AddProfesor profesor = new AddProfesor();
            profesor.editar = true;
            profesor.profesorAEditar = profes.Find(x => x.id == dgvProfesores.Rows[index].Cells[0].Value.ToString());
            profesor.Show();
          
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

        private void dgvProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProfesores_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvProfesores.CurrentCell.RowIndex;
        }
    }
}
