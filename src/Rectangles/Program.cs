using System;
using System.Linq;
using System.Text;

namespace FlareHR.Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var output = DrawRectangles(new Tuple<int,int>(8,8), new Tuple<int,int>(4,3), new Tuple<int,int>(5,6), new Tuple<int,int>(10,20));
            Console.WriteLine(output);


        }

        // Assume the Tuples are <height, width>
        static string DrawRectangles(params Tuple<int, int>[] measurements)
        {
            var sb = new StringBuilder(Environment.NewLine);
            var maxHeight = FindMax(measurements).Item1;
            var maxHeight2 = measurements.Max().Item1;

            for (var h = maxHeight; h > -1; h--)
            {
                foreach (var measurement in measurements)
                {
                    // If you're on the top or bottom row of a rectangle...
                    if (h == 0 || measurement.Item1 == h)
                    {
                        sb.Append(String.Format("{0}{1}{0}", "+", new String('-', measurement.Item2 - 2)));
                        continue;
                    }

                    // If you're in the middle of a rectangle...
                    if (measurement.Item1 > h)
                    {
                        sb.Append(String.Format("{0}{1}{0}", "+", new String(' ', measurement.Item2 - 2)));
                        continue;
                    }

                    sb.Append(new String(' ', measurement.Item2));
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        static T FindMax<T>(params T[] items)
        {
            return items.Max();
        }
    }
}
