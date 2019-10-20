namespace Tetris
{
    partial class frmTest
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
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.lblReady = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnCheckOver = new System.Windows.Forms.Button();
            this.btnContraRotate = new System.Windows.Forms.Button();
            this.btnDeasiRotate = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.Location = new System.Drawing.Point(12, 12);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(200, 300);
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.PbRun_Paint);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.Black;
            this.lblReady.Location = new System.Drawing.Point(38, 9);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(100, 100);
            this.lblReady.TabIndex = 1;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.LblReady_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnDrop);
            this.panel1.Controls.Add(this.btnCheckOver);
            this.panel1.Controls.Add(this.btnContraRotate);
            this.panel1.Controls.Add(this.btnDeasiRotate);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(219, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 450);
            this.panel1.TabIndex = 2;
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(51, 343);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(75, 23);
            this.btnDrop.TabIndex = 9;
            this.btnDrop.Text = "丢下";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnCheckOver
            // 
            this.btnCheckOver.Location = new System.Drawing.Point(51, 313);
            this.btnCheckOver.Name = "btnCheckOver";
            this.btnCheckOver.Size = new System.Drawing.Size(75, 23);
            this.btnCheckOver.TabIndex = 8;
            this.btnCheckOver.Text = "检查到底";
            this.btnCheckOver.UseVisualStyleBackColor = true;
            this.btnCheckOver.Click += new System.EventHandler(this.BtnCheckOver_Click);
            // 
            // btnContraRotate
            // 
            this.btnContraRotate.Location = new System.Drawing.Point(51, 284);
            this.btnContraRotate.Name = "btnContraRotate";
            this.btnContraRotate.Size = new System.Drawing.Size(75, 23);
            this.btnContraRotate.TabIndex = 7;
            this.btnContraRotate.Text = "逆时针旋转";
            this.btnContraRotate.UseVisualStyleBackColor = true;
            this.btnContraRotate.Click += new System.EventHandler(this.BtnContraRotate_Click);
            // 
            // btnDeasiRotate
            // 
            this.btnDeasiRotate.Location = new System.Drawing.Point(51, 255);
            this.btnDeasiRotate.Name = "btnDeasiRotate";
            this.btnDeasiRotate.Size = new System.Drawing.Size(75, 23);
            this.btnDeasiRotate.TabIndex = 6;
            this.btnDeasiRotate.Text = "顺时针旋转";
            this.btnDeasiRotate.UseVisualStyleBackColor = true;
            this.btnDeasiRotate.Click += new System.EventHandler(this.BtnDeasiRotate_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(51, 225);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "右移";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(51, 195);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "左移";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(51, 165);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(51, 136);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(51, 373);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 10;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(51, 415);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 11;
            this.btnConfig.Text = "设置";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.KeyPreview = true;
            this.Name = "frmTest";
            this.Text = "俄罗斯方块";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTest_FormClosing);
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTest_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnContraRotate;
        private System.Windows.Forms.Button btnDeasiRotate;
        private System.Windows.Forms.Button btnCheckOver;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnConfig;
    }
}