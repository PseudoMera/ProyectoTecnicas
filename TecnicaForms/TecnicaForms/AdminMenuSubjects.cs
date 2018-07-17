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
    public partial class AdminMenuSubjects : Form
    {
        int index = 0;
        Datos data = new Datos();
        List<Materia> materias = new List<Materia>();

        public AdminMenuSubjects()
        {
            InitializeComponent();
        }

        //Agregar button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarAsignatura agregar = new AgregarAsignatura();
            agregar.Show();
            
        }
        //Editar button
        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            AgregarAsignatura agregar = new AgregarAsignatura();
            agregar.editar = true;

            agregar.materiaAEditar = new Materia();
            agregar.materiaAEditar = materias.Find(x => x.materiaCodigo == dgvMaterias.Rows[index].Cells[1].Value.ToString() && x.materiaProfesor == dgvMaterias.Rows[index].Cells[3].Value.ToString());
            agregar.Show();
        }
        //Salir button
        private void button3_Click(object sender, EventArgs e)
        {
            //Pops up a box that ask the user if he wants to exit the menu or no
            DialogResult dialog = MessageBox.Show("Estas seguro de que deseas salir?", "Salir", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
                AdminMenu AM = new AdminMenu();
                AM.Show();
            }
        }

        //Minimize button
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Allow us to move the app while holding left mouse button
        Point lastPoint;
        private void AdminMenuSubjects_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AdminMenuSubjects_MouseDown(object sender, MouseEventArgs e)
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
        
        private void AdminMenuSubjects_Load(object sender, EventArgs e)
        {
            Datos data = new Datos();
            data.cargarMaterias();
            if (materias == null)
                materias = new List<Materia>();

            materias = data.obtenerMaterias();
            int counter = 0;
            string val = materias.Count.ToString();
            foreach(Materia mat in materias)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaNombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCodigo;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCreditos.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaProfesor;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.estudiantes.Count.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                dgvMaterias.Rows.Add(nuevaFila);
            }
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminMenuSubjects_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void dgvMaterias_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvMaterias.CurrentCell.RowIndex;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
       
            Materia aEliminar = new Materia();
            aEliminar = materias.Find(x => x.materiaCodigo == dgvMaterias.Rows[index].Cells[1].Value.ToString() && x.materiaProfesor == dgvMaterias.Rows[index].Cells[3].Value.ToString());
            if (aEliminar.cantidadEstudiante > 0)
            {
                MessageBox.Show("Ya hay estudiantes registrados en esta materia, con lo cual no puede borrarla.");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Estas seguro que desea eliminar la materia?", "Salir", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    data.eliminarMateria(aEliminar);
                }
                dgvMaterias.Rows.Clear();
                dgvMaterias.Refresh();
                data.cargarMaterias();
                if (materias == null)
                    materias = new List<Materia>();

                materias = data.obtenerMaterias();
                int counter = 0;
                string val = materias.Count.ToString();
                foreach (Materia mat in materias)
                {
                    DataGridViewRow nuevaFila = new DataGridViewRow();
                    DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = mat.materiaNombre;
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = mat.materiaCodigo;
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = mat.materiaCreditos.ToString();
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = mat.materiaProfesor;
                    nuevaFila.Cells.Add(nuevaCelda);
                    nuevaCelda = new DataGridViewTextBoxCell();
                    nuevaCelda.Value = mat.estudiantes.Count.ToString();
                    nuevaFila.Cells.Add(nuevaCelda);
                    dgvMaterias.Rows.Add(nuevaFila);
                }
            }
        }
    }
}
