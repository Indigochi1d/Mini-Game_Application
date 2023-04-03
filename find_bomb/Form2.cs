using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformForTest
{
    public partial class Form2 : Form
    {
        // 지뢰의 개수
        int MINE_NUM = 20;
        Button[] buttons = new Button[101];  // 버튼 100개를 담는 배열. 1번부터 사용하므로, 0번은 비워둠
        int[] mines = new int[100];  // 지뢰가 될 버튼의 번호를 담을 배열
        Random rand = new Random();  // 난수를 생성해주는 객체 rand
        int[] nears = new int[101];  // 주변 지뢰 개수를 저장할 배열

        public Form2()
        {
            InitializeComponent();  // Form2.Designer.cs에 있는 함수

            for (int i = 1; i < 101; i++)  // 100개의 버튼을 생성 및 배치하는 과정
            {
                Button button = new Button();
                // 생성할 버튼의 위치, 이름, 사이즈 지정
                button.Location = new System.Drawing.Point(30 * ((i - 1) % 10) + 100, 30 * (((i - 1) / 10) + 1));
                button.Name = (String.Format("mine{0}", i.ToString()));
                button.Size = new System.Drawing.Size(30, 30);
                // 얘넨 아직 뭔지 모름
                button.TabIndex = 0;
                button.UseVisualStyleBackColor = true;
                // MouseDown: 마우스가 버튼에 있는 상태에서 클릭이 수행될 때 발생! 자세한 것은 Minesweeper_MouseDown 함수에서
                button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Minesweeper_MouseDown);
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

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void Minesweeper_MouseDown(object sender, MouseEventArgs e)
        {
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
                if (button.Text == "")
                    button.Text = "🚩";
                else if (button.Text == "🚩")
                    button.Text = "?";
                else if (button.Text == "?")
                    button.Text = "";
            }
        }

        private bool Ismine(int idx)
        {
            //  해당 번호의 버튼이 지뢰인지를 알려줌.
            //  true/false 반환
            //  인덱스가 범위 밖이여도 오류 X, false 반환
            return Array.IndexOf(mines, idx) != -1;
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
            // 주변의, nearby가 0인 타일을 재귀적으로 밝혀줌.
            if (Ismine(idx) || idx < 1 || idx > 100 || nears[idx] != 0 || buttons[idx].BackColor == Color.Gray)  // 지뢰이거나, 0이 아니거나, 이미 방문했거나, 범위 밖의 버튼이라면 종료
                return;

            buttons[idx].BackColor = Color.Gray;  // 버튼 방문: 색 변환

            if (idx % 10 != 1)  // 왼쪽이 막혀있지 않다면 왼쪽으로
                Show_Zeros(idx - 1);
            if (idx % 10 != 0)  // 오른쪽이 막혀있지 않다면 오른쪽으로
                Show_Zeros(idx + 1);
            Show_Zeros(idx + 10);  // 아래쪽으로
            Show_Zeros(idx - 10);  // 위쪽으로
        }

    }
}
