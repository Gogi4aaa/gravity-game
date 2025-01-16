using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace gravity_game
{
    public partial class Form1 : Form
    {
        //veriables
        int gravity;
        int gravityValue = 8;
        int obstacleSpeed = 12;
        int coinSpeed = 12;
        int coinScore = 0;
        int coinHighScore = 0;
        int score = 0;
        int highScore = 0;
        bool gameOver = false;
        SoundPlayer sound = new SoundPlayer("gravityGuy.wav");
        Random random = new Random();
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
            RestartGame();
            sound.Play();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            labelScore.Text = "Score: " + score;
            labelHighScore.Text = "High Score: " + highScore;
            labelCoinsScore.Text = "Coins:" + coinScore;
            labelMaxCoins.Text = "Max Coins:" + coinHighScore;
            player.Top += gravity;

            //when the players land on the platforms.
            if (player.Top > 455)
            {
                gravity = 0;
                player.Top = 455;
                player.Image = Properties.Resources.run_down0;
            }
            else if (player.Top < 55)
            {
                gravity = 0;
                player.Top = 55;
                player.Image = Properties.Resources.run_up0;
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;


                    if (x.Left < -50)
                    {
                        x.Left = random.Next(1200, 2500);
                        score += 1;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        gameTimer.Stop();
                        labelScore.Text += " Game Over Press Enter to Restart!";
                        gameOver = true;
                        sound.Stop();
                        if (score > highScore)
                        {
                            highScore = score;
                        }
                        
                            coinHighScore += coinScore;
                    }
                }
            }
            foreach (Control y in this.Controls)
            {

                if (y is PictureBox && (string)y.Tag == "coin")
                {
                    y.Left -= coinSpeed;

                    if (player.Bounds.IntersectsWith(y.Bounds))
                    {
                        coinScore ++;
                        y.Left = random.Next(1300, 2500);
                    }
                    else if(y.Left < -50)
                    {
                        y.Left = random.Next(1300, 2500);
                    }

                }
            }


            if (score > 10)
            {
                obstacleSpeed = 20;
                gravityValue = 12;
                coinSpeed = 20;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (player.Top == 455)
                {
                    player.Top -= 10;
                    gravity = -gravityValue;
                }
                else if (player.Top == 55)
                {
                    player.Top += 10;
                    gravity = gravityValue;
                }
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }
        private void RestartGame()
        {
            labelScore.Parent = pictureBox1;
            labelHighScore.Parent = pictureBox2;
            labelHighScore.Top = 0;
            player.Location = new Point(180, 149);
            player.Image = Properties.Resources.run_down0;
            coinScore = 0;
            labelCoinsScore.Parent = pictureBox1;
            labelMaxCoins.Parent = pictureBox2;
            labelMaxCoins.Top = 0;
            score = 0;
            gravityValue = 8;
            gravity = gravityValue;
            obstacleSpeed = 12;
            coinSpeed = 12;
            sound.Play();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left = random.Next(1200, 2500);
                }
            }
            gameTimer.Start();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
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
        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
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
            //back to Game button settings
            foreach (Control x in this.Controls)
            {
                if(x.Bounds.IntersectsWith(player.Bounds) == true)
                {      
                    if (x is PictureBox && (string)x.Tag == "obstacle")
                    {
                        if (x.Bounds.IntersectsWith(player.Bounds))
                        {
                            Menu menu = new Menu();
                            this.Hide();
                            menu.ShowDialog();
                        }
                    }

                }
            }
        }
    }
}
