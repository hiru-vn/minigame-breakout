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
    public partial class Bullet : PictureBox
    {       
        public Bullet()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void move() { this.Top -= 6; }
        public bool ShotOut()
        {
            if (this.Top < 0)
                return true;
            return false;
        }
    }
}
