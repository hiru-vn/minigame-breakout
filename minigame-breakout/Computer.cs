using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigame_breakout
{
    public partial class Computer : PictureBox
    {
        #region properties
        protected int speed = 10;
        protected bool goLeft = false;
        protected bool goRight = false;
        protected bool isBuffSpeed = false;
        protected bool isSlowSpeed = false;
        protected bool isBouncing = false;
        protected bool isShorten = false;
        protected bool isLengthen = false;
        protected bool isGunMode = false;
        protected int image = 1;
        protected int life = 3;
        protected bool passCrom = false;
        private int hardLevel = 2;

        public Computer()
        {
            InitializeComponent();
            GetImage();
        }

        public bool GoRight { get => goRight; set => goRight = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        public int Speed { get => speed; set => speed = value; }
        public bool IsBuffSpeed { get => isBuffSpeed; }
        public bool IsBouncing { get => isBouncing; set => isBouncing = value; }
        public bool IsGunMode { get => isGunMode; set => isGunMode = value; }
        public int Life { get => life; }
        public bool PassCrom { get => passCrom; set => passCrom = value; }
        public int HardLevel { get => hardLevel; set => hardLevel = value; }
        #endregion

        #region functions
        public void GetImage()
        {
            this.ResizeRedraw = false;
            this.BackgroundImage = Properties.Resources.player2_1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void BouncingMode()
        {
            if (image == 1)
            {
                image = 2;
                this.BackgroundImage = Properties.Resources.Player2_2;
            }
            else if (image == 2)
            {
                image = 3;
                this.BackgroundImage = Properties.Resources.Player2_3;
            }
            else if (image == 3)
            {
                image = 1;
                this.BackgroundImage = Properties.Resources.player2_1;
            }
        }
        public void GunMode()
        {

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
        //may tan cong/phong thu
        public void move(BallPvP ball, Player player, int clienSizeWidth, int clienSizeHeight)
        {
            #region Phong thu
            if (hardLevel == 0)
            {
                this.speed = 7;
                if (ball.Y < 0 && ball.Top<clienSizeHeight/2)
                {
                    if (this.Left < ball.Left || this.Right > ball.Right)
                        if (Math.Abs(ball.X) <= 7) this.speed = Math.Abs(ball.X);
                    if (isSlowSpeed) this.speed = 5;
                    if (isBuffSpeed) this.speed = 13;
                    if (isBouncing && !isShorten && !isLengthen) BouncingMode();
                    if (Left + Width < clienSizeWidth)
                        if (Left + Width / 2 - 7 < ball.Left) { this.Left += this.speed; }
                    if (Left > 0)
                        if (this.Right - this.Width / 2 + 7 > ball.Left) { this.Left -= this.speed; }
                }
                else if (ball.Top > clienSizeHeight / 2)
                {
                    if (player.Left > 2 * clienSizeWidth / 3)
                    { if (Left > 0) this.Left -= this.speed; }
                    else if (player.Left < clienSizeWidth / 3)
                    {
                        if (Left + Width < clienSizeWidth)
                            this.Left += this.speed;
                    }
                }
                else
                {
                    if (ball.X > 0)
                    {
                        if (ball.Top > clienSizeHeight/2)
                        { if (Left + Width < clienSizeWidth)
                                if (player.GoLeft) { this.Left += this.speed; }
                            if (Left > 0)
                                if (player.GoRight) { this.Left -= this.speed; } }
                        else {
                            if (Left > 0)
                                if (player.GoLeft) { this.Left -= this.speed; }
                            if (Left + Width < clienSizeWidth)
                                if (player.GoRight) { this.Left += this.speed; }
                        }
                    }
                    else
                    {
                        if (ball.Top < clienSizeHeight/2)
                        {
                            if (Left + Width < clienSizeWidth)
                                if (player.GoLeft) { this.Left += this.speed; }
                            if (Left > 0)
                                if (player.GoRight) { }
                        }
                        else
                        {
                            if (Left > 0)
                                if (player.GoLeft) { this.Left -= this.speed; }
                            if (Left + Width < clienSizeWidth)
                                if (player.GoRight) { this.Left += this.speed; }
                        }
                    }
                }
            }
            else if (hardLevel == 1)
            {
                this.speed = 7;
                if (ball.Y < 0 || ball.Top < clienSizeHeight/3)
                {
                    if (this.Left < ball.Left || this.Right > ball.Right)
                        if (Math.Abs(ball.X) <= 7) this.speed = Math.Abs(ball.X);
                    if (isSlowSpeed) this.speed = 5;
                    if (isBuffSpeed) this.speed = 13;
                    if (isBouncing && !isShorten && !isLengthen) BouncingMode();
                    if (this.Left + this.Width / 2 - 7 < ball.Left) { this.Left += this.speed; }
                    else if (this.Right - this.Width / 2 + 7 > ball.Left) { this.Left -= this.speed; }
                }
                else
                {
                    if (ball.X > 0)
                    {
                            if (Left > 0)
                                if (player.GoLeft) { }
                            if (Left + Width < clienSizeWidth)
                                if (player.GoRight) { this.Left += this.speed; }
                    }
                    else
                    {
                            if (Left > 0)
                                if (player.GoRight) { this.Left -= this.speed; }
                            if (Left + Width < clienSizeWidth)
                                if (player.GoLeft) { this.Left += this.speed; }
                    }
                    if (!player.GoLeft && !player.GoRight)
                    {
                        if (player.Left > 2* clienSizeWidth / 3)
                        { if (Left > 0) this.Left -= this.speed; }
                        else if (player.Left < clienSizeWidth / 3)
                        {
                            if (Left + Width < clienSizeWidth)
                                this.Left += this.speed;
                        }

                    }
                }
            }
            else if (hardLevel == 2)
            {
                this.speed = 8;
                if (ball.Y < 0 || ball.Top < clienSizeHeight / 2)
                {
                    if (this.Left < ball.Left || this.Right>ball.Right)
                        if (Math.Abs(ball.X) <= 8) this.speed = Math.Abs(ball.X);
                    if (isSlowSpeed) this.speed = 5;
                    if (isBuffSpeed) this.speed = 13;
                    if (isBouncing && !isShorten && !isLengthen) BouncingMode();
                    if (this.Left + this.Width / 2 - 7 < ball.Left) { this.Left += this.speed; }
                    else if (this.Right - this.Width / 2 + 7 > ball.Left) { this.Left -= this.speed; }
                }
                else
                {
                    if (ball.X > 0)
                    {
                        if (Left > 0)
                            if (player.GoLeft) { }
                        if (Left + Width < clienSizeWidth)
                            if (player.GoRight) { this.Left += this.speed; }
                    }
                    else
                    {
                        if (Left > 0)
                            if (player.GoRight) { this.Left -= this.speed; }
                        if (Left + Width < clienSizeWidth)
                            if (player.GoLeft) { this.Left += this.speed; }
                    }
                    if (!player.GoLeft && !player.GoRight)
                    {
                        if (player.Left > 2 * clienSizeWidth / 3)
                        { if (Left > 0) this.Left -= this.speed; }
                        else if (player.Left < clienSizeWidth / 3)
                        {
                            if (Left + Width < clienSizeWidth)
                                this.Left += this.speed;
                        }

                    }
                }
            }
            #endregion

            #region tan cong
            if (this.HardLevel == 0)
            {
                if (player.Left > ball.Left && player.Right < Right)
                    this.isBouncing = true;
                else if (player.Right < Right && ball.X > 0)
                    this.isBouncing = true;
                else
                    this.isBouncing = false;
            }
            if (this.HardLevel == 1)
            {
                if (player.Left > ball.Left && player.Right < Right)
                    this.isBouncing = true;
                else if (player.Right < Right && ball.X > 0)
                    this.isBouncing = true;
                else if (player.IsBouncing)
                    this.isBouncing = true;
                else
                    this.isBouncing = false;
            }
            if (this.HardLevel == 2)
            {
                if (player.Left > ball.Left && player.Right < Right)
                    this.isBouncing = true;
                else if (!player.GoLeft && !player.GoRight)
                    this.isBouncing = true;
                else if (player.IsBouncing)
                    this.isBouncing = true;
                else if (player.Left<clienSizeWidth/4 || player.Right>clienSizeWidth*3/4)
                    this.isBouncing = true;
                else
                    this.isBouncing = false;
            }
            #endregion
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
                    int generator = rnd.Next(7) + 1;
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
                    this.PassCrom = true;
                }
                else if (func == 7)
                {
                    this.IsGunMode = true;
                    this.BackgroundImage = Properties.Resources.player_gunmode2;
                }
                else if (func == 8)
                {
                    life++;
                }
                return func;
            }
            return 0;
        }
        public bool lostLife()
        {
            life--;
            if (life > 0) return false;
            return true;
        }
        #endregion
    }
}
