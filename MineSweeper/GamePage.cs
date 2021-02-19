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
        private const int tileSize = 23;
        private const String FLAG = "🚩", UNFLIPPED = "", MINE = "*";

        private int minesLeft, mapSize, tileUnrevealed;
        private int timeSec = 0, timeMin = 0;
        private String[,] text = new String[,] {
            {"Time: ", "Mines Left: ", "You WON!", "Great work! All the mines were found, and the field is now safe to walk on!", "You LOST!", "A mine has exploded beneath your feet, better luck next time, and hope you can recover soon...", "Games played: ", "Games won: ", "Percentage: "},
            {"时间: ", "剩余地雷: ", "你赢了!", "又一片土地成功摆脱了战争遗留的隐患, 恢复了它该有的安宁。", "你输了!", "一枚地雷在你的脚下引爆了,下次要再加小心呦...", "游戏局数: ", "胜利局数: ", "百分比: "}
        };

        private bool firstClick = true, gamePaused = false;

        private Button[,] tiles;
        private int[,] ans;

        public GamePage()
        {
            InitializeComponent();

            minesLeft = StartPage.currentNumMines;
            lblMinesLeft.Text = text[StartPage.currentLanguage, 1] + minesLeft.ToString();

            mapSize = StartPage.currentMapSize;
            tiles = new Button[mapSize, mapSize];
            drawBoard();

            tileUnrevealed = mapSize * mapSize - minesLeft;
        }

        private void generateMines()
        {
            ans = new int[mapSize, mapSize];

            if (StartPage.isDifficult) generateByRow();
            else generateByRandom();
        }

        private void incrimentNeighbours(int i, int j)
        {
            /// left
            if (i > 0 && ans[i - 1, j] != -1)
            {
                ans[i - 1, j]++;
            }

            /// left top
            if (i > 0 && j > 0 && ans[i - 1, j - 1] != -1)
            {
                ans[i - 1, j - 1]++;
            }

            /// left bottom
            if (i > 0 && j < mapSize-1 && ans[i - 1, j + 1] != -1)
            {
                ans[i - 1, j + 1]++;
            }

            /// top
            if (j > 0 && ans[i, j - 1] != -1)
            {
                ans[i, j - 1]++;
            }

            /// bottom
            if (j < mapSize-1 && ans[i, j + 1] != -1)
            {
                ans[i, j + 1]++;
            }

            /// right
            if (i < mapSize-1 && ans[i + 1, j] != -1)
            {
                ans[i + 1, j]++;
            }

            ///right top
            if (i < mapSize-1 && j > 0 && ans[i + 1, j - 1] != -1)
            {
                ans[i + 1, j - 1]++;
            }

            /// right bottom
            if (i < mapSize-1 && j < mapSize-1 && ans[i + 1, j + 1] != -1)
            {
                ans[i + 1, j + 1]++;
            }
        }

        private void generateByRandom()
        {
            Random random = new Random();
            int numMines = minesLeft;
            int count = 0;

            while (numMines > 0)
            {
                if (++count >= 1000000)
                {
                    MessageBox.Show("Error generating mines!", "Error!");
                    break;
                }

                int i = random.Next(mapSize), j = random.Next(mapSize);
                if (ans[i,j] != -1)
                {
                    ans[i, j] = -1;
                    incrimentNeighbours(i, j);
                    numMines--;
                }
            }
        }

        private void generateByRow()
        {
            Random random = new Random();
            int numMines = minesLeft;
            int minesPerRow = numMines / mapSize;

            for (int i = 0; i < mapSize; i++)
            {
                int minesCount = minesPerRow;
                if (i == mapSize - 1) minesCount = numMines;

                while (minesCount > 0)
                {
                    int j = random.Next(mapSize);

                    if (ans[i, j] != -1)
                    {
                        ans[i, j] = -1;
                        incrimentNeighbours(i, j);
                        minesCount--;
                        numMines--;
                    }
                }
            }
        }

        private void centreTiles()
        {
            while (this.Size.Width - gbField.Right > gbField.Left + 10)
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
                    newButton.Text = UNFLIPPED;
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
            generateMines();
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (gamePaused) return;

            Button btn = (Button)sender;
            int x = Convert.ToInt32(btn.Tag) / mapSize;
            int y = Convert.ToInt32(btn.Tag) % mapSize;

            
            if (e.Button == MouseButtons.Right)
            {
                if (firstClick) return;
                else if (btn.Text == UNFLIPPED)
                {
                    btn.Text = FLAG;
                    btn.ForeColor = Color.Red;
                    //btn.BackColor = Color.Blue;
                    lblMinesLeft.Text = text[StartPage.currentLanguage, 1] + (--minesLeft);
                }
                else if (btn.Text == FLAG)
                {
                    btn.Text = UNFLIPPED;
                    btn.BackColor = Color.DimGray;
                    lblMinesLeft.Text = text[StartPage.currentLanguage, 1] + (++minesLeft);
                }
                
            }

            
            if (e.Button == MouseButtons.Left)
            {
                if (firstClick)
                {
                    firstClick = false;
                    int count = 0;
                    while ((ans[x, y] == -1 || ans[x, y] > 2) && count++ < 100000)
                    {
                        generateMines();
                    }
                }

                if (btn.Text == "")
                {
                    revealTile(x, y);
                    connectZero(x, y);


                    if (tileUnrevealed == 0)
                    {
                        gameWon();
                    }
                }
                /*
                if (!Globals.dClickTimerOn)
                {
                    Globals.dClickTimerOn = true;
                    timerDClick.Enabled = true;
                }
                else
                {
                    btn_doubleClick(x, y);
                }*/
            }
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

        private void revealTile(int i, int j)
        {
            if (tiles[i, j].Text == "")
            {

                switch (ans[i, j])
                {
                    case -1:
                        gameLost();
                        return;
                    case 0:
                        tiles[i, j].Text = " ";
                        break;
                    case 1:
                        tiles[i, j].Text = "1";
                        tiles[i, j].ForeColor = Color.Blue;
                        break;
                    case 2:
                        tiles[i, j].Text = "2";
                        tiles[i, j].ForeColor = Color.Green;
                        break;
                    case 3:
                        tiles[i, j].Text = "3";
                        tiles[i, j].ForeColor = Color.OrangeRed;
                        break;
                    case 4:
                        tiles[i, j].Text = "4";
                        tiles[i, j].ForeColor = Color.DarkGreen;
                        break;
                    case 5:
                        tiles[i, j].Text = "5";
                        tiles[i, j].ForeColor = Color.Gray;
                        break;
                    case 6:
                        tiles[i, j].Text = "6";
                        tiles[i, j].ForeColor = Color.DarkGray;
                        break;
                    case 7:
                        tiles[i, j].Text = "7";
                        tiles[i, j].ForeColor = Color.Black;
                        break;
                    case 8:
                        tiles[i, j].Text = "8";
                        tiles[i, j].ForeColor = Color.Black;
                        break;
                }
                tileUnrevealed--;
                tiles[i, j].BackColor = Color.White;
            }
        }

        private void showAllMines()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (ans[i, j] == -1)
                    {
                        tiles[i, j].Text = MINE;
                        tiles[i, j].BackColor = Color.Black;
                        tiles[i, j].ForeColor = Color.Red;
                    }
                }
            }
        }

        private void connectZero(int x, int y)
        {
            if (ans[x, y] == 0)
            {
                if (x > 0 && y > 0 && tiles[x - 1, y - 1].Text == "")
                {
                    revealTile(x - 1, y - 1);
                    connectZero(x - 1, y - 1);
                }

                if (x > 0 && tiles[x - 1, y].Text == "")
                {
                    revealTile(x - 1, y);
                    connectZero(x - 1, y);
                }

                if (x > 0 && y < mapSize - 1 && tiles[x - 1, y + 1].Text == "")
                {
                    revealTile(x - 1, y + 1);
                    connectZero(x - 1, y + 1);
                }

                if (y > 0 && tiles[x, y - 1].Text == "")
                {
                    revealTile(x, y - 1);
                    connectZero(x, y - 1);
                }

                if (y < mapSize - 1 && tiles[x, y + 1].Text == "")
                {
                    revealTile(x, y + 1);
                    connectZero(x, y + 1);
                }

                if (x < mapSize - 1 && y > 0 && tiles[x + 1, y - 1].Text == "")
                {
                    revealTile(x + 1, y - 1);
                    connectZero(x + 1, y - 1);
                }

                if (x < mapSize - 1 && tiles[x + 1, y].Text == "")
                {
                    revealTile(x + 1, y);
                    connectZero(x + 1, y);
                }

                if (x < mapSize - 1 && y < mapSize - 1 && tiles[x + 1, y + 1].Text == "")
                {
                    revealTile(x + 1, y + 1);
                    connectZero(x + 1, y + 1);
                }
            }
        }

        private void gameWon()
        {
            timer.Enabled = false;
            gamePaused = true;
            StartPage.gamesPlayed++;
            StartPage.gamesWon++;

            String winMessage = text[StartPage.currentLanguage, 3] 
                + "\n\n" + text[StartPage.currentLanguage, 0] + timeMin.ToString("D2") + ":" + timeSec.ToString("D2")
                + "\n\n" + text[StartPage.currentLanguage, 6] + StartPage.gamesPlayed
                + "\n" + text[StartPage.currentLanguage, 7] + StartPage.gamesWon
                + "\n" + text[StartPage.currentLanguage, 8] + (100.0 * StartPage.gamesWon / StartPage.gamesPlayed) + "%";

            MessageBox.Show(winMessage, text[StartPage.currentLanguage, 2]);
            this.Close();
        }

        private void gameLost()
        {
            timer.Enabled = false;
            gamePaused = true;
            StartPage.gamesPlayed++;

            showAllMines();

            String loseMessage = text[StartPage.currentLanguage, 5]
                + "\n\n" + text[StartPage.currentLanguage, 0] + timeMin.ToString("D2") + ":" + timeSec.ToString("D2")
                + "\n\n" + text[StartPage.currentLanguage, 6] + StartPage.gamesPlayed
                + "\n" + text[StartPage.currentLanguage, 7] + StartPage.gamesWon
                + "\n" + text[StartPage.currentLanguage, 8] + (100.0 * StartPage.gamesWon / StartPage.gamesPlayed) + "%";

            MessageBox.Show(loseMessage, text[StartPage.currentLanguage, 4]);

            this.Close();
        }
    }
}
