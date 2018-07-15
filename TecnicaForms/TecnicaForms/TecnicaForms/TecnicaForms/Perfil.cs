using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace login
{
    public partial class Perfil : Form
    {
        public string usuarioActual;
        public Perfil()
        {
            InitializeComponent();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cerrar sesión", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LogIn log = new LogIn();
                log.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditarDatos dts = new EditarDatos();
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            dts.estudianteAEditar = estudiantes.Find(x => x.usuario == usuarioActual);
            dts.ShowDialog();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            Estudiante estu = estudiantes.Find(x => x.usuario == usuarioActual);
            lblNombre.Text = estu.nombre;
            lblApellido.Text = estu.apellido;
            lblCarrera.Text = estu.carrera;
            int valor = 0;
            int totalCreditos = 0;
            foreach(Materia mat in estu.Materias)
            {

                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCodigo;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaNombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaProfesor;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCreditos.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaNota.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.calificacion.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                if(mat.letra.ToString() != null)
                nuevaCelda.Value = mat.letra.ToString();
                else
                    nuevaCelda.Value = "Z";
                nuevaFila.Cells.Add(nuevaCelda);
                dgvMateria.Rows.Add(nuevaFila);
                valor += mat.materiaCreditos * mat.calificacion;
                totalCreditos += mat.materiaCreditos;
            }
            double indice = valor * 1.0 / totalCreditos * 1.0;
            if(indice >= 3.8)
            {
                lblGrado.Text = "Summa Cum Laude";
            }else if(indice >= 3.5 && indice < 3.8)
            {
                lblGrado.Text = "Magna Cum Laude";
            }
            else if (indice >= 3.2 && indice < 3.5)
            {
                lblGrado.Text = "Cum Laude";
            }
            else
            {
                lblGrado.Text = "Sin Honor";
            }
            lblInd.Text = indice.ToString();
        }

        //Indice trimestral
        private void label9_Click(object sender, EventArgs e)
        {

        }
        //Indice general
        private void lablgn_Click(object sender, EventArgs e)
        {
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        //Minimize button
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        private void Perfil_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Perfil_MouseDown(object sender, MouseEventArgs e)
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

        //Contactar button
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Si tienes alguna duda escribenos a este correo: JAVAC@javacdesign.com",
                "Contactar",
                MessageBoxButtons.OK);      
            
        }

        private void Perfil_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.PNG | All files(*.*) | *.*";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Estudiante student = new Estudiante();
              
                string selectedFile = openFileDialog1.FileName;
                //Saving image as base64 to save it in json
                using (Image image = Image.FromFile(selectedFile))
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        image.Save(memory, image.RawFormat);
                        byte[] imageBytes = memory.ToArray();
                        string base64 = Convert.ToBase64String(imageBytes);
                        student.profilePicture = base64;
                    }
                }
                    pictureBox1.Image = Image.FromFile(selectedFile);
            }
        }
    }
}
