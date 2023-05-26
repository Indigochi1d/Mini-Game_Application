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
			Board = new TableLayoutPanel();
			BlackLabel = new Label();
			BlackScore = new Label();
			label1 = new Label();
			WhiteScore = new Label();
			WhiteLabel = new Label();
			ResetButton = new Button();
			SuspendLayout();
			// 
			// Board
			// 
			Board.BackColor = Color.SeaGreen;
			Board.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
			Board.ColumnCount = 8;
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
			Board.Location = new Point(0, 100);
			Board.Name = "Board";
			Board.Padding = new Padding(10);
			Board.RowCount = 8;
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
			Board.Size = new Size(584, 584);
			Board.TabIndex = 0;
			// 
			// BlackLabel
			// 
			BlackLabel.BackColor = Color.Transparent;
			BlackLabel.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point);
			BlackLabel.Location = new Point(170, 9);
			BlackLabel.Name = "BlackLabel";
			BlackLabel.Size = new Size(100, 27);
			BlackLabel.TabIndex = 1;
			BlackLabel.Text = "Black";
			BlackLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// BlackScore
			// 
			BlackScore.Font = new Font("맑은 고딕", 36F, FontStyle.Bold, GraphicsUnit.Point);
			BlackScore.Location = new Point(170, 36);
			BlackScore.Margin = new Padding(0);
			BlackScore.Name = "BlackScore";
			BlackScore.Size = new Size(100, 61);
			BlackScore.TabIndex = 2;
			BlackScore.Text = "0";
			BlackScore.TextAlign = ContentAlignment.TopCenter;
			// 
			// label1
			// 
			label1.Font = new Font("맑은 고딕", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(273, 36);
			label1.Name = "label1";
			label1.Size = new Size(40, 61);
			label1.TabIndex = 3;
			label1.Text = ":";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// WhiteScore
			// 
			WhiteScore.Font = new Font("맑은 고딕", 36F, FontStyle.Bold, GraphicsUnit.Point);
			WhiteScore.ForeColor = Color.White;
			WhiteScore.Location = new Point(316, 36);
			WhiteScore.Margin = new Padding(0);
			WhiteScore.Name = "WhiteScore";
			WhiteScore.Size = new Size(100, 61);
			WhiteScore.TabIndex = 5;
			WhiteScore.Text = "0";
			WhiteScore.TextAlign = ContentAlignment.TopCenter;
			// 
			// WhiteLabel
			// 
			WhiteLabel.BackColor = Color.Transparent;
			WhiteLabel.Font = new Font("맑은 고딕", 15F, FontStyle.Bold, GraphicsUnit.Point);
			WhiteLabel.ForeColor = Color.White;
			WhiteLabel.Location = new Point(316, 9);
			WhiteLabel.Name = "WhiteLabel";
			WhiteLabel.Size = new Size(100, 27);
			WhiteLabel.TabIndex = 4;
			WhiteLabel.Text = "White";
			WhiteLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ResetButton
			// 
			ResetButton.Location = new Point(492, 9);
			ResetButton.Name = "ResetButton";
			ResetButton.Size = new Size(80, 27);
			ResetButton.TabIndex = 6;
			ResetButton.Text = "Reset";
			ResetButton.UseVisualStyleBackColor = true;
			ResetButton.Click += ResetButton_Click;
			// 
			// Othello
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.MediumSeaGreen;
			ClientSize = new Size(584, 684);
			Controls.Add(ResetButton);
			Controls.Add(WhiteScore);
			Controls.Add(WhiteLabel);
			Controls.Add(label1);
			Controls.Add(BlackScore);
			Controls.Add(BlackLabel);
			Controls.Add(Board);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "Othello";
			Text = "Othello";
			ResumeLayout(false);
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