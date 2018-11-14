﻿using System;
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
        public Ball()
        {
            InitializeComponent();
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        #endregion

        #region design
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
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
            if (this.Left + constant.ballHeight > clientWidthSize || this.Left < 5)
            {
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
                    this.reverseY();
                else if (this.Bounds.IntersectsWith(new Rectangle(new Point(player.Location.X, player.Location.Y), new Size(15, player.Height))))
                {
                    this.x -= 2;
                    this.reverseY();
                }
                else if (this.Bounds.IntersectsWith(new Rectangle(new Point(player.Location.X + player.Width - 5, player.Location.Y), new Size(15, player.Height))))
                {
                    this.x += 2;
                    this.reverseY();
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
                    this.reverseX();
                    return true;
                }
            }
            else if (this.Bounds.IntersectsWith(new Rectangle(new Point(block.Location.X + block.Width, block.Location.Y), new Size(1, block.Height))))
            {
                if (X < 0)
                {
                    this.reverseX();
                    return true;
                }
            }
            else if (this.Bounds.IntersectsWith(block.Bounds))
            {
                this.reverseY();
                return true;
            }
            return false;
        }
        //Xu ly banh roi ra ngoai
        public bool fall_Out(int clientHeightSize)
        {
            if (this.Top >= clientHeightSize)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
