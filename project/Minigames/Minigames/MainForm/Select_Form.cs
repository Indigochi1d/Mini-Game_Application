using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 오목목목;
using MineSweeper;
using othello;
using sudoku;

namespace Main_display
{
    public partial class Select_Form : Form
    {
        public Select_Form()
        {
            InitializeComponent();
        }

        private void Mine_Click(object sender, EventArgs e)
        {
            Mine_Setting_Form mine = new Mine_Setting_Form();
            mine.ShowDialog();
        }

        private void Omok_Click(object sender, EventArgs e)
        {
            Omok_Form omok = new Omok_Form();
            omok.ShowDialog();
        }

        private void Sudoku_Click(object sender, EventArgs e)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.ShowDialog();
        }

        private void Othello_Click(object sender, EventArgs e)
        {
            Othello othello = new Othello();
            othello.ShowDialog();
        }
    }
}
