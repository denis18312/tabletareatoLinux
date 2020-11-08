using System;

namespace tabletareatoLinux
{
    class Program
    {
        struct Point
        {
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public double x;
            public double y;
        }

        struct Area
        {
            public Area(double x, double coefWH)
            {
                width = x;
                heigth = width / coefWH;
            }

            public double width;
            public double heigth;
        }

        public struct AreaByPoints
        {
            public AreaByPoints(double widthS, double heigthS, double widthE, double heigthE)
            {
                wS = widthS;
                wE = widthE;
                hS = heigthS;
                hE = heigthE;
            }

            public double wS { get; set; }
            public double hS { get; set; }
            public double wE { get; set; }
            public double hE { get; set; }

            public void PrintArea()
            {
                Console.WriteLine($"The area is defined by points {String.Format("{0:0.##}", wS)} {String.Format("{0:0.##}", wE)} {String.Format("{0:0.##}", hS)} {String.Format("{0:0.##}", hE)}");
            }
        }
        // 152mm x 85.5mm
        static void Main(string[] args)
        {
            double coefWH = 1.778;

            Console.WriteLine("Hello World!");
            double widthmm = 0;
            

            Area maxArea = new Area(152, coefWH);
            Console.WriteLine("Enter current area width in mm");
            Area curArea = new Area(Convert.ToDouble(Console.ReadLine()),coefWH);
            Point offset;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter offset in mm (x 'space' y)");
                    var offArr = Console.ReadLine().Split(' ');
                    offset = new Point(Convert.ToDouble(offArr[0]), Convert.ToDouble(offArr[1]));
                    break;
                }
                catch
                {
                    continue;
                }
            }
            AreaByPoints maxAreabP = new AreaByPoints(0,0,14720, 9225);
            AreaByPoints targetAreabP = new AreaByPoints();
            double pointsInMM = (maxAreabP.wE - maxAreabP.wS) / maxArea.width;

            targetAreabP.wS = maxAreabP.wS + (pointsInMM * offset.x);
            targetAreabP.hS = maxAreabP.hS + (pointsInMM * offset.y);

            targetAreabP.wE = maxAreabP.wE / (maxArea.width / curArea.width) + targetAreabP.wS;
            targetAreabP.hE = maxAreabP.hE / (maxArea.heigth / curArea.heigth) + targetAreabP.hS;

            targetAreabP.PrintArea();
        }
    }
}
