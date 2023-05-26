using othello.Properties;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
	//매치에 참여중인 사용자
	public class Player
	{
		//플레이어가 사용하는 돌의 종류
		public readonly StoneType MyStoneType;
		//플레이어의 현재 점수
		public int Score { get; set; }

		public Player(StoneType stoneType)
		{
			MyStoneType = stoneType;
			Score = 0;
		}
	}
}
