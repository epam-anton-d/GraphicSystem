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
        private Pen pen;

        public Pen PenOfThis
        {
            get
            {
                return pen;
            }
        }

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

        public MyStar(Pen pen, Point[] point, int tops)
        {
            this.pen = pen;
            this.tops = tops;
            this.point = point;
        }
    }
}

