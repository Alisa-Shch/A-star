using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace A
{
    public partial class MainForm : Form
    {
        private readonly int[,] _grid1 = new int[,]
        {
            { 0, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 1 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0 }
        };

        private readonly int[,] _grid2 = new int[,]
        {
            { 0, 1, 1, 1, 0, 0, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 1, 0, 1, 1 },
            { 1, 0, 1, 1, 0, 0, 1, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 1, 1, 0, 1, 0 }
        };

        private readonly int[,] _grid3 = new int[,]
        {
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 }
        };

        private readonly int[,] _grid4 = new int[,]
        {
            { 0, 1, 0, 1, 0, 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0, 0, 1, 0, 1, 0 },
            { 0, 1, 0, 1, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 1, 1, 0, 1, 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
            { 1, 0, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 1, 0, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }
        };

        private readonly int[,] _grid5 = new int[,]
        {
            { 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 },
            { 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0 },
            { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0 },
            { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }
        };

        List<Button> _listControls = new List<Button>();
        private Button[,] _buttons;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object s, EventArgs e)
        {
            var resultPath = new List<Tuple<int, int>>();
            int N = 0, M = 0;
            switch (comboBox.SelectedIndex)
            {
                case 0: resultPath = FindWay(_grid1);
                    N = _grid1.GetLength(0);
                    M = _grid1.GetLength(1);
                    break;
                case 1: resultPath = FindWay(_grid2);
                    N = _grid2.GetLength(0);
                    M = _grid2.GetLength(1);
                    break;
                case 2: resultPath = FindWay(_grid3);
                    N = _grid3.GetLength(0);
                    M = _grid3.GetLength(1);
                    break;
                case 3: resultPath = FindWay(_grid4);
                    N = _grid4.GetLength(0);
                    M = _grid4.GetLength(1);
                    break;
                case 4: resultPath = FindWay(_grid5);
                    N = _grid5.GetLength(0);
                    M = _grid5.GetLength(1);
                    break;
            }
            foreach (var point in resultPath) { _buttons[point.Item1, point.Item2].BackColor = Color.Pink; }
            _buttons[0, 0].BackColor = Color.Red;
            _buttons[N-1, M-1].BackColor = Color.Red;
        }

        public List<Tuple<int, int>> FindWay(int[,] grid)
        {
            int N = grid.GetLength(0);
            int M = grid.GetLength(1);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(N-1, M-1);
            return FindShortestPath.AStar(grid, start, end);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0: ShowGrid(_grid1);
                    break;
                case 1: ShowGrid(_grid2);
                    break;
                case 2: ShowGrid(_grid3);
                    break;
                case 3: ShowGrid(_grid4);
                    break;
                case 4: ShowGrid(_grid5);
                    break;
            }
        }

        private void ShowGrid(int[,] grid)
        {
            int N = grid.GetLength(0);
            int M = grid.GetLength(1);

            _buttons = new Button[N, M];

            for (int i = 0; i < _listControls.Count; i++) Controls.Remove(_listControls[i]);
            _listControls.Clear();

            panel.Location = new Point(M*30/2 - panel.Width/2, 0);
            Width = MinimumSize.Width; Height = MinimumSize.Height;
            CenterToScreen();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(j*30, i*30+60)
                    };
                    if ((i == 0 && j == 0) || (i == N-1 && j == M-1)) button.BackColor = Color.Red; 
                    else  button.BackColor = grid[i, j] == 0 ? Color.White : Color.Black;
                    _buttons[i, j] = button;
                    Controls.Add(button);
                    _listControls.Add(button);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormP(this).ShowDialog();
        }
    }
}