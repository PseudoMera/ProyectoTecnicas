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
    public partial class AdminSubjectsList : Form
    {
        int indice = 0;
        public string usuarioActual;
        public AdminSubjectsList()
        {
            InitializeComponent();
        }

        //Informacion personal listbox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Salir button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas seguro de que deseas salir?", "Salir", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                this.Close();
                AdminStudentsMenu ASM = new AdminStudentsMenu();
                ASM.Show();
            }
            
        }
        

        //Minimize button
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AdminSubjectsList_Load(object sender, EventArgs e)
        {
            //Materia - Codigo - Profesor - Creditos - Calificacion - Puntos
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
              //  listBox1.Items.Add(estu.cantidadMaterias);

                if (estu.usuario == usuarioActual)
                {
                    lblNombre.Text = estu.nombre;
                    lblApellido.Text = estu.apellido;
                    lblCarrera.Text = estu.carrera;
                    lblID.Text = estu.id.ToString();
                    var s = objeto.Element("Materias").Value;

                    if (primero)
                    {
                        double resultado = 0.0;
                        int creds = 0;
                        for (int i = 0; i < estu.cantidadMaterias; i++)
                        {
                            // listBox1.Items.Add(xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value);
                            DataGridViewRow nuevaFila = new DataGridViewRow();
                            DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Codigo").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Profesor").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            dgvMateria.Rows.Add(nuevaFila);
                          //  resultado += Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value) * Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value);
                          //  creds += Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value);
                        }
                       // resultado /= creds;
                        //lablgn.Text = resultado.ToString();
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
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Codigo").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Profesor").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            nuevaCelda = new DataGridViewTextBoxCell();
                            nuevaCelda.Value = xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value;
                            nuevaFila.Cells.Add(nuevaCelda);
                            dgvMateria.Rows.Add(nuevaFila);
                          //  resultado += Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value) * Convert.ToDouble(xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value);
                           // creds += Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value);
                        }
                      //  resultado /= creds;
                      //  lablgn.Text = resultado.ToString();
                    }
                   // estudianteActual = estu;
                }
                primero = false;
            }

        }

        private void dgvMateria_SelectionChanged(object sender, EventArgs e)
        {
            indice = dgvMateria.CurrentCell.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Height = this.Height + panelCalificacion.Height;
            this.MinimumSize = new Size(this.Width, this.Height);
            lblMateriaNombre.Text = dgvMateria.Rows[indice].Cells[0].Value.ToString();
            lblCodigo.Text = dgvMateria.Rows[indice].Cells[1].Value.ToString();
            lblCredito.Text = dgvMateria.Rows[indice].Cells[3].Value.ToString();
            lblMateriaNombre.Text = dgvMateria.Rows[indice].Cells[4].Value.ToString();
            panelCalificacion.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

           this.Height = this.Height - panelCalificacion.Height;
            this.MinimumSize = new Size(this.Width, this.Height);
            panelCalificacion.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
