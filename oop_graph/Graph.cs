using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_graph
{
    class Graph
    {
        public Dictionary<string, Point> pointMap { get; set; }
        public List<Edge> edgeList { get; set; }

        public Graph()
        {
            pointMap = new Dictionary<string, Point>();
            edgeList = new List<Edge>();
        }

        public void addEdge(Point source, Point destination, double weight)
        {
            edgeList.Add(new Edge(source, destination, weight));

            pointMap[source.name] = source;
            source.addNeighbor(destination);

            pointMap[destination.name] = destination;
            destination.addNeighbor(source);
        }

        public double getEdge(Point source, Point destination)
        {
            foreach (var edge in edgeList)
            {
                if (edge.source.name == source.name && edge.destination.name == destination.name || edge.source.name == destination.name && edge.destination.name == source.name)
                {
                    return edge.weight;
                }
            }
            return int.MaxValue;
        }

        public Point getPointFromName(string name)
        {
            foreach (KeyValuePair<string, Point> entry in pointMap)
            {
                if (entry.Key == name)
                {
                    return entry.Value;
                }
                else
                {
                    continue;
                }
            }
            return null;
        }

        public bool pointAlreadyExist(int x, int y)
        {
            foreach (KeyValuePair<string, Point> entry in pointMap)
            {
                if (entry.Value.x == x && entry.Value.y == y)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Point> randomListPoint(int amount)
        {
            List<Point> randomList = new List<Point>();
            Random random = new Random();
            int x, y;
            for (int i = 1; i <= amount; i++)
            {
                x = random.Next(1, 2000);
                y = random.Next(1, 2000);
                // nếu đã tồn tại điểm có tọa độ này rồi thì random lại
                if (pointAlreadyExist(x, y))
                {
                    i--;
                }
                else
                {
                    randomList.Add(new Point(i.ToString(), x, y));
                }
            }
            return randomList;
        }

        public void addRandomEdge(List<Point> randomList)
        {
            List<Point> randomNeighbors = new List<Point>();
            int maxNeighbor = 0;
            int randomNumerOfNeighbor = 0;
            int randomWeight = 0;
            foreach (var point in randomList)
            {
                // số lượng hàng xóm của 1 điểm sẽ là random trong khoảng nhỏ hơn một nửa của tổng số điểm trên mặt phẳng
                maxNeighbor = Convert.ToInt32((randomList.Count)/2);
                randomNumerOfNeighbor = new Random().Next(0, 10);
                //randomNumerOfNeighbor = maxNeighbor;


                // lấy ra list hàng xóm với số lượng random bên trên 
                randomNeighbors = randomList.OrderBy(arg => Guid.NewGuid()).Take(randomNumerOfNeighbor).ToList();

                // duyệt từng hàng xóm và tạo cạnh giữa hai điểm
                for (int i = 0; i < randomNeighbors.Count; i++)
                {
                    // ramdom chi phí giữa hai điểm từ 1 đến 100
                    randomWeight = new Random().Next(1, 1000);

                    addEdge(point, randomNeighbors[i], randomWeight);
                }
            }
        }


    }
}
