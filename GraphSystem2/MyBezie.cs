using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    class MyBezie
    {
        private Point[] point;

        public Point this[int index]
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

        public MyBezie(Point p1, Point p2, Point p3, Point p4)
        {
            point = new Point[] { p1, p2, p3, p4 };
        }

        public MyBezie(Point[] point)
        {
            this.point = point;
        }
    }
}
