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
        public static int count = 0;
        protected bool containItems = false;
        protected static Random rndItem = new Random();
        public Block()
        {
            InitializeComponent();
            count++;
            int gen = rndItem.Next(5);
            if (gen == 0)
                containItems = true;
        }

        public bool ContainItems { get => containItems; }
        #endregion
    }
}
