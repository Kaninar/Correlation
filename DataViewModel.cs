using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correlation
{
    public class DataViewModel
    {
        public List<DataModel> Data {
            get; set;
        }

        public List<DataModel> Regration
        {
            get; set;
        }

        public List<Brush> ShutterBrushes
        {
            get; set;
        }

        public List<Brush> LineBrushes
        {
            get; set;
        }

        public DataViewModel()
        {
            Data = new List<DataModel>()
            {
                new DataModel(78, 82),
                new DataModel(91, 88),
                new DataModel(70, 82),
                new DataModel(80, 90),
                new DataModel(83, 90),
                new DataModel(74, 80),
                new DataModel(89, 85),
                new DataModel(76, 90),
                new DataModel(76, 90),
                new DataModel(78, 90),
                new DataModel(86, 90),
                new DataModel(62, 81),
                new DataModel(73, 65),
                new DataModel(80, 92),
                new DataModel(68, 75),
                new DataModel(78, 80),
                new DataModel(89, 91),
                new DataModel(61, 85),
                new DataModel(78, 85),
                new DataModel(76, 88),
                new DataModel(77, 85),
                new DataModel(87, 85),
                new DataModel(90, 90),
                new DataModel(88, 90),
                new DataModel(77, 85),
                new DataModel(96, 100),
                new DataModel(80, 80),
                new DataModel(82, 80),
                new DataModel(76, 70),
                new DataModel(83, 75),
                new DataModel(92, 93),
                new DataModel(71, 80),
                new DataModel(88, 92),
                new DataModel(80, 80),
                new DataModel(87, 80),
                new DataModel(77, 85),
                new DataModel(84, 80),
                new DataModel(94, 90),
                new DataModel(90, 90),
                new DataModel(86, 85),
                new DataModel(67, 75),
                new DataModel(82, 85),
                new DataModel(86, 80)
            };

            RegrationData();
            this.ShutterBrushes = new List<Brush>();
            this.ShutterBrushes.Add(new SolidColorBrush(Colors.MediumPurple));

            this.LineBrushes = new List<Brush>();
            this.LineBrushes.Add(new SolidColorBrush(Colors.Orange));
        }

        void RegrationData()
        {
            double count = Data.Count;
            IEnumerable<double> X = Data.Select(d => d.X);
            IEnumerable<double> Y = Data.Select(d => d.Y);
            double avgX = X.Average();
            double avgY = Y.Average();
            double avgXY = Data.Select(d => d.X * d.Y).Average();
            double avgX2 = X.Select(x => x * x).Average();

            double b = (avgXY - avgX * avgY) / (avgX2 - (avgX * avgX));
            double a = (avgX2 * avgY - avgX * avgXY) / (avgX2 - (avgX * avgX));

            double minX = X.Min();
            double maxX = X.Max();

            Regration = new List<DataModel>()
            {
                new (maxX, Math.Round(b * maxX + a, 0)),
                new (minX, Math.Round(b * minX + a,0))
            };

            double numerator = Data.Select(d => (d.X - avgX) * (d.Y - avgY)).Sum();
            double denominator = Math.Sqrt(
                X.Sum(x => Math.Pow(x - avgX, 2)) *
                Y.Sum(y => Math.Pow(y - avgY, 2))
            );
            double r = numerator / denominator;


            //label1.Text = $"y = {b:F2}x + {a:F2}\r\n" +
            //    $"Коэффициент корреляции: r = {r:F2}";
        }
    
    }

    public class DataModel
    {

        public double X { get; set; }
        public double Y
        {
            get; set;
        }

        public DataModel(double X, double Y)
        {
            this.X = X; this.Y = Y;
        }
    }

}
