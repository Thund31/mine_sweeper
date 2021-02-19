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
    public partial class StartPage : Form
    {
        public static Form FormStart;

        public decimal minePercentage = 10;
        public static int currentLanguage = 0, currentDifficulty = 8, currentMapSize = 10, currentNumMines = 10;
        public String[,] text = new string[,]{
            {"中文", "Mine Sweeper", "Map Size", "# of Mines", "Start", "enter an integer", "map is too large", "map is too small", "Easy", "Normal", "Hard", "Legendary", "Impossible", "Invalid"},
            {"English", "扫雷", "地图大小", "地雷数量", "开始游戏", "输入一个整数", "地图过大", "地图过小", "简单", "正常", "困难", "传奇", "神仙", "输入错误"}
        };

        public StartPage()
        {
            InitializeComponent();

            FormStart = this;
        }

        public void changeLanguage()
        {
            currentLanguage++;
            if (currentLanguage >= text.GetLength(0)) currentLanguage = 0;

            btnLanguage.Text = text[currentLanguage, 0];
            lblTitle.Text = text[currentLanguage, 1];
            lblMapSize.Text = text[currentLanguage, 2];
            lblNumMines.Text = text[currentLanguage, 3];
            btnStart.Text = text[currentLanguage, 4];
            lblDifficulty.Text = text[currentLanguage, currentDifficulty];
            
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            changeLanguage();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form newGame = new GamePage();
            newGame.Show();

            this.Hide();
        }

        private void txtMapSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int mapSizeValue = Convert.ToInt32(txtMapSize.Text);

                if (mapSizeValue > 40)
                {
                    btnStart.Enabled = false;
                    lblMapSizeDuplicate.Text = text[currentLanguage, 6];
                }
                else if (mapSizeValue < 10)
                {
                    btnStart.Enabled = false;
                    lblMapSizeDuplicate.Text = text[currentLanguage, 7];
                }
                else
                {
                    currentMapSize = mapSizeValue;
                    lblMapSizeDuplicate.Text = "x " + txtMapSize.Text;
                    txtNumMines.Text = ((int)(mapSizeValue * mapSizeValue * minePercentage / 100)).ToString();
                    btnStart.Enabled = true;
                }
            } catch
            {
                lblMapSizeDuplicate.Text = text[currentLanguage, 5];
                btnStart.Enabled = false;
            }
        }

        private void txtNumMines_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int numMinesValue = Convert.ToInt32(txtNumMines.Text);

                if (numMinesValue >= currentMapSize * currentMapSize * 0.9 || numMinesValue <= 0)
                {
                    btnStart.Enabled = false;
                    currentDifficulty = 13;
                }
                else
                {
                    btnStart.Enabled = true;
                    currentNumMines = numMinesValue;
                    minePercentage = (decimal)currentNumMines * 100 / currentMapSize / currentMapSize;

                    if (minePercentage < 20) currentDifficulty = 8;
                    else if (minePercentage < 40) currentDifficulty = 9;
                    else if (minePercentage < 60) currentDifficulty = 10;
                    else if (minePercentage < 80) currentDifficulty = 11;
                    else currentDifficulty = 12;
                }
            } catch
            {
                currentDifficulty = 13;
                btnStart.Enabled = false;
            }

            lblDifficulty.Text = text[currentLanguage, currentDifficulty];
        }
    }
}
