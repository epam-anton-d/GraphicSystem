using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    class MyBezie : IMyFigure
    {
        private Point[] point;
        private Pen pen;

        public Pen PenOfThis
        {
            get
            {
                return pen;
            }
        }

        public Point[] Point
        {
            get
            {
                return point;
            }
        }

        public Point this[int index]
        {
            set
            {
                if (index >= 0 && index < point.Length)
                {
                    point[index] = value;
                }
                else
                    throw new IndexOutOfRangeException();
            }
            get
            {
                if (index >= 0 && index < point.Length)
                {
                    return point[index];
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public MyBezie(Pen pen, Point p1, Point p2, Point p3, Point p4)
        {
            this.pen = pen;
            point = new Point[] { p1, p2, p3, p4 };
        }

        public MyBezie(Pen pen, Point[] point)
        {
            this.pen = pen;
            this.point = point;
        }
    }
}
