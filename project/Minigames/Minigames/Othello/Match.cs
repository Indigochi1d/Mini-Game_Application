using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace othello
{
	public class Match
	{
		//플레이어 리스트, 원소의 순서가 턴 순서를 의미함
		Player[] turnTable;
		//현재 턴을 진행 중인 플레이어의 인덱스
		int currentTurn;
		//보드의 스퀘어 2차원 배열, 돌을 표현할 때 사용
		Square[,] squares;
		//매치가 종료됐는지
		bool isFinish;
		//플레이어의 이름을 표시하는 레이블
		public Label[] PlayerLabels { get; set; }
		//플레이어의 점수를 표시하는 레이블
		public Label[] ScoreLabels { get; set; }

		public Match(TableLayoutPanel board)
		{
			turnTable = new Player[] { new Player(StoneType.Black), new Player(StoneType.White) };
			squares = new Square[8, 8];

			//보드에 돌을 표현할 스퀘어 이미지 추가
			board.SuspendLayout();
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					PictureBox squareImage = new PictureBox();
					squareImage.Dock = DockStyle.Fill;
					squareImage.Image = null;
					squareImage.SizeMode = PictureBoxSizeMode.StretchImage;
					squareImage.TabStop = false;
					squareImage.Click += OnSquareClick;
					//스퀘어와 스퀘어 이미지 연결
					squares[i, j] = new Square(new Position(i, j), squareImage);
					squareImage.Tag = squares[i, j];
					//보드에 스퀘어 이미지를 자식으로 추가
					board.Controls.Add(squareImage, i, j);
				}
			}
			board.ResumeLayout();
		}

		//매치 초기화
		public void Reset()
		{
			//모든 플레이어의 점수를 0으로 초기화
			foreach (var player in turnTable)
			{
				player.Score = 0;
			}
			//모든 스퀘어를 빈 칸으로 초기화
			foreach (var square in squares)
			{
				square.Stone = StoneType.None;
			}
			//기본 돌 강제 착수
			squares[3, 3].Stone = StoneType.White;
			squares[4, 3].Stone = StoneType.Black;
			squares[3, 4].Stone = StoneType.Black;
			squares[4, 4].Stone = StoneType.White;

			isFinish = false;
			//레이블 초기화
			UpdateScoreLabels();
			//턴 테이블의 0번 플레이어부터 시작
			currentTurn = -1;
			NextTurn();
		}

		//보드의 스퀘어가 클릭 됐을 때
		void OnSquareClick(object sender, EventArgs e)
		{
			//매치가 종료됐으면 착수 금지
			if (isFinish) return;
			//컨트롤을 Square로 변환
			var squareImage = sender as Control;
			var square = squareImage?.Tag as Square;
			if (square == null) return;

			//착수할 수 없는 스퀘어면 클릭 무시
			StoneType playerStoneType = turnTable[currentTurn].MyStoneType;
			if (GetFlippableStones(square.Position, playerStoneType).Any() == false) return;
			//착수 시 뒤집힐 모든 돌 뒤집기
			foreach (var flippableSquare in GetFlippableStones(square.Position, playerStoneType))
			{
				flippableSquare.Stone = playerStoneType;
			}
			//착수
			square.Stone = playerStoneType;

			//점수 레이블 갱신
			UpdateScoreLabels();
			//매치 종료 조건 검사
			isFinish = CheckFinishCondition();
			//매치가 종료됐으면 결과 메세지 출력
			if (isFinish)
			{
				//점수를 기준으로 승자 출력
				if (turnTable[0].Score > turnTable[1].Score)
				{
					MessageBox.Show("Winner is Black");
				}
				else if (turnTable[0].Score < turnTable[1].Score)
				{
					MessageBox.Show("Winner is White");
				}
				else
				{
					MessageBox.Show("Draw");
				}
			}
			//매치가 진행중이면 다음 차례로 넘기기
			else
			{
				NextTurn();
			}
		}

		//해당 위치에 착수시 뒤집을 수 있는 모든 돌 반환
		IEnumerable<Square> GetFlippableStones(Position setPos, StoneType stoneType)
		{
			//빈 칸을 착수할 수 없음
			if (stoneType == StoneType.None) yield break;
			//착수 위치에 돌이 있으면 중복해서 착수할 수 없음
			if (squares[setPos.x, setPos.y].Stone != StoneType.None) yield break;

			//상하좌우 및 대각선 총 8가지 방향으로 뒤집을 수 있는 돌 탐색
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					//크기가 0인 방향은 무시
					if (i == 0 && j == 0) continue;
					Position pos;
					//검사 진행 방향
					Position dir = new Position(i, j);

					//착수할 돌과 동일한 종류의 돌이 라인에 존재하는지 검사
					pos = setPos + dir;
					bool isFlippableLine = false;
					int flippableStoneCount = 0;
					while (0 <= pos.x && pos.x < 8 && 0 <= pos.y && pos.y < 8)
					{
						Square square = squares[pos.x, pos.y];
						//돌 사이에 빈 칸이 있으면 현재 라인은 뒤집을 수 없음
						if (square.Stone == StoneType.None)
						{
							break;
						}
						//동일한 돌이 존재하면 사이의 상대방의 돌을 뒤집을 수 있음
						else if (square.Stone == stoneType)
						{
							isFlippableLine = true;
							break;
						}
						//뒤집힐 상대방의 돌 개수 저장
						else
						{
							flippableStoneCount++;
						}
						pos += dir;
					}
					//현재 라인에서 뒤집을 수 있는 돌이 없으면 다음 라인 검사
					if (!isFlippableLine || flippableStoneCount == 0) continue;

					//뒤집을 수 있는 돌을 하나씩 반환
					pos = setPos + dir;
					for (int k = 0; k < flippableStoneCount; k++)
					{
						//뒤집을 돌 하나 반환
						yield return squares[pos.x, pos.y];
						pos += dir;
					}
				}
			}
		}

		//점수 레이블 업데이트
		void UpdateScoreLabels()
		{
			for (int i = 0; i < turnTable.Length; i++)
			{
				Player player = turnTable[i];
				//플레이어의 점수 업데이트
				player.Score = 0;
				foreach (var square in squares)
				{
					if (square.Stone == player.MyStoneType) player.Score++;
				}
				//점수 레이블 업데이트
				ScoreLabels[i].Text = player.Score.ToString();
			}
		}

		//차례를 다음 플레이어에게 넘기기
		void NextTurn()
		{
			//현재 턴 번호를 턴 테이블 인덱스 범위로 제한
			currentTurn++;
			if (currentTurn >= turnTable.Length) currentTurn = 0;

			//플레이어 레이블 업데이트
			for (int i = 0; i < turnTable.Length; i++)
			{
				//현재 자신의 차례인 경우에만 레이블 배경색으로 강조
				if (i == currentTurn)
				{
					PlayerLabels[i].BackColor = Color.Green;
				}
				//현재 자신의 차례가 아니면 레이블의 배경색 제거
				else
				{
					PlayerLabels[i].BackColor = Color.Transparent;
				}
			}

			//턴을 진행할 수 있는 플레이어의 차례가 올 때까지 패스
			while (CheckPassCondition()) NextTurn();
		}

		//현재 차례의 플레이어가 착수할 수 있는 자리가 있는지 검사
		bool CheckPassCondition()
		{
			StoneType playerStoneType = turnTable[currentTurn].MyStoneType;
			foreach (var square in squares)
			{
				//현재 스퀘어에 착수시 돌을 1개라도 뒤집을 수 있으면 false 반환
				if (GetFlippableStones(square.Position, playerStoneType).Any() == true)
				{
					return false;
				}
			}
			//뒤집을 돌이 없으면 패스를 위해 true 반환
			return true;
		}

		//게임이 종료 조건을 달성했는지 검사
		bool CheckFinishCondition()
		{
			//돌이 하나도 없는 플레이어 탐색
			foreach (var player in turnTable)
			{
				//플레이어의 돌이 하나도 없으면 착수할 수 없으므로 패배
				if (player.Score == 0)
				{
					return true;
				}
			}
			//보드에 착수할 스퀘어가 하나도 없는지 검사
			foreach (var square in squares)
			{
				//착수 가능한 스퀘어가 하나라도 있다면 게임은 안 끝남
				if (square.Stone == StoneType.None)
				{
					return false;
				}
			}
			return true;
		}
	}
}
