namespace minigame_breakout
{
    partial class FormPvP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPvP));
            this.timerBall = new System.Windows.Forms.Timer(this.components);
            this.timerPlayer1 = new System.Windows.Forms.Timer(this.components);
            this.timerPlayer2 = new System.Windows.Forms.Timer(this.components);
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelLife2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelLife1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PauseButton = new System.Windows.Forms.PictureBox();
            this.block32 = new minigame_breakout.Block3();
            this.block33 = new minigame_breakout.Block3();
            this.block31 = new minigame_breakout.Block3();
            this.ball = new minigame_breakout.BallPvP();
            this.player2 = new minigame_breakout.Player2();
            this.player1 = new minigame_breakout.Player();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerBall
            // 
            this.timerBall.Enabled = true;
            this.timerBall.Interval = 20;
            this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
            // 
            // timerPlayer1
            // 
            this.timerPlayer1.Enabled = true;
            this.timerPlayer1.Interval = 20;
            this.timerPlayer1.Tick += new System.EventHandler(this.timerPlayer1_Tick);
            // 
            // timerPlayer2
            // 
            this.timerPlayer2.Enabled = true;
            this.timerPlayer2.Interval = 20;
            this.timerPlayer2.Tick += new System.EventHandler(this.timerPlayer2_Tick);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(12, 774);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(122, 24);
            this.labelSpeed.TabIndex = 102;
            this.labelSpeed.Text = "Ball speed: ";
            // 
            // labelLife2
            // 
            this.labelLife2.AutoSize = true;
            this.labelLife2.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLife2.ForeColor = System.Drawing.Color.Black;
            this.labelLife2.Location = new System.Drawing.Point(799, 12);
            this.labelLife2.Margin = new System.Windows.Forms.Padding(0);
            this.labelLife2.Name = "labelLife2";
            this.labelLife2.Size = new System.Drawing.Size(53, 35);
            this.labelLife2.TabIndex = 104;
            this.labelLife2.Text = "0x";
            this.labelLife2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::minigame_breakout.Properties.Resources.function_heart;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(855, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 35);
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // labelLife1
            // 
            this.labelLife1.AutoSize = true;
            this.labelLife1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLife1.ForeColor = System.Drawing.Color.Black;
            this.labelLife1.Location = new System.Drawing.Point(799, 764);
            this.labelLife1.Margin = new System.Windows.Forms.Padding(0);
            this.labelLife1.Name = "labelLife1";
            this.labelLife1.Size = new System.Drawing.Size(53, 35);
            this.labelLife1.TabIndex = 106;
            this.labelLife1.Text = "0x";
            this.labelLife1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::minigame_breakout.Properties.Resources.function_heart;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(855, 763);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 35);
            this.pictureBox2.TabIndex = 105;
            this.pictureBox2.TabStop = false;
            // 
            // PauseButton
            // 
            this.PauseButton.BackgroundImage = global::minigame_breakout.Properties.Resources.pause;
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButton.Location = new System.Drawing.Point(2, 8);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(41, 39);
            this.PauseButton.TabIndex = 111;
            this.PauseButton.TabStop = false;
            this.PauseButton.Tag = "pause";
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // block32
            // 
            this.block32.BackColor = System.Drawing.Color.Transparent;
            this.block32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("block32.BackgroundImage")));
            this.block32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.block32.Location = new System.Drawing.Point(424, 338);
            this.block32.Name = "block32";
            this.block32.Size = new System.Drawing.Size(60, 60);
            this.block32.TabIndex = 110;
            this.block32.TabStop = false;
            // 
            // block33
            // 
            this.block33.BackColor = System.Drawing.Color.Transparent;
            this.block33.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("block33.BackgroundImage")));
            this.block33.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.block33.Location = new System.Drawing.Point(658, 338);
            this.block33.Name = "block33";
            this.block33.Size = new System.Drawing.Size(60, 60);
            this.block33.TabIndex = 109;
            this.block33.TabStop = false;
            // 
            // block31
            // 
            this.block31.BackColor = System.Drawing.Color.Transparent;
            this.block31.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("block31.BackgroundImage")));
            this.block31.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.block31.Location = new System.Drawing.Point(172, 338);
            this.block31.Name = "block31";
            this.block31.Size = new System.Drawing.Size(60, 60);
            this.block31.TabIndex = 107;
            this.block31.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ball.IsCrom = false;
            this.ball.Location = new System.Drawing.Point(424, 689);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(28, 28);
            this.ball.Skin = 3;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            this.ball.X = 5;
            this.ball.Y = 5;
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Transparent;
            this.player2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("player2.BackgroundImage")));
            this.player2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player2.GoLeft = false;
            this.player2.GoRight = false;
            this.player2.IsBouncing = false;
            this.player2.IsGunMode = false;
            this.player2.Location = new System.Drawing.Point(374, 47);
            this.player2.Name = "player2";
            this.player2.PassCrom = false;
            this.player2.Size = new System.Drawing.Size(131, 27);
            this.player2.Speed = 10;
            this.player2.TabIndex = 1;
            this.player2.TabStop = false;
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Transparent;
            this.player1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("player1.BackgroundImage")));
            this.player1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player1.GoLeft = false;
            this.player1.GoRight = false;
            this.player1.IsBouncing = false;
            this.player1.IsGunMode = false;
            this.player1.Location = new System.Drawing.Point(374, 732);
            this.player1.Name = "player1";
            this.player1.PassCrom = false;
            this.player1.Size = new System.Drawing.Size(131, 27);
            this.player1.Speed = 10;
            this.player1.TabIndex = 0;
            this.player1.TabStop = false;
            // 
            // FormPvP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::minigame_breakout.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(907, 807);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.block32);
            this.Controls.Add(this.block33);
            this.Controls.Add(this.block31);
            this.Controls.Add(this.labelLife1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelLife2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.MaximizeBox = false;
            this.Name = "FormPvP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "pause";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPvP_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPvP_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPvP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPvP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormPvP_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Player player1;
        private Player2 player2;
        private BallPvP ball;
        private System.Windows.Forms.Timer timerBall;
        private System.Windows.Forms.Timer timerPlayer1;
        private System.Windows.Forms.Timer timerPlayer2;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelLife2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelLife1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Block3 block31;
        private Block3 block33;
        private Block3 block32;
        private System.Windows.Forms.PictureBox PauseButton;
    }
}