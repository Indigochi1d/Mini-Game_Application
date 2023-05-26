using othello.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
	//스퀘어의 2차원 위치
	public struct Position
	{
		public int x, y;

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Position operator +(Position a, Position b) => new Position(a.x + b.x, a.y + b.y);
		public static Position operator -(Position a, Position b) => new Position(a.x - b.x, a.y - b.y);
	}

	//스퀘어에서 돌의 상태
	public enum StoneType
	{
		None = 0,
		Black,
		White
	}

	//보드의 칸
	public class Square
	{
		public readonly Position Position;
		readonly PictureBox Image;
		StoneType _stone;
		public StoneType Stone
		{
			get => _stone;
			set
			{
				_stone = value;
				//돌의 상태가 변경될 때 이미지도 함께 변경
				Image.Image = value switch
				{
					StoneType.Black => Resources.black,
					StoneType.White => Resources.white,
					_ => Image.Image = null
				};
			}
		}

		public Square(Position position, PictureBox image)
		{
			Position = position;
			Image = image;
			Stone = StoneType.None;
		}
	}
}
