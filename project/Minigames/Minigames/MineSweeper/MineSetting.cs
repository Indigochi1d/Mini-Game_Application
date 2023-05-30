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

        private void mineform_Click(object sender, EventArgs e)  // "����ã��" ��ư Ŭ�� ��
        {
            if (mine_num_updown.Value < 1 || mine_num_updown.Value > 99)
            {
                MessageBox.Show("��ȿ���� �ʴ� ���Դϴ�!");
                return;
            }
            // ���ο� â MineSweeperForm ���� �� ���
            MineSweeper mine = new MineSweeper((int)mine_num_updown.Value);

            this.Close();
            mine.ShowDialog();
        }
    }
}