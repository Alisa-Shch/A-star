using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A
{
    public partial class MainFormD : Form
    {
        static Button[,] _buttons;
        static bool _CBA;
        static bool _CBD;
        static double _SearchTime;

        public static async Task<List<Tuple<int, int>>> AStar(int[,] grid, Tuple<int, int> start, Tuple<int, int> end, Button[,] buttons, bool CBA, bool CBD, double SearchTime)
        {
            _buttons = buttons;
            _CBA = CBA;
            _CBD = CBD;
            _SearchTime = SearchTime;

            Color colorSF;
            if (_CBA && _CBD) colorSF = Color.Teal;
            else if (_CBD) colorSF = Color.DodgerBlue;
            else colorSF = Color.ForestGreen;

            int N = grid.GetLength(0), M = grid.GetLength(1);
            foreach (var but in buttons) { but.Text = ""; }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if ((i == 0 && j == 0) || (i == N - 1 && j == M - 1)) buttons[i, j].BackColor = colorSF;
                    else buttons[i, j].BackColor = grid[i, j] == 0 ? Color.White : Color.Black;
                }
            }

            var cost = new Dictionary<Tuple<int, int>, int>();
            var cameFrom = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

            var priorityQueue = new List<Tuple<int, int>> { start };
            cost[start] = 0;

            while (priorityQueue.Any())
            {
                var currentPoint = priorityQueue.OrderBy(t => cost.TryGetValue(t, out var value) ? value : int.MaxValue).First();
                priorityQueue.Remove(currentPoint);

                if (currentPoint.Equals(end)) { break; }

                foreach (var neighbor in await GetNeighbors(currentPoint, grid))
                {
                    var newCost = cost[currentPoint] + 1;

                    if (!cost.TryGetValue(neighbor, out var currentCost) || newCost < currentCost)
                    {
                        cost[neighbor] = newCost;
                        priorityQueue.Add(neighbor);
                        cameFrom[neighbor] = currentPoint;
                    }
                }
            }
            return ReconstructPath(cameFrom, end);
        }

        public static List<Tuple<int, int>> ReconstructPath(Dictionary<Tuple<int, int>, Tuple<int, int>> cameFrom, Tuple<int, int> end)
        {
            var path = new List<Tuple<int, int>>();
            var current = end;
            while (current != null)
            {
                path.Add(current);
                cameFrom.TryGetValue(current, out current);
            }
            path.Reverse();

            return path;
        }

        public static async Task<IEnumerable<Tuple<int, int>>> GetNeighbors(Tuple<int, int> point, int[,] grid)
        {
            var neighbors = new List<Tuple<int, int>>();
            var x = point.Item1;
            var y = point.Item2;

            if (_CBD && !_CBA)
            {
                Color myColor = Color.LightSteelBlue;
                int alpha = 150;

                _buttons[x, y].BackColor = Color.FromArgb(alpha, myColor.R, myColor.G, myColor.B);
                await Task.Delay((int)(_SearchTime * 1000));
            }

            if (x > 0 && grid[x - 1, y] == 0) neighbors.Add(Tuple.Create(x - 1, y));
            if (x < grid.GetLength(0) - 1 && grid[x + 1, y] == 0) neighbors.Add(Tuple.Create(x + 1, y));
            if (y > 0 && grid[x, y - 1] == 0) neighbors.Add(Tuple.Create(x, y - 1));
            if (y < grid.GetLength(1) - 1 && grid[x, y + 1] == 0) neighbors.Add(Tuple.Create(x, y + 1));

            return neighbors;
        }
    }
}