using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace minigame_breakout
{
    public partial class Ball : PictureBox
    {
        #region properties
        private int x=5;
        private int y=5;
        private int ballHits = 0;
        private int timesScore = 1;
        private int speedLevel = 1;
        private int skin = 3;
        private bool isCrom = false;
        private static int countBall=0;
        private float speed = (float)7.07;

        public Ball()
        {
            InitializeComponent();
            countBall++;
            this.DoubleBuffered = true;
            setSkin();
        }
        public Ball(Ball otherBall)
        {
            InitializeComponent();
            this.x = otherBall.x;
            this.y = otherBall.y;
            this.speedLevel = otherBall.speedLevel;
            this.skin = otherBall.skin;
            this.isCrom = otherBall.isCrom;
            countBall++;
            this.DoubleBuffered = true;
            setSkin();
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Skin { get => skin; set => skin = value; }
        public bool IsCrom { get => isCrom; set => isCrom = value; }
        public float Speed { get => speed; }
        #endregion

        #region design
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath gp = new GraphicsPath())
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
            }
        }
        #endregion

        #region functions
        public void reverseX()
        {
            X = -X;
        }
        public void reverseY()
        {
            Y = -Y;
        }
        public void move()
        {
            this.Left += x;
            this.Top += y;
        }

        //Xu ly va cham voi tuong
        public void collision_Wall(int clientWidthSize)
        {
            if (this.Left + constant.ballHeight > clientWidthSize)
            {
                if (X>0)
                    this.reverseX();
            }
            else if (this.Left < 5)
            {
                if (X<0)
                    this.reverseX();
            }
            if (this.Top < 1)
            {
                this.reverseY();
            }
        }
        //Xu ly va cham voi player
        public void collision_Player(Player player)
        {
            if (Y > 0)
            {
                if (this.Bounds.IntersectsWith(new Rectangle(new Point(player.Location.X + 20, player.Location.Y), new Size(player.Width - 40, 1))))
                {
                    this.reverseY();
                    this.ResetHitsPoint();
                    this.SpeedChange(player.IsBouncing);
                    if (player.PassCrom && isCrom)
                    {
                        player.PassCrom = false;
                        isCrom = false;
                    }
                    else if (player.PassCrom && !isCrom)
                    {
                        isCrom = true;
                    }
                    setSpeed();
                }
                else if (this.Bounds.IntersectsWith(new Rectangle(new Point(player.Location.X, player.Location.Y), new Size(20, player.Height))))
                {
                    if (x <= 0)
                    {
                        x -= 1;
                        GetYfromXChange();
                    }
                    else
                    {
                        x = -(int)(5 * Math.Pow(1.25, speedLevel-1));
                    }
                    this.reverseY();
                    this.ResetHitsPoint();
                    this.SpeedChange(player.IsBouncing);
                    if (player.PassCrom && isCrom)
                    {
                        player.PassCrom = false;
                        isCrom = false;
                    }
                    else if (player.PassCrom && !isCrom)
                    {
                        isCrom = true;
                    }
                    setSpeed();
                }
                else if (this.Bounds.IntersectsWith(new Rectangle(new Point(player.Location.X + player.Width - 5, player.Location.Y), new Size(20, player.Height))))
                {
                    if (x >= 0)
                    {
                        x += 1;
                        GetYfromXChange();
                    }
                    else
                    {
                        x = (int)(5 * Math.Pow(1.25, speedLevel-1));
                    }
                    this.reverseY();
                    this.ResetHitsPoint();
                    this.SpeedChange(player.IsBouncing);
                    if (player.PassCrom && isCrom)
                    {
                        player.PassCrom = false;
                        isCrom = false;
                    }
                    else if (player.PassCrom && !isCrom)
                    {
                        isCrom = true;
                    }
                    setSpeed();
                }
            }
        }
        //Xu ly va cham voi block
        public bool collision_Block(Block block)
        {
            if (this.Bounds.IntersectsWith(new Rectangle(new Point(block.Location.X,block.Location.Y), new Size(1, block.Height))))
            {
                if (X > 0)
                {
                    if (!isCrom) this.reverseX();
                    addHitsPoint();
                    return true;
                }
            }
            else if (this.Bounds.IntersectsWith(new Rectangle(new Point(block.Location.X + block.Width, block.Location.Y), new Size(1, block.Height))))
            {
                if (X < 0)
                {
                    if (!isCrom) this.reverseX();
                    addHitsPoint();
                    return true;
                }
            }
            else if (this.Bounds.IntersectsWith(block.Bounds))
            {
                if (!isCrom) this.reverseY();
                addHitsPoint();
                return true;
            }
            return false;
        }
        //Xu ly banh roi ra ngoai
        public bool fall_Out(int clientHeightSize)
        {
            if (this.Top >= clientHeightSize)
            {
                countBall--;
                return true;
            }
            return false;
        }
        public bool all_fall_out()
        {
            if (countBall == 0)
                return true;
            return false;
        }
        //Xu ly so diem tra ve khi va cham voi block (moi 3 block bi huy trong 1 lan phong tang 1 diem moi block tiep theo bi huy)
        public int GetScore()
        {
            return timesScore;
        }
        public void ResetHitsPoint()
        {
            ballHits = 0;
            timesScore = 1;
        }
        public void addHitsPoint()
        {
            ballHits++;
            if (ballHits>3)
            {
                timesScore++;
                ballHits = 0;
            }
        }
        //speed
        public void SpeedChange(bool isBouncing)
        {
            if (isBouncing)
            {
                if (speedLevel < 4)
                {
                    speedLevel++;
                    if (speedLevel == 2) BackColor = Color.Orange;
                    if (speedLevel == 3) BackColor = Color.OrangeRed;
                    if (speedLevel == 4) BackColor = Color.DarkRed;

                    x = (int)(x * 1.25);
                    y = (int)(y * 1.25);
                }
            }
        }
        public void setSkin()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (skin == 0) this.BackgroundImage = Properties.Resources.ball0;
            else if (skin == 1) this.BackgroundImage = Properties.Resources.ball1;
            else if (skin == 2) this.BackgroundImage = Properties.Resources.ball2;
            else if (skin == 3) this.BackgroundImage = Properties.Resources.ball3;
            else if (skin == 4) this.BackgroundImage = Properties.Resources.ball4;
            else if (skin == 5) this.BackgroundImage = Properties.Resources.ball5;
            else if (skin == 6) this.BackgroundImage = Properties.Resources.ball6;
        }
        private void setSpeed()
        {
            speed = (float) Math.Sqrt(x * x + y * y);
        }
        private void GetYfromXChange()
        {
            y = (int)Math.Sqrt(speed * speed - x * x);
            y = -y;
        }
        #endregion
    }
}
