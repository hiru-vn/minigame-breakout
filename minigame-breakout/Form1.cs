using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigame_breakout
{
    public partial class Form1 : Form
    {
        #region properties
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            setDefault();
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
            else if (e.KeyCode == Keys.Space)
            {
                Player.IsBouncing = true;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                Player.GoLeft = false;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.S)
                Player.GoRight = false;
            else if (e.KeyCode == Keys.Space)
            {
                Player.IsBouncing = false;
            }
        }
        private void MouseIsMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X - Player.Width / 2 > Player.Location.X + 7)
            {
                Player.GoRight = true;
                Player.GoLeft = false;
            }
            else if (e.Location.X - Player.Width / 2 < Player.Location.X - 7)
            {
                Player.GoLeft = true;
                Player.GoRight = false;
            }
            else
            {
                Player.GoLeft = false;
                Player.GoRight = false;
            }
        }
        private void MouseIsDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Player.IsBouncing = true;
        }
        private void MouseIsUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Player.IsBouncing = false;
        }
        #endregion

        #region timerTickEvent
        private void timer1_Tick(object sender, EventArgs e)
        {
            //cap nhat score
            labelScore.Text = "Score: " + score;
            //di chuyen player
            Player.move();
            //player va cham tuong
            Player.collision_Wall(ClientSize.Width);
            //su kien cua controls
            foreach (Control x in this.Controls)
            {
                if (x is Block2)
                {
                    Block2 tempblock = x as Block2;
                    //va cham voi block
                    if (Ball.collision_Block(tempblock))
                    {
                        score+=Ball.GetScore();
                        if (tempblock.getHit())
                        {
                            if (tempblock.ContainItems)
                            {
                                Item item = new Item();
                                item.Location = new Point(x.Location.X + x.Width / 2, x.Location.Y + x.Height);
                                this.Controls.Add(item);
                                x.BackgroundImage = Properties.Resources.brickGreen;
                                //using (Graphics g = this.CreateGraphics())
                                //{
                                //    string testString = "+1";
                                //    Font verdana14 = new Font("Verdana", 14);
                                //    SizeF sz = g.MeasureString(testString, verdana14);
                                //    g.DrawString(testString, verdana14, Brushes.Orange, new PointF(x.Location.X + x.Width, x.Location.Y + x.Height));
                                //    g.Dispose();
                                //}
                            }
                            this.Controls.Remove(x);
                        }
                    }
                }
                //su kien khi player cham vao item
                if (x is Item)
                {
                    (x as Item).move();
                    int function = Player.collision_Item(x as Item);
                    if (function!=0)
                    {
                        this.Controls.Remove(x);
                        if (function == 3)
                        {
                            //x3 funtion
                            //Ball ball1 = new Ball(Ball);
                            //ball1.reverseX();
                            //this.Controls.Add(ball1);
                            //Ball ball2 = new Ball(Ball);
                            //ball2.reverseY();
                            //this.Controls.Add(ball2);
                        }
                        else if (function == 6)
                        {
                            Ball.IsCrom = true;
                        }

                    }
                }
                //ball event
                if (x is Ball)
                {
                    //banh di chuyen
                    Ball ball = x as Ball;
                    ball.move();
                    //banh va cham voi tuong
                    ball.collision_Wall(ClientSize.Width);
                    //xu ly banh va cham voi player
                    ball.collision_Player(Player);
                    //banh roi ra ngoai
                    if (ball.fall_Out(ClientSize.Height))
                    {
                        this.Controls.Remove(x);
                        if (ball.all_fall_out()) loseStage(); 
                    }
                }
                if (Block2.count < 1)
                    winStage();
            }
        }
        #endregion

        #region functions
        private void setDefault()
        {
            this.timer1.Interval = 20;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.background2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            foreach (Control x in this.Controls)
            {
                if (x is Block2)
                {
                    (x as Block2).setSkin();
                }
            }
            this.KeyPreview = true;
        }
        private void loseStage()
        {
            this.timer1.Enabled = false;
            this.Controls.Clear();
            //if (MessageBox.Show("you lose! try again?", "lose", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    Application.Restart();
            //}
            //else
            //{
            //    this.Close();
            //}
            MessageBox.Show("you lose!");
        }
        private void winStage()
        {
            this.timer1.Enabled = false;
            this.Controls.Clear();
            score = 0;
            MessageBox.Show("you win!");
        }
        #endregion

    }
}
