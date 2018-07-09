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
    public partial class EditarDatos : Form
    {
        public EditarDatos()
        {
            InitializeComponent();
        }

        //We open the directory and put the image in the picture box
        //We should save the image in a file and upload it in the perfil form
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.PNG | All files(*.*) | *.*";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(selectedFile);
            }
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
            }
        }

        private void EditarDatos_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
    }
}
