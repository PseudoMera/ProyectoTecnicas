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
        public Estudiante estudianteActual = new Estudiante();
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
            dts.estudianteAEditar = estudianteActual;
            dts.ShowDialog();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            XElement xelement = XElement.Load(ruta + "\\estudiantes.xml");
            IEnumerable<XElement> elementos = xelement.Elements();
            int inicio = 0;
            bool primero = true;
            // Read the entire XML
            foreach (var objeto in elementos)
            {
                Estudiante estu = new Estudiante();
                estu.nombre = objeto.Element("Nombre").Value;
                estu.apellido = objeto.Element("Apellido").Value;
                estu.carrera = objeto.Element("Carrera").Value;
                estu.usuario = objeto.Element("Usuario").Value;
                estu.id = Convert.ToInt32(objeto.Element("ID").Value);
                estu.cantidadMaterias = Convert.ToInt32(objeto.Element("CantidadMateria").Value);
                inicio += estu.cantidadMaterias;
                listBox1.Items.Add(estu.cantidadMaterias);
               
                if (estu.usuario == usuarioActual)
                {
                    lblNombre.Text = estu.nombre;
                    lblApellido.Text = estu.apellido;
                    lblCarrera.Text = estu.carrera; var s = objeto.Element("Materias").Value;
                  
                    if (primero)
                    {
                        double resultado = 0.0;
                        int creds = 0;
                        for (int i = 0; i < estu.cantidadMaterias; i++)
                        {
                            // listBox1.Items.Add(xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value);
                            DataGridViewRow nuevaFila = new DataGridViewRow();
                            DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Codigo").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Profesor").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nota").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Letra").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            dgvMateria.Rows.Add(nuevaFila);
                            resultado += Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value) * Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value);
                            creds += Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value);
                        }
                        resultado /= creds;
                        lablgn.Text = resultado.ToString();
                    }
                    else
                    {
                        double resultado = 0.0;
                        int creds = 0;
                        for (int i = inicio - estu.cantidadMaterias; i < (--inicio + estu.cantidadMaterias); i++)
                        {
                            // listBox1.Items.Add(xelement.Descendants("Materia").ElementAt(i));
                            DataGridViewRow nuevaFila = new DataGridViewRow();
                            DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Codigo").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Profesor").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nota").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Letra").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            dgvMateria.Rows.Add(nuevaFila);
                            resultado += Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value) * Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value);
                            creds += Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value);
                        }
                        resultado /= creds;
                        lablgn.Text = resultado.ToString();
                    }
                    estudianteActual = estu;
                }
                primero = false;
            }
            
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
    }
}

// List<Materia> prueba = new List<Materia>(objeto.Element("Materias").Value.ToList());
// var materias = from materia in xelement.Elements("Estudiante")
//              where (string)materia.Element("Estudiante").Element("Usuario") == estudianteActual.nombre
//             select materia;

//    IEnumerable<XElement> asignaturas = materias.Elements();
//foreach (XElement xEle in xelement.Descendants("Materia"))
//  foreach(var asign in asignaturas)
// {
//    listBox1.Items.Add(asign);
//}
//foreach (var xEle in materias)
//{
/*DataGridViewRow nuevaFila = new DataGridViewRow();
DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
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
nuevaCelda.Value = mat.materiaNota;
nuevaFila.Cells.Add(nuevaCelda);
nuevaCelda = new DataGridViewTextBoxCell();
nuevaCelda.Value = mat.calificacion;
nuevaFila.Cells.Add(nuevaCelda);
nuevaCelda = new DataGridViewTextBoxCell();
nuevaCelda.Value = mat.letra;
nuevaFila.Cells.Add(nuevaCelda);
dgvMateria.Rows.Add(nuevaFila);*/
//  listBox1.Items.Add(xEle);
//}
// foreach(var mate in objeto.Element("Materias").Value)
//{
//  label8.Text = mate.Element("Materia").Value;
//}
