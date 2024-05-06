using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    public class FindShortestPath
    {
        public static List<Tuple<int, int>> AStar(int[,] grid, Tuple<int, int> start, Tuple<int, int> end)
        {
            var cost = new Dictionary<Tuple<int, int>, int>();
            var cameFrom = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

            var priorityQueue = new List<Tuple<int, int>> { start };
            cost[start] = 0;

            while (priorityQueue.Any())
            {
                var currentPoint = priorityQueue.OrderBy(t => cost.TryGetValue(t, out var value) ? value : int.MaxValue).First();
                priorityQueue.Remove(currentPoint);

                if (currentPoint.Equals(end)) { break; }

                foreach (var neighbor in GetNeighbors(currentPoint, grid))
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

        static List<Tuple<int, int>> ReconstructPath(Dictionary<Tuple<int, int>, Tuple<int, int>> cameFrom, Tuple<int, int> end)
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

        static IEnumerable<Tuple<int, int>> GetNeighbors(Tuple<int, int> point, int[,] grid)
        {
            var neighbors = new List<Tuple<int, int>>();
            var x = point.Item1;
            var y = point.Item2;

            if (x > 0 && grid[x-1, y] == 0) neighbors.Add(Tuple.Create(x-1, y));
            if (x < grid.GetLength(0)-1 && grid[x+1, y] == 0) neighbors.Add(Tuple.Create(x+1, y));
            if (y > 0 && grid[x, y-1] == 0) neighbors.Add(Tuple.Create(x, y-1));
            if (y < grid.GetLength(1)-1 && grid[x, y+1] == 0) neighbors.Add(Tuple.Create(x, y+1));

            return neighbors;
        }
    }
}