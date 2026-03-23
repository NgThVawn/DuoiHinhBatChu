namespace DuoiHinhBatChu
{
    partial class frmGamePlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGamePlay));
            this.label1 = new System.Windows.Forms.Label();
            this.flpLetter = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpAnswer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.ptbQuestionImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnHint = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.questionTimer = new System.Windows.Forms.Timer(this.components);
            this.wmpAnswerSound = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuestionImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpAnswerSound)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Fz Game Of Squids ver202", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(281, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 60);
            this.label1.TabIndex = 4;
            this.label1.Text = "ĐUỔI HÌNH";
            // 
            // flpLetter
            // 
            this.flpLetter.Location = new System.Drawing.Point(154, 700);
            this.flpLetter.Name = "flpLetter";
            this.flpLetter.Size = new System.Drawing.Size(619, 296);
            this.flpLetter.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Fz Game Of Squids ver202", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(360, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 60);
            this.label2.TabIndex = 6;
            this.label2.Text = "BẮT CHỮ";
            // 
            // flpAnswer
            // 
            this.flpAnswer.Location = new System.Drawing.Point(110, 486);
            this.flpAnswer.Name = "flpAnswer";
            this.flpAnswer.Size = new System.Drawing.Size(696, 187);
            this.flpAnswer.TabIndex = 7;
            // 
            // btnMenu
            // 
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.Color.Transparent;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = global::DuoiHinhBatChu.Properties.Resources.row;
            this.btnMenu.ImageSize = new System.Drawing.Size(40, 40);
            this.btnMenu.Location = new System.Drawing.Point(3, 4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(52, 51);
            this.btnMenu.TabIndex = 8;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // ptbQuestionImage
            // 
            this.ptbQuestionImage.ImageRotate = 0F;
            this.ptbQuestionImage.Location = new System.Drawing.Point(209, 157);
            this.ptbQuestionImage.Name = "ptbQuestionImage";
            this.ptbQuestionImage.Size = new System.Drawing.Size(500, 300);
            this.ptbQuestionImage.TabIndex = 3;
            this.ptbQuestionImage.TabStop = false;
            // 
            // btnHint
            // 
            this.btnHint.BackColor = System.Drawing.Color.Transparent;
            this.btnHint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHint.FillColor = System.Drawing.Color.Transparent;
            this.btnHint.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btnHint.Image = ((System.Drawing.Image)(resources.GetObject("btnHint.Image")));
            this.btnHint.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHint.Location = new System.Drawing.Point(818, 4);
            this.btnHint.Name = "btnHint";
            this.btnHint.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnHint.Size = new System.Drawing.Size(99, 128);
            this.btnHint.TabIndex = 2;
            this.btnHint.Text = "Gợi ý";
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Fz Game Of Squids ver202", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.lblTime.Location = new System.Drawing.Point(15, 97);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(84, 35);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "1 : 30";
            // 
            // questionTimer
            // 
            this.questionTimer.Interval = 1000;
            this.questionTimer.Tick += new System.EventHandler(this.timeAnswer_Tick);
            // 
            // wmpAnswerSound
            // 
            this.wmpAnswerSound.Enabled = true;
            this.wmpAnswerSound.Location = new System.Drawing.Point(12, 964);
            this.wmpAnswerSound.Name = "wmpAnswerSound";
            this.wmpAnswerSound.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpAnswerSound.OcxState")));
            this.wmpAnswerSound.Size = new System.Drawing.Size(136, 32);
            this.wmpAnswerSound.TabIndex = 10;
            this.wmpAnswerSound.Visible = false;
            // 
            // frmGamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(918, 1022);
            this.Controls.Add(this.wmpAnswerSound);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.flpAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpLetter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptbQuestionImage);
            this.Controls.Add(this.btnHint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGamePlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGamePlay_FormClosing);
            this.Load += new System.EventHandler(this.frmGamePlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuestionImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpAnswerSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox ptbQuestionImage;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnHint;
        private System.Windows.Forms.FlowLayoutPanel flpLetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpAnswer;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer questionTimer;
        private AxWMPLib.AxWindowsMediaPlayer wmpAnswerSound;
    }
}