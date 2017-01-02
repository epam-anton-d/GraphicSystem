using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    class MyStar : MyFigure
    {
        private Point[] point;

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

        public MyStar(Point[] point)
        {
            this.point = point;
        }
    }
}

