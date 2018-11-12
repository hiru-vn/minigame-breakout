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
        bool goright = false;
        bool goleft = false;
        int speed = 10;

        int ballx = 5;
        int bally = 5;
        int score = 0;

        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Width>constant.ballHeight)
                {
                    x.Tag = "block";
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    Color rndColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    x.BackColor = rndColor;
                }
            }
            this.KeyPreview = true;


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    TextBox temp1 = new TextBox();
                    temp1.Location = x.Location;
                    temp1.Height = constant.brickHeight - 5;
                    temp1.Width = 1;
                    this.Controls.Add(temp1);
                    TextBox temp2 = new TextBox();
                    temp2.Location = new Point(x.Location.X + constant.brickWidth, x.Location.Y);
                    temp2.Height = constant.brickHeight - 5;
                    temp2.Width = 1;
                    this.Controls.Add(temp2);
                }
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && this.button1.Left > 0)
            {
                goleft = true;
                goright = false;
            }
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.F) && (this.button1.Left + constant.playerWidth) < ClientSize.Width)
            {
                goright = true;
                goleft = false;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                goleft = false;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.F)
                goright = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball.Left += ballx;
            Ball.Top += bally;
            label1.Text = "Score: " + score;
            if (goleft) { button1.Left -= speed; }
            else if (goright) { button1.Left += speed; }

            if (button1.Left<1)
            {
                goleft = false;
            }
            else if (button1.Left+constant.playerWidth>this.ClientSize.Width)
            {
                goright = false;
            }
            if (Ball.Left + constant.ballHeight > ClientSize.Width || Ball.Left<1)
            {
                ballx = -ballx;
            }
            if (Ball.Top<1 || Ball.Bounds.IntersectsWith(button1.Bounds))
            {
                bally = -bally;
            }
            if (Ball.Top + constant.ballHeight >= ClientSize.Height)
            {
                this.timer1.Enabled = false;
                this.Controls.Clear();
                MessageBox.Show("you lose!");
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (Ball.Bounds.IntersectsWith(new Rectangle(x.Location, new Size(1, constant.brickHeight-5))) || Ball.Bounds.IntersectsWith(new Rectangle(new Point(x.Location.X+constant.brickWidth,x.Location.Y) , new Size(1,constant.brickHeight-5))))
                    {
                        this.Controls.Remove(x);
                        ballx = -ballx;
                        score++;
                    }
                    else if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        bally = -bally;
                        score++;
                    }
                }
                if (score> 34)
                {
                    this.timer1.Enabled = false;
                    this.Controls.Clear();
                    score = 0;
                    MessageBox.Show("you win!");
                }
            }
        }
    }
}
