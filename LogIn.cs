using Newtonsoft.Json;
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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //First picure
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Name of the app
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //UserName textbox && we are saving the username entered by the user to confirm if the one making the log in
        //request is the administrator of the platform
        string UserName;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UserName = tbUsuario.Text;
        }

        //Password textbox && we are saving the password entered by the user to confirm if the one making the log in
        //request is the administrator of the platform
        string password;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tbClave.PasswordChar = '*';
            password = tbClave.Text;
        }

        //Sign Up button
        //If we click the register button, we will hide the login screen and open the register one
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register1 = new Register();
            register1.Show();

        }

        //Log In button
        //We are checking if the password and the username matches the admin account
        //If it does not match, it clear the textbox
        //If it does, we continue to the admin menu
        private void button1_Click(object sender, EventArgs e)
        {
            if(UserName == "Admin")
            {
                this.Hide();
                AdminMenu admin = new AdminMenu();
                admin.Show();
                
            } else
            {
                Perfil perfil = new Perfil();
                perfil.usuarioActual = tbUsuario.Text;
                this.Hide();
                perfil.Show();
            }
            //THIS WILL CLEAN THE PASSWORD AND USERNAME TEXTBOX IF IT IS INCORRECT
            //THIS SHOULD BE KEPT ON THE BOTTOM OF THE METHOD
            tbUsuario.ResetText();
            tbClave.ResetText();
        }

        //Exit button (closes the entire app)
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimize button
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Allows the logIn design to be moved around
        private void LogIn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        Point lastPoint;
        //Allows the logIn design to be moved around
        private void LogIn_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //Black bar at the top
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //Allows the logIn design to be moved around from the top panel(purple one)
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        //Allows the logIn design to be moved around from the top panel(purple one)
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);

        }

        //Adds a very thin border to the form
        private void LogIn_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            /* string ruta = System.IO.Directory.GetCurrentDirectory();
             string prueba = System.IO.File.ReadAllText(ruta + "\\estudiantes.json");
             List<Estudiante> probando = JsonConvert.DeserializeObject<List<Estudiante>>(prueba);

            foreach(Estudiante estu in probando)
            {
                foreach(Materia mate in estu.Materias)
                    MessageBox.Show(mate.materiaNombre, "Salir", MessageBoxButtons.YesNo);
            }*/
            Datos data = new Datos();
            data.cargarEstudiantes();
            Estudiante estu = new Estudiante();
            estu.nombre = "Pedro";
            estu.apellido = "Cimarra";
            estu.usuario = "pedrox";
            estu.contrasena = "1221";
            estu.gradoHonor = "Summa Cum Laude";
            estu.id = 123;
            estu.indiceTrimestral = 3.8;
            estu.carrera = "Software";
            estu.cantidadMaterias = 1;
            List < Materia > lista = new List<Materia>();
            List<Estudiante> lisE = new List<Estudiante>();
            lisE.Add(new Estudiante()
            {
                nombre = "Pedro",
                apellido = "Cimarra",
                usuario = "pedrox",
                contrasena = "1221",
                gradoHonor = "Summa Cum Laude",
                id = 123,
                indiceTrimestral = 3.8,
                carrera = "Software",
                cantidadMaterias = 1

            });

            lista.Add(new Materia()
            {
                materiaNombre = "Sociales",
                materiaCodigo = "SOC-230",
                materiaCreditos = 4,
                materiaId = 12345,
                materiaNota = 90,
                materiaProfesor = "Sergio Lopez",
                calificacion = 92,
                letra = "A",
                cantidadEstudiante = 1,
                estudiantes = lisE
            });
            estu.Materias = lista;
            data.agregarEstudiante(estu);
            data.guardarEstudiantes();
        }
    }
}
