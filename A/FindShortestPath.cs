using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A
{
    public partial class FindShortestPath
    {
        static Button[,] _buttons;
        static (bool A, bool D) _checkBox;
        static double _SearchTime;

        public static int Heuristic(Tuple<int, int> a, Tuple<int, int> b)
        {
            return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
        }

        static Color Points()
        {
            if (_checkBox.A && _checkBox.D) return Color.Teal;
            else if (_checkBox.D) return Color.DodgerBlue;
            else return Color.ForestGreen;
        }

        static Color FindWay()
        {
            if (_checkBox.A && !_checkBox.D)
            {
                Color color = Color.DarkSeaGreen;
                return Color.FromArgb(100, color.R, color.G, color.B);
            }
            else if (_checkBox.D && !_checkBox.A)
            {
                Color color = Color.LightSteelBlue;
                return Color.FromArgb(150, color.R, color.G, color.B);
            }
            return Color.White;
        }

        public static async Task<List<Tuple<int, int>>> AStar(int[,] grid, Tuple<int, int> start, Tuple<int, int> end, Button[,] buttons, (bool, bool) checkBox, double SearchTime)
        {
            _buttons = buttons;
            _checkBox = checkBox;
            _SearchTime = SearchTime;

            Color colorSF = Points();

            int N = grid.GetLength(0), M = grid.GetLength(1);
            foreach (var but in buttons) { but.Text = ""; }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    buttons[i, j].BackColor = ((i == 0 && j == 0) || (i == N-1 && j == M-1)) ? colorSF : grid[i, j] == 0 ? Color.White : Color.Black;
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
                    int q = _checkBox.A ? Heuristic(neighbor, end)+1 : 1;
                    var newCost = cost[currentPoint] + q;

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
            int x = point.Item1, y = point.Item2;

            _buttons[x, y].BackColor = FindWay();
            if (_checkBox.A && !_checkBox.D || !_checkBox.A && _checkBox.D) await Task.Delay((int)(_SearchTime*1000));

            if (x > 0 && grid[x-1, y] == 0) neighbors.Add(Tuple.Create(x-1, y));
            if (x < grid.GetLength(0)-1 && grid[x+1, y] == 0) neighbors.Add(Tuple.Create(x+1, y));
            if (y > 0 && grid[x, y-1] == 0) neighbors.Add(Tuple.Create(x, y-1));
            if (y < grid.GetLength(1)-1 && grid[x, y+1] == 0) neighbors.Add(Tuple.Create(x, y+1));

            return neighbors;
        }
    }
}