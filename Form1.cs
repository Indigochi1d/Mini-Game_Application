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

        private void mineform_Click(object sender, EventArgs e)  // "지뢰찾기" 버튼 클릭 시
        {
            // 새로운 창 Form2 생성 및 출력
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}