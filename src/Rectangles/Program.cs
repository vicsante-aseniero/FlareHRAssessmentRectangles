using System;
using System.Linq;
using System.Text;

namespace FlareHR.Rectangles
{
    class Program
    {
        private static SingleInstanceGrid _Grid;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var output = DrawRectangles(new Tuple<int,int>(8,8), new Tuple<int,int>(4,3), new Tuple<int,int>(5,6), new Tuple<int,int>(10,20));
            Console.WriteLine(output);

            _Grid = SingleInstanceGrid.GetInstance();
        }

        // Assume the Tuples are <height, width>
        static string DrawRectangles(params Tuple<int, int>[] measurements)
        {
            var sb = new StringBuilder(Environment.NewLine);
            var maxHeight = measurements.Max().Item1;
            var maxHeight2 = FindMax(measurements).Item1;

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

    public class SingleInstanceGrid
    {
        //Create a static variable as static method GetInstance() will accept only static variable.
        private static SingleInstanceGrid instance = null;

        //Make the constructor private to stop object creation from out side of the class
        private SingleInstanceGrid()
        {
        }

        //Design GetInstance() method to return only one object on multiple calls
        //@return : Return type is of same class i.e.SingleInstanceClass 
        public static SingleInstanceGrid GetInstance()
        {
            //If instance is null then create object of the class
            // and return it or else return the same object.
            if (instance == null)
            {
                instance = new SingleInstanceGrid();

                //Create the Grid upon creation of the SingleInstanceGrid Class
                //Set a fix dimension for the Grid as required in the constraits i.e. 25 for both height and width
                Console.WriteLine("{0}", instance.DrawGrid(25,25));
            }

            return instance;
        }

        public void Display()
        {
            Console.WriteLine("SingleTon Class Function");
        }

        private string DrawGrid(int height, int width)
        {
            var sb = new StringBuilder(Environment.NewLine);

            for (var h = height; h > -1; h--)
            {
                for (var w = width; w > -1; w--)
                {
                    // If you're on the top or bottom row of a rectangle...
                    if (h == 0 || height == h)
                    {
                        sb.Append(String.Format("{0}{1}", "+", " "));
                        //continue;
                    }
                    // If you're in the left or right column of a rectangle...
                    else if (w == 0 || w == width)
                    {
                        sb.Append(String.Format("{0}{1}", "|", " "));
                        //continue;
                    }
                    // If you're in the middle of a rectangle...
                    else {
                        sb.Append(String.Format("{0}", "  "));
                    }
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
