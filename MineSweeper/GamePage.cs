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
    public partial class GamePage : Form
    {
        private const int tileSize = 20;

        private int minesLeft, mapSize;
        private int timeSec = 0, timeMin = 0;
        private String[,] text = new String[,] {
            {"Time: ", "Mines Left: "},
            {"时间: ", "剩余地雷: "}
        };

        private Button[,] tiles;

        public GamePage()
        {
            InitializeComponent();

            minesLeft = StartPage.currentNumMines;
            lblMinesLeft.Text = text[StartPage.currentLanguage, 1] + minesLeft.ToString();

            mapSize = StartPage.currentMapSize;
            tiles = new Button[mapSize, mapSize];
            drawBoard();
        }

        private void centreTiles()
        {
            while (this.Size.Width - gbField.Right > gbField.Left)
            {
                gbField.Left++;
            }
        }

        private void drawBoard()
        {
            int x = 0, y = 0;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button newButton = new Button();
                    newButton.Visible = true;
                    newButton.Name = "tile" + i + ", " + j;
                    newButton.Text = "";
                    newButton.Size = new Size(tileSize, tileSize);
                    newButton.Location = new Point(x, y);
                    newButton.Tag = i * mapSize + j;
                    newButton.MouseDown += btn_MouseDown;
                    newButton.BackColor = Color.DimGray;
                    newButton.FlatStyle = FlatStyle.Flat;

                    gbField.Controls.Add(newButton);
                    tiles[i, j] = newButton;

                    x += tileSize;
                }
                y += tileSize;
                x = 0;
            }

            centreTiles();
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            int x = Convert.ToInt32(btn.Tag) / mapSize;
            int y = Convert.ToInt32(btn.Tag) % mapSize;

            
            if (e.Button == MouseButtons.Right)
            {
                if (btn.Text == "")
                {
                    btn.Text = "🚩";
                    btn.ForeColor = Color.Red;
                    btn.BackColor = Color.Blue;
                    lblMinesLeft.Text = text[StartPage.currentLanguage, 1] + (--minesLeft);
                }
                else if (btn.Text == "🚩")
                {
                    btn.Text = "";
                    btn.BackColor = Color.DimGray;
                    lblMinesLeft.Text = "地雷剩余：" + ++minesLeft;
                }

                if (minesLeft == 0)
                {
                    bool flagAllOnMines = true;

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            if (tiles[i, j].Text == "P" && Globals.ans[i, j] != -1)
                            {
                                flagAllOnMines = false;
                            }
                        }
                    }

                    if (flagAllOnMines)
                    {
                        MessageBox.Show("恭喜！游戏胜利！");
                        frm2.Show();
                        this.Close();
                    }
                }
            }

            /*
            if (e.Button == MouseButtons.Left)
            {
                if (Globals.firstClick)
                {
                    Globals.firstClick = false;
                    int count = 0;
                    while ((Globals.ans[x, y] == -1 || Globals.ans[x, y] > 2) && count++ < 10000)
                    {
                        generateMines();
                    }
                }

                if (btn.Text == "")
                {
                    flipArea(x, y);
                    connectZero(x, y);


                    if (--Globals.areaUnfliped == 0)
                    {
                        MessageBox.Show("恭喜！游戏胜利！");
                        frm2.Show();
                        this.Close();
                        frm2.Show();
                    }
                }

                if (!Globals.dClickTimerOn)
                {
                    Globals.dClickTimerOn = true;
                    timerDClick.Enabled = true;
                }
                else
                {
                    btn_doubleClick(x, y);
                }
            }*/
        }

        private void GamePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartPage.FormStart.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeSec++;
            if (timeSec >= 60)
            {
                timeSec = 0;
                timeMin++;
            }

            lblTimer.Text = text[StartPage.currentLanguage, 0] + timeMin.ToString("D2") + ":" + timeSec.ToString("D2");
        }
    }
}
