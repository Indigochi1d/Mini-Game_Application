using System;
using System.Windows.Forms;

namespace sudoku
{
    public partial class MainForm : Form
    {
        private const int CELL_SIZE = 30;
        private const int GRID_SIZE = 9;

        SudokuGrid MainGrid;


        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            MainGrid = new SudokuGrid(GRID_SIZE, CELL_SIZE, 20, 40, this);
        }

        // Game -> New -> Create puzzle
        private void msMainMenuGameNewCreatePuzzle_Click(object sender, EventArgs e)
        {
            MainGrid.ClearField();
            msMainMenuFieldUnlock.PerformClick();
        }

        // Game -> New -> Load from file
        private void msMainMenuGameNewLoadFromFile_Click(object sender, EventArgs e)
        {
            // Clearing current field and unlocking
            MainGrid.ClearField();
            msMainMenuFieldUnlock.PerformClick();

            // Creating new FileDialog which will handle file opening
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Open Text File",
                Filter = "TXT files|*.txt",
                RestoreDirectory = true
            };

            // 유저가 OK 클릭했을때
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String[] lines = System.IO.File.ReadAllLines(fileDialog.FileName);
                    // Loading puzzle
                    MainGrid.LoadPuzzle(lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            msMainMenuFieldLock.PerformClick();
        }

        // Game -> Check Solution
        private void msMainMenuGameCheckSolution_Click(object sender, EventArgs e)
        {
            // 그리드가 완전히 채워졌는지 확인
            if (MainGrid.HasNoConflicts())
                MessageBox.Show("No conflicts in the grid!", "Information");
            else
                MessageBox.Show("There are conflicts in the grid!", "Information");
        }

        // Game -> Solve
        private void msMainMenuGameSolve_Click(object sender, EventArgs e)
        {
            MainGrid.Solve();
        }

        // Game -> Exit
        private void msMainMenuExit_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
                Application.Exit();
            else
                Environment.Exit(1);
        }

        // Field -> Lock
        private void msMainMenuFieldLock_Click(object sender, EventArgs e)
        {
            if (MainGrid.HasNoConflicts() == false)
            {
                MessageBox.Show("Your grid has conflicts and therefore cannot be locked!", "Error");
                return;
            }

            MainGrid.LockField();
            lblLockedField.Visible = true;
            msMainMenuFieldLock.Enabled = false;
            msMainMenuFieldUnlock.Enabled = true;
        }

        // Field -> Unlock
        private void msMainMenuFieldUnlock_Click(object sender, EventArgs e)
        {
            MainGrid.UnlockField();
            lblLockedField.Visible = false;
            msMainMenuFieldLock.Enabled = true;
            msMainMenuFieldUnlock.Enabled = false;
        }

        // Field -> Clear
        private void msMainMenuFieldClear_Click(object sender, EventArgs e)
        {
            MainGrid.ClearField();
        }

        // Help -> Rules
        private void msMainMenuRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 게임은 스도쿠 게임으로 9X9로 이루어져있습니다. 클릭 한번에 숫자 1이 올라가며 게임내에서 숫자가 중복되거나 겹치면 해당칸이 빨간색으로 표시됩니다. 즉, 해당 칸에 그 숫자를 넣을 수 없다는 뜻이죠.", "Rules");
        }

        // Help -> About
        private void msMainMenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 게임을 플레이 하는 방법에는 두가지가 있습니다. 첫번째는 처음부터 아무것도 없는 배경부터 시작하는 것입니다.\n 두번째는 Game을 선택후 Load from file을 선택해서 .txt형식의 파일을 불러오면 스도쿠에 해당 퍼즐이 입혀집니다.", "About");
        }
    }
}
