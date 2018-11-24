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
    public partial class Item : PictureBox
    {
        #region properties
        private int function = 0;
        private static Random rd = new Random();
        public Item()
        {
            InitializeComponent();
            SetFunction();
            GetImage();
        }

        public int Function { get => function; set => function = value; }
        #endregion

        #region function
        public void move()
        {
            this.Top += 2;
        }
        public void SetFunction()
        {
            int generator = rd.Next(16);
            if (generator % 2 == 0 &&  generator < 17) function = 8;
            else
            {
                if (generator == 1 || generator == 17)
                    this.function = 1;
                else if (generator == 3 || generator == 19)
                    this.function = 2;
                else if (generator == 5 || generator == 21)
                    this.function = 3;
                else if (generator == 7 || generator == 23)
                    this.function = 4;
                else if (generator == 9 || generator == 25)
                    this.function = 5;
                else if (generator == 11 || generator == 27)
                    this.function = 6;
                else if (generator == 13 || generator == 29)
                    this.function = 7;
                else if (generator == 15 || generator == 31)
                    this.function = 8;
            }
        }
        public void GetImage()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Width = this.Height = 35;

            if (function == 0)
            {
                GetRounded();
                this.BackgroundImage = Properties.Resources.function_unknown;
            }
            else if (function == 1)
            {
                this.BackColor = Color.Transparent;
                GetRounded();
                this.BackgroundImage = Properties.Resources.function_slow;
            }
            else if (function == 2)
            {
                GetRounded();
                this.BackgroundImage = Properties.Resources.function_fast;
            }
            else if (function == 3)
            {
                GetRounded();
                this.BackgroundImage = Properties.Resources.function_x3ball;
            }
            else if (function == 4)
            {
                this.BackColor = Color.Transparent;
                this.Height = 15;
                this.Width = 80;
                this.BackgroundImage = Properties.Resources.player_lengthen;
            }
            else if (function == 5)
            {
                this.BackColor = Color.Transparent;
                this.Height = 15;
                this.Width = 40;
                this.BackgroundImage = Properties.Resources.player_shorten;
            }
            else if (function == 6)
            {
                GetRounded();
                this.BackgroundImage = Properties.Resources.funtion_cromball;
            }
            else if (function == 7)
            {
                GetRounded();
                this.BackgroundImage = Properties.Resources.function_gun;
            }
            else if (function == 8)
            {
                this.BackColor = Color.Transparent;
                //using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                //{
                //    path.AddBezier(this.Width >> 1,
                //                    this.Height >> 2,
                //                    this.Width * 1.25f, 0f,
                //                    this.Width,
                //                    this.Height * 0.75f,
                //                    this.Width >> 1,
                //                    this.Height);
                //    path.AddBezier(this.Width >> 1,
                //                    this.Height >> 2,
                //                    -this.Width * .25f, 0f,
                //                    0f,
                //                    this.Height * 0.75f,
                //                    this.Width >> 1,
                //                    this.Height);

                //    this.Region = new Region(path);
                //}
                this.Height = 30;
                this.BackgroundImage = Properties.Resources.function_heart;
            }
        }
        public void GetRounded()
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
            }
        }
        public bool FallOut(int Height)
        {
            if (this.Top > Height)
                return true;
            return false;
        }
        #endregion
    }
}
