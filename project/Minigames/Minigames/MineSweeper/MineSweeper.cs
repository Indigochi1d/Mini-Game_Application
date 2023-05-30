using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {
        // 지뢰의 개수
        static int MINE_NUM;
        Button[] buttons = new Button[101];  // 버튼 100개를 담는 배열. 1번부터 사용하므로, 0번은 비워둠
        int[] mines = new int[100];  // 지뢰가 될 버튼의 번호를 담을 배열
        Random rand = new Random();  // 난수를 생성해주는 객체 rand
        int[] nears = new int[101];  // 주변 지뢰 개수를 저장할 배열
        int[] flags = new int[100];  // 깃발의 위치를 지정할 배열
        int flag_cnt = 0;  // 깃발의 개수
        bool gameover = false;  // 게임오버 되었는지 알려주는 변수

        public MineSweeper(int mine_num)
        {
            MINE_NUM = mine_num;
            InitializeComponent();  // MineSweeperForm.Designer.cs에 있는 함수

            for (int i = 1; i < 101; i++)  // 100개의 버튼을 생성 및 배치하는 과정
            {
                Button button = new Button();
                // 생성할 버튼의 위치, 이름, 사이즈 지정
                button.Location = new System.Drawing.Point(30 * ((i - 1) % 10) + 90, 30 * (((i - 1) / 10) + 1) + 50);
                button.Name = (String.Format("mine{0}", i.ToString()));
                button.Size = new System.Drawing.Size(30, 30);
                button.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                // 얘넨 아직 뭔지 모름
                button.TabIndex = 0;
                button.UseVisualStyleBackColor = true;
                // MouseDown: 마우스가 버튼에 있는 상태에서 클릭이 수행될 때 발생! 자세한 것은 Minesweeper_MouseDown 함수에서
                button.MouseDown += new System.Windows.Forms.MouseEventHandler(Minesweeper_MouseDown);
                // 폼에 버튼 배치
                Controls.Add(button);
                buttons[i] = button;
             }

            for (int i = 0; i < MINE_NUM; i++)
            {
                int newRandomNumber = rand.Next(1, 101);

                // 새로운 랜덤 숫자가 기존 배열에 없는 경우에만 할당
                if (Array.IndexOf(mines, newRandomNumber) == -1)
                    mines[i] = newRandomNumber;
                // 이미 있는 경우에는 다시 루프를 돌아야 하므로 i를 감소시킴
                else
                    i--;
            }

            for (int i = 1; i < 101; i++)
                // 주변 지뢰 개수 저장
                nears[i] = nearby(i);

            // 남은 지뢰 개수 표시
            remain_mines.Text = String.Format("남은 지뢰: {0}", MINE_NUM - flag_cnt);

        }

        private void Form2_Load(object sender, EventArgs e)  // 지우지 말 것
        {

        }


        private void Minesweeper_MouseDown(object sender, MouseEventArgs e)
        {
            // 게임오버 되었다면 동작 X
            if (gameover)
                return;

            // 변수 button: 클릭이 발생한 버튼
            // 매개변수(파라미터) e: 마우스로 발생한 이벤트
            Button button = (Button)sender;
            if (button.Text == "" && e.Button == MouseButtons.Left)  // 빈 버튼에 좌클릭 발생 시
            {
                // 버튼의 번호 button_idx
                int button_idx = Array.IndexOf(buttons, button);
                // 해당 버튼이 지뢰라면
                if (Ismine(button_idx))
                {
                    // 모든 지뢰 표시 및 게임 종료
                    for (int i = 0; i < MINE_NUM; i++)
                    {
                        int idx = mines[i];
                        buttons[idx].Text = "💣";
                        buttons[idx].BackColor = Color.Red;
                        remain_mines.Text = "      패배!";
                        remain_mines.ForeColor = Color.Red;
                        gameover = true;
                    }
                }
                // 지뢰가 아니라면
                else
                {
                    if (nears[button_idx] != 0)
                    {
                        // 0이 아니라면 숫자 표시
                        button.Text = nears[button_idx].ToString();
                        // 회색으로 표시
                        button.BackColor = Color.Gray;
                    }
                    else
                    {
                        // 0이라면 주변 0도 전부 밝힘
                        Show_Zeros(button_idx);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)  // 우클릭 발생 시
            {
                // 회색이 아닌 빈칸을 클릭했고, 깃발이 남았다면
                if (button.Text == "" && button.BackColor != Color.Gray && flag_cnt != MINE_NUM)
                {
                    // 깃발 목록 추가 및 개수 증가, 텍스트 갱신
                    flags[flag_cnt] = Array.IndexOf(buttons, button);
                    flag_cnt++;
                    remain_mines.Text = String.Format("남은 지뢰: {0}", MINE_NUM - flag_cnt);
                    button.Text = "🚩";
                    
                    // 깃발을 다 사용했다면 승리 검사
                    if (flag_cnt == MINE_NUM)
                    {
                        remain_mines.ForeColor = Color.Red;
                        if (Iswin())
                        {
                            remain_mines.Text = "      승리!";
                            remain_mines.ForeColor = Color.Blue;
                            gameover = true;
                        }
                    }

                }
                // 깃발 -> ? 로 바꾸는 상황
                else if (button.Text == "🚩")
                {
                    // flags배열에서 해당 번호 삭제 및 공간 창출
                    for (int i = Array.IndexOf(flags, Array.IndexOf(buttons, button)); i < flag_cnt; i++)
                        flags[i] = flags[i + 1];

                    flag_cnt--;
                    // 남은 지뢰 갱신
                    remain_mines.Text = String.Format("남은 지뢰: {0}", MINE_NUM - flag_cnt);
                    remain_mines.ForeColor = Color.Black;
                    button.Text = "?";
                }
                // ? -> 공백으로 바꾸기
                else if (button.Text == "?")
                    button.Text = "";
            }
        }

        private bool Ismine(int idx)
        {
            //  범위 내의, 해당 번호의 버튼이 지뢰인지를 알려줌.
            //  true/false 반환
            return Array.IndexOf(mines, idx) != -1 && idx > 0;
        }

        private int nearby(int idx)
        {
            //  해당 번호의 버튼 주변 지뢰가 몇개인지를 알려줌.
            int result = 0;

            //  왼쪽 위 검사
            if (Ismine(idx - 11) && idx % 10 != 1)
                result++;
            //  위 검사
            if (Ismine(idx - 10))
                result++;
            //  오른쪽 위 검사
            if (Ismine(idx - 9) && idx % 10 != 0)
                result++;
            //  왼쪽 검사
            if (Ismine(idx - 1) && idx % 10 != 1)
                result++;
            //  오른쪽 검사
            if (Ismine(idx + 1) && idx % 10 != 0)
                result++;
            //  왼쪽 아래 검사
            if (Ismine(idx + 9) && idx % 10 != 1)
                result++;
            //  아래 검사
            if (Ismine(idx + 10))
                result++;
            //  오른쪽 아래 검사
            if (Ismine(idx + 11) && idx % 10 != 0)
                result++;
            
            return result;
        }

        private void Show_Zeros(int idx)
        {
            // 주변의 타일을 재귀적으로 밝혀줌.
            if (Ismine(idx) || idx < 1 || idx > 100 || buttons[idx].BackColor == Color.Gray)  // 지뢰이거나, 이미 방문했거나, 범위 밖의 버튼이라면 종료
                return;

            buttons[idx].BackColor = Color.Gray;  // 버튼 방문: 색 변환
            if (nearby(idx) != 0)  // 0이 아니라면 밝히고 종료
            {
                buttons[idx].Text = nearby(idx).ToString();
                return;
            }
            if (idx % 10 != 1)  // 왼쪽이 막혀있지 않다면 왼쪽으로
            {
                Show_Zeros(idx - 1);
                Show_Zeros(idx - 11);
                Show_Zeros(idx + 9);
            }
            if (idx % 10 != 0)  // 오른쪽이 막혀있지 않다면 오른쪽으로
            {
                Show_Zeros(idx + 1);
                Show_Zeros(idx + 11);
                Show_Zeros(idx - 9);
            }
            Show_Zeros(idx + 10);  // 아래쪽으로
            Show_Zeros(idx - 10);  // 위쪽으로
        }

        private bool Iswin()
        {
            // 승리 조건 검사 함수
            for (int i = 0; i < MINE_NUM; i++)
            {
                // 깃발 하나하나 검사 후 하나라도 지뢰가 아니면 승리가 아님. 
                if (Array.IndexOf(mines, flags[i]) == -1)
                    return false;
            }

            return true;
        }

        private void retry_button_Click(object sender, EventArgs e)
        {
            // retry? 버튼 클릭 시 발생되는 이벤트.
            // 또 다른 자기 자신을 처음 상태로 호출하고, 원본은 닫는다.
            MineSweeper new_form = new MineSweeper(MINE_NUM);
            new_form.Show();
            this.Close();
        }
    }
}
