using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigame_breakout
{
    public partial class FormPvP : Form
    {
        #region properties
        public FormPvP()
        {
            InitializeComponent();
            setDefault();
        }
        #endregion

        #region key_mouse_events
        private void Pause(object sender, EventArgs e)
        {
            //timer1.Stop();
            //TimeLeft.Stop();
        }
        private void Resume(object sender, EventArgs e)
        {
            //timer1.Start();
            //TimeLeft.Start();
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
            //if (PauseButton.Tag != null)
            //{
            //    if (PauseButton.Tag.ToString() == "pause")
            //    {
            //        PauseButton.BackgroundImage = Properties.Resources.resume;
            //        PauseButton.Tag = "resume";
            //        Pause(sender, e);
            //    }
            //    else if (PauseButton.Tag.ToString() == "resume")
            //    {
            //        PauseButton.BackgroundImage = Properties.Resources.pause;
            //        PauseButton.Tag = "pause";
            //        Resume(sender, e);
            //    }
            //}

        }

        private void FormPvP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && this.player2.Left > 0)
            {
                player2.GoLeft = true;
                player2.GoRight = false;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.S) && (this.player2.Left + player2.Width) < ClientSize.Width)
            {
                player2.GoRight = true;
                player2.GoLeft = false;
            }
            else if (e.KeyCode == Keys.Space)
            {
                player2.IsBouncing = true;
            }
        }

        private void FormPvP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player2.GoLeft = false;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.S)
                player2.GoRight = false;
            else if (e.KeyCode == Keys.Space)
            {
                player2.IsBouncing = false;
            }
        }

        private void FormPvP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                player1.IsBouncing = true;
        }

        private void FormPvP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X - player1.Width / 2 > player1.Location.X + 7)
            {
                player1.GoRight = true;
                player1.GoLeft = false;
            }
            else if (e.Location.X - player1.Width / 2 < player1.Location.X - 7)
            {
                player1.GoLeft = true;
                player1.GoRight = false;
            }
            else
            {
                player1.GoLeft = false;
                player1.GoRight = false;
            }
        }

        private void FormPvP_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                player1.IsBouncing = false;
        }
        #endregion

        #region timer_tick_events
        private void timerBall_Tick(object sender, EventArgs e)
        {
            ball.move();
            updateBallSpeed();
            ball.collision_Player(player1);
            ball.collision_Player(player2);
            ball.collision_Wall(ClientSize.Width);
            //fall out
            if (ball.fall_Out_Down(ClientSize.Height))
            {
                this.Controls.Remove(ball);
                if (player1.lostLife())
                    player1LoseStage();
                else
                {
                    BallPvP otherBall = new BallPvP();
                    otherBall.Size = new System.Drawing.Size(22, 22);
                    otherBall.reverseY();
                    otherBall.Location = new Point(player1.Location.X + player1.Width / 2, player1.Location.Y - constant.ballHeight - 1);
                    this.ball = otherBall;
                    this.Controls.Add(otherBall);
                }
            }
            if (ball.fall_Out_Up())
            {
                this.Controls.Remove(ball);
                if (player2.lostLife())
                    player2LoseStage();
                else
                {
                    BallPvP otherBall = new BallPvP();
                    otherBall.Size = new System.Drawing.Size(22, 22);
                    otherBall.Location = new Point(player2.Location.X + player2.Width / 2, player2.Location.Y + constant.ballHeight + 1);
                    this.ball = otherBall;
                    this.Controls.Add(otherBall);
                }
            }
        }
        private void timerPlayer1_Tick(object sender, EventArgs e)
        {
            player1.move();
            player1.collision_Wall(ClientSize.Width);
            labelLife1.Text = player1.Life.ToString() + "x";
        }
        private void timerPlayer2_Tick(object sender, EventArgs e)
        {
            player2.move();
            player2.collision_Wall(ClientSize.Width);
            labelLife2.Text = player2.Life.ToString() + "x";
        }
        #endregion

        #region function
        private void setDefault()
        {
            this.DoubleBuffered = true;
            labelLife1.BackColor = Color.Transparent;
            labelLife2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            labelSpeed.BackColor = Color.Transparent;
        }
        private void player1LoseStage()
        {
            labelLife1.Text = "0x";
            disabledTimer();
            MessageBox.Show("player 2 win");
        }
        private void player2LoseStage()
        {
            labelLife2.Text = "0x";
            disabledTimer();
            MessageBox.Show("player 1 win");
        }
        private void disabledTimer()
        {
            timerBall.Enabled = false;
            timerPlayer1.Enabled = false;
            timerPlayer2.Enabled = false;
        }
        private void stopTimer()
        {
            timerBall.Stop();
            timerPlayer1.Stop();
            timerPlayer2.Stop();
        }
        private void startTimer()
        {
            timerBall.Start();
            timerPlayer1.Start();
            timerPlayer2.Start();
        }
        private void updateBallSpeed()
        {
            if (ball.Speed > 11) labelSpeed.ForeColor = Color.Red;
            labelSpeed.Text = "Ball speed: " + (float)(Math.Round(ball.Speed, 2));
        }
        #endregion
    }
}
