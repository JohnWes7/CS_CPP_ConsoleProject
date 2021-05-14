using System;
using System.Collections.Generic;
using System.Text;

namespace MineGame
{
    class Mine
    {

        private byte[,] mines; //储存棋盘每个位置的信息
        private int height;//雷区高度
        private int width;//雷区宽度
        private int initCount;//初始雷数
        private int mineCount;//当前雷数
        private int markCount;//可标记雷数
        private bool isGameOver;//游戏是否结束

        public int Height
        {
            get { return height; }
        }
        public int Width
        {
            get { return width; }
        }
        public bool IsGameOver
        {
            get { return isGameOver; }
        }


        //规定一下不同信息的标准格式
        //第一层
        private const byte MINE_FLAG_NULL = 0x00;//没翻开 0
        private const byte MINE_FLAG_SCAN = 0x01;//翻开的 1
        private const byte MINE_FLAG_MARK = 0x02;//标记的 2

        //第二层
        private const byte MINE_DATA_NULL = 0x00;//空的0
        private const byte MINE_DATA_MINE = 0x90;//雷9
        
        public Mine()
        {//不指定棋盘的高度 宽度 雷数
            InitMineArea(9, 9, 10);
        }
        public Mine(int heigth, int width, int mineCount)
        { //指定棋盘的高度 宽度 雷数
            //限定一下数据的范围
            heigth = heigth < 9 ? 9 : heigth;
            heigth = heigth > 21 ? 21 : heigth;
            width = width < 9 ? 9 : width;
            width = width > 40 ? 40 : width;
            mineCount = mineCount > (width * heigth) - 1 ? (width * heigth) - 1 : mineCount;
            mineCount = mineCount < 1 ? 1 : mineCount;
            InitMineArea(heigth, width, mineCount);
        }
        /// <summary>
        /// 初始话雷区数据
        /// </summary>
        private void InitMineArea(int height, int width, int mineCount)
        {
            mines = new byte[height, width];
            for (int i = 0; i < mines.GetLength(0); i++)
            {
                for (int j = 0; j < mines.GetLength(1); j++)
                {
                    mines[i, j] = MINE_DATA_NULL;
                }
            }
            //随机分布雷
            RandomSetMine(mineCount);

            this.width = width;
            this.height = height;
            this.mineCount = mineCount;
            this.initCount = mineCount;
            this.markCount = mineCount;
            this.isGameOver = false;


        }

        private void RandomSetMine(int mineCount)
        {
            Random r = new Random();
            int x;
            int y;
            while (mineCount > 0)
            {//只要手里有雷，就继续随机
                x = r.Next(0, mines.GetLength(0));
                y = r.Next(0, mines.GetLength(1));
                if (mines[x, y] == MINE_DATA_NULL)//如果该位置是空的，就把雷放进去
                {
                    mines[x, y] = MINE_DATA_MINE;//把雷存进去
                    mineCount--;
                }

            }

        }
        /// <summary>
        /// 统计周围雷的信息
        /// </summary>
        private void StatistMineCount()
        {
            for (int i = 0; i < mines.GetLength(0); i++)
            {
                for (int j = 0; j < mines.GetLength(1); j++)
                {
                    //不是雷的位置才需要统计 周围有没有雷
                    if (mines[i, j] != MINE_DATA_MINE)
                    {

                    }
                }
            }


        }

        private int StatistMineCountAt(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                if (i<0)
                {
                        
                }
                for (int j = y - 1; j <= y + 1; j++)
                {

                }
            }
        }

    }
}
