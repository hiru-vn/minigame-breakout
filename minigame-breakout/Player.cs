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
    public partial class Player : PictureBox
    {
        #region properties
        private int speed = 10;
        private bool goLeft = false;
        private bool goRight = false;
        private bool isBuffSpeed = false;
        private bool isSlowSpeed = false;
        private bool isBouncing = false;
        private bool isShorten = false;
        private bool isLengthen = false;
        private bool isGunMode = false;
        private int image = 1;

        public Player()
        {
            InitializeComponent();
            GetImage();
        }

        public bool GoRight { get => goRight; set => goRight = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool IsBuffSpeed { get => isBuffSpeed; set => isBuffSpeed = value; }
        public bool IsBouncing { get => isBouncing; set => isBouncing = value; }
        #endregion

        #region functions
        public void GetImage()
        {
            this.ResizeRedraw = false;
            this.BackgroundImage = Properties.Resources.player_1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
       
        public void BouncingMode()
        {
            if (image == 1)
            {
                image = 2;
                this.BackgroundImage = Properties.Resources.player_2;
            }
            else if (image == 2)
            {
                image = 3;
                this.BackgroundImage = Properties.Resources.player_3;
            }
            else if (image == 3)
            {
                image = 1;
                this.BackgroundImage = Properties.Resources.player_1;
            }
        }
        public void GunMode()
        {
            if (IsBouncing)
            {
                if (image == 1)
                {
                    image = 2;
                    this.BackgroundImage = Properties.Resources.player_gunmode2;
                }
                else if (image == 2)
                {
                    image = 3;
                    this.BackgroundImage = Properties.Resources.player_gunmode3;
                }
                else if (image == 3)
                {
                    image = 1;
                    this.BackgroundImage = Properties.Resources.player_gunmode1;
                }
            }
            else
            {
                this.BackgroundImage = Properties.Resources.player_gunmode2;
            }
        }
        //di chuyen
        public void move()
        {
            this.speed = 8;
            if (isSlowSpeed) this.speed = 5;
            if (isBuffSpeed) this.speed = 13;
            if (isBouncing && !isShorten && !isLengthen) BouncingMode();
            if (this.GoLeft) { this.Left -= this.speed; }
            else if (this.GoRight) { this.Left += this.speed; }
        }
        //xu ly va cham voi tuong
        public void collision_Wall(int clientWidthSize)
        {
            if (this.Left < 1)
            {
                this.GoLeft = false;
            }
            else if (this.Left + this.Width > clientWidthSize)
            {
                this.GoRight = false;
            }
        }
        //xu ly va cham voi item
        public int collision_Item(Item item)
        {
            if (this.Bounds.IntersectsWith(item.Bounds))
            {
                int func = item.Function;
                if (func == 0)
                {
                    Random rnd = new Random();
                    int generator = rnd.Next(7)+1;
                    func = generator;
                }
                if (func == 1)
                {
                    this.isSlowSpeed = true;
                    this.isBuffSpeed = false;
                }
                else if (func == 2)
                {
                    this.isSlowSpeed = false;
                    this.isBuffSpeed = true;
                }
                else if (func == 3)
                {
                    //toball
                }
                else if (func == 4)
                {
                    if (!isLengthen)
                    {
                        Width = (int)(Width * 1.5);
                        if (isShorten)
                        {
                            isShorten = false;
                            isLengthen = false;
                        }
                        else
                        {
                            isLengthen = true;
                            this.BackgroundImage = Properties.Resources.player_lengthen;
                        }
                    }
                }
                else if (func == 5)
                {
                    if (!isShorten)
                    {
                        Width = (int)(Width / 1.5);
                        if (isLengthen)
                        {
                            isShorten = false;
                            isLengthen = false;
                        }
                        else
                        {
                            isShorten = true;
                            this.BackgroundImage = Properties.Resources.player_shorten;
                        }
                    }
                }
                else if (func == 6)
                {
                    //toball
                }
                else if (func == 7)
                {
                    this.isGunMode = true;
                    GunMode();                    
                }
                else if (func == 8)
                {
                    //heart++
                }
                return func;
            }
            return 0;
        }
        #endregion
    }
}
