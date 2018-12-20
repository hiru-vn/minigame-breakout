using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minigame_breakout
{
    public partial class FormPVCLoad : Form
    {
        public FormPVCLoad()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Easy_Choose;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Easy;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPvC FPVC = new FormPvC(0);

            FPVC.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPvC FPVC = new FormPvC(1);     
            FPVC.ShowDialog();
            this.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPvC FPVC = new FormPvC(2);
            FPVC.ShowDialog();
            this.Close();
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.Normal_Choose;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.Normal;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Hard_Choose;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.Hard;
        }
    }
}
