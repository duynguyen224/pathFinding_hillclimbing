using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_graph
{
    class HillClimbing
    {
        public double heuristic(Graph g, Point source, Point destination)
        {
            // chi phí giữa hai điểm 
            double weight = g.getEdge(source, destination);

            // khoảng cách giữa hai điểm dựa vào tọa độ
            double xdiff = Math.Abs(source.x - destination.x);
            double ydiff = Math.Abs(source.y - destination.y);
            double distance = Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2));

            // return về Heuristic theo công thức 0.4 - 0.6
            return 0.4 * distance + 0.6 * weight;



            // cái bên dưới này để test 
            //return g.getEdge(source, destination);
        }
        public List<Point> getAllNeighbor(Graph g, Point source)
        {
            // lấy tất cả neighbor của source ra
            List<Point> neighbors = new List<Point>();
            foreach (var point in source.neighbors)
            {
                neighbors.Add(point);
            }
            return neighbors;
        }

        public List<Point> listNeighborDesc(Graph g, Point source, List<Point> neighbors)
        {
            // sắp xếp neighbor giảm dần theo heuristic để tí nữa cho vào stack
            Dictionary<string, double> pointPair = new Dictionary<string, double>();
            foreach (var point in neighbors)
            {
                pointPair[point.name] = heuristic(g, source, point);
            }
            // chua sort nha !!!!!!!!!!!!!!!!!! ???????????????
            var sortedDictDesc = from entry in pointPair orderby entry.Value descending select entry;

            // lấy dữ liệu đã sắp xếp đưa ra List
            List<Point> result = new List<Point>();
            foreach (KeyValuePair<string, double> entry in sortedDictDesc)
            {
                result.Add(g.getPointFromName(entry.Key));
            }
            return result;
        }
        public List<Point> hillClimbing(Graph g, Point source, Point destination)
        {
            List<Point> visitedPoint = new List<Point>(); // những điểm đã đi qua

            Stack<Point> stack = new Stack<Point>(); // stack chứa các điểm chưa đi qua

            Point current;
            stack.Push(source);
            while (stack.Count != 0)
            {
                current = stack.Pop();
                visitedPoint.Add(current);
                Console.Write("{0,5}", current.name);
                // nếu đến đích rồi thì dừng 
                if (current.name == destination.name)
                {
                    break;
                }

                // lấy hết điểm kề current ra
                // sắp xếp giảm dần
                // duyệt cái vừa sắp xếp và cho vào stack (giá trị lớn cho trước)
                foreach (var point in listNeighborDesc(g, current, getAllNeighbor(g, current)))
                {
                    if (visitedPoint.Contains(point))
                    {
                        continue;
                    }
                    else
                    {
                        stack.Push(point);
                    }
                }
            }

            return visitedPoint;

            //// in ra kết quả
            //foreach (var point in visitedPoint)
            //{
            //    Console.WriteLine(point.name);
            //}

            //if (!visitedPoint.Contains(destination))
            //{
            //    Console.WriteLine("Can't find destination point !");
            //}
        }


        public List<Point> getMinPath(Graph g, List<Point> visitedPoint, Point source, Point destination)
        {
            List<Point> minPath = new List<Point>();
            Stack<Point> stack = new Stack<Point>();

            // đưa lần lượt các điểm visited vào stack
            foreach (var point in visitedPoint)
            {
                stack.Push(point);
            }

            // kiểm tra điểm destination có phải điểm đầu stack hay không
            // nếu không thì không tìm được minPath và return null
            Point current = stack.Pop();
            if (current.name != destination.name)
            {
                return null;
            }

            // nếu không null thì tìm những điểm có kết nối với nhau và cho nó thành minpath
            minPath.Add(current);
            while (stack.Count != 0)
            {
                Point top = stack.Pop();
                if (g.getEdge((minPath[minPath.Count - 1]), top) != int.MaxValue)
                {
                    minPath.Add(top);
                }
                else
                {
                    continue;
                }
            }

            // đảo ngược lại cho xuôi rồi return
            List<Point> resultMinPath = new List<Point>();
            for (int i = minPath.Count - 1; i >= 0; i--)
            {
                resultMinPath.Add(minPath[i]);
            }
            return resultMinPath;
        }
    }
}
