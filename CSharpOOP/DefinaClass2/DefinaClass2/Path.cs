using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinaClass2
{
    public struct Point3D
    {
        private static readonly Point3D start = new Point3D(0, 0, 0);
        public static Point3D Start
        {
            get { return start; }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
       
        public override string ToString()
        {
            return string.Format("The points are {0},{1},{2}", this.X, this.Y, this.Z);
        }

    }

    public static class Calculate
    {
        public static double Distance(Point3D a, Point3D b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
        }
    }

    public class Path
    {
        private List<Point3D> path = new List<Point3D>();

        public Path()
        {
        }
        public Path(List<Point3D> path)
        {
            this.path = path;
        }
        public void Add(Point3D point)
        {
            path.Add(point);
        }
        public int Count
        {
            get { return path.Count; }
        }
        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return path[index];
                }
            }
        }

    }

    public class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName, true);
                using (writer)
                {
                    for (int i = 0; i < path.Count; ++i)
                    {
                        writer.WriteLine(path[i].X);
                        writer.WriteLine(path[i].Y);
                        writer.WriteLine(path[i].Z);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Path LoadPath(string fileName)
        {
            Path path = new Path();
            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    string lineX = reader.ReadLine();
                    string lineY = reader.ReadLine();
                    string lineZ = reader.ReadLine();
                    while(lineX != null && lineY !=null && lineZ != null)
                    {
                        path.Add(new Point3D(int.Parse(lineX), int.Parse(lineY), int.Parse(lineZ));
                        lineX=reader.ReadLine();
                        lineY=reader.ReadLine();
                        lineZ=reader.ReadLine();

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return path;
        }
    }

}
