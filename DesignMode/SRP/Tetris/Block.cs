using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 砖块
    /// </summary>
    class Block
    {
        protected Point[] structArr;//存放砖块组成信息的坐标数组
        //protected int xpos;//砖块中心点x坐标
        //protected int ypos;//砖块中心点y坐标
        //protected Color blockColor;//砖块颜色
        protected Color disapperColor;//擦除颜色
        protected int rectPix;//每单元格像素

        public Block(Point[] sa, Color bColor, Color dColor, int pix)
        {
            BlockColor = bColor;
            disapperColor = dColor;
            rectPix = pix;
            structArr = sa;
        }

        /// <summary>
        /// 索引器，根据索引访问砖块里的小方块坐标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                return structArr[index];
            }
        }

        /// <summary>
        /// structArr的长度
        /// </summary>
        public int Length { get { return structArr.Length; } }
        /// <summary>
        /// 砖块中心点x坐标
        /// </summary>
        public int XPos { get; set; }
        /// <summary>
        /// 砖块中心点y坐标
        /// </summary>
        public int YPos { get; set; }
        /// <summary>
        /// 砖块颜色
        /// </summary>
        public Color BlockColor { get; }

        /// <summary>
        /// 顺时针旋转
        /// </summary>
        public void DeasilRotate()
        {
            int temp;
            //旋转公式 x1=y  y1=-x
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = structArr[i].Y;
                structArr[i].Y = -temp;
            }
        }

        /// <summary>
        /// 逆时针旋转
        /// </summary>
        public void ContraRotate()
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = -structArr[i].Y;
                structArr[i].Y = temp;
            }
        }

        /// <summary>
        /// 把一个坐标点转成画布的坐标值
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Rectangle PointToRect(Point p)
        {
            return new Rectangle(
                (XPos + p.X) * rectPix + 1,
                (YPos - p.Y) * rectPix + 1,
                rectPix - 2,
                rectPix - 2
            );
        }

        /// <summary>
        /// 在指定画板上绘制砖块
        /// </summary>
        /// <param name="gp"></param>
        public virtual void Paint(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(BlockColor);
            foreach (var item in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(item));
                }
            }
        }

        /// <summary>
        /// 擦除矩形
        /// </summary>
        /// <param name="gp"></param>
        public void Erase(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(disapperColor);
            foreach (var item in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(item));
                }
            }
        }
    }
}
