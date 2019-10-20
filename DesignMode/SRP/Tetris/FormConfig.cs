using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FormConfig : Form
    {
        private Config config = new Config();

        public FormConfig()
        {
            InitializeComponent();
        }

        private bool[,] arr = new bool[5, 5];
        private Color blockColor = Color.Red;

        //窗体最小化再打开，会再次执行
        private void lblMode_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);
            Pen p = new Pen(Color.White);
            for (int i = 31; i < 155; i = i + 31) //画横白线
                gp.DrawLine(p, 1, i, 155, i);
            for (int i = 31; i < 155; i = i + 31) //画竖白线
                gp.DrawLine(p, i, 1, i, 155);

            //填充已选择的方块
            SolidBrush s = new SolidBrush(blockColor);
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (arr[x, y])
                        gp.FillRectangle(s, 31 * x + 1, 31 * y + 1, 30, 30);
                }
            }

            //gp.Dispose();
        }

        private void lblMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) //如果点击的不是鼠标左键，则退出
                return;
            int xPos = e.X / 31;
            int yPos = e.Y / 31;
            arr[xPos, yPos] = !arr[xPos, yPos];
            bool b = arr[xPos, yPos];

            Graphics gp = lblMode.CreateGraphics();
            SolidBrush s = new SolidBrush(b ? blockColor : Color.Black);//创建刷子，并确定颜色
            gp.FillRectangle(s, xPos * 31 + 1, yPos * 31 + 1, 30, 30);//给点击方块上色

            gp.Dispose();
        }

        private void lblMode_MouseMove(object sender, MouseEventArgs e)
        {
            lblPos.Text = string.Format("{0},{1}", e.X, e.Y);
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();//打开颜色选择对话框
            blockColor = colorDialog1.Color;
            lblColor.BackColor = blockColor;
            lblMode.Invalidate();//重绘lblMode，即执行Paint事件
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
                return;
            
            string blockString = GetFromArr();
            //检查是否有重复图案
            foreach (ListViewItem item in lstBlockSet.Items)
            {
                //比较第一列
                if (item.SubItems[0].Text == blockString)
                {
                    MessageBox.Show("图案已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //把新砖块图案添加到ListView
            ListViewItem myItem = lstBlockSet.Items.Add(blockString);
            myItem.SubItems.Add(blockColor.ToArgb().ToString());
        }
        private bool CheckEmpty()
        {
            bool isEmpty = false;//图案是否为空
            foreach (bool i in arr)
            {
                if (i)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                MessageBox.Show("图案为空，请点击上面图案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        private string GetFromArr()
        {
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in arr)
            {
                sb.Append(i ? "1" : "0");
            }

            return sb.ToString();
        }
        private void lstBlockSet_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                blockColor = Color.FromArgb(int.Parse(e.Item.SubItems[1].Text));
                lblColor.BackColor = blockColor;
                string blockString = e.Item.SubItems[0].Text;
                for (int i = 0; i < blockString.Length; i++)
                {
                    //转换的算法
                    arr[i / 5, i % 5] = (blockString[i] == '1' ? true : false);
                }
                lblMode.Invalidate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择条目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lstBlockSet.Items.Remove(lstBlockSet.SelectedItems[0]);//删除选中的条目。注意：需设置不能选择多个条目
            btnClear.PerformClick();//生成按钮的Click事件
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = false;
                }
            }
            lblMode.Invalidate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择条目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (CheckEmpty())
                return;
            
            lstBlockSet.SelectedItems[0].SubItems[0].Text = GetFromArr();//改变图案信息
            lstBlockSet.SelectedItems[0].SubItems[1].Text = blockColor.ToArgb().ToString();//改变颜色信息
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            //排除不适合的键
            if ((e.KeyValue >= 33 && e.KeyValue <= 36) ||
                (e.KeyValue >= 45 && e.KeyValue <= 46) ||
                (e.KeyValue >= 48 && e.KeyValue <= 57) ||
                (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                (e.KeyValue >= 96 && e.KeyValue <= 107) ||
                (e.KeyValue >= 109 && e.KeyValue <= 111) ||
                (e.KeyValue >= 186 && e.KeyValue <= 192) ||
                (e.KeyValue >= 219 && e.KeyValue <= 222)
                )
            {
                //检查存在冲突的快捷键设置
                foreach (Control c in gbKeySet.Controls)
                {
                    //TODO：这里为啥不用is判断类型
                    Control tempC = c as TextBox;
                    if (tempC != null && !string.IsNullOrEmpty(((TextBox)tempC).Text))
                    {
                        if (((int)(((TextBox)tempC).Tag)) == e.KeyValue)
                        {
                            ((TextBox)tempC).Text = "";
                            ((TextBox)tempC).Tag = Keys.None;
                        }
                    }
                }
                ((TextBox)sender).Text = e.KeyCode.ToString();
                ((TextBox)sender).Tag = (Keys)e.KeyValue;
            }
        }

        private void lblBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();//打开颜色选择对话框
            lblBackColor.BackColor = colorDialog1.Color;//把选择的颜色作为标签背景色
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            config.LoadFromXmlFile();
            InfoArr info = config.Info;
            //读取砖块
            ListViewItem myItem = null;//new ListViewItem();
            for (int i = 0; i < info.Length; i++)
            {
                myItem = lstBlockSet.Items.Add(info[i].GetIdStr());
                myItem.SubItems.Add(info[i].GetColorStr());
            }
            //读取快捷键
            txtDown.Text = config.DownKey.ToString();
            txtDown.Tag = config.DownKey;
            txtDrop.Text = config.DropKey.ToString();
            txtDrop.Tag = config.DropKey;
            txtLeft.Text = config.MoveLeftKey.ToString();
            txtLeft.Tag = config.MoveLeftKey;
            txtRight.Text = config.MoveRightKey.ToString();
            txtRight.Tag = config.MoveRightKey;
            txtDeasil.Text = config.DeasilRotateKey.ToString();
            txtDeasil.Tag = config.DeasilRotateKey;
            txtContra.Text = config.ContraRotateKey.ToString();
            txtContra.Tag = config.ContraRotateKey;
            //读取环境设置参数
            txtCoorWidth.Text = config.CoorWidth.ToString();
            txtCoorHeight.Text = config.CoorHeight.ToString();
            txtRectPix.Text = config.RectPix.ToString();
            lblBackColor.BackColor = config.BackColor;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoArr info = new InfoArr();
            //从lsvBlockSet列表读取砖块信息，并存入info内
            foreach (ListViewItem item in lstBlockSet.Items)
            {
                info.Add(item.SubItems[0].Text, item.SubItems[1].Text);
            }
            config.Info = info;
            config.DownKey = (Keys)txtDown.Tag;
            config.DropKey = (Keys)txtDrop.Tag;
            config.MoveLeftKey = (Keys)txtLeft.Tag;
            config.MoveRightKey = (Keys)txtRight.Tag;
            config.DeasilRotateKey = (Keys)txtDeasil.Tag;
            config.ContraRotateKey = (Keys)txtContra.Tag;
            config.CoorWidth = int.Parse(txtCoorWidth.Text);
            config.CoorHeight = int.Parse(txtCoorHeight.Text);
            config.RectPix = int.Parse(txtRectPix.Text);
            config.BackColor = lblBackColor.BackColor;

            //保存到xml文件
            config.SaveToXmlFile();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
