using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace login
{
    public partial class SubjectsList : Form
    {
        private static List<Materia> materiasSeleccionadas = new List<Materia>();
        List<Materia> materiasDisponibles = new List<Materia>();
        List<Materia> materiaSeleccionada = new List<Materia>();
        public int index = 0;
        public SubjectsList()
        {
            InitializeComponent();
        }

        private void SubjectsList_Load(object sender, EventArgs e)
        {
            Datos data = new Datos();
            data.cargarMaterias();
            materiasDisponibles = data.obtenerMaterias();
            int counter = 0;
            foreach (Materia mat in materiasDisponibles)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaId;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
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
                dgvMaterias.Rows.Add(nuevaFila);
            }
            materiasSeleccionadas.Clear();
        }     

        //Save button
 

        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            //Displays a textbox to confirm that the user indeed wants to close the app
            DialogResult dialog = MessageBox.Show("Estas seguro de que deseas salir?", "Salir", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Allows to move the subjects list when clicking on it
        Point lastPoint;

        internal static List<Materia> MateriasSeleccionadas { get => materiasSeleccionadas; set => materiasSeleccionadas = value; }

        private void SubjectsList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void SubjectsList_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //Allows to move the subjects list when clicking on it
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

        //Minimize button
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaterias_SelectionChanged(object sender, EventArgs e)
        {
            //materia, codigo,creditos, profesor
            index = dgvMaterias.CurrentCell.RowIndex;
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Displays a textbox to confirm that the user indeed wants to close the app
            DialogResult dialog = MessageBox.Show("Estas seguro que deseas guardar las materias seleccionadas?", "Guardar", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Materia materiaAGuardar = new Materia();
            materiaAGuardar.materiaId = dgvMaterias.Rows[index].Cells[0].Value.ToString();
            materiaAGuardar.materiaNombre = dgvMaterias.Rows[index].Cells[1].Value.ToString();
            materiaAGuardar.materiaCodigo = dgvMaterias.Rows[index].Cells[2].Value.ToString();
            materiaAGuardar.materiaCreditos = Convert.ToInt32(dgvMaterias.Rows[index].Cells[3].Value);
            materiaAGuardar.materiaProfesor = dgvMaterias.Rows[index].Cells[4].Value.ToString();
            materiaAGuardar.letra = "Z";
            dgvMaterias.Rows[index].DefaultCellStyle.BackColor = Color.LightBlue;
            if (materiasSeleccionadas == null)
                materiasSeleccionadas = new List<Materia>();

            materiasSeleccionadas.Add(materiaAGuardar);
        }

        private void dgvMaterias_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
