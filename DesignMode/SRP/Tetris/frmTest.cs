using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private Palette p;
        private Keys downKey;
        private Keys dropKey;
        private Keys moveLeftKey;
        private Keys moveRightKey;
        private Keys deasilRotateKey;//顺时针旋转键
        private Keys contraRotateKey;//逆时针旋转键
        private int paletteWidth;//画板宽度
        private int paletteHeight;//画板高度
        private Color paletteColor;//背景色
        private int rectPix;//每单元格像素

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //p = new Palette(10, 15, 20, Color.Black, pbRun.CreateGraphics(), lblReady.CreateGraphics());
            //p.Start();

            if (p != null)
                p.Close();
            p = new Palette(paletteWidth, paletteHeight, rectPix, paletteColor,
                Graphics.FromHwnd(pbRun.Handle),
                Graphics.FromHwnd(lblReady.Handle)
                );
            p.Start();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            p.Down();
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            p.MoveLeft();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            p.MoveRight();
        }

        private void BtnDeasiRotate_Click(object sender, EventArgs e)
        {
            p.DeasiRotate();
        }

        private void BtnContraRotate_Click(object sender, EventArgs e)
        {
            p.ContraRotate();
        }

        private void PbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
                p.PaintPalette(e.Graphics);
        }

        private void LblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
                p.PaintReady(e.Graphics);
        }

        private void BtnCheckOver_Click(object sender, EventArgs e)
        {
            p.CheckAndOverBlock();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            p.Drop();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            //读取快捷键
            downKey = config.DownKey;
            dropKey = config.DropKey;
            moveLeftKey = config.MoveLeftKey;
            moveRightKey = config.MoveRightKey;
            deasilRotateKey = config.DeasilRotateKey;
            contraRotateKey = config.ContraRotateKey;
            //读取环境设置参数
            paletteWidth = config.CoorWidth;
            paletteHeight = config.CoorHeight;
            paletteColor = config.BackColor;
            rectPix = config.RectPix;
            //根据画板的长度和宽度动态改变窗体及画板大小
            this.Width = paletteWidth * rectPix + 134;
            this.Height = paletteHeight * rectPix + 58;
            pbRun.Width = paletteWidth * rectPix;
            pbRun.Height = paletteHeight * rectPix;
        }

        private void frmTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32) //屏蔽回车键
                e.Handled = true;
            if (e.KeyCode == downKey)
                p.Down();
            else if (e.KeyCode == dropKey)
                p.Drop();
            else if (e.KeyCode == moveLeftKey)
                p.MoveLeft();
            else if (e.KeyCode == moveRightKey)
                p.MoveRight();
            else if (e.KeyCode == Keys.NumPad3)
                p.DeasiRotate();
            else if (e.KeyCode == Keys.NumPad1)
                p.ContraRotate();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (p == null)
                return;
            if (btnPause.Text == "暂停")
            {
                p.Pause();
                btnPause.Text = "继续";
            }
            else
            {
                p.EndPause();
                btnPause.Text = "暂停";
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            //使游戏暂停
            if (btnPause.Text == "暂停")
                btnPause.PerformClick();

            using (FormConfig frmConfig = new FormConfig())
            {
                frmConfig.ShowDialog();
            }
        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
                p.Close();
        }
    }
}
