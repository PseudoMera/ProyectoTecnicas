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
    public partial class StudentRanking : Form
    {
        public StudentRanking()
        {
            InitializeComponent();
        }

        private void StudentRanking_Load(object sender, EventArgs e)
        {
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            estudiantes = estudiantes.OrderBy(x => x.indiceTrimestral).ToList();

            foreach(Estudiante mat in estudiantes)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                DataGridViewCell nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.id;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.nombre;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.apellido;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.carrera;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.cantidadMaterias;
                nuevaFila.Cells.Add(nuevaCelda);
                nuevaCelda = new DataGridViewTextBoxCell();
                nuevaCelda.Value = mat.indiceTrimestral;
                nuevaFila.Cells.Add(nuevaCelda);
                dgvInformacion.Rows.Add(nuevaFila);
            }
            dgvInformacion.Sort(dgvInformacion.Columns[5], ListSortDirection.Descending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
