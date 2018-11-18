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
            Random rd = new Random();
            int generator = rd.Next(14);
            if (generator % 2 == 0) function = 0;
            else
            {
                if (generator == 1)
                    this.function = 1;
                else if (generator == 3)
                    this.function = 2;
                else if (generator == 5)
                    this.function = 3;
                else if (generator == 7)
                    this.function = 4;
                else if (generator == 9)
                    this.function = 5;
                else if (generator == 11)
                    this.function = 6;
                else if (generator == 13)
                    this.function = 7;
            }
        }
        public void GetImage()
        {
            this.Width = 60;
            this.Height = 20;
            this.BackColor = Color.Black;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.Width = this.Height = 35;
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
            }

            if (function == 0)
            {
                this.BackgroundImage = Properties.Resources.function_unknown;
            }
            else if (function == 1)
            {               
                this.BackgroundImage = Properties.Resources.function_slow;
            }
            else if (function == 2)
            {
                this.BackgroundImage = Properties.Resources.function_fast;
            }
            else if (function == 3)
            {
                this.BackgroundImage = Properties.Resources.function_x3ball;
            }
            else if (function == 4)
            {
                this.BackgroundImage = Properties.Resources.function_lengthen;
            }
            else if (function == 5)
            {
                this.BackgroundImage = Properties.Resources.function_shorten;
            }
            else if (function == 6)
            {
                this.BackgroundImage = Properties.Resources.funtion_cromball;
            }
            //function_gun later
        }
        public void GetFunction()
        {

        }
        #endregion
    }
}
