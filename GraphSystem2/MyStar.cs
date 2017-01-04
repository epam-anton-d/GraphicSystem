using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    class MyStar : IMyFigure
    {
        private Point[] point;
        private int tops;

        public int Tops
        {
            get
            {
                return tops;
            }
        }

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
                    throw new Exception("Out of range index array");
            }
            get
            {
                if (index >= 0 && index < point.Length)
                {
                    return point[index];
                }
                else
                    throw new Exception("Out of range index array");
            }
        }

        public MyStar(Point[] point, int tops)
        {
            this.tops = tops;
            this.point = point;
        }
    }
}

