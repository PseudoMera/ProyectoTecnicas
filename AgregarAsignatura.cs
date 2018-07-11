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
    public partial class AgregarAsignatura : Form
    {
        Datos data = new Datos();
        Materia mat;
        public Materia materiaAEditar = new Materia();
        public bool editar = false;
        public AgregarAsignatura()
        {
            InitializeComponent();
        }

        private void AgregarAsignatura_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                tbNombre.Text = materiaAEditar.materiaNombre;
                tbCodigo.Text = materiaAEditar.materiaCodigo;
                tbCreditos.Text = materiaAEditar.materiaCreditos.ToString();
                tbProfesor.Text = materiaAEditar.materiaProfesor;
            }
        }

        Point lastPoint;
        private void AgregarAsignatura_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
           
        }

        private void AgregarAsignatura_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        //Save button
        string nombre, codigo, profesor, creditos;
        private void button1_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            data.cargarMaterias();
            mat = new Materia();
            mat.materiaCodigo = tbCodigo.Text;
            mat.materiaCreditos = Convert.ToInt32(tbCreditos.Text);
            mat.materiaProfesor = tbProfesor.Text;
            mat.materiaNombre = tbNombre.Text;
            mat.estudiantes = new List<Estudiante>();
            mat.cantidadEstudiante = 0;
           // data.guardarMaterias(mat);
            DialogResult dialog = MessageBox.Show("Quieres guardar esta informacion?", "save", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                if (editar)
                {
                    data.editarMateria(materiaAEditar, mat);
                    MessageBox.Show("Si edito", "save", MessageBoxButtons.YesNo);
                }
                else
                {
                    data.agregarMateria(mat);
                }
            }

            this.Close();
            AdminMenuSubjects AMS = new AdminMenuSubjects();
            AMS.Show();

        }
        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMenuSubjects AMS = new AdminMenuSubjects();
            AMS.Show();
        }
    }
}
