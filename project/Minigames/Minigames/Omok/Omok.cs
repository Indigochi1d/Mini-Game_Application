using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winnamespace;
using rules;

namespace 오목목목
{
    public enum STONE { none, black, white };//오목 놓여져있는 상태 저장할 STONE정의
    public partial class Omok_Form : Form
    {
        
        public int margin = 40;
        public int boardsize = 30;
        public int stonesize = 25;
        public int crosssize = 10;

        Graphics g;
        Pen pen;
        Brush wBrush, bBrush;

        
        public STONE[,] board = new STONE[19, 19];
        public int flag = 0;//검은돌일때는 flag = 0;
        public int mouseflag = 1;//마우스 클릭 가능한 상태
        public Omok_Form()
        {

            InitializeComponent();
            //this.MinimizeBox = false;
            this.BackColor = Color.Orange;
            pen = new Pen(Color.Black);
            wBrush = new SolidBrush(Color.White);
            bBrush = new SolidBrush(Color.Black);

            this.ClientSize = new Size(2 * margin + 18 * boardsize,
                2 * margin + 18 * boardsize　+ 30);

            panel1.MouseDown += panel1_MouseDown;//마우스 이벤트 핸들러 등록

            Button button = new Button();
            button.Text = "다시하기";
            button.Location = new Point(10, 10);
            button.BackColor = Color.White;

            button.Click += Button_Click; // 버튼 클릭 이벤트 핸들러 설정
            panel1.Controls.Add(button);


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBoard();
        }

        void panel1_MouseDown(object sender, MouseEventArgs e)//바둑알 놓는 함수
        {
            if (mouseflag == 0)
                return;
            //e.X, e.Y -> x, y(바둑판 좌표)로 바꾸기
            int x = (e.X - margin + boardsize / 2) / boardsize;
            int y = (e.Y - margin + boardsize / 2) / boardsize;
            Console.WriteLine($"x = {x},y = {y}");
            if (board[y, x] != STONE.none)//이미 돌이 놓여져있다면 함수 종료
                return;
            Rectangle r = new Rectangle(margin + boardsize * x - stonesize / 2,
                margin + boardsize * y - stonesize / 2, stonesize, stonesize);
            int result;
            if (flag == 0)//검은돌 그리기
            {
                flag = 1;//흰돌 차례로 바꿔주기
                board[y, x] = STONE.black;
                result = winclass.CheckWin(board);
                if (winclass.fiveflag == 1)//육목체크
                {
                    board[y, x] = STONE.none;
                    MessageBox.Show("육목입니다. 흑돌은 놓을 수 없습니다.");
                    winclass.fiveflag = 0;//육목 체크했으니까 다시 돌 놓을 수 있게 0으로 바꾸기
                    flag = 0;//아직 못놨으니까 검은돌 차례
                    return;
                }
                g.FillEllipse(bBrush, r);
            }
            else//흰돌 그리기
            {
                g.FillEllipse(wBrush, r);
                flag = 0;
                board[y, x] = STONE.white;
                result = winclass.CheckWin(board);
            }
            if (result == 0)
            {
                return;
            }
            else if (result == 1)
            {
                MessageBox.Show("흑돌이 이겼습니다!");
                mouseflag = 0;
            }
            else if (result == 2)
            {
                MessageBox.Show("백돌이 이겼습니다!");
                mouseflag = 0;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void DrawBoard()//기본 바둑판 그리기
        {
            g = panel1.CreateGraphics();
            int i;
            for (i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin + i * boardsize, margin),
                    new Point(margin + i * boardsize, margin + 18 * boardsize)); //세로선 19개 그리기
                g.DrawLine(pen, new Point(margin, margin + i * boardsize),
                    new Point(margin + 18 * boardsize, margin + i * boardsize));//가로선 19개 그리기
            }
            for(int x = 3; x <= 15; x += 6)//화점 그리기
            {
                for(int y = 3; y<=15; y+= 6)
                {
                    g.FillEllipse(bBrush, margin + (boardsize * x) - (crosssize / 2),
                        margin + boardsize * y - (crosssize / 2), crosssize, crosssize);
                }
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            g.Clear(panel1.BackColor);
            DrawBoard();
            mouseflag = 1;
            flag = 0;//흑돌이 먼저
            int i, j;
            for (i = 0; i < 19; i++)
            {
                for (j = 0; j < 19; j++)
                {
                    board[i, j] = STONE.none;
                }
            }
        }


    }
}