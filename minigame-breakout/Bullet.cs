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
        #region properties
        public static Timer timer;
        public static int timeEffect = 300;
        public static bool onGunMode = false;
        public Bullet()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        #region function
        public void move() { this.Top -= 7; }
        public bool ShotOut()
        {
            if (this.Top < 0)
                return true;
            return false;
        }
        public static void tick()
        {
            if (onGunMode)
            {
                if (timeEffect > 0) timeEffect--;
                if (timeEffect == 0)
                {
                    timeEffect = 300;
                    onGunMode = false;
                }
            }
        }
        public static void StartGunMode()
        {
            onGunMode = true;
        }
        public bool collision_Block(Block block)
        {
            if (this.Bounds.IntersectsWith(block.Bounds)) return true;
            return false;
        }
        public static bool Shoot()
        {
            if (timeEffect % 25 == 0) return true;
            return false;
        }
        #endregion
    }
}
