using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigame_breakout
{
    public partial class UWIN : Form
    {
        private SoundPlayer backgroundSound = new SoundPlayer(Properties.Resources.Youwin);
        public UWIN()
        {
            backgroundSound.Play();
            InitializeComponent();

            label1.BackColor = Color.Black;
        }
        public UWIN(int mode)
        {
            backgroundSound.Play();
            InitializeComponent();
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            label1.BackColor = Color.Black;
            label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            if (mode == 1) label1.Text = "player 1 win";
            if (mode == 2) label1.Text = "player 2 win";
        }
    }
}
