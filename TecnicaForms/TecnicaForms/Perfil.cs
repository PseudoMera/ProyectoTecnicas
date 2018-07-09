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
    public partial class Perfil : Form
    {
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
            dts.ShowDialog();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {

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
