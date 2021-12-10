using System;
using System.Collections.Generic;

namespace oop_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph g = new Graph();
            //Point p1 = new Point("1", 1, 1);
            //Point p2 = new Point("2", 2, 2);
            //Point p3 = new Point("3", 3, 3);
            //Point p4 = new Point("4", 4, 4);
            //Point p5 = new Point("5", 5, 5);
            //Point p6 = new Point("6", 6, 6);
            //Point p7 = new Point("7", 7, 7);
            //Point p8 = new Point("8", 8, 8);
            //g.addEdge(p1, p2, 15);
            //g.addEdge(p1, p3, 6);
            //g.addEdge(p1, p4, 7);
            //g.addEdge(p3, p5, 10);
            //g.addEdge(p3, p6, 8);
            //g.addEdge(p6, p7, 0);
            //g.addEdge(p6, p8, 5);
            //HillClimbing h = new HillClimbing();
            //h.hillClimbing(g, p1, p7);

            // =======================================
            //Graph g = new Graph();
            //Point p1 = new Point("1", 1, 1);
            //Point p2 = new Point("2", 2, 2);
            //Point p3 = new Point("3", 3, 3);
            //Point p4 = new Point("4", 4, 4);
            //Point p5 = new Point("5", 5, 5);
            //Point p6 = new Point("6", 6, 6);
            //Point p7 = new Point("7", 7, 7);
            //Point p8 = new Point("8", 8, 8);
            //Point p9 = new Point("9", 9, 9);
            //Point p10 = new Point("10", 10, 10);
            //Point p11 = new Point("11", 11, 11);
            //Point p12 = new Point("12", 12, 12);
            //Point p13 = new Point("13", 13, 13);
            //Point p14 = new Point("14", 14, 14);
            //g.addEdge(p1, p2, 3);
            //g.addEdge(p1, p3, 6);
            //g.addEdge(p1, p4, 5);
            //g.addEdge(p2, p5, 9);
            //g.addEdge(p2, p6, 8);
            //g.addEdge(p3, p7, 12);
            //g.addEdge(p3, p8, 14);
            //g.addEdge(p4, p9, 7);
            //g.addEdge(p9, p10, 5);
            //g.addEdge(p9, p11, 6);
            //g.addEdge(p10, p12, 1);
            //g.addEdge(p10, p13, 10);
            //g.addEdge(p10, p14, 2);

            ////g.addEdge(p1, p2, 3);
            ////g.addEdge(p1, p3, 3);
            ////g.addEdge(p1, p4, 3);
            ////g.addEdge(p2, p5, 3);
            ////g.addEdge(p2, p6, 3);
            ////g.addEdge(p3, p7, 3);
            ////g.addEdge(p3, p8, 3);
            ////g.addEdge(p4, p9, 3);
            ////g.addEdge(p9, p10, 3);
            ////g.addEdge(p9, p11, 3);
            ////g.addEdge(p10, p12, 3);
            ////g.addEdge(p10, p13, 3);
            ////g.addEdge(p10, p14, 3);
            ///
            // ===============================
            Graph g = new Graph();
            //Point p1 = new Point("1", 1, 1);
            //Point p2 = new Point("2", 2, 2);
            //Point p3 = new Point("3", 3, 2);
            //Point p4 = new Point("4", 4, 2);
            //Point p5 = new Point("5", 7, 2);
            //Point p6 = new Point("6", 6, 1);
            //g.addEdge(p1, p2, 1);
            //g.addEdge(p1, p6, 1);
            //g.addEdge(p2, p3, 1);
            //g.addEdge(p3, p4, 1);
            //g.addEdge(p4, p5, 1);
            //g.addEdge(p4, p6, 1);
            //g.addEdge(p5, p6, 1);


            //HillClimbing h = new HillClimbing();
            //h.hillClimbing(g, p1, p6);

            // ---

            List<Point> randomList = new List<Point>();
            randomList = g.randomListPoint(1000);
            Console.WriteLine("--------------------random list point:  ");
            foreach (var point in randomList)
            {
                Console.WriteLine($"name: {point.name}, x: {point.x}, y: {point.y}");
            }
            Console.WriteLine("--------------------end random list point");
            g.addRandomEdge(randomList);

            HillClimbing h = new HillClimbing();
            Point source = g.getPointFromName("1");
            Point destination = g.getPointFromName("1000");
            var visited = h.hillClimbing(g, source, destination);
            //foreach(var item in visited)
            //{
            //    Console.Write(item.name + " ");
            //}
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine("visited count: " + visited.Count);
            var minPath = h.getMinPath(g, visited, source, destination);
            foreach (var item in minPath)
            {
                Console.Write("{0,5}", item.name);
            }
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine("minPath count: " + minPath.Count);

            // -- test bai co the se bi sai

            //Point p1 = new Point("1", 1, 1);
            //Point p2 = new Point("2", 1, 1);
            //Point p3 = new Point("3", 1, 1);
            //Point p4 = new Point("4", 1, 1);
            //Point p5 = new Point("5", 1, 1);
            //Point p6 = new Point("6", 1, 1);
            //Point p7 = new Point("7", 1, 1);

            //g.addEdge(p1, p2, 1);
            //g.addEdge(p1, p3, 2);
            //g.addEdge(p1, p4, 10);
            //g.addEdge(p4, p5, 3);
            //g.addEdge(p4, p6, 1);
            //g.addEdge(p4, p7, 100);
            //g.addEdge(p5, p7, 1);
            //g.addEdge(p6, p7, 100);
            //g.addEdge(p5, p6, 1);

            //HillClimbing h = new HillClimbing();
            //var visited = h.hillClimbing(g, p1, p7);
            //Console.WriteLine("visited count: " + visited.Count);
            //var minPath = h.getMinPath(g, visited, p1, p7);
            //Console.WriteLine("minPath count: " + minPath.Count);
        }
    }
}
