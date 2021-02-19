
namespace MineSweeper
{
    partial class GamePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblMinesLeft = new System.Windows.Forms.Label();
            this.gbField = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(147, 10);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(91, 20);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "Time: 00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinesLeft
            // 
            this.lblMinesLeft.AutoSize = true;
            this.lblMinesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinesLeft.Location = new System.Drawing.Point(12, 10);
            this.lblMinesLeft.Name = "lblMinesLeft";
            this.lblMinesLeft.Size = new System.Drawing.Size(109, 20);
            this.lblMinesLeft.TabIndex = 1;
            this.lblMinesLeft.Text = "Mines Left: 10";
            // 
            // gbField
            // 
            this.gbField.AutoSize = true;
            this.gbField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbField.Location = new System.Drawing.Point(16, 43);
            this.gbField.Name = "gbField";
            this.gbField.Size = new System.Drawing.Size(6, 19);
            this.gbField.TabIndex = 2;
            this.gbField.TabStop = false;
            // 
            // GamePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(250, 163);
            this.Controls.Add(this.gbField);
            this.Controls.Add(this.lblMinesLeft);
            this.Controls.Add(this.lblTimer);
            this.Name = "GamePage";
            this.Text = "GamePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GamePage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblMinesLeft;
        private System.Windows.Forms.GroupBox gbField;
    }
}