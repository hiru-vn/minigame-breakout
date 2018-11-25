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
    public partial class Block1 : Block
    {
        #region properties
        private int skin = 0;
        public Block1()
        {
            InitializeComponent();
        }
        #endregion

        #region function
        public void setSkin()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (skin == 0)
                this.BackgroundImage = Properties.Resources.block1_green;
            else if (skin == 1)
                this.BackgroundImage = Properties.Resources.block1_blue;
            else if (skin == 2)
                this.BackgroundImage = Properties.Resources.block1_yellow;
            else if (skin == 3)
                this.BackgroundImage = Properties.Resources.block1_red;
        }
        public bool getHit()
        {
            count--;
            return true;
        }
        #endregion
    }
}
