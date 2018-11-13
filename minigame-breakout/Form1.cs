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
    public partial class Form1 : Form
    {
        #region properties
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            setDefault();
            //this.timer1.Interval = 100;
        }
        #endregion

        #region key_mouse_events
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && this.Player.Left > 0)
            {
                Player.GoLeft = true;
                Player.GoRight = false;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.S) && (this.Player.Left + Player.Width) < ClientSize.Width)
            {
                Player.GoRight = true;
                Player.GoLeft = false;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                Player.GoLeft = false;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.S)
                Player.GoRight = false;
        }
        #endregion

        #region timerTickEvent
        private void timer1_Tick(object sender, EventArgs e)
        {
            //banh di chuyen
            Ball.move();
            //cap nhat score
            labelScore.Text = "Score: " + score;
            //di chuyen player
            Player.move();
            //player va cham tuong
            Player.collision_Wall(ClientSize.Width);
            //banh va cham voi tuong
            Ball.collision_Wall(ClientSize.Width);
            //banh roi ra ngoai
            if (Ball.fall_Out(ClientSize.Height))
            {
                //loseStage();
                this.timer1.Enabled = false;
                this.Controls.Clear();
                MessageBox.Show("you lose");
            }
            //banh va cham voi block
            foreach (Control x in this.Controls)
            {
                if (x is Block)
                {
                    if (Ball.collision_Block(x as Block))
                    {
                        score++;
                        this.Controls.Remove(x);
                    }
                }
                if (score> 34)
                {
                    this.timer1.Enabled = false;
                    this.Controls.Clear();
                    score = 0;
                    //winStage();
                    MessageBox.Show("you win!");
                }
            }
            //xu ly banh va cham voi player
            Ball.collision_Player(Player);
        }
        #endregion

        #region functions
        private void setDefault()
        {
            foreach (Control x in this.Controls)
            {
                if (x is Block && x.Width > constant.ballHeight)
                {
                    x.Tag = "block";
                }
            }

            Random rnd = new Random();
            foreach (Control x in this.Controls)
            {
                if (x is Block)
                {
                    Color rndColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    x.BackColor = rndColor;
                }
            }
            this.KeyPreview = true;
        }
        #endregion
    }
}
