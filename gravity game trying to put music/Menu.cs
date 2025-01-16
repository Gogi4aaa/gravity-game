using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace gravity_game
{
    public partial class Menu : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        SoundPlayer sound = new SoundPlayer("gravityGuyLobbyMusic.wav");
        public Menu()
        {
            InitializeComponent();
            sound.Play();
        }

        private void btn_start_MouseHover(object sender, EventArgs e)
        {
            btn_start.Image = Properties.Resources.Screenshot_16_removebg_preview;
        }

        private void btn_Info_MouseHover(object sender, EventArgs e)
        {
            btn_Info.Image = Properties.Resources.Screenshot_18_removebg_preview;
        }

        private void btn_exit_MouseHover(object sender, EventArgs e)
        {
            btn_exit.Image = Properties.Resources.Screenshot_22_removebg_preview;
        }

        private void btn_start_MouseLeave(object sender, EventArgs e)
        {
            btn_start.Image = Properties.Resources.Screenshot_9_removebg_preview;
        }

        private void btn_Info_MouseLeave(object sender, EventArgs e)
        {
            btn_Info.Image = Properties.Resources.Screenshot_10_removebg_preview;
        }

        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            btn_exit.Image = Properties.Resources.Screenshot_11_removebg_preview;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            btn_sound options = new btn_sound();
            this.Hide();
            options.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
