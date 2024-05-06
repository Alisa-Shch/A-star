using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace A
{
    public partial class FormP : Form
    {
        private MainForm _mainForm;

        public FormP(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private int gridRows;
        private int gridColumns;

        private int[,] grid;
        private Button[,] buttons;
        List<Button> listControls = new List<Button>();

        private void button2_Click(object s, EventArgs e)
        {
            gridRows = comboBox1.SelectedIndex+5;
            gridColumns = comboBox2.SelectedIndex+5;
            grid = new int[gridRows, gridColumns];
            buttons = new Button[gridRows, gridColumns];

            for (int i = 0; i < listControls.Count; i++) Controls.Remove(listControls[i]);
            listControls.Clear();

            panel.Location = new Point(gridRows*30/2 - panel.Width/2, 0);
            Width = MinimumSize.Width; Height = MinimumSize.Height;
            CenterToScreen();

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {
                    var button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(i*30, j*30 + 60)
                    };
                    int P = i, Q = j;
                    button.Click += (sender, args) => OnButtonClick(sender, args, P, Q);
                    buttons[i, j] = button;
                    Controls.Add(button);
                    listControls.Add(button);

                    grid[i, j] = 0;
                    if ((i == 0 && j == 0) || (i == gridRows-1 && j == gridColumns-1)) button.BackColor = Color.Red;
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e, int i, int j)
        {
            if ((i == 0 && j == 0) || (i == gridRows-1 && j == gridColumns-1))
            {
                grid[i, j] = 0;
                buttons[i, j].BackColor = Color.Red;
            }
            else
            {
                grid[i, j] = grid[i, j] == 0 ? 1 : 0;
                buttons[i, j].BackColor = grid[i, j] == 0 ? Color.White : Color.Black;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridColumns; j++) { buttons[i, j].BackColor = grid[i, j] == 0 ? Color.White : Color.Black; }
            }
            var resultPath = _mainForm.FindWay(grid);
            foreach (var point in resultPath) { buttons[point.Item1, point.Item2].BackColor = Color.Pink; }

            int N = grid.GetLength(0);
            int M = grid.GetLength(1);
            buttons[0, 0].BackColor = Color.Red;
            buttons[N-1, M-1].BackColor = Color.Red;
        }
    }
}