namespace othello
{
	public partial class Othello : Form
	{
		Match match;

		public Othello()
		{
			InitializeComponent();

			//���ο� ��ġ ����
			match = new Match(Board)
			{
				PlayerLabels = new[] { BlackLabel, WhiteLabel },
				ScoreLabels = new[] { BlackScore, WhiteScore }
			};
			//��ġ �ʱ�ȭ
			match.Reset();
		}

		//��ġ ���� ��ư Ŭ����
		private void ResetButton_Click(object sender, EventArgs e)
		{
			//��ġ �ʱ�ȭ
			match.Reset();
		}
	}
}
