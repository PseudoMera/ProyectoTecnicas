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
            Datos data = new Datos();
            List<Profesor> profesores = new List<Profesor>();
            data.cargarProfesores();
            profesores = data.obtenerProfesor();
            tbCreditos.Visible = true;
            label3.Visible = true;
            foreach (Profesor p in profesores)
            {
                cbbProfesores.Items.Add(p.nombre);
            }
            if (editar)
            {
                tbNombre.Text = materiaAEditar.materiaNombre;
                tbCodigo.Text = materiaAEditar.materiaCodigo;
                cbbProfesores.Text = materiaAEditar.materiaProfesor;
                tbCreditos.Visible = false;
                label3.Visible = false;
                tbCreditos.Text = materiaAEditar.materiaCreditos.ToString();
               
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
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string generadorID()
        {
            string res = "";
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            res += sYear + sMonth + sDay + RandomString(5) + "M";

            return res;
        }
        //Save button
        string nombre, codigo, profesor, creditos;
        private void button1_Click(object sender, EventArgs e)
        {
            Datos data = new Datos();
            data.cargarMaterias();
            if (editar)
            {
                mat = new Materia();
                mat = materiaAEditar;
                mat.materiaNombre = tbNombre.Text;
                mat.materiaCodigo = tbCodigo.Text;
                if (cbbProfesores.SelectedItem.ToString() == null)
                    mat.materiaProfesor = cbbProfesores.Text;
                else
                    mat.materiaProfesor = cbbProfesores.SelectedItem.ToString();
            }
            else
            {

                mat = new Materia();
                mat.materiaId = generadorID();
                mat.materiaCodigo = tbCodigo.Text;
                mat.materiaCreditos = Convert.ToInt32(tbCreditos.Text);
                if (cbbProfesores.SelectedItem == null)
                {
                    mat.materiaProfesor = cbbProfesores.Text;
                }
                else
                {
                    mat.materiaProfesor = cbbProfesores.SelectedItem.ToString();
                }
                List<Profesor> profes = new List<Profesor>();
                data.cargarProfesores();
                profes = data.obtenerProfesor();
                Profesor p = new Profesor();
                if (cbbProfesores.SelectedItem == null)
                {
                    p = profes.Find(x => x.id == cbbProfesores.Text);
                }
                else
                {
                    p = profes.Find(x => x.nombre == cbbProfesores.SelectedItem.ToString());
                }

                p.cantidadMaterias++;
                if (cbbProfesores.SelectedItem == null)
                {
                    data.editarProfesor(profes.Find(x => x.nombre == cbbProfesores.Text), p);
                }
                else
                {
                    data.editarProfesor(profes.Find(x => x.nombre == cbbProfesores.SelectedItem.ToString()), p);
                }
                mat.materiaNombre = tbNombre.Text;
                mat.estudiantes = new List<Estudiante>();
                mat.cantidadEstudiante = 0;

            }
            DialogResult dialog = MessageBox.Show("Quieres guardar esta informacion?", "save", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                if (editar)
                {
                    data.editarMateria(materiaAEditar, mat);
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
