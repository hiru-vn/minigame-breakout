namespace minigame_breakout
{
    partial class StartScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Quit = new System.Windows.Forms.PictureBox();
            this.VsC = new System.Windows.Forms.PictureBox();
            this.twoPlayer = new System.Windows.Forms.PictureBox();
            this.Board = new System.Windows.Forms.PictureBox();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.splayer = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VsC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(654, 771);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Transparent;
            this.Quit.BackgroundImage = global::minigame_breakout.Properties.Resources.Quit;
            this.Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Quit.Location = new System.Drawing.Point(389, 577);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(219, 92);
            this.Quit.TabIndex = 19;
            this.Quit.TabStop = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click_1);
            this.Quit.MouseEnter += new System.EventHandler(this.Quit_MouseEnter);
            this.Quit.MouseLeave += new System.EventHandler(this.Quit_MouseLeave);
            // 
            // VsC
            // 
            this.VsC.BackColor = System.Drawing.Color.Transparent;
            this.VsC.BackgroundImage = global::minigame_breakout.Properties.Resources.vscp;
            this.VsC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VsC.Location = new System.Drawing.Point(389, 407);
            this.VsC.Name = "VsC";
            this.VsC.Size = new System.Drawing.Size(219, 92);
            this.VsC.TabIndex = 18;
            this.VsC.TabStop = false;
            this.VsC.Click += new System.EventHandler(this.VsC_Click);
            this.VsC.MouseEnter += new System.EventHandler(this.VsC_MouseEnter);
            this.VsC.MouseLeave += new System.EventHandler(this.VsC_MouseLeave);
            // 
            // twoPlayer
            // 
            this.twoPlayer.BackColor = System.Drawing.Color.Transparent;
            this.twoPlayer.BackgroundImage = global::minigame_breakout.Properties.Resources.twoplayer;
            this.twoPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twoPlayer.Location = new System.Drawing.Point(52, 577);
            this.twoPlayer.Name = "twoPlayer";
            this.twoPlayer.Size = new System.Drawing.Size(219, 92);
            this.twoPlayer.TabIndex = 17;
            this.twoPlayer.TabStop = false;
            this.twoPlayer.Click += new System.EventHandler(this.twoPlayer_Click_1);
            this.twoPlayer.MouseEnter += new System.EventHandler(this.twoPlayer_MouseEnter);
            this.twoPlayer.MouseLeave += new System.EventHandler(this.twoPlayer_MouseLeave);
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.Transparent;
            this.Board.BackgroundImage = global::minigame_breakout.Properties.Resources.player_lengthen;
            this.Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Board.Location = new System.Drawing.Point(245, 700);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(151, 26);
            this.Board.TabIndex = 16;
            this.Board.TabStop = false;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Transparent;
            this.Ball.BackgroundImage = global::minigame_breakout.Properties.Resources.ball3;
            this.Ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ball.Location = new System.Drawing.Point(296, 670);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(32, 34);
            this.Ball.TabIndex = 15;
            this.Ball.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::minigame_breakout.Properties.Resources.spaceship;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(452, 186);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(202, 200);
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(255, 449);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(162, 205);
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::minigame_breakout.Properties.Resources.rocket;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(0, 133);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(157, 205);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // splayer
            // 
            this.splayer.BackColor = System.Drawing.Color.Transparent;
            this.splayer.BackgroundImage = global::minigame_breakout.Properties.Resources.splayer;
            this.splayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splayer.Location = new System.Drawing.Point(52, 407);
            this.splayer.Name = "splayer";
            this.splayer.Size = new System.Drawing.Size(219, 92);
            this.splayer.TabIndex = 10;
            this.splayer.TabStop = false;
            this.splayer.Click += new System.EventHandler(this.splayer_Click);
            this.splayer.MouseEnter += new System.EventHandler(this.splayer_MouseEnter);
            this.splayer.MouseLeave += new System.EventHandler(this.splayer_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::minigame_breakout.Properties.Resources.BreakoutName;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(52, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(578, 168);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // ManHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(654, 771);
            this.Controls.Add(this.splayer);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.VsC);
            this.Controls.Add(this.twoPlayer);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ManHinh";
            this.Text = "ManHinh";
            this.Load += new System.EventHandler(this.ManHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VsC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Quit;
        private System.Windows.Forms.PictureBox VsC;
        private System.Windows.Forms.PictureBox twoPlayer;
        private System.Windows.Forms.PictureBox Board;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox splayer;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}