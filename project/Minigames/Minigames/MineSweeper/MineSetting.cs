using System.Windows.Forms;
using System;

namespace MineSweeper
{
    public partial class Mine_Setting_Form : Form
    {
        int[] arr = new int[100];

        public Mine_Setting_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mineform_Click(object sender, EventArgs e)  // "지뢰찾기" 버튼 클릭 시
        {
            if (mine_num_updown.Value < 1 || mine_num_updown.Value > 99)
            {
                MessageBox.Show("유효하지 않는 값입니다!");
                return;
            }
            // 새로운 창 MineSweeperForm 생성 및 출력
            MineSweeper mine = new MineSweeper((int)mine_num_updown.Value);

            this.Close();
            mine.ShowDialog();
        }
    }
}