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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        //Subject button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminMenuSubjects AMS = new AdminMenuSubjects();
            AMS.Show();
        }

        //Exit button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn log = new LogIn();
            log.Show();
        }

        //Students button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminStudentsMenu studentsMenu = new AdminStudentsMenu();
            studentsMenu.Show();
        }

        //Minimize button
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        //Allows us to move the app to the position we desire
        Point lastPoint;
        private void AdminMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AdminMenu_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void AdminMenu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        //Professors list button
        private void button5_Click(object sender, EventArgs e)
        {
            AdminTeacherList adminTeacherList = new AdminTeacherList();
            this.Close();
            adminTeacherList.Show();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            StudentRanking SR = new StudentRanking();
            SR.Show();
        }
    }
}
