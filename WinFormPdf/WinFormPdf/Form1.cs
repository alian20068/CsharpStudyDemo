using org.pdfbox.pdmodel;
using org.pdfbox.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog();
            //selectFileDialog.InitialDirectory = "C:\\"; //初始目录
            selectFileDialog.Filter = "便携式文档|*.pdf|所有文件|*.*"; //文件过滤
            selectFileDialog.FilterIndex = 1; //默认第一个过滤条件
            selectFileDialog.RestoreDirectory = true; //保存上一次目录
            selectFileDialog.Title = "请选择文件";
            //selectFileDialog.Multiselect = true;//设置多选

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strExtension = Path.GetExtension(selectFileDialog.FileName).ToLower();
                string[] arr = new string[] { ".pdf" };
                if (!((IList)arr).Contains(strExtension))
                {
                    MessageBox.Show("仅能上传pdf格式的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblFileName.Text = "文件名：" + selectFileDialog.SafeFileName;
                    lblFullName.Text = "完整路径：" + selectFileDialog.FileName;
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFullName.Text))
            {
                MessageBox.Show("请先选择文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //参考 https://www.cnblogs.com/yjd_hycf_space/p/7942444.html

            PDDocument doc = PDDocument.load(lblFullName.Text.Replace("完整路径：", ""));
            PDFTextStripper pdfStripper = new PDFTextStripper();
            string text = pdfStripper.getText(doc);
            //StreamWriter sw = new StreamWriter("", false, Encoding.GetEncoding("gb2312"));
            //sw.Write(text);
            //sw.Close();
            rtxShow.Text = text;

        }
    }
}
