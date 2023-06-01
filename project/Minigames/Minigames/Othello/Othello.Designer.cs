using System.Windows.Forms;
using System.Drawing;

namespace othello
{
	partial class Othello
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Board = new System.Windows.Forms.TableLayoutPanel();
			this.BlackLabel = new System.Windows.Forms.Label();
			this.BlackScore = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.WhiteScore = new System.Windows.Forms.Label();
			this.WhiteLabel = new System.Windows.Forms.Label();
			this.ResetButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Board
			// 
			this.Board.BackColor = System.Drawing.Color.SeaGreen;
			this.Board.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
			this.Board.ColumnCount = 8;
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.Location = new System.Drawing.Point(0, 100);
			this.Board.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Board.Name = "Board";
			this.Board.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
			this.Board.RowCount = 8;
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.Board.Size = new System.Drawing.Size(584, 584);
			this.Board.TabIndex = 0;
			// 
			// BlackLabel
			// 
			this.BlackLabel.BackColor = System.Drawing.Color.Transparent;
			this.BlackLabel.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.BlackLabel.Location = new System.Drawing.Point(170, 2);
			this.BlackLabel.Name = "BlackLabel";
			this.BlackLabel.Size = new System.Drawing.Size(100, 27);
			this.BlackLabel.TabIndex = 1;
			this.BlackLabel.Text = "Black";
			this.BlackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BlackScore
			// 
			this.BlackScore.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Bold);
			this.BlackScore.Location = new System.Drawing.Point(170, 29);
			this.BlackScore.Margin = new System.Windows.Forms.Padding(0);
			this.BlackScore.Name = "BlackScore";
			this.BlackScore.Size = new System.Drawing.Size(100, 69);
			this.BlackScore.TabIndex = 2;
			this.BlackScore.Text = "0";
			this.BlackScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(273, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 49);
			this.label1.TabIndex = 3;
			this.label1.Text = ":";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WhiteScore
			// 
			this.WhiteScore.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Bold);
			this.WhiteScore.ForeColor = System.Drawing.Color.White;
			this.WhiteScore.Location = new System.Drawing.Point(316, 29);
			this.WhiteScore.Margin = new System.Windows.Forms.Padding(0);
			this.WhiteScore.Name = "WhiteScore";
			this.WhiteScore.Size = new System.Drawing.Size(100, 69);
			this.WhiteScore.TabIndex = 5;
			this.WhiteScore.Text = "0";
			this.WhiteScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// WhiteLabel
			// 
			this.WhiteLabel.BackColor = System.Drawing.Color.Transparent;
			this.WhiteLabel.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.WhiteLabel.ForeColor = System.Drawing.Color.White;
			this.WhiteLabel.Location = new System.Drawing.Point(316, 2);
			this.WhiteLabel.Name = "WhiteLabel";
			this.WhiteLabel.Size = new System.Drawing.Size(100, 27);
			this.WhiteLabel.TabIndex = 4;
			this.WhiteLabel.Text = "White";
			this.WhiteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(492, 7);
			this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(80, 22);
			this.ResetButton.TabIndex = 6;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// Othello
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.ClientSize = new System.Drawing.Size(584, 686);
			this.Controls.Add(this.ResetButton);
			this.Controls.Add(this.WhiteScore);
			this.Controls.Add(this.WhiteLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BlackScore);
			this.Controls.Add(this.BlackLabel);
			this.Controls.Add(this.Board);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Othello";
			this.Text = "Othello";
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel Board;
		private Label BlackLabel;
		private Label BlackScore;
		private Label label1;
		private Label WhiteScore;
		private Label WhiteLabel;
		private Button ResetButton;
	}
}