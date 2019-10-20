using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 砖块信息
    /// </summary>
    class BlockInfo
    {
        public BlockInfo(BitArray id,Color bcolor)
        {
            this.Id = id;
            this.Bcolor = bcolor;
        }

        /// <summary>
        /// 存放颜色信息
        /// </summary>
        public Color Bcolor { get; set; }

        /// <summary>
        /// 存放砖块样式信息
        /// </summary>
        public BitArray Id { get; set; }

        public string GetIdStr()
        {
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in Id)
            {
                sb.Append(i ? "1" : "0");
            }

            return sb.ToString();
        }

        public string GetColorStr()
        {
            return Bcolor.ToArgb().ToString();
        }
    }
}
