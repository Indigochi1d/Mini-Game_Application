namespace WinformForTest
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = count.ToString();
            count++;
        }

        private void mineform_Click(object sender, EventArgs e)  // "����ã��" ��ư Ŭ�� ��
        {
            // ���ο� â Form2 ���� �� ���
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}