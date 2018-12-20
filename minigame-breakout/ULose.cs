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
    public partial class ULose : Form
    {
        private SoundPlayer backgroundSound = new SoundPlayer(Properties.Resources.gameover);
        public ULose()
        {
            InitializeComponent();
            backgroundSound.Play();
        }

    }
}
