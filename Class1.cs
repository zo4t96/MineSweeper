using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Mine
    {
        //測試git運作加的註解
        public Random rnd = new Random();
        public int x = 8;
        public int y = 8;
        public int Bombs = 10;
        public int[] SafeOrBomb;//0 = 未踏;1 = 已開啟;-1 = 地雷;2 = 插錯旗;3 = 插對旗
        public int[] Num;//遊戲地圖數字陣列化
        public void CreateMap()//建立新遊戲的地雷配置
        
        {
            SafeOrBomb = new int[x*y];
            Num = new int[x*y];
            for (int i = 0; i <= x * y - 1; i++) SafeOrBomb[i] = 0;//將全地圖地雷清零
            for (int i = 1; i <= Bombs; i++)//隨機配置i數量的地雷
            {
                int j = rnd.Next(1, x * y);
                if (SafeOrBomb[j] == -1)
                    i--;
                else
                    SafeOrBomb[j] = -1;
            }
            for (int i = 0; i <= x * y - 1; i++)//繪製數字化地圖
            {
                if (SafeOrBomb[i] == -1)
                    Num[i] = -1;
                else
                    Num[i] = Find(i);
            }
        }

        public int Find(int w)
        {
            int HowManyBombs = 0;
            if (w >= x + 1 && w % x != 0)//計算左上角是否有地雷，要濾掉沒有左上角的
                if (SafeOrBomb[w - (x + 1)] == -1) HowManyBombs++;
            if (w >= x)//計算正上方是否有地雷，要濾掉沒有上方的
                if (SafeOrBomb[w - x] == -1) HowManyBombs++;
            if (w >= x && w % x != x -1)//計算右上角是否有地雷，要濾掉沒有右上角的
                if (SafeOrBomb[w - (x - 1)] == -1) HowManyBombs++;
            if (w % x != 0)//計算左方是否有地雷，要濾掉沒有左方的
                if (SafeOrBomb[w - 1] == -1) HowManyBombs++;
            if (w % x != x - 1)//計算右方是否有地雷，要濾掉沒有右方的
                if (SafeOrBomb[w + 1] == -1) HowManyBombs++;
            if (w <= (x * y - 1) - x && w % x != 0)//計算左下角是否有地雷，要濾掉沒有右下方的
                if (SafeOrBomb[w + (x - 1)] == -1) HowManyBombs++;
            if (w <= (x * y - 1) - x)//計算正下方是否有地雷，要濾掉沒有正下方的
                if (SafeOrBomb[w + x] == -1) HowManyBombs++;
            if (w <= (x * y - 2) - x && w % x != x - 1)//計算右下角是否有地雷，要濾掉沒有右下角的
                if (SafeOrBomb[w + (x + 1)] == -1) HowManyBombs++;
            return HowManyBombs;
        }

        public int FindFlags(int w)//檢測按下去的格子周遭的旗子
        {
            int HowManyFlags = 0; int WrongFlags = 0;
            if (w >= x + 1 && w % x != 0)
            {
                if (SafeOrBomb[w - (x + 1)] == 3) HowManyFlags++;
                if (SafeOrBomb[w - (x + 1)] == 2) WrongFlags++;
            }
            if (w >= x)
            {
                if (SafeOrBomb[w - x] == 3) HowManyFlags++;
                if (SafeOrBomb[w - x] == 2) WrongFlags++;
            }
            if (w >= x && w % x != x - 1)
            {
                if (SafeOrBomb[w - (x - 1)] == 3) HowManyFlags++;
                if (SafeOrBomb[w - (x - 1)] == 2) WrongFlags++;
            }
            if (w % x != 0)
            {
                if (SafeOrBomb[w - 1] == 3) HowManyFlags++;
                if (SafeOrBomb[w - 1] == 2) WrongFlags++;
            }
            if (w % x != x - 1)
            {
                if (SafeOrBomb[w + 1] == 3) HowManyFlags++;
                if (SafeOrBomb[w + 1] == 2) WrongFlags++;
            }
            if (w <= (x * y - 1) - x && w % x != 0)
            {
                if (SafeOrBomb[w + (x - 1)] == 3) HowManyFlags++;
                if (SafeOrBomb[w + (x - 1)] == 2) WrongFlags++;
            }
            if (w <= (x * y - 1) - x)
            {
                if (SafeOrBomb[w + x] == 3) HowManyFlags++;
                if (SafeOrBomb[w + x] == 2) WrongFlags++;
            }
            if (w <= (x * y - 2) - x && w % x != x - 1)
            {
                if (SafeOrBomb[w + (x + 1)] == 3) HowManyFlags++;
                if (SafeOrBomb[w + (x + 1)] == 2) WrongFlags++;
            }
            if (WrongFlags >= 1)
                return -1;
            else
                return HowManyFlags;
        }

        public void Quickly(int w)//自動判斷周遭沒有地雷的擴散系統
        {
            if (SafeOrBomb[w] == 0)//擴散效果只會影響沒開過的格子
                SafeOrBomb[w] = 1;
            if (w >= x + 1 && w % x != 0)
            {
                if (SafeOrBomb[w - (x + 1)] == 0)
                {
                    SafeOrBomb[w - (x + 1)] = 1;
                    if (Num[w - (x + 1)] == 0) Quickly(w - (x + 1));
                }
            }
            if (w >= x)
            {
                if (SafeOrBomb[w - x] == 0)
                {
                    SafeOrBomb[w - x] = 1;
                    if (Num[w - x] == 0) Quickly(w - x);
                }
            }
            if (w >= x && w % x != x - 1)
            {
                if (SafeOrBomb[w - (x - 1)] == 0)
                {
                    SafeOrBomb[w - (x - 1)] = 1;
                    if (Num[w - (x - 1)] == 0) Quickly(w - (x - 1));
                }
            }
            if (w % x != 0)
            {
                if (SafeOrBomb[w - 1] == 0)
                {
                    SafeOrBomb[w - 1] = 1;
                    if (Num[w - 1] == 0) Quickly(w - 1);
                }
            }
            if (w % x != x - 1)
            {
                if (SafeOrBomb[w + 1] == 0)
                {
                    SafeOrBomb[w + 1] = 1;
                    if (Num[w + 1] == 0) Quickly(w + 1);
                }
            }
            if (w <= (x * y - 1) - x && w % x != 0)
            {
                if (SafeOrBomb[w + (x - 1)] == 0)
                {
                    SafeOrBomb[w + (x - 1)] = 1;
                    if (Num[w + (x - 1)] == 0) Quickly(w + (x - 1));
                }
            }
            if (w <= (x * y - 1) - x)
            {
                if (SafeOrBomb[w + x] == 0)
                {
                    SafeOrBomb[w + x] = 1;
                    if (Num[w + x] == 0) Quickly(w + x);
                }
            }
            if (w <= (x * y - 2) - x && w % x != x - 1)
            {
                if (SafeOrBomb[w + (x + 1)] == 0)
                {
                    SafeOrBomb[w + (x + 1)] = 1;
                    if (Num[w + (x + 1)] == 0) Quickly(w + (x + 1));
                }
            }
        }
        public int PutOrTakeFlag(int i)//插旗或拔旗系統
        {
            if (SafeOrBomb[i] == -1)
            {
                SafeOrBomb[i] = 3;
                return 11;
            }
            else if (SafeOrBomb[i] == 0)
            {
                SafeOrBomb[i] = 2;
                return 11;
            }
            else if (SafeOrBomb[i] == 3)
            {
                SafeOrBomb[i] = -1;
                return 0;
            }
            else if (SafeOrBomb[i] == 2)
            {
                SafeOrBomb[i] = 0;
                return 0;
            }
            else
                return Num[i];
        }

        public void DifficultySelect(int d)
        {
            if (d == 10) { x = 8; y = 8; Bombs = d; }
            if (d == 40) { x = 16; y = 16; Bombs = d; }
            if (d == 99) { x = 30; y = 16; Bombs = d; }
            CreateMap();
        }
    }
}
