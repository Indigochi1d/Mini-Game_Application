namespace othello
{
	public partial class Othello : Form
	{
		Match match;

		public Othello()
		{
			InitializeComponent();

			//새로운 매치 생성
			match = new Match(Board)
			{
				PlayerLabels = new[] { BlackLabel, WhiteLabel },
				ScoreLabels = new[] { BlackScore, WhiteScore }
			};
			//매치 초기화
			match.Reset();
		}

		//매치 리셋 버튼 클릭시
		private void ResetButton_Click(object sender, EventArgs e)
		{
			//매치 초기화
			match.Reset();
		}
	}
}
