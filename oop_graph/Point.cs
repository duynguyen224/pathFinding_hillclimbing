using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_graph
{
    class Point
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public List<Point> neighbors { get; set; }
        public Point(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            neighbors = new List<Point>();
        }
        public void addNeighbor(Point neighbor)
        {
            neighbors.Add(neighbor);
        }

    }
}
