using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public Mine mine;
        bool GameRound;
        bool Right_Press;
        bool Left_Press;
        public PictureBox[] pic;
        Button Face;
        Label Time;
        int x;
        int y;
        public Form1()
        {
            InitializeComponent();
            mine = new Mine();
            Start();
            ToEasy.Click += Difficulty_Click;
            ToNormal.Click += Difficulty_Click;
            ToHard.Click += Difficulty_Click;
        }
        private void Start()
        {
            x = mine.x;
            y = mine.y;
            pic = new PictureBox[x * y];
            int Bx = 0; int By = 0;

            Face = new Button();
            Face.Size = new Size(36, 36);
            Face.Location = new Point(5 + 36*(int)(0.5*x)-18, 28 + By);//只是要把臉喬到一個好看的位置
            Face.Image = imageList1.Images[10];
            Face.FlatStyle = FlatStyle.Popup;
            Face.Click += FaceClick;
            Controls.Add(Face);

            Time = new Label();
            Time.Text = "0";
            Time.Size = new Size(72,36);
            Time.Location = new Point(5 + 36 * (x - 2), 28 + By);
            Time.BackColor = Color.Black; Time.ForeColor = Color.Red;
            Time.BorderStyle = BorderStyle.Fixed3D;
            Time.TextAlign = ContentAlignment.MiddleRight;
            Time.Font = new Font("Microsoft YaHei UI",18,FontStyle.Bold);
            Controls.Add(Time);
            timer1.Enabled = false;

            for (int i = 0; i <= x * y - 1; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Size = new Size(36, 36);
                pic[i].BorderStyle = BorderStyle.FixedSingle;
                pic[i].Image = imageList1.Images[0];
                pic[i].Location = new Point(4 + Bx, 66 + By);
                Bx += 36;
                if (Bx == 36 * x)
                {
                    Bx = 0;
                    By += 36;
                }
                Controls.Add(pic[i]);
                pic[i].MouseDown += pic_MouseDown;
                pic[i].MouseUp += pic_MouseUp;
                pic[i].MouseLeave += pic_MouseLeave;
                pic[i].MouseClick += pic_MouseClick;
            }
            mine.CreateMap();
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            //按左鍵的情況
             
            timer1.Enabled = true;
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i <= mine.x * mine.y - 1; i++)
                {
                    if (sender == pic[i] && !GameRound && mine.Num[i] == -1)//一輪遊戲初次點擊
                    {
                        mine.SafeOrBomb[i] = 0;
                        mine.SafeOrBomb[0] = -1;
                        for (int j = 0; j <= mine.x * mine.y - 1; j++)//重繪製數字化地圖
                        {
                            if (mine.SafeOrBomb[j] == -1)
                                mine.Num[j] = -1;
                            else
                                mine.Num[j] = mine.Find(j);
                        }
                        GameRound = true;
                    }
                    
                    if (sender == pic[i])//取得所按按鈕的索引值
                    {
                        if (mine.SafeOrBomb[i] == -1)//點到地雷的狀況
                        {
                            for (int j = 0; j <= mine.x * mine.y -1; j++)//失敗後一口氣顯示所有地雷
                            {
                                if (mine.SafeOrBomb[j] == -1)
                                {
                                    pic[j].Image = imageList1.Images[12];
                                    pic[i].Image = imageList1.Images[13];
                                }
                            }
                            Face.Image = imageList1.Images[9];
                            timer1.Enabled = false;
                            MessageBox.Show("失敗了", "哭哭ㄛ");
                            Renew();
                        }

                        else if (mine.SafeOrBomb[i] == 0)//沒有按到地雷的狀況
                        {
                            mine.SafeOrBomb[i] = 1;
                            pic[i].Image = imageList1.Images[mine.Num[i]];
                            if (mine.Num[i] == 0)//如果點下去的格子周遭沒有地雷，啟動快速擴散系統
                            {
                                mine.Quickly(i);
                                for (int j = 0; j <= mine.x * mine.y -1; j++)//確認地圖上被擴散的格子，並將按鈕圖示改為壓下
                                {
                                    if (mine.SafeOrBomb[j] == 1)
                                    {
                                        pic[j].Image = imageList1.Images[mine.Num[j]];
                                        pic[j].BorderStyle = BorderStyle.Fixed3D;
                                    }
                                }
                            }
                            break;
                        }
                        else if (mine.SafeOrBomb[i] == 1 && Left_Press && Right_Press)//左右雙鍵都按
                        {
                            if (mine.FindFlags(i) == -1)
                            {
                                for (int j = 0; j <= mine.x * mine.y -1; j++)//失敗後一口氣顯示所有地雷
                                {
                                    if (mine.SafeOrBomb[j] == 2)
                                        pic[j].Image = imageList1.Images[14];
                                    if(mine.SafeOrBomb[j] == -1)
                                        pic[j].Image = imageList1.Images[12];
                                }
                                Face.Image = imageList1.Images[9];
                                timer1.Enabled = false;
                                MessageBox.Show("失敗了", "哭哭ㄛ");
                                Renew();
                            }
                            if(mine.FindFlags(i) == mine.Num[i])
                                mine.Quickly(i);
                            for (int j = 0; j <= mine.x * mine.y -1 ; j++)
                            {
                                if (mine.SafeOrBomb[j] == 1)
                                {
                                    pic[j].Image = imageList1.Images[mine.Num[j]];
                                    pic[j].BorderStyle = BorderStyle.Fixed3D;
                                }
                            }
                            Left_Press = false;
                            Right_Press = false;
                        }
                    }
                }
                GameRound = true;
            }
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Left_Press = true;
            if (e.Button == MouseButtons.Right)
                Right_Press = true;
             
            for (int i = 0; i <= mine.x * mine.y - 1; i++)
            {
                if (sender == pic[i] && e.Button == MouseButtons.Left)//左鍵按住不放會有壓下的效果
                {
                    if (mine.SafeOrBomb[i] != 2 && mine.SafeOrBomb[i] != 3)//但是對插旗中的格子無效
                        pic[i].BorderStyle = BorderStyle.Fixed3D;
                }
                else if (sender == pic[i] && e.Button == MouseButtons.Right)//按右鍵插旗或拔旗
                    pic[i].Image = imageList1.Images[mine.PutOrTakeFlag(i)];

                if (sender == pic[i] && mine.SafeOrBomb[i] == 1 && Left_Press && Right_Press)
                {
                    if (i >= x + 1 && i % x != 0)
                        if (NoOpen(i - (x + 1))) pic[i - (x + 1)].BorderStyle = BorderStyle.Fixed3D;
                    if (i >= x)
                        if (NoOpen(i - x)) pic[i - x].BorderStyle = BorderStyle.Fixed3D;
                    if (i >= x && i % x != x - 1)
                        if (NoOpen(i - (x - 1))) pic[i - (x - 1)].BorderStyle = BorderStyle.Fixed3D;
                    if (i % x != 0)
                        if (NoOpen(i - 1)) pic[i - 1].BorderStyle = BorderStyle.Fixed3D;
                    if (i % x != x - 1)
                        if (NoOpen(i + 1)) pic[i + 1].BorderStyle = BorderStyle.Fixed3D;
                    if (i <= (x * y - 1) - x && i % x != 0)
                        if (NoOpen(i + (x - 1))) pic[i + (x - 1)].BorderStyle = BorderStyle.Fixed3D;
                    if (i <= (x * y - 1) - x)
                        if (NoOpen(i + x)) pic[i + x].BorderStyle = BorderStyle.Fixed3D;
                    if (i <= (x * y - 2) - x && i % x != x - 1)
                        if (NoOpen(i + (x + 1))) pic[i + (x + 1)].BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Left_Press = false;
            if (e.Button == MouseButtons.Right)
                Right_Press = false;
             
            for (int i = 1; i <= mine.x * mine.y - 1; i++)
            {
                if (sender == pic[i])
                {
                    if (i >= x + 1 && i % x != 0)
                        if (NoOpen(i - (x + 1))) pic[i - (x + 1)].BorderStyle = BorderStyle.FixedSingle;
                    if (i >= x)
                        if (NoOpen(i - x)) pic[i - x].BorderStyle = BorderStyle.FixedSingle;
                    if (i >= x && i % x != x - 1)
                        if (NoOpen(i - (x - 1))) pic[i - (x - 1)].BorderStyle = BorderStyle.FixedSingle;
                    if (i % x != 0)
                        if (NoOpen(i - 1)) pic[i - 1].BorderStyle = BorderStyle.FixedSingle;
                    if (i % x != x - 1)
                        if (NoOpen(i + 1)) pic[i + 1].BorderStyle = BorderStyle.FixedSingle;
                    if (i <= (x * y - 1) - x && i % x != 0)
                        if (NoOpen(i + (x - 1))) pic[i + (x - 1)].BorderStyle = BorderStyle.FixedSingle;
                    if (i <= (x * y - 1) - x)
                        if (NoOpen(i + x)) pic[i + x].BorderStyle = BorderStyle.FixedSingle;
                    if (i <= (x * y - 2) - x && i % x != x - 1)
                        if (NoOpen(i + (x + 1))) pic[i + (x + 1)].BorderStyle = BorderStyle.FixedSingle;
                }
            }
            Win();
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
             
            for (int i = 0; i <= mine.x * mine.y - 1; i++)
            {
                if (sender == pic[i] && NoOpen(i))
                    pic[i].BorderStyle = BorderStyle.FixedSingle;
            }
        }
        
        public void Renew()
        {
            for (int k = 0; k <= mine.x * mine.y - 1; k++)
            {
                pic[k].Image = imageList1.Images[0];
                pic[k].BorderStyle = BorderStyle.FixedSingle;
            }
            Face.Image = imageList1.Images[10];
            timer1.Enabled = false;
            Time.Text = "0";
            mine.CreateMap();
            GameRound = false;
        }

        public bool NoOpen(int i)
        {
            if (mine.SafeOrBomb[i] == 0 || mine.SafeOrBomb[i] == -1)
                return true;
            else
                return false;
        }

        private void Difficulty_Click(object sender, EventArgs e)
        {
            int d = 0;
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            if (t == ToEasy) d = 10;
            else if (t == ToNormal) d = 40;
            else if (t == ToHard) d = 99;
            for (int i = 0; i <= x * y - 1; i++)
            {
                Controls.Remove(pic[i]);
            }
            Controls.Remove(Face);
            Controls.Remove(Time);
            Array.Clear(pic, 0, x * y);
            mine.DifficultySelect(d);
            Start();
        }

        private void Arrange_Click(object sender, EventArgs e)
        {
            ArrangeForm ar = new ArrangeForm();
            ar.ShowDialog();
            if (ar.ok)
            {
                mine.x = ar.Arrange_x;
                mine.y = ar.Arrange_y;
                mine.Bombs = ar.Arrange_m;
                for (int i = 0; i <= x * y - 1; i++)
                {
                    Controls.Remove(pic[i]);
                }
                Controls.Remove(Face);
                Controls.Remove(Time);
                Array.Clear(pic, 0, x * y);
                Start();
                Renew();
            }
        }

        private void FaceClick(object sender, EventArgs e)
        {
            Renew();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = (Convert.ToInt32(Time.Text) + 1).ToString();
            if (Convert.ToInt32(Time.Text) >= 999)
                timer1.Enabled = false ;
        }

        public void Win()
        {
            for (int i = 0; i < x * y - 1; i++)
            {
                if (mine.SafeOrBomb[i] == 0 || mine.SafeOrBomb[i] == 2)
                    return;
            }
            timer1.Enabled = false;
            Face.Image = imageList1.Images[15];
            for (int i = 0; i <= x * y - 1; i++)
            {
                if(mine.SafeOrBomb[i] == -1)
                {
                    pic[i].Image = imageList1.Images[11];
                    mine.SafeOrBomb[i] = 3;
                }
            }
        }

        //測試數字化地圖用的
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mine.x * mine.y - 1; i++)
            {
                Console.Write($"{mine.Num[i]}      ");
                if (mine.Num[i] >= 0)
                    Console.Write(" ");
                if (i % mine.x == mine.x - 1)
                    Console.WriteLine("");
            }
        }
        
    }
}
