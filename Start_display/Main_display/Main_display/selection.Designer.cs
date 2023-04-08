namespace Main_display
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mine_game = new System.Windows.Forms.Button();
            this.Omok = new System.Windows.Forms.Button();
            this.Sudoku = new System.Windows.Forms.Button();
            this.Odelo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mine_game
            // 
            this.mine_game.BackColor = System.Drawing.SystemColors.GrayText;
            this.mine_game.FlatAppearance.BorderSize = 0;
            this.mine_game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mine_game.Font = new System.Drawing.Font("에스코어 드림 6 Bold", 13F, System.Drawing.FontStyle.Bold);
            this.mine_game.Location = new System.Drawing.Point(12, 93);
            this.mine_game.Name = "mine_game";
            this.mine_game.Size = new System.Drawing.Size(130, 159);
            this.mine_game.TabIndex = 0;
            this.mine_game.Text = "지뢰찾기";
            this.mine_game.UseVisualStyleBackColor = false;
            this.mine_game.Click += new System.EventHandler(this.mine_game_Click);
            // 
            // Omok
            // 
            this.Omok.BackColor = System.Drawing.SystemColors.GrayText;
            this.Omok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Omok.FlatAppearance.BorderSize = 0;
            this.Omok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Omok.Font = new System.Drawing.Font("에스코어 드림 6 Bold", 13F, System.Drawing.FontStyle.Bold);
            this.Omok.Location = new System.Drawing.Point(178, 93);
            this.Omok.Name = "Omok";
            this.Omok.Size = new System.Drawing.Size(130, 159);
            this.Omok.TabIndex = 1;
            this.Omok.Text = "오목";
            this.Omok.UseVisualStyleBackColor = false;
            this.Omok.Click += new System.EventHandler(this.Omok_Click);
            // 
            // Sudoku
            // 
            this.Sudoku.BackColor = System.Drawing.SystemColors.GrayText;
            this.Sudoku.FlatAppearance.BorderSize = 0;
            this.Sudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sudoku.Font = new System.Drawing.Font("에스코어 드림 6 Bold", 13F, System.Drawing.FontStyle.Bold);
            this.Sudoku.Location = new System.Drawing.Point(12, 287);
            this.Sudoku.Name = "Sudoku";
            this.Sudoku.Size = new System.Drawing.Size(130, 159);
            this.Sudoku.TabIndex = 2;
            this.Sudoku.Text = "스도쿠";
            this.Sudoku.UseVisualStyleBackColor = false;
            this.Sudoku.Click += new System.EventHandler(this.Sudoku_Click);
            // 
            // Odelo
            // 
            this.Odelo.BackColor = System.Drawing.SystemColors.GrayText;
            this.Odelo.FlatAppearance.BorderSize = 0;
            this.Odelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Odelo.Font = new System.Drawing.Font("에스코어 드림 6 Bold", 13F, System.Drawing.FontStyle.Bold);
            this.Odelo.Location = new System.Drawing.Point(178, 287);
            this.Odelo.Name = "Odelo";
            this.Odelo.Size = new System.Drawing.Size(130, 159);
            this.Odelo.TabIndex = 3;
            this.Odelo.Text = "오델로";
            this.Odelo.UseVisualStyleBackColor = false;
            this.Odelo.Click += new System.EventHandler(this.Odelo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(320, 570);
            this.Controls.Add(this.Odelo);
            this.Controls.Add(this.Sudoku);
            this.Controls.Add(this.Omok);
            this.Controls.Add(this.mine_game);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MINI GAME";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mine_game;
        private System.Windows.Forms.Button Omok;
        private System.Windows.Forms.Button Sudoku;
        private System.Windows.Forms.Button Odelo;
    }
}

