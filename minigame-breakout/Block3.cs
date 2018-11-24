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
    public partial class Block3 : Block
    {
        #region properties
        private int skin = 0;
        private bool iscracked = false;
        public Block3()
        {
            InitializeComponent();
        }

        public int Skin { get => skin; set => skin = value; }
        #endregion

        #region functions
        public void setSkin()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (skin == 0)
                this.BackgroundImage = Properties.Resources.brickGreen;
            else if (skin == 1)
                this.BackgroundImage = Properties.Resources.brickBlue;
            else if (skin == 2)
                this.BackgroundImage = Properties.Resources.brickYellow;
            else if (skin == 3)
                this.BackgroundImage = Properties.Resources.brickRed;
        }
        public void setCrackedSkin()
        {
            if (skin == 0)
                this.BackgroundImage = Properties.Resources.brickGreen_cracked;
            else if (skin == 1)
                this.BackgroundImage = Properties.Resources.brickBlue_cracked;
            else if (skin == 2)
                this.BackgroundImage = Properties.Resources.brickYellow_cracked;
            else if (skin == 3)
                this.BackgroundImage = Properties.Resources.brickRed_cracked;
        }
        public bool getHit()
        {
            if (iscracked == false)
            {
                setCrackedSkin();
                iscracked = true;
                return false;
            }
            else
            {
                count--;
                return true;
            }
        }
        #endregion
    }
}
