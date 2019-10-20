using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Tetris
{
    class Config
    {
        /// <summary>
        /// 向下键
        /// </summary>
        public Keys DownKey { get; set; }

        /// <summary>
        /// 丢下键
        /// </summary>
        public Keys DropKey { get; set; }

        /// <summary>
        /// 左移键
        /// </summary>
        public Keys MoveLeftKey { get; set; }

        /// <summary>
        /// 右移键
        /// </summary>
        public Keys MoveRightKey { get; set; }

        /// <summary>
        /// 顺时针旋转键
        /// </summary>
        public Keys DeasilRotateKey { get; set; }

        /// <summary>
        /// 逆时针旋转键
        /// </summary>
        public Keys ContraRotateKey { get; set; }
        
        private int _CoorWidth;
        /// <summary>
        /// 水平格子数
        /// </summary>
        public int CoorWidth
        {
            get { return _CoorWidth; }
            set { if (value >= 10 && value <= 50) _CoorWidth = value; }
        }

        private int _CoorHeight;
        /// <summary>
        /// 垂直格子数
        /// </summary>
        public int CoorHeight
        {
            get { return _CoorHeight; }
            set { if (value >= 15 && value <= 50) _CoorHeight = value; }
        }

        private int _RectPix;
        /// <summary>
        /// 方块像素
        /// </summary>
        public int RectPix
        {
            get { return _RectPix; }
            set { if (value >= 10 && value <= 30) _RectPix = value; }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// 砖块信息集合
        /// </summary>
        public InfoArr Info { get; set; }

        public Config()
        {
            Info = new InfoArr();
        }

        public void LoadFromXmlFile()
        {
            XmlTextReader reader;
            //优先读取外部BlockSet.xml文件
            //如果不存在，则从嵌入资源内读取 注意：需要设置xml文件为嵌入的资源，即exe文件里，是只读的
            if (File.Exists("BlockSet.xml"))
            {
                reader = new XmlTextReader("BlockSet.xml");
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream s = asm.GetManifestResourceStream("Tetris.BlockSet.xml");
                reader = new XmlTextReader(s);
            }

            string key = string.Empty;
            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Id")
                        {
                            key = reader.ReadElementString().Trim();
                            Info.Add(key, "");
                        }
                        else if (reader.Name == "Color")
                        {
                            Info[key] = reader.ReadElementString().Trim();
                        }
                        else if (reader.Name == "DownKey")
                        {
                            DownKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DropKey")
                        {
                            DropKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveLeftKey")
                        {
                            MoveLeftKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveRightKey")
                        {
                            MoveRightKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DeasilRotateKey")
                        {
                            DeasilRotateKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "ContraRotateKey")
                        {
                            ContraRotateKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "CoorWidth")
                        {
                            CoorWidth = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "CoorHeight")
                        {
                            CoorHeight = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RectPix")
                        {
                            RectPix = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "BackColor")
                        {
                            BackColor = Color.FromArgb(Convert.ToInt32(reader.ReadElementString().Trim()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public void SaveToXmlFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<BlockSet></BlockSet>");
            XmlNode root = doc.SelectSingleNode("BlockSet");
            //写砖块信息
            for (int i = 0; i < Info.Length; i++)
            {
                XmlElement xeType = doc.CreateElement("Type");

                XmlElement xeId = doc.CreateElement("Id");
                xeId.InnerText = Info[i].GetIdStr();
                xeType.AppendChild(xeId);

                XmlElement xeColor = doc.CreateElement("Color");
                xeColor.InnerText = Info[i].GetColorStr();
                xeType.AppendChild(xeColor);

                root.AppendChild(xeType);
            }
            //写快捷键
            XmlElement xeKey = doc.CreateElement("Key");

            XmlElement xeDownKey = doc.CreateElement("DownKey");
            xeDownKey.InnerText = Convert.ToInt32(DownKey).ToString();
            xeKey.AppendChild(xeDownKey);

            XmlElement xeDropKey = doc.CreateElement("DropKey");
            xeDropKey.InnerText = Convert.ToInt32(DropKey).ToString();
            xeKey.AppendChild(xeDropKey);

            XmlElement xeMoveLeftKey = doc.CreateElement("MoveLeftKey");
            xeMoveLeftKey.InnerText = Convert.ToInt32(MoveLeftKey).ToString();
            xeKey.AppendChild(xeMoveLeftKey);

            XmlElement xeMoveRightKey = doc.CreateElement("MoveRightKey");
            xeMoveRightKey.InnerText = Convert.ToInt32(MoveRightKey).ToString();
            xeKey.AppendChild(xeMoveRightKey);

            XmlElement xeDeasilRotateKey = doc.CreateElement("DeasilRotateKey");
            xeDeasilRotateKey.InnerText = Convert.ToInt32(DeasilRotateKey).ToString();
            xeKey.AppendChild(xeDeasilRotateKey);

            XmlElement xeContraRotateKey = doc.CreateElement("ContraRotateKey");
            xeContraRotateKey.InnerText = Convert.ToInt32(ContraRotateKey).ToString();
            xeKey.AppendChild(xeContraRotateKey);

            root.AppendChild(xeKey);

            //写界面信息
            XmlElement xeSurface = doc.CreateElement("Surface");

            XmlElement xeCoorWidth = doc.CreateElement("CoorWidth");
            xeCoorWidth.InnerText = CoorWidth.ToString();
            xeSurface.AppendChild(xeCoorWidth);

            XmlElement xeCoorHeight = doc.CreateElement("CoorHeight");
            xeCoorHeight.InnerText = CoorHeight.ToString();
            xeSurface.AppendChild(xeCoorHeight);

            XmlElement xeRectPix = doc.CreateElement("RectPix");
            xeRectPix.InnerText = RectPix.ToString();
            xeSurface.AppendChild(xeRectPix);

            XmlElement xeBackColor = doc.CreateElement("BackColor");
            xeBackColor.InnerText = BackColor.ToArgb().ToString();
            xeSurface.AppendChild(xeBackColor);

            root.AppendChild(xeSurface);

            doc.Save("BlockSet.xml");
        }
    }
}
