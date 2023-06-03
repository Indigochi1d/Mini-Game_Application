using System;
using System.Drawing;
using System.Windows.Forms;

namespace sudoku
{
    class SudokuGrid
    {
        private int GridSize;
        private int BoxSize;
        private int CellSize;
        private Label[,] Field;
        private bool GridIsSolved = false;


        public SudokuGrid(int size, int cellSize, int startX, int startY, Sudoku parent)
        {
            GridSize = size;
            CellSize = cellSize;
            Field = new Label[GridSize, GridSize];

            //시작 위치 지정
            int horizontal = startX;
            int vertical = startY;

            
            BoxSize = size / (int)Math.Sqrt(size);

            // 스도쿠 필드를 만듬
            for (int i = 0; i < GridSize; i++) {
                if (i % BoxSize == 0)
                    vertical += 1;

                //행의 시작 부분에 배치
                horizontal = startX;

                for (int j = 0; j < GridSize; j++) {
                    if (j % BoxSize == 0)
                        horizontal += 1;

                    //새 라벨을 만들고 필드에 적용
                    Field[i, j] = new Label()
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(horizontal, vertical),
                        BorderStyle = BorderStyle.FixedSingle,
                        ForeColor = Color.Black,
                        BackColor = Color.White,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Tag = new GridLocation(i, j)
                    };

                    Field[i, j].Click += OnFieldClick;
                    parent.Controls.Add(Field[i, j]);
                    horizontal += cellSize - 1;
                }

                //다음 행으로 이동
                vertical += cellSize - 1;
            }

            //새 크기에 맞게 부모 폼 크기 조정
            parent.Size = new Size(horizontal + 2 * startX, vertical + startY + CellSize / 2);
        }


        // 필드 배열에서 해당 레이블의 인덱스를 인스턴스에 보관하는 것을 도와주는 클래스 GridLocation
        internal class GridLocation
        {
            public readonly int i;
            public readonly int j;

            public GridLocation(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }


        private void OnFieldClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
                OnLeftClick(sender, e);
            else if (me.Button == MouseButtons.Right)
                OnRightClick(sender, e);
            else if (me.Button == MouseButtons.Middle)
                OnMiddleClick(sender, e);
            else return;

            if (HasNoConflictsAt(sender) == false)
                ((Label)sender).BackColor = Color.Tomato;
            else
                ((Label)sender).BackColor = Color.White;
        }

        private void OnLeftClick(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Text == "")
                l.Text = "1";
            else if (l.Text == GridSize.ToString())
                l.Text = "1";
            else
                l.Text = (int.Parse(l.Text) + 1).ToString();
        }

        private void OnRightClick(object sender, EventArgs e)
        {
            Label l = sender as Label;

            if (l.Text == "")
                l.Text = GridSize.ToString();
            else if (l.Text == "1")
                l.Text = GridSize.ToString();
            else
                l.Text = (int.Parse(l.Text) - 1).ToString();
        }

        private void OnMiddleClick(object sender, EventArgs e)
        {
            ((Label)sender).Text = "";
        }

        private bool HasNoConflictsAt(object sender)
        {
            Label pressedLabel = sender as Label;

            // 빈 것
            if (pressedLabel.Text == "")
                return true;
            
            // 칸눌렀을때 그 위치 확인하고 저장
            GridLocation index = (GridLocation)pressedLabel.Tag;
            int x = index.i;
            int y = index.j;

            // 행 확인
            for (int i = 0; i < GridSize; i++)
                if (i != y && Field[x, i].Text == pressedLabel.Text)
                    return false;
            // 열 확인
            for (int i = 0; i < GridSize; i++)
                if (i != x && Field[i, y].Text == pressedLabel.Text)
                    return false;
            int sqStartX = x - x % BoxSize;
            int sqEndX = sqStartX + BoxSize;
            int sqStartY = y - y % BoxSize;
            int sqEndY = sqStartY + BoxSize;
            for (int i = sqStartX; i < sqEndX; i++)
                for (int j = sqStartY; j < sqEndY; j++)
                    if (i != x && j != y && Field[i, j].Text == pressedLabel.Text)
                        return false;

            return true;
        }

        public bool HasNoConflicts()
        {
            foreach (Label i in Field)
                if (HasNoConflictsAt(i) == false)
                    return false;

            return true;
        }

        public void Solve()
        {
            if (GridIsSolved)
                return;

            if (HasNoConflicts())
                SolveGrid(0, 0);
            else
                MessageBox.Show("중복에 의해 충돌이 있습니다.", "Error");
        }

        private void SolveGrid(int row, int col)
        {
            // 그리드 경계를 벗어나면
            if (row == GridSize) {
                GridIsSolved = true;
                return;
            }

            // 다음 row, column의 indexes
            int nextRow, nextCol;
            
            // 다음 열과 행을 계산
            if (col == GridSize - 1) {
                nextRow = row + 1;
                nextCol = 0;
            } else {
                nextRow = row;
                nextCol = col + 1;
            }

            // 현재 위치가 차있다면 다음 인덱스로 넘김
            if (Field[row, col].Text != "")
                SolveGrid(nextRow, nextCol);
            else {
                // 비어있다면 그 자리에 맞는 숫자후보를 찾음
                for (int candidate = 1; candidate <= GridSize; candidate++) {
                    Field[row, col].Text = candidate.ToString();
                    if (HasNoConflictsAt(Field[row, col])) {
                        SolveGrid(nextRow, nextCol);
                        if (GridIsSolved)
                            return;
                    }
                    Field[row, col].Text = "";
                }
            }
        }

        public void LoadPuzzle(String[] content)
        이

            // 9x9 스도쿠 그리드를 생성

            try {
                for (int i = 0; i < GridSize; i++) {
                    char[] line = content[i].ToCharArray();
                    for (int j = 0; j < GridSize; j++) {

                        if (Char.IsNumber(line[j]) == false)
                            throw new Exception();

                        if (line[j] != '0')
                            Field[i, j].Text = (line[j] - '0').ToString();
                        else
                            Field[i, j].Text = "";
                    }
                }
            } catch (Exception) {
                MessageBox.Show("Invalid file content!");
            }

            UpdateFieldColors();
        }

        public void ClearField()        //clear 동작수행
        {
            foreach (Label cell in Field)
                if (cell.ForeColor == Color.Black) {
                    cell.Text = "";
                    cell.BackColor = Color.White;
                }

            GridIsSolved = false;
        }

        private void UpdateFieldColors()    // 필드 안에 숫자가 갱신될때 부적절하다면 레드 아니면 평시 유지
        {
            foreach (Label cell in Field) {
                if (cell.Text == "")
                    cell.ForeColor = Color.Black;
                else
                    cell.ForeColor = Color.Red;

                cell.BackColor = Color.White;
            }
        }

        public void LockField()     //필드 잠금 메소드
        {
            foreach (Label cell in Field) {
                if (cell.Text != "") {
                    cell.ForeColor = Color.Red;
                    cell.Click -= OnFieldClick;
                } else
                    cell.ForeColor = Color.Black;

                cell.BackColor = Color.White;
            }
        }

        public void UnlockField()   //필드 잠금 해제 메소드
        {
            foreach (Label cell in Field) {
                if (cell.Text != "")
                    cell.Click += OnFieldClick;

                cell.ForeColor = Color.Black;
                cell.BackColor = Color.White;
            }
        }
    }
}
