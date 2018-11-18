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
    public partial class Block : PictureBox
    {
        #region properties
        public static int count=0;
        private int skin = 1;
        public Block()
        {
            InitializeComponent();
            count++;
            setSkin();
        }

        public int Skin { get => skin; set => skin = value; }
        #endregion

        #region functions
        public void setSkin()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (skin == 0)
                this.BackgroundImage = Properties.Resources.brickWood;
            if (skin == 1)
                this.BackgroundImage = Properties.Resources.brickBlue;
        }
        #endregion
    }
}
