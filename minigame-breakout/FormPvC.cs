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
    public partial class FormPvC : Form
    {
        #region properties
        private int hardlevel;
        public FormPvC()
        {
            InitializeComponent();
            setDefault();
        }
        public FormPvC(int level)
        {
            hardlevel = level;
        }
        #endregion

        #region key_mouse_events
        private void Pause(object sender, EventArgs e)
        {
            stopTimer();
        }
        private void Resume(object sender, EventArgs e)
        {
            startTimer();
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
            Home.Visible = !(Home.Visible);
            PauseName.Visible = !(PauseName.Visible);
            if (PauseButton.Tag != null)
            {
                if (PauseButton.Tag.ToString() == "pause")
                {
                    PauseButton.BackgroundImage = Properties.Resources.resume;
                    PauseButton.Tag = "resume";
                    Pause(sender, e);
                }
                else if (PauseButton.Tag.ToString() == "resume")
                {
                    PauseButton.BackgroundImage = Properties.Resources.pause;
                    PauseButton.Tag = "pause";
                    Resume(sender, e);
                }
            }
        }

        private void FormPvC_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && this.player.Left > 0)
            {
                player.GoLeft = true;
                player.GoRight = false;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.S) && (this.player.Left + player.Width) < ClientSize.Width)
            {
                player.GoRight = true;
                player.GoLeft = false;
            }
            else if (e.KeyCode == Keys.Space)
            {
                player.IsBouncing = true;
            }
        }

        private void FormPvC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                player.GoLeft = false;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.S)
                player.GoRight = false;
            else if (e.KeyCode == Keys.Space)
            {
                player.IsBouncing = false;
            }
        }

        private void FormPvC_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                player.IsBouncing = true;
        }

        private void FormPvC_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X - player.Width / 2 > player.Location.X + 7)
            {
                player.GoRight = true;
                player.GoLeft = false;
            }
            else if (e.Location.X - player.Width / 2 < player.Location.X - 7)
            {
                player.GoLeft = true;
                player.GoRight = false;
            }
            else
            {
                player.GoLeft = false;
                player.GoRight = false;
            }
        }

        private void FormPvC_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                player.IsBouncing = false;
        }
        #endregion

        #region timer_tick_events
        private void timerBall_Tick(object sender, EventArgs e)
        {
            ball.move();
            updateBallSpeed();
            ball.collision_Player(player);
            ball.collision_Computer(computer);
            ball.collision_Wall(ClientSize.Width);
            //fall out
            if (ball.fall_Out_Down(ClientSize.Height))
            {
                this.Controls.Remove(ball);
                if (player.lostLife())
                    playerLoseStage();
                else
                {
                    BallPvP otherBall = new BallPvP();
                    otherBall.Size = new System.Drawing.Size(22, 22);
                    otherBall.reverseY();
                    otherBall.Location = new Point(player.Location.X + player.Width / 2, player.Location.Y - constant.ballHeight - 1);
                    this.ball = otherBall;
                    this.Controls.Add(otherBall);
                }
            }
            if (ball.fall_Out_Up())
            {
                this.Controls.Remove(ball);
                if (computer.lostLife())
                    computerLoseStage();
                else
                {
                    BallPvP otherBall = new BallPvP();
                    otherBall.Size = new System.Drawing.Size(22, 22);
                    otherBall.Location = new Point(computer.Location.X + computer.Width / 2, computer.Location.Y + constant.ballHeight + 1);
                    this.ball = otherBall;
                    this.Controls.Add(otherBall);
                }
            }
            //colision_block
            ball.collision_Block(block31 as Block);
            ball.collision_Block(block33 as Block);
            ball.collision_Block(block32 as Block);
            block32.move(block31 as Block, ClientSize.Width);
            block32.move(block33 as Block, ClientSize.Width);
            block31.move(block32 as Block, ClientSize.Width);
            block31.move(block33 as Block, ClientSize.Width);
            block33.move(block31 as Block, ClientSize.Width);
            block33.move(block32 as Block, ClientSize.Width);
        }
        private void timerPlayer1_Tick(object sender, EventArgs e)
        {
            player.move();
            player.collision_Wall(ClientSize.Width);
            labelLife1.Text = player.Life.ToString() + "x";
        }
        private void timerPlayer2_Tick(object sender, EventArgs e)
        {
            computer.move(ball, player, ClientSize.Width, ClientSize.Height);
            computer.collision_Wall(ClientSize.Width);
            labelLife2.Text = computer.Life.ToString() + "x";
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
            PauseButton.BackColor = Color.Transparent;
            labelLevel.BackColor = Color.Transparent;
            DifficultLevel.BackColor = Color.Transparent;
            if (computer.HardLevel == 0) { labelLevel.Text = "Easy"; labelLevel.ForeColor = Color.Yellow; }
            if (computer.HardLevel == 1) { labelLevel.Text = "Normal"; labelLevel.ForeColor = Color.Orange; }
            if (computer.HardLevel == 2) { labelLevel.Text = "Difficult"; labelLevel.ForeColor = Color.Red; }

            this.GotFocus += new EventHandler(Resume);
            this.LostFocus += new EventHandler(Pause);
        }
        private void playerLoseStage()
        {
            disabledTimer();
            this.LostFocus -= new System.EventHandler(Pause);
            this.GotFocus -= new System.EventHandler(Resume);
            labelLife1.Text = "0x";
            MessageBox.Show("you have lose the computer, try better next time");
        }
        private void computerLoseStage()
        {
            disabledTimer();
            this.LostFocus -= new System.EventHandler(Pause);
            this.GotFocus -= new System.EventHandler(Resume);
            labelLife2.Text = "0x";
            MessageBox.Show("you have won the computer");
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
            else labelSpeed.ForeColor = Color.Black;
            labelSpeed.Text = "Ball speed: " + (float)(Math.Round(ball.Speed, 2));
        }
        #endregion

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartScreen ManHinh = new StartScreen();
            ManHinh.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void labelLevel_Click(object sender, EventArgs e)
        {

        }

        private void DifficultLevel_Click(object sender, EventArgs e)
        {

        }
        public void SetHardLevel(int HL)
        {
            computer.HardLevel = HL;
        }
    }
}
