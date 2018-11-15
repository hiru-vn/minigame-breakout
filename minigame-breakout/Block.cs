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
        public Block()
        {
            InitializeComponent();
            count++;
        }
        #endregion

        #region functions

        #endregion
    }
}
