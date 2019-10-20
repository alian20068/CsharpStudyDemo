using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 生成砖块的类
    /// </summary>
    class BlockGroup
    {
        /// <summary>
        /// 存放所有砖块样式信息
        /// </summary>
        public InfoArr Info { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color DisapperColor { get; set; }
        /// <summary>
        /// 单元格像素
        /// </summary>
        public int RectPix { get; set; }

        public BlockGroup()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            Info = config.Info;
            DisapperColor = config.BackColor;
            RectPix = config.RectPix;
        }

        /// <summary>
        /// 随机一个砖块样式
        /// </summary>
        /// <returns></returns>
        public Block GetSuiJiBlock()
        {
            Random rd = new Random();
            int keyOrder = rd.Next(0, Info.Length);
            BitArray ba = Info[keyOrder].Id;
            //确定砖块中被填充方块的个数，即需要确定Point数组的长度
            int struNum = 0;
            foreach (bool b in ba)
            {
                if (b)
                    struNum++;
            }
            //新建Point数组，并确定长度，以创建新的Block
            Point[] structArr = new Point[struNum];
            int k = 0;
            for (int j = 0; j < ba.Length; j++)
            {
                if (ba[j])
                {
                    //坐标赋值
                    structArr[k].X = j / 5 - 2;
                    structArr[k].Y = 2 - j % 5;
                    k++;
                }
            }

            //创建一个新砖块并返回
            return new Block(structArr, Info[keyOrder].Bcolor, DisapperColor, RectPix);
        }
    }
}
