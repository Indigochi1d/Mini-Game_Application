using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_display
{
    public partial class First_Form : Form
    {
        public First_Form()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.Hide();
            Select_Form game_select = new Select_Form();
            game_select.ShowDialog();
            this.Close();
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button button1 = (Button)sender;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button1 = (Button)sender;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }


    }
}
