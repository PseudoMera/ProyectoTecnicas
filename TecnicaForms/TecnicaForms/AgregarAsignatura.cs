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
        public AgregarAsignatura()
        {
            InitializeComponent();
        }

        private void AgregarAsignatura_Load(object sender, EventArgs e)
        {

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
            mat = new Materia();
            mat.materiaCodigo = tbCodigo.Text;
            mat.materiaCreditos = Convert.ToInt32(tbCreditos.Text);
            mat.materiaProfesor = tbProfesor.Text;
            mat.materiaNombre = tbNombre.Text;

           // data.guardarMaterias(mat);
            DialogResult dialog = MessageBox.Show("Quieres guardar esta informacion?", "save", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                //Tu sabras lo que vas a hacer con esta data o si no me avisas porque desde 
                //mi perspectiva este tipo de cosas le tocaba a ustedes
                nombre = tbNombre.Text;
                codigo = tbCodigo.Text;
                profesor = tbProfesor.Text;
                creditos = tbCreditos.Text;
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
