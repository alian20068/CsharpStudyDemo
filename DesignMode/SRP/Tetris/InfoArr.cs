using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    /// <summary>
    /// 砖块数组
    /// </summary>
    class InfoArr
    {
        private ArrayList info = new ArrayList();//存放多个 BlockInfo 砖块的数组
        public int Length
        {
            get
            {
                return info.Count;
            }
        }
        
        /// <summary>
        /// 索引器，根据下标，返回BlockInfo
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BlockInfo this[int index]
        {
            get
            {
                return (BlockInfo)info[index];
            }
        }
        
        /// <summary>
        /// 索引器，根据一个字符串的ID值下标，给相应ID的颜色赋值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string this[string id]
        {
            set
            {
                if (value == "")
                {
                    return;
                }
                for (int i = 0; i < info.Count; i++)
                {
                    if (((BlockInfo)info[i]).GetIdStr() == id)
                    {
                        try
                        {
                            ((BlockInfo)info[i]).Bcolor = Color.FromArgb(Convert.ToInt32(value));
                        }
                        catch (System.FormatException)
                        {
                            MessageBox.Show("颜色信息错误！请删除BlockSet.xml文件，并重新启动程序", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 把字符串转换为BitArray
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private BitArray StringToBit(string id)
        {
            if (id.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序");
            }
            BitArray ba = new BitArray(25);
            for (int i = 0; i < 25; i++)
            {
                ba[i] = (id[i] == '0' ? false : true);
            }
            return ba;
        }

        /// <summary>
        /// 添加一个砖块信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bColor"></param>
        public void Add(BitArray id,Color bColor)
        {
            if (id.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序");
            }
            info.Add(new BlockInfo(id, bColor));//给动态数组info添加一个砖块信息
        }
        /// <summary>
        /// 添加一个砖块信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bColor"></param>
        public void Add(string id, string bColor)
        {
            Color temp;
            if (!(bColor == ""))
            {
                temp = Color.FromArgb(Convert.ToInt32(bColor));//把字符串转颜色值
            }
            else
            {
                temp = Color.Empty;
            }
            info.Add(new BlockInfo(StringToBit(id), temp));
        }
    }
}
