using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// 画板
    /// </summary>
    class Palette
    {
        /// <summary>
        /// 画板宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 画板高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 固定砖块数组
        /// </summary>
        public Color[,] CoorArr { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color disapperColor{ get; set; }
        /// <summary>
        /// 砖块活动画板
        /// </summary>
        public Graphics gpPalette { get; set; }
        /// <summary>
        /// 下一个砖块样式画板
        /// </summary>
        public Graphics gpReady { get; set; }
        /// <summary>
        /// 砖块生产机
        /// </summary>
        public BlockGroup bGroup { get; set; }
        /// <summary>
        /// 正在活动的砖块
        /// </summary>
        public Block runBlock { get; set; }
        /// <summary>
        /// 下一个砖块
        /// </summary>
        public Block readyBlock { get; set; }
        /// <summary>
        /// 单元格像素
        /// </summary>
        public int RectPic { get; set; }

        private System.Timers.Timer timerBlock;//定时器
        private int timeSpan = 800;//定时器的时间间隔

        public Palette(int x, int y, int pix, Color dColor, Graphics gp, Graphics gr)
        {
            Width = x;
            Height = y;
            CoorArr = new Color[Width, Height];
            disapperColor = dColor;
            gpPalette = gp;
            gpReady = gr;
            RectPic = pix;
        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        public void Start()
        {
            bGroup = new BlockGroup();
            runBlock = bGroup.GetSuiJiBlock();
            runBlock.XPos = Width / 2;
            //寻找y的最大值
            int y = 0;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (runBlock[i].Y > y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock.YPos = y;
            gpPalette.Clear(disapperColor);//清除画板
            runBlock.Paint(gpPalette);

            Thread.Sleep(20);//线程挂起20毫秒
            readyBlock = bGroup.GetSuiJiBlock();
            readyBlock.XPos = 2;
            readyBlock.YPos = 2;
            gpReady.Clear(disapperColor);//清除画板
            readyBlock.Paint(gpReady);

            timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }
        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            Down();
        }

        /// <summary>
        /// 砖块下移
        /// </summary>
        /// <returns></returns>
        public bool Down()
        {
            int xpos = runBlock.XPos;
            int ypos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                //如果超出下边界则失败
                if (ypos - runBlock[i].Y > Height - 1)
                    return false;
                //如果下边有东西挡住则失败
                if (!CoorArr[xpos + runBlock[i].X, ypos - runBlock[i].Y].IsEmpty)
                    return false;
            }
            runBlock.Erase(gpPalette);//擦除
            runBlock.YPos++;
            runBlock.Paint(gpPalette);
            return true;
        }
        public void Drop()
        {
            timerBlock.Stop();
            while (Down()) ;
            timerBlock.Start();
        }
        /// <summary>
        /// 砖块左移
        /// </summary>
        /// <returns></returns>
        public bool MoveLeft()
        {
            int xpos = runBlock.XPos - 1;
            int ypos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                //如果超出左边界则失败
                if (xpos - runBlock[i].X < 0)
                    return false;
                //如果左边有东西挡住则失败
                if (!CoorArr[xpos + runBlock[i].X, ypos - runBlock[i].Y].IsEmpty)
                    return false;
            }
            runBlock.Erase(gpPalette);//擦除
            runBlock.XPos--;
            runBlock.Paint(gpPalette);
            return true;
        }

        /// <summary>
        /// 砖块右移
        /// </summary>
        /// <returns></returns>
        public bool MoveRight()
        {
            int xpos = runBlock.XPos + 1;
            int ypos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                //如果超出右边界则失败
                if (xpos + runBlock[i].X > Width-1)
                    return false;
                //如果右边有东西挡住则失败
                if (!CoorArr[xpos + runBlock[i].X, ypos - runBlock[i].Y].IsEmpty)
                    return false;
            }
            runBlock.Erase(gpPalette);//擦除
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
            return true;
        }

        /// <summary>
        /// 顺时针旋转
        /// </summary>
        /// <returns></returns>
        public void DeasiRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                //如果超出左右边界，则旋转失败
                if (x < 0 || x > Width - 1)
                    return;
                //如果超出上下边界，则旋转失败
                if (y < 0 || y > Height - 1)
                    return;
                //如果旋转后的位置有砖块，则旋转失败
                if (!CoorArr[x, y].IsEmpty)
                    return;
            }
            runBlock.Erase(gpPalette);//擦除
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }

        /// <summary>
        /// 逆时针旋转
        /// </summary>
        public void ContraRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos - runBlock[i].Y;
                int y = runBlock.YPos - runBlock[i].X;
                //如果超出左右边界，则旋转失败
                if (x < 0 || x > Width - 1)
                    return;
                //如果超出上下边界，则旋转失败
                if (y < 0 || y > Height - 1)
                    return;
                //如果旋转后的位置有砖块，则旋转失败
                if (!CoorArr[x, y].IsEmpty)
                    return;
            }
            runBlock.Erase(gpPalette);//擦除
            runBlock.ContraRotate();
            runBlock.Paint(gpPalette);
        }

        /// <summary>
        /// 重画画板的背景
        /// </summary>
        /// <param name="gp"></param>
        private void PaintBackground(Graphics gp)
        {
            gp.Clear(Color.Black);//首先清空画板
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (!CoorArr[j, i].IsEmpty)
                    {
                        SolidBrush sb = new SolidBrush(CoorArr[j, i]);
                        gp.FillRectangle(sb,
                            j * RectPic + 1, i * RectPic + 1,
                            RectPic - 2, RectPic - 2
                        );
                    }
                }
            }
        }
        /// <summary>
        /// 重画整个画板
        /// </summary>
        /// <param name="gp"></param>
        public void PaintPalette(Graphics gp)
        {
            //先画背景
            PaintBackground(gp);
            //再画活动的砖块
            if (runBlock != null)
                runBlock.Paint(gp);
        }
        /// <summary>
        /// 重画下一个砖块
        /// </summary>
        /// <param name="gp"></param>
        public void PaintReady(Graphics gp)
        {
            if (readyBlock != null)
                readyBlock.Paint(gp);
        }
        
        /// <summary>
        /// 检查砖块是否到底，如果到底则把砖块归入 CoorArr，并产生新的砖块
        /// </summary>
        public void CheckAndOverBlock()
        {
            bool over = false;//设置当前运行砖块是否到底
            //遍历当前砖块的所有小方块
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].X;
                int y = runBlock.YPos - runBlock[i].Y;
                //如果到达下边界，则当前砖块结束
                if (y == Height - 1)
                {
                    over = true;
                    break;
                }
                //如果下面有其他砖块，则当前砖块结束
                if (!CoorArr[x, y + 1].IsEmpty)
                {
                    over = true;
                    break;
                }
            }
            //当前砖块已结束
            if (over)
            {
                //把当前砖块归入 CoorArr
                for (int i = 0; i < runBlock.Length; i++)
                {
                    CoorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                //检查是否有满行，如果有，则去掉满行
                CheckAndDelFullRow();
                //产生新的砖块
                runBlock = readyBlock;
                runBlock.XPos = Width / 2;

                //确保新砖块上面没有空行
                int y = 0;
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                        y = runBlock[i].Y;
                }

                runBlock.YPos = y;
                //检查新产生砖块所占地方是否已有砖块，如果有，则游戏结束
                for (int i = 0; i < runBlock.Length; i++)
                {
                    //游戏结束
                    if (!CoorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y].IsEmpty)
                    {
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("Game Over",
                            new Font("Arial Black", 25f),
                            new SolidBrush(Color.White),
                            new RectangleF(0, Height * RectPic / 2 - 100, Width * RectPic, 100),
                            drawFormat
                        );
                        timerBlock.Stop();//关闭定时器
                        return;
                    }
                }
                runBlock.Paint(gpPalette);

                //新的准备砖块
                readyBlock = bGroup.GetSuiJiBlock();
                readyBlock.XPos = 2;
                readyBlock.YPos = 2;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }

        /// <summary>
        /// 检查并删除满行
        /// </summary>
        private void CheckAndDelFullRow()
        {
            //找出当前砖块所在行范围
            int lowRow = runBlock.YPos - runBlock[0].Y;
            int highRow = lowRow;
            //找出当前砖块所占行的范围，放入low、high变量
            for (int i = 1; i < runBlock.Length; i++)
            {
                int y = runBlock.YPos - runBlock[i].Y;
                if (y < lowRow)
                    lowRow = y;
                if (y > highRow)
                    highRow = y;
            }

            bool repaint = false;//判断是否需要重画
            //检查满行，如果有，则删除这一行
            for (int i = lowRow; i <= highRow; i++)
            {
                bool rowFull = true;
                for (int j = 0; j < Width; j++)
                {
                    //如果有一个单元格为空，说明这行不是满行
                    if (CoorArr[j, i].IsEmpty)
                    {
                        rowFull = false;
                        break;
                    }
                }
                //如果满行，则删除这一行
                if (rowFull)
                {
                    repaint = true;//如果有要删除的行，则需要重画
                    //把第n行的值用n-1行的值来代替
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            CoorArr[j, k] = CoorArr[j, k - 1];
                        }
                    }
                    for (int j = 0; j < Width; j++)
                    {
                        CoorArr[j, 0] = Color.Empty;
                    }
                }
            }
            if (repaint)
                PaintBackground(gpPalette);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            if (timerBlock.Enabled)
                timerBlock.Enabled = false;
        }
        /// <summary>
        /// 结束暂停
        /// </summary>
        public void EndPause()
        {
            if (!timerBlock.Enabled)
                timerBlock.Enabled = true;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            timerBlock.Close();//关闭定时器
            gpPalette.Dispose();//释放画布
            gpReady.Dispose();//释放画布  应实现释放模式，以保证Dispose可执行，参看析构节
        }
    }
}
