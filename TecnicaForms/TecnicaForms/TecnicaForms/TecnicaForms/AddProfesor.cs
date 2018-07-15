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
    public partial class AddProfesor : Form
    {
        public bool editar = false;
        public Profesor profesorAEditar;
        public int cantidadMaterias = 0;
        public string id = "";
        public AddProfesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddProfesor_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                txbUsuario.Text = profesorAEditar.usuario;
                txbClave.Text = profesorAEditar.clave;
                txbNombre.Text = profesorAEditar.nombre;
                cantidadMaterias = profesorAEditar.cantidadMaterias;
                id = profesorAEditar.id;
            }
        }

   
        //Exit button
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
                AdminTeacherList ATL = new AdminTeacherList();
                ATL.Show();
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
            res += sYear + sMonth + sDay + RandomString(5) + "P";

            return res;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                Profesor profe = new Profesor();
                profe.nombre = txbNombre.Text;
                profe.clave = txbClave.Text;
                profe.usuario = txbUsuario.Text;
              

                DialogResult dialog = MessageBox.Show("Esta seguro que desea guardar estos datos?", "Guardar", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    Datos data = new Datos();
                if (!editar)
                {
                    profe.id = generadorID();
                    data.agregarProfesor(profe);
                }
                else
                {
                    List<Profesor> profes = new List<Profesor>();
                    data.cargarProfesores();
                    profe.id = id;
                    profe.cantidadMaterias = cantidadMaterias;
                    profes = data.obtenerProfesor();
                    data.editarProfesor(profes.Find(x => x.id == id), profe);
                }
                    this.Close();
                    AdminTeacherList ATL = new AdminTeacherList();
                    ATL.Show();
                }
            
        }

    }
}
