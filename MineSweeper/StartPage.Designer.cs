
namespace MineSweeper
{
    partial class StartPage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLanguage = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.lblNumMines = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtMapSize = new System.Windows.Forms.TextBox();
            this.txtNumMines = new System.Windows.Forms.TextBox();
            this.lblMapSizeDuplicate = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLanguage
            // 
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLanguage.Location = new System.Drawing.Point(258, 12);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(75, 23);
            this.btnLanguage.TabIndex = 0;
            this.btnLanguage.Text = "中文";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(82, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Mine Sweeper";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMapSize
            // 
            this.lblMapSize.Location = new System.Drawing.Point(82, 113);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(67, 13);
            this.lblMapSize.TabIndex = 2;
            this.lblMapSize.Text = "Map Size";
            this.lblMapSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumMines
            // 
            this.lblNumMines.Location = new System.Drawing.Point(85, 146);
            this.lblNumMines.Name = "lblNumMines";
            this.lblNumMines.Size = new System.Drawing.Size(64, 13);
            this.lblNumMines.TabIndex = 3;
            this.lblNumMines.Text = "# of Mines";
            this.lblNumMines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(141, 186);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtMapSize
            // 
            this.txtMapSize.Location = new System.Drawing.Point(183, 110);
            this.txtMapSize.Name = "txtMapSize";
            this.txtMapSize.Size = new System.Drawing.Size(45, 20);
            this.txtMapSize.TabIndex = 5;
            this.txtMapSize.Text = "10";
            this.txtMapSize.TextChanged += new System.EventHandler(this.txtMapSize_TextChanged);
            // 
            // txtNumMines
            // 
            this.txtNumMines.Location = new System.Drawing.Point(183, 143);
            this.txtNumMines.Name = "txtNumMines";
            this.txtNumMines.Size = new System.Drawing.Size(45, 20);
            this.txtNumMines.TabIndex = 6;
            this.txtNumMines.Text = "10";
            this.txtNumMines.TextChanged += new System.EventHandler(this.txtNumMines_TextChanged);
            // 
            // lblMapSizeDuplicate
            // 
            this.lblMapSizeDuplicate.AutoSize = true;
            this.lblMapSizeDuplicate.Location = new System.Drawing.Point(235, 113);
            this.lblMapSizeDuplicate.Name = "lblMapSizeDuplicate";
            this.lblMapSizeDuplicate.Size = new System.Drawing.Size(27, 13);
            this.lblMapSizeDuplicate.TabIndex = 7;
            this.lblMapSizeDuplicate.Text = "x 10";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Location = new System.Drawing.Point(234, 147);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(76, 16);
            this.lblDifficulty.TabIndex = 8;
            this.lblDifficulty.Text = "Easy";
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 241);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblMapSizeDuplicate);
            this.Controls.Add(this.txtNumMines);
            this.Controls.Add(this.txtMapSize);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNumMines);
            this.Controls.Add(this.lblMapSize);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLanguage);
            this.Name = "StartPage";
            this.Text = "Mine Sweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.Label lblNumMines;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtMapSize;
        private System.Windows.Forms.TextBox txtNumMines;
        private System.Windows.Forms.Label lblMapSizeDuplicate;
        private System.Windows.Forms.Label lblDifficulty;
    }
}

