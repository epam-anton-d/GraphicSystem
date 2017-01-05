
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphSystem2
{
    internal interface IMyFigure
    {
        Pen PenOfThis
        {
            get;
        }

        Point this[int index]
        {
            set;
            get;
        }

        Point[] Point
        {
            get;
        }
    }
}
