using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace A
{
    public partial class FormP : Form
    {
        static private MainForm _mainForm;

        int _gridRows;
        int _gridColumns;
        int[,] _grid;
        List<Button> _listControls = new List<Button>();
        Button[,] _buttons;
        static (bool A, bool D) _checkBox;
        double _SearchTime = 0.1;

        public FormP(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            textBoxST.Text = _SearchTime.ToString();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            _checkBox = (checkBoxA.Checked, checkBoxD.Checked);
            Color colorSF = Points();
            foreach (var but in _buttons) { but.Text = ""; }
            for (int i = 0; i < _gridRows; i++)
            {
                for (int j = 0; j < _gridColumns; j++) { _buttons[i, j].BackColor = _grid[i, j] == 0 ? Color.White : Color.Black; }
            }            
            _gridRows = comboBox.SelectedIndex+5;
            _gridColumns = comboBox2.SelectedIndex+5;
            _buttons[0, 0].BackColor = colorSF;
            _buttons[_gridRows-1, _gridColumns-1].BackColor = colorSF;
        }

        private void button2_Click(object s, EventArgs e)
        {
            button1.Enabled = true;
            checkBoxA.Enabled = true;
            checkBoxD.Enabled = true;

            Color colorSF = Points();

            _gridRows = comboBox.SelectedIndex+5;
            _gridColumns = comboBox2.SelectedIndex+5;
            _grid = new int[_gridRows, _gridColumns];
            _buttons = new Button[_gridRows, _gridColumns];

            for (int i = 0; i < _listControls.Count; i++) Controls.Remove(_listControls[i]);
            _listControls.Clear();            
            
            panel.Location = _gridRows*30 < MinimumSize.Width ? new Point(MinimumSize.Width/2 - panel.Width/2, 0) : new Point(_gridRows*30/2 - panel.Width/2, 0);
            Width = MinimumSize.Width; 
            Height = MinimumSize.Height;

            int q = comboBox.SelectedIndex <= 5 ? (MinimumSize.Width-_gridRows*30)/2 : 0;

            for (int i = 0; i < _gridRows; i++)
            {
                for (int j = 0; j < _gridColumns; j++)
                {
                    var button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(i*30+q, j*30+115),
                        BackColor = Color.White
                    };
                    int P = i, Q = j;
                    button.Click += (sender, args) => OnButtonClick(sender, args, P, Q);
                    _buttons[i, j] = button;
                    Controls.Add(button);
                    _listControls.Add(button);

                    _grid[i, j] = 0;
                    if ((i == 0 && j == 0) || (i == _gridRows-1 && j == _gridColumns-1)) button.BackColor = colorSF;
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e, int i, int j)
        {
            if ((i == 0 && j == 0) || (i == _gridRows-1 && j == _gridColumns-1))
            {
                _grid[i, j] = 0;
                _buttons[i, j].BackColor = Points();
            }
            else
            {
                _grid[i, j] = _grid[i, j] == 0 ? 1 : 0;
                _buttons[i, j].BackColor = _grid[i, j] == 0 ? Color.White : Color.Black;
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            _checkBox = (checkBoxA.Checked, checkBoxD.Checked);
            foreach (var but in _buttons) { but.Text = ""; }
            for (int i = 0; i < _gridRows; i++)
            {
                for (int j = 0; j < _gridColumns; j++) { _buttons[i, j].BackColor = _grid[i, j] == 0 ? Color.White : Color.Black; }
            }
            var resultPath = FindWay(_grid);
            int p = 0;
            Color color = Way(), colorSF = Points();

            foreach (var point in await resultPath)
            {
                _buttons[point.Item1, point.Item2].Text = p++.ToString();
                _buttons[point.Item1, point.Item2].BackColor = color;
                await Task.Delay((int)(_SearchTime*1000)+200);
            }
            int N = _grid.GetLength(0), M = _grid.GetLength(1);
            _buttons[0, 0].BackColor = colorSF;
            _buttons[N-1, M-1].BackColor = colorSF;
        }

        public async Task<List<Tuple<int, int>>> FindWay(int[,] grid)
        {
            int N = grid.GetLength(0);
            int M = grid.GetLength(1);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(N - 1, M - 1);
            return await FindShortestPath.AStar(grid, start, end, _buttons, (checkBoxA.Checked, checkBoxD.Checked), _SearchTime);
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

        private void textBoxST_TextChanged(object sender, EventArgs e)
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

        public void textBoxST_KeyPress(object sender, KeyPressEventArgs e)
        {
            _mainForm.textBox_KeyPress(sender, e);
        }
    }
}