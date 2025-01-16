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
    
    public partial class btn_sound : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public btn_sound()
        {
            InitializeComponent();
            
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
        private void backToMenu_btn_MouseHover(object sender, EventArgs e)
        {
            backToMenu_btn.Image = Properties.Resources.Screenshot_39_removebg_preview;
        }

        private void backToMenu_btn_MouseLeave(object sender, EventArgs e)
        {
            backToMenu_btn.Image = Properties.Resources.Screenshot_38_removebg_preview;
        }

        private void backToMenu_btn_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
        }

        private void btn_play_MouseHover(object sender, EventArgs e)
        {
            btn_play.Image = Properties.Resources.Screenshot_16_removebg_preview;
        }

        private void btn_play_MouseLeave(object sender, EventArgs e)
        {
            btn_play.Image = Properties.Resources.Screenshot_9_removebg_preview;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void btn_sound_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btn_sound_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void btn_sound_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }
    }
}
