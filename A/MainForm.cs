﻿using System;
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
        Button[,] _buttons;
        bool _CBA;
        bool _CBD;
        double _SearchTime = 0.5;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void button2_Click(object s, EventArgs e)
        {
            _CBA = checkBoxA.Checked;
            _CBD = checkBoxD.Checked;
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

            Color color, colorSF;
            if (_CBA && _CBD)
            {
                color = ColorTranslator.FromHtml("#8CDEC5");
                colorSF = Color.Teal;
            }
            else if (_CBD)
            {
                color = Color.LightSkyBlue;
                colorSF = Color.DodgerBlue;
            }
            else
            {
                color = Color.LightGreen;
                colorSF = Color.ForestGreen;
            }

            var resultPath = await FindWay(grid);
            int N = grid.GetLength(0), M = grid.GetLength(1), p = 0;
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
            int N = grid.GetLength(0);
            int M = grid.GetLength(1);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(N-1, M-1);
            if (_CBA) return await MainFormA.AStar(grid, start, end, _buttons, _CBA, _CBD, _SearchTime);
            else return await MainFormD.AStar(grid, start, end, _buttons, _CBA, _CBD, _SearchTime);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            _CBA = checkBoxA.Checked;
            _CBD = checkBoxD.Checked;
            comboBox_SelectedIndexChanged(sender, e);
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
            Color colorSF;
            if (_CBA && _CBD) colorSF = Color.Teal;
            else if (_CBD) colorSF = Color.DodgerBlue;
            else colorSF = Color.ForestGreen;

            int N = grid.GetLength(0);
            int M = grid.GetLength(1);

            _buttons = new Button[N, M];

            for (int i = 0; i < _listControls.Count; i++) Controls.Remove(_listControls[i]);
            _listControls.Clear();

            if (M*30 < MinimumSize.Width) panel.Location = new Point(MinimumSize.Width/2 - panel.Width/2, 0);
            else panel.Location = new Point(M*30/2 - panel.Width/2, 0);
            Width = MinimumSize.Width; Height = MinimumSize.Height;
            //CenterToScreen();

            int q = 0;
            if (comboBox.SelectedIndex == 0) q = 65;

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
                    if ((i == 0 && j == 0) || (i == N-1 && j == M-1)) button.BackColor = colorSF; 
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