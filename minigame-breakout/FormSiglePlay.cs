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
    public partial class FormSiglePlay : Form
    {
        #region properties
        private int score = 0;
        public FormSiglePlay()
        {
            InitializeComponent();
            setDefault();
        }
        #endregion

        #region key_mouse_events
        private void Pause(object sender, EventArgs e)
        {
            timer1.Stop();
            TimeLeft.Stop();
        }
        private void Resume(object sender, EventArgs e)
        {
            timer1.Start();
            TimeLeft.Start();
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
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
        private void TimeLeft_Tick(object sender, EventArgs e)
        {
            int count = int.Parse(labelCount.Text);
            count--;
            labelCount.Text = count.ToString();
            if (count == 10) labelCount.ForeColor = Color.Red;
            if (count == 0) loseStage();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //cap nhat score
            labelScore.Text = "Score: " + score;
            //cap nhat life
            labelLife.Text = Player.Life + "x";
            //di chuyen player
            Player.move();
            //player va cham tuong
            Player.collision_Wall(ClientSize.Width);
            //neu dang trong trang thai gunmode
            if (Player.IsGunMode)
            {
                Bullet.tick();
                if (Bullet.Shoot())
                {
                    Bullet bullet1 = new Bullet();
                    Bullet bullet2 = new Bullet();
                    bullet1.Location = new Point(Player.Location.X, Player.Location.Y - constant.bulletHeigth);
                    bullet2.Location = new Point(Player.Location.X + Player.Width-constant.bulletWidth, Player.Location.Y - constant.bulletHeigth);
                    this.Controls.Add(bullet1);
                    this.Controls.Add(bullet2);
                }
                if (!Bullet.onGunMode)
                {
                    Player.IsGunMode = false;
                    Player.GetImage();
                }
            }
            //su kien cua controls
            foreach (Control x in this.Controls)
            {
                if (x is Block)
                {
                    //va cham voi block
                    if (Ball.collision_Block(x as Block))
                    {
                        score+=Ball.GetScore();
                        if (x is Block2)
                        {
                            Block2 temp = x as Block2;
                            if (temp.getHit())
                            {
                                if (temp.ContainItems)
                                {
                                    Item item = new Item();
                                    item.Location = new Point(x.Location.X + x.Width / 2, x.Location.Y + x.Height);
                                    this.Controls.Add(item);
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
                        if (x is Block1)
                        {
                            Block1 temp = x as Block1;
                            temp.getHit();
                            if (temp.ContainItems)
                            {
                                Item item = new Item();
                                item.Location = new Point(x.Location.X + x.Width / 2, x.Location.Y + x.Height);
                                this.Controls.Add(item);
                            }
                            this.Controls.Remove(x);
                        }
                    }
                }
                //su kien khi player cham vao item
                if (x is Item)
                {
                    Item temp = x as Item;
                    temp.move();
                    if (temp.FallOut(ClientSize.Height))
                        this.Controls.Remove(x);
                    int function = Player.collision_Item(temp);
                    if (function != 0)
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
                        else if (function == 7) Bullet.StartGunMode();
                    }
                }
                //ball event
                if (x is Ball)
                {
                    //banh di chuyen
                    Ball temp = x as Ball;
                    temp.move();
                    //banh va cham voi tuong
                    temp.collision_Wall(ClientSize.Width);
                    //xu ly banh va cham voi player
                    temp.collision_Player(Player);
                    //cap nhat ball speed
                    labelSpeed.Text = "Ball speed: " + (float)(Math.Round(Ball.Speed, 2));
                    //banh roi ra ngoai
                    if (temp.fall_Out(ClientSize.Height))
                    {
                        this.Controls.Remove(x);
                        if (temp.all_fall_out())
                        {
                            if (Player.lostLife())
                            {
                                loseStage();
                                labelLife.Text = "0x";
                            }
                            else
                            {
                                //this.Controls.Remove(x);
                                Ball otherBall = new Ball();
                                otherBall.Size = new System.Drawing.Size(22, 22);
                                otherBall.reverseY();
                                otherBall.Location = new Point(Player.Location.X + Player.Width / 2, Player.Location.Y - constant.ballHeight - 10);
                                this.Ball = otherBall;
                                this.Controls.Add(otherBall);
                            }
                        }
                    }
                }
                if (x is Bullet)
                {
                    Bullet temp = x as Bullet;
                    temp.move();
                    if (temp.ShotOut()) this.Controls.Remove(x);
                    foreach (Control y in this.Controls)
                    {
                        if (y is Block2)
                        {
                            Block2 temp2 = y as Block2;
                            if (temp.collision_Block(temp2))
                            {
                                if (temp2.getHit()) this.Controls.Remove(y);
                                this.Controls.Remove(x);
                            }
                        }
                        else if (y is Block1)
                        {
                            Block1 temp2 = y as Block1;
                            if (temp.collision_Block(temp2))
                            {
                                temp2.getHit();
                                this.Controls.Remove(y);
                                this.Controls.Remove(x);
                            }
                        }
                    }
                }
            }
            //all block remove
            if (Block2.count < 1)
                winStage();
        }
        #endregion

        #region functions
        private void setDefault()
        {
            this.timer1.Interval = 20;
            this.DoubleBuffered = true;
            this.BackgroundImage = Properties.Resources.background2;
            this.pictureBox1.BackColor = Color.Transparent;
            this.labelLife.BackColor = Color.Transparent;
            this.labelCount.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.labelScore.BackColor = Color.Transparent;
            this.PauseButton.BackColor = Color.Transparent;
            this.labelSpeed.BackColor = Color.Transparent;
            foreach (Control x in this.Controls)
            {
                if (x is Block2)
                {
                    (x as Block2).setSkin();
                }
                else if (x is Block1)
                {
                    (x as Block1).setSkin();
                }
            }
            this.KeyPreview = true;
            this.LostFocus += new System.EventHandler(Pause);
            this.GotFocus += new System.EventHandler(Resume);
        }
        private void loseStage()
        {
            this.timer1.Enabled = false;
            this.TimeLeft.Enabled = false;
            this.LostFocus -= new System.EventHandler(Pause);
            this.GotFocus -= new System.EventHandler(Resume);
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
            this.LostFocus -= new System.EventHandler(Pause);
            this.GotFocus -= new System.EventHandler(Resume);
            this.timer1.Enabled = false;
            this.TimeLeft.Enabled = false;
            score = 0;
            MessageBox.Show("you win!");
        }
        #endregion

    }
}
