﻿using System;
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
    public partial class Register : Form
    {
        List<Estudiante> estudiantes;
        Datos data = new Datos();
        List<Materia> materiasAGuardar;
        private static Estudiante estu;

        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Closes the register screen and opens the login screen
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn log = new LogIn();
            log.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            if (data.obtenerEstudiantes() != null)
            {
                estudiantes = data.obtenerEstudiantes();
            }
            else
            {
                estudiantes = new List<Estudiante>();
            }
        }

        //Allows the register screen to be moved around
        Point lastPoint;

        internal static Estudiante Estu { get => estu; set => estu = value; }

        private void Register_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //Allows the top panel of the register screen to be moved around
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

        //Seleccionar materia button
        private void button3_Click(object sender, EventArgs e)
        {
            SubjectsList subjectlist = new SubjectsList();
            subjectlist.Show();
            materiasAGuardar = new List<Materia>();
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
            res += sYear + sMonth + sDay + RandomString(5) + "E";

            return res;
        }

        //Register button
        private void button2_Click(object sender, EventArgs e)
        {
            estu = new Estudiante();
            estu.id = generadorID();
            estu.usuario = tbUsername.Text;
            estu.nombre = tbNombre.Text;
            estu.apellido = tbApellido.Text;
            estu.carrera = tbCarrera.Text;
            estu.contrasena = tbContrasena.Text;
            materiasAGuardar = new List<Materia>();
            materiasAGuardar = SubjectsList.MateriasSeleccionadas;
            estu.Materias = materiasAGuardar;
            estu.cantidadMaterias = materiasAGuardar.Count;
            data.agregarEstudiante(estu);
            foreach(Materia mate in materiasAGuardar)
            {
                Datos data = new Datos();
                data.cargarMaterias();
                List<Materia> materias = new List<Materia>();
                materias = data.obtenerMaterias();
                Materia prueba = materias.Find(x => x.materiaId == mate.materiaId);
                prueba.estudiantes.Add(estu);
                prueba.cantidadEstudiante++;
                data.editarMateria(materias.Find(x => x.materiaId == mate.materiaId), prueba);
            }

            MessageBox.Show("Felicidades! Te has registrado con exito");
            this.Close();
            LogIn log = new LogIn();
            log.Show();
        }

        //UserName Textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        //Minimize button
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Password Textbox
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            tbContrasena.PasswordChar = '*';
        }
        //Nombre textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //Apellidos textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //Carrera textbox
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
