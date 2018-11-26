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
        private int X = 2;
        #region properties
        public Block3()
        {
            InitializeComponent();
            setSkin();
        }

        #endregion

        #region functions
        private void setSkin()
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
        }
        public void move(Block block, int clienSizeWidth)
        {
            this.Left += X;
            collision_block(block);
            collision_wall(clienSizeWidth);
        }
        private void collision_block(Block block)
        {
            if (this.Bounds.IntersectsWith(block.Bounds))
                X = -X;
        }
        private void collision_wall(int clienSizeWidth)
        {
            if (this.Right> clienSizeWidth || this.Left < 3)
                X = -X;
        }
        #endregion
    }
}
