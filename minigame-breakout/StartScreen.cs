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
    public partial class StartScreen : Form
    {
        
        //public int VSpeed;
        //public int HSpeed;
        public StartScreen()
        {
            InitializeComponent();
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    FormMain FormMain = new FormMain();
        //    FormMain.ShowDialog();
        //    this.Close();
        //}
        private void ManHinh_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
   
        }

        //private void Board_Click(object sender, EventArgs e)
        //{

        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    FormPvC FormPvC = new FormPvC();
        //    FormPvC.ShowDialog();
        //    this.Close();
        //}

        //private void twoPlayer_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    FormPvP FormPvP = new FormPvP();
        //    FormPvP.ShowDialog();
        //    this.Close();
        //}

        //private void Quit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}


        //private void splayer_MouseMove(object sender, MouseEventArgs e)
        //{
        //    splayer.Visible = true;
        //}

        private void splayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSiglePlay FormMain = new FormSiglePlay();
            FormMain.ShowDialog();
            FormMain.Show();
            this.Close();
        }

        private void twoPlayer_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormPvP FormPvP = new FormPvP();
            FormPvP.ShowDialog();
            FormPvP.Show();
            this.Close();
            
        }

        private void VsC_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPVCLoad FormPvC = new FormPVCLoad();
            FormPvC.ShowDialog();
            FormPvC.Show();
            this.Close();
        
        }

        private void Quit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quit_MouseEnter(object sender, EventArgs e)
        {
            Quit.BackgroundImage = Properties.Resources.Quit_choose;
        }

        private void Quit_MouseLeave(object sender, EventArgs e)
        {
            Quit.BackgroundImage = Properties.Resources.Quit;
        }

        private void splayer_MouseEnter(object sender, EventArgs e)
        {
            splayer.BackgroundImage = Properties.Resources.spchoose;
        }

        private void splayer_MouseLeave(object sender, EventArgs e)
        {
            splayer.BackgroundImage = Properties.Resources.splayer;
        }

        private void twoPlayer_MouseEnter(object sender, EventArgs e)
        {
            twoPlayer.BackgroundImage = Properties.Resources.twoplayer_choose;

        }

        private void twoPlayer_MouseLeave(object sender, EventArgs e)
        {
            twoPlayer.BackgroundImage = Properties.Resources.twoplayer;
        }

        private void VsC_MouseEnter(object sender, EventArgs e)
        {
            VsC.BackgroundImage = Properties.Resources.vscp_choose;
        }

        private void VsC_MouseLeave(object sender, EventArgs e)
        {
            VsC.BackgroundImage = Properties.Resources.vscp;
        }
    }
}
