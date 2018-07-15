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
        List<Estudiante> estudiantes = new List<Estudiante>();
        List<Materia> mates = new List<Materia>();
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
            Datos data = new Datos();
            data.cargarEstudiantes();

            estudiantes = data.obtenerEstudiantes();

            string ruta = System.IO.Directory.GetCurrentDirectory();

            var estu = estudiantes.Find(x => x.usuario == usuarioActual);
            lblNombre.Text = estu.nombre;
            lblApellido.Text = estu.apellido;
            lblCarrera.Text = estu.carrera;
            lblID.Text = estu.id.ToString();
            mates = estu.Materias;

            double resultado = 0.0;
            int creds = 0;
            foreach (Materia mat in mates)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaNombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCodigo;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaProfesor;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaCreditos.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.calificacion.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.materiaId.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                dgvMateria.Rows.Add(nuevaFila);
            }
        
        //  resultado /= creds;
        //  lablgn.Text = resultado.ToString();
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
            Estudiante estu = new Estudiante();
            estu.id = lblID.Text;
            estu.nombre = lblNombre.Text;
            estu.apellido = lblApellido.Text;
            estu.carrera = lblCarrera.Text;
            estu.usuario = usuarioActual;
            estu.contrasena = estudiantes.Find(x => x.usuario == usuarioActual).contrasena;
            List<Materia> mates = new List<Materia>();
            List<Materia> nuevasMates = new List<Materia>();
            mates = estudiantes.Find(x => x.usuario == usuarioActual).Materias;
            estu.cantidadMaterias = mates.Count();
            int valor = 0;
            int totalCreditos = 0;
            foreach (Materia mate in mates)
            {
                Materia nueva = new Materia();
                nueva = mate;
                if (mate.materiaId == dgvMateria.Rows[indice].Cells[5].Value.ToString())
                {
                    int nota = Convert.ToInt32(txbCalificacion.Text);
                    nueva.materiaNota = nota;
                    string letra = "";
                    int calif = 0;
                    if(nota >= 90)
                    {
                        letra = "A";
                        calif = 4;
                    }else if(nota >= 80 && nota < 89)
                    {
                        letra = "B";
                        calif = 3;
                    }else if(nota >= 70 && nota < 79)
                    {
                        letra = "C";
                        calif = 2;
                    }else if(nota >= 60 && nota < 69)
                    {
                        letra = "D";
                        calif = 1;
                    }
                    else
                    {
                        letra = "F";
                    }
                    nueva.letra = letra;
                    nueva.calificacion = calif;
                }
                nuevasMates.Add(mate);
                valor += mate.materiaCreditos * mate.calificacion;
                totalCreditos += mate.materiaCreditos;
            }

            double val = valor * 1.0 / totalCreditos * 1.0;
            estu.indiceTrimestral = val;
            estu.Materias = nuevasMates;
            Datos data = new Datos();
            data.cargarEstudiantes();

            DialogResult dialog = MessageBox.Show("Quieres guardar esta informacion?", "save", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                    data.editarEstudiante(estudiantes.Find(x => x.usuario == usuarioActual), estu);
            }

            panelCalificacion.Hide();
            txbCalificacion.Text = "0";

            dgvMateria.Rows.Clear();
            dgvMateria.Refresh();
            data.cargarMaterias();
            
            List<Materia> materias = data.obtenerMaterias();
            int counter = 0;
            foreach (Materia mate in materias)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.materiaNombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.materiaCodigo;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.materiaProfesor;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.materiaCreditos.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.calificacion.ToString();
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mate.materiaId;
                nuevaFila.Cells.Add(nuevaCelda);
                dgvMateria.Rows.Add(nuevaFila);
            }
        }
    }
}
