using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopUhr
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private bool moved;
        private Point lastLocation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uhrzeitAnzeigen();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uhrzeitAnzeigen();
        }

        private void uhrzeitAnzeigen() {
            label1.Text = string.Format("{0:T}", System.DateTime.Now);        
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            moved = false;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                moved = true;
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (moved == false)
            {
                this.Close();
                // this.WindowState = FormWindowState.Minimized;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            // this.WindowState = FormWindowState.Minimized;
        }


    }
}
