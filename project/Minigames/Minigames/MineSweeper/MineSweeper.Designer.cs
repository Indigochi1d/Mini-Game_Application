using System.Windows.Forms;

namespace MineSweeper
{
    partial class MineSweeper
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
            this.remain_mines = new System.Windows.Forms.Label();
            this.retry_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // remain_mines
            // 
            this.remain_mines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remain_mines.AutoSize = true;
            this.remain_mines.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.remain_mines.Location = new System.Drawing.Point(200, 34);
            this.remain_mines.Name = "remain_mines";
            this.remain_mines.Size = new System.Drawing.Size(80, 15);
            this.remain_mines.TabIndex = 0;
            this.remain_mines.Text = "남은 지뢰: 20";
            this.remain_mines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retry_button
            // 
            this.retry_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.retry_button.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.retry_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.retry_button.Location = new System.Drawing.Point(203, 433);
            this.retry_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.retry_button.Name = "retry_button";
            this.retry_button.Size = new System.Drawing.Size(75, 26);
            this.retry_button.TabIndex = 1;
            this.retry_button.Text = "Retry?";
            this.retry_button.UseVisualStyleBackColor = false;
            this.retry_button.Click += new System.EventHandler(this.retry_button_Click);
            // 
            // MineSweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 508);
            this.Controls.Add(this.retry_button);
            this.Controls.Add(this.remain_mines);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MineSweeperForm";
            this.Text = "지뢰찾기";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label remain_mines;
        private Button retry_button;
    }
}