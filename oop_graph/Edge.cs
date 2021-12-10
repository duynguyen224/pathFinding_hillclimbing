using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_graph
{
    class Edge
    {
        public Point source { get; set; }
        public Point destination { get; set; }
        public double weight { get; set; }
        //public double heuristic { get; set; }

        public Edge(Point source, Point destination, double weight)
        {
            this.source = source;
            this.destination = destination;
            this.weight = weight;
            //this.heuristic = int.MaxValue;
        }

        //public void updateHeuristic(Point source, Point destination, double heuristic)
        //{
        //    if(this.source.name == source.name && this.destination.name == destination.name || this.source.name == destination.name && this.destination.name == source.name)
        //    {
        //        this.heuristic = heuristic;
        //    }
        //}
    }
}
