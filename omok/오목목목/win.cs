using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 오목목목;
using rules;

namespace winnamespace
{
    public static class winclass
    {
        public static int ruleflag = 0;
        public static int CheckWin(STONE [,] board)
        {
            if (CheckHorizontal(board, STONE.black) || CheckVertical(board, STONE.black) ||
                CheckRightDown(board,STONE.black) || CheckLeftDown(board, STONE.black))
            {
                return 1;//흑돌 승리하면 1 반환
            }
            else if (CheckHorizontal(board, STONE.white) || CheckVertical(board, STONE.white) ||
                CheckRightDown(board, STONE.white) || CheckLeftDown(board, STONE.white))
            {
                return 2;//백돌 승리하면 2 반환
            }
            else
                return 0;//승부 안났으면 0 반환
        }

        public static  bool CheckHorizontal(STONE[,] board, STONE target)//가로 방향 확인
        {
            for (int y = 0; y < 19; y++)
            {
                int count = 0;
                for (int x = 0; x < 19; x++)
                {
                    if (board[y, x] == target)//target돌이 놓여져있으면 count증가
                    {
                        count++;
                        if (count == 5)
                        {
                            ruleflag = 1;
                            return true;
                        }
                    }
                    else//target돌 없으면 감소하므로 연속된 돌 판정 가능
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

        public static bool CheckVertical(STONE[,] board, STONE target)//세로 방향 확인
        {
            for (int x = 0; x < 19; x++)
            {
                int count = 0;
                for (int y = 0; y < 19; y++)
                {
                    if (board[y, x] == target)//target돌이 놓여져있으면 count증가
                    {
                        count++;
                        if (count == 5)
                        {
                            ruleflag = 2;
                            return true;
                        }
                        
                    }
                    else//target돌 없으면 0이 되므로 연속된 돌 판정 가능
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

        public static bool CheckRightDown(STONE[,] board, STONE target)//오른쪽 아래 대각선 방향으로 체크
        {
            int count = 0;

            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    STONE stone = board[y, x];
                    if (stone == STONE.none)// 돌이 없는 경우 건너뛰기
                        continue;

                    count = 1;
                    for (int k = 1; k < 5; k++)
                    {
                        if (board[y + k, x + k] == target)
                            count++;
                        else
                            break;
                    }

                    if (count == 5)
                    {
                        ruleflag = 3;
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckLeftDown(STONE[,] board, STONE target)//왼쪽 위 대각선 방향으로 체크
        {
            int count = 0;

            for (int y = 4; y < 19; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    STONE stone = board[y, x];
                    if (stone == STONE.none)// 돌이 없는 경우 건너뛰기
                        continue;

                    count = 1;
                    for (int k = 1; k < 5; k++)
                    {
                        if (board[y - k, x + k] == target)
                            count++;
                        else
                            break;
                    }

                    if (count == 5)
                    {
                        ruleflag = 4;
                        return true;
                    }
                }
            }

            return false;
        }


    }
}
