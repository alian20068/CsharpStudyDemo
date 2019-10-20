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
            ReadPdf();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveFolder.Text.Trim()))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "请选择要保存到的文件夹"; //对话框提供描述性信息
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop; //对话框根文件夹
                folderBrowserDialog.ShowNewFolderButton = true; //显示新建文件夹
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                    {
                        MessageBox.Show("文件夹路径不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    txtSaveFolder.Text = folderBrowserDialog.SelectedPath + "\\file.txt";
                }
            }

            WriteFile(txtSaveFolder.Text, "\r\n\r\n\r\n" + rtxShow.Text.Trim().Replace("\n", "\r\n"), true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int.TryParse(txtBegin.Text.Trim(), out var iBegin);
            int.TryParse(txtEnd.Text.Trim(), out var iEnd);
            iBegin++;
            iEnd++;
            txtBegin.Text = iBegin.ToString();
            txtEnd.Text = iEnd.ToString();

            ReadPdf();
        }

        private void ReadPdf()
        {
            if (string.IsNullOrEmpty(lblFullName.Text))
            {
                MessageBox.Show("请先选择文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //参考 https://www.cnblogs.com/yjd_hycf_space/p/7942444.html

            int.TryParse(txtBegin.Text.Trim(), out var iBegin);
            int.TryParse(txtEnd.Text.Trim(), out var iEnd);
            if (iBegin <= 0) iBegin = 1;
            if (iEnd <= 0) iEnd = 1;

            PDDocument doc = PDDocument.load(lblFullName.Text.Replace("完整路径：", ""));
            int iPageCnt = doc.getNumberOfPages();
            lblCnt.Text = "共" + iPageCnt + "页";
            if (iEnd > iPageCnt)
                iEnd = iPageCnt;

            PDFTextStripper pdfStripper = new PDFTextStripper();
            pdfStripper.setSortByPosition(false);//设置是否排序
            pdfStripper.setStartPage(iBegin);//设置起始页
            pdfStripper.setEndPage(iEnd);//设置结束页
            string text = pdfStripper.getText(doc);

            rtxShow.Text = text;

            //提取图片
            //https://blog.csdn.net/u012337114/article/details/80436485
        }

        private void WriteFile(string fileFullPath, string content, bool append)
        {
            StreamWriter sw = new StreamWriter(fileFullPath, append, Encoding.GetEncoding("gb2312"));
            sw.Write(content);
            sw.Flush();
            sw.Close();
        }
        //private string ReadTxt(string fileFullPath)
        //{
        //    StreamReader sr = new StreamReader(fileFullPath, Encoding.GetEncoding("gb2312"), false);
        //    string content = sr.ReadToEnd(); 
        //    sr.Close();

        //    return content;
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string settingFilePath = Environment.CurrentDirectory + "\\setting.txt";

            string content = lblFileName.Text.Trim().Replace("文件名：", "") + "\r\n";
            content += lblFullName.Text.Trim().Replace("完整路径：", "") + "\r\n";
            content += txtSaveFolder.Text.Trim() + "\r\n";
            content += txtBegin.Text.Trim() + "\r\n";
            content += txtEnd.Text.Trim() + "\r\n";

            WriteFile(settingFilePath, content, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string settingFilePath = Environment.CurrentDirectory + "\\setting.txt";
            if (File.Exists(settingFilePath))
            {
                StreamReader sr = new StreamReader(settingFilePath, Encoding.GetEncoding("gb2312"), false);

                lblFileName.Text = sr.ReadLine();
                lblFullName.Text = sr.ReadLine();
                txtSaveFolder.Text = sr.ReadLine();
                txtBegin.Text = sr.ReadLine();
                txtEnd.Text = sr.ReadLine();

                sr.Close();
            }
        }
    }
}
