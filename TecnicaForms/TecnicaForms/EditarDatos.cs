﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace login
{
    public partial class EditarDatos : Form
    {
       public  Estudiante estudianteAEditar;
        public string selectedFile = "";
        public EditarDatos()
        {
            InitializeComponent();
        }

        //Regresar button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void EditarDatos_Load(object sender, EventArgs e)
        {
            tbNombre.Text = estudianteAEditar.nombre;
            tbApellido.Text = estudianteAEditar.apellido;
            tbCarrera.Text = estudianteAEditar.carrera;
            tbUsuario.Text = estudianteAEditar.usuario;
            tbClave.Text = estudianteAEditar.contrasena;
        }

        //Guardar button
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Esta seguro de que desea realizar los siguientes cambios?",
                "Guardar", MessageBoxButtons.YesNo
                );

            //You have to implement the actual save
            if(dialog == DialogResult.Yes)
            {
                this.Close();
                Datos data = new Datos();
                data.cargarEstudiantes();
                List<Estudiante> estudiantes = new List<Estudiante>();
                estudiantes = data.obtenerEstudiantes();
                Estudiante nuevoEstudiante = new Estudiante();
                nuevoEstudiante = estudiantes.Find(x => x.id == estudianteAEditar.id);
                nuevoEstudiante.nombre = tbNombre.Text;
                nuevoEstudiante.apellido = tbApellido.Text;
                nuevoEstudiante.usuario = tbUsuario.Text;
                nuevoEstudiante.contrasena = tbClave.Text;
                nuevoEstudiante.carrera = tbCarrera.Text;

                data.editarEstudiante(estudiantes.Find(x => x.id == estudianteAEditar.id), nuevoEstudiante);

            }
        }

        private void EditarDatos_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void tbNombre_Validating(object sender, CancelEventArgs e)
        {
            string errormsg = "";
            Validacion valid = new Validacion();
            if (!valid.validarTexto(tbNombre.Text, out errormsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(tbNombre, errormsg);
            }
            else
            {
                e.Cancel = false;
                this.errorProvider1.Dispose();
            }

        }

        private void tbApellido_Validating(object sender, CancelEventArgs e)
        {

            string errormsg = "";
            Validacion valid = new Validacion();
            if (!valid.validarTexto(tbApellido.Text, out errormsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(tbApellido, errormsg);
            }
            else
            {
                e.Cancel = false;
                this.errorProvider1.Dispose();
            }

        }

        private void tbCarrera_Validating(object sender, CancelEventArgs e)
        {
            string errormsg = "";
            Validacion valid = new Validacion();
            if (!valid.validarTexto(tbCarrera.Text, out errormsg))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(tbCarrera, errormsg);
            }
            else
            {
                e.Cancel = false;
                this.errorProvider1.Dispose();
            }

        }


        private void button3_MouseEnter(object sender, EventArgs e)
        {
            tbClave.PasswordChar = '\0';
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            tbClave.PasswordChar = '*';
        }
    }
}
