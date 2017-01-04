using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    class MyIsoScalesTriangle : IMyFigure
    {
        private Point[] point;

        public Point[] Point
        {
            get
            {
                return point;
            }
        }

        public Point this [int index]
        {
            set
            {
                if (index >= 0 && index < point.Length)
                {
                    point[index] = value;
                }
                else
                    throw new NotImplementedException();
            }
            get
            {
                if (index >= 0 && index < point.Length)
                {
                    return point[index];
                }
                else
                    throw new NotImplementedException();
            }
        }

        public MyIsoScalesTriangle(Point p1, Point p2, Point p3)
        {
            point = new Point[] { p1, p2, p3 };
        }

        public MyIsoScalesTriangle(Point[] point)
        {
            this.point = point;
        }
    }
}
