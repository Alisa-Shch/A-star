using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
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
            { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
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

        private readonly int[,] _grid5 = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        List<Button> _listControls = new List<Button>();
        Button[,] _buttons;
        static (bool A, bool D) _checkBox;
        double _SearchTime = 0.1;

        public MainForm()
        {
            InitializeComponent();
            textBoxST.Text = _SearchTime.ToString();
        }

        private async void button2_Click(object s, EventArgs e)
        {
            _checkBox = (checkBoxA.Checked, checkBoxD.Checked);
            int[,] grid = _grid1;
            switch (comboBox.SelectedIndex)
            {
                case 1: grid = _grid2;
                    break;
                case 2: grid = _grid3;
                    break;
                case 3: grid = _grid4;
                    break;
                case 4: grid = _grid5;
                    break;
            }

            var resultPath = await FindWay(grid);
            int N = grid.GetLength(0), M = grid.GetLength(1), p = 0;
            Color color = Way(), colorSF = Points();
            foreach (var point in resultPath) 
            {
                _buttons[point.Item1, point.Item2].Text = p++.ToString();
                _buttons[point.Item1, point.Item2].BackColor = color;
                await Task.Delay((int)(_SearchTime*1000)+200);
            }
            _buttons[0, 0].BackColor = colorSF;
            _buttons[N-1, M-1].BackColor = colorSF;
        }

        public async Task<List<Tuple<int, int>>> FindWay(int[,] grid)
        {
            int N = grid.GetLength(0), M = grid.GetLength(1);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(N-1, M-1); 
            return await FindShortestPath.AStar(grid, start, end, _buttons, (checkBoxA.Checked, checkBoxD.Checked), _SearchTime);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            _checkBox = (checkBoxA.Checked, checkBoxD.Checked);

            int[,] grid = _grid1;
            switch (comboBox.SelectedIndex)
            {
                case 1: grid = _grid2;
                    break;
                case 2: grid = _grid3;
                    break;
                case 3: grid = _grid4;
                    break;
                case 4: grid = _grid5;
                    break;
            }
            int N = grid.GetLength(0), M = grid.GetLength(1);

            Color colorSF = Points();

            foreach (var but in _buttons) { but.Text = ""; }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++) { _buttons[i, j].BackColor = grid[i, j] == 0 ? Color.White : Color.Black; }
            }
            _buttons[0, 0].BackColor = colorSF;
            _buttons[N-1, M-1].BackColor = colorSF;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            checkBoxA.Enabled = true;
            checkBoxD.Enabled = true;
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
            Color colorSF = Points();

            int N = grid.GetLength(0), M = grid.GetLength(1);

            _buttons = new Button[N, M];

            for (int i = 0; i < _listControls.Count; i++) Controls.Remove(_listControls[i]);
            _listControls.Clear();
            
            panel.Location = M*30 < MinimumSize.Width ? new Point(MinimumSize.Width/2 - panel.Width/2, 0) : new Point(M*30/2 - panel.Width/2, 0);
            Width = MinimumSize.Width; 
            Height = MinimumSize.Height;

            int q = comboBox.SelectedIndex == 0 ? 65 : 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(j*30+q, i*30+115),
                        BackColor = Color.White
                    };
                    button.BackColor = ((i == 0 && j == 0) || (i == N-1 && j == M-1)) ? colorSF : grid[i, j] == 0 ? Color.White : Color.Black;
                    _buttons[i, j] = button;
                    Controls.Add(button);
                    _listControls.Add(button);
                }
            }
        }

        static Color Way()
        {
            if (_checkBox.A && _checkBox.D) return ColorTranslator.FromHtml("#8CDEC5");
            else if (_checkBox.D) return Color.LightSkyBlue;
            else return Color.LightGreen;
        }

        static Color Points()
        {
            if (_checkBox.A && _checkBox.D) return Color.Teal;
            else if (_checkBox.D) return Color.DodgerBlue;
            else return Color.ForestGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormP(this).ShowDialog();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _SearchTime = Convert.ToDouble(textBoxST.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.SelectionStart == 0 && e.KeyChar == 45)
                {
                    e.Handled = true;
                    MessageBox.Show("Только положительные числа!");
                }
                else
                {
                    if (e.KeyChar == '.') e.KeyChar = ',';
                    if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    {
                        e.Handled = true;
                        MessageBox.Show("Только цифpы!");
                    }
                    if (e.KeyChar == 13)
                    {
                        if (textBox.Text.Length > 0 && textBox.Text != "-") SendKeys.Send("{TAB}");
                        else MessageBox.Show("Bведите число");
                    }
                }
            }
        }
    }
}