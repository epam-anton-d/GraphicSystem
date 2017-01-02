using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphSystem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point[] point;
        int pointCounter;
        Pen pen;
        Graphics drawArea;


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Графические системы. Вариант №1";
            string[] figures = new string[] { "Линия", "Кривая Безье", "Равнобедренный треугольник", "Звезда" };
            string[] actions = new string[] { "Нарисовать" };
            figureChanger.Items.AddRange(figures);
            actionChanger.Items.AddRange(actions);

            for (int topCounter = 3; topCounter < 21; topCounter++)
            {
                starTops.Items.Add(topCounter);
            }

            point = new Point[4];
            pointCounter = 0;
            var colors = new Color[] { Color.Blue, Color.Red, Color.Green };
            figureColor.Items.Clear();
            foreach (var item in colors)
            {
                figureColor.Items.Add(item);
            }
            figureColor.Sorted = true;

            for (int i = 1; i < 5; i++)
            {
                thickness.Items.Add(i);
            }

            figureChanger.SelectedIndex = 0;
            actionChanger.SelectedIndex = 0;
            starTops.SelectedIndex = 0;
            figureColor.SelectedIndex = 0;
            thickness.SelectedIndex = 0;
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {

        }

        private void figureChanger_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (actionChanger.SelectedItem == "Нарисовать")
            {
                if (figureChanger.SelectedItem == "Линия")
                {
                    switch(pointCounter)
                    {
                        case 0:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 1:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter = 0;
                            pen = new Pen((Color)figureColor.SelectedItem);
                            drawArea = CreateGraphics();
                            DrawMyLine(drawArea, pen, point);
                            return;
                        default:
                            pointCounter = 0;
                            return;
                    }
                }
                else if (figureChanger.SelectedItem == "Кривая Безье")
                {
                    switch (pointCounter)
                    {
                        case 0:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 1:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 2:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 3:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter = 0;
                            pen = new Pen((Color)figureColor.SelectedItem);
                            drawArea = CreateGraphics();
                            DrawMyBezie(drawArea,pen,point);
                            return;
                        default:
                            pointCounter = 0;
                            return;
                    }
                }
                else if (figureChanger.SelectedItem == "Равнобедренный треугольник")
                {
                    switch(pointCounter)
                    {
                        case 0:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 1:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 2:
                            point[pointCounter] = new Point(e.X, e.Y);
                            point[pointCounter + 1] = point[0];
                            pointCounter = 0;
                            drawArea = CreateGraphics();
                            pen = new Pen((Color)figureColor.SelectedItem);
                            DrawMyIsoScalesTriangle(drawArea, point);
                            
                            return;
                        default:
                            pointCounter = 0;
                            return;
                    }
                }
                else if (figureChanger.SelectedItem == "Звезда")
                {
                    switch(pointCounter)
                    {
                        case 0:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter++;
                            return;
                        case 1:
                            point[pointCounter] = new Point(e.X, e.Y);
                            pointCounter = 0;
                            drawArea = CreateGraphics();
                            pen = new Pen((Color)figureColor.SelectedItem);
                            DrawMyStar(drawArea, pen, point[0], point[1], Convert.ToInt32(starTops.SelectedItem));
                            return;
                        default:
                            pointCounter = 0;
                            return;
                    }
                }
            }
        }

        private void figureColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void DrawMyLine(Graphics drawArea, Pen pen, Point[] point)
        {
            int dx, dy, Sx = 0, Sy = 0;
            Point pXY;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            dx = point[1].X - point[0].X;
            dy = point[1].Y - point[0].Y;
            bool tr = true;
            Sx = Math.Sign(dx); 
            Sy = Math.Sign(dy);
            if (Sx > 0)
                dFx = dy;
            else
                dFx = -dy;
            if (Sy > 0)
                dFy = dx;
            else
                dFy = -dx;
            //x = x1;
            //y = y1;
            pXY = point[0];
            F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                // угол наклона <= 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    Draw(drawArea, pen, pXY);
                    if (pXY.X == point[1].X)//(x == x2)
                        break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    pXY.X = pXY.X + Sx; //x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F))
                        F = Fx;
                    else
                        pXY.Y = pXY.Y + Sy;//y = y + Sy;
                } while (tr);
            }
            else // угол наклона > 45 градусов 
            {
                do { //Вывести пиксель с координатами х, у
                    Draw(drawArea, pen, pXY);
                    if (pXY.Y == point[1].Y)//(y == y2)
                        break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    pXY.Y = pXY.Y + Sy;//y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F))
                        F = Fy;
                    else
                        pXY.X = pXY.X + Sx;//x = x + Sx;
                } while (tr);
            }
        }

        // Вывод точки (квадрата)
        public void Draw(Graphics drawArea, Pen pen, Point point)
        {
            drawArea.DrawRectangle(pen, point.X, point.Y, thickness.SelectedIndex + 1, thickness.SelectedIndex + 1);
        }

        public void DrawMyBezie(Graphics drawArea, Pen pen, Point[] point)
        {
            Point[] pXY = new Point[100];

            double del = 0.01;
            for (int t = 0; t < 100; t++)
            {
                pXY[t].X = (int)Math.Round(Math.Pow((1 - t * del), 3) * point[0].X + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].X + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].X + t * t * t * Math.Pow(del, 3) * point[3].X);
                pXY[t].Y = (int)Math.Round(Math.Pow((1 - t * del), 3) * point[0].Y + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].Y + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].Y + t * t * t * Math.Pow(del, 3) * point[3].Y);
                if (t != 0)
                {
                    DrawMyLine(drawArea, pen, new Point[] { pXY[t - 1], pXY[t] });
                }
            }
            
        }

        public void DrawMyIsoScalesTriangle(Graphics graph, Point[] point)
        {
            int yFant;
            int xFant;

            xFant = (int)(Math.Round((2 * point[0].Y * point[2].Y - Math.Pow(point[0].X, 2) - Math.Pow(point[0].Y, 2) + Math.Pow(point[1].X, 2) + Math.Pow(point[1].Y, 2) - 2 * point[1].Y * point[2].Y) / (2 * (point[1].X - point[0].X))));
            yFant = (int)(Math.Round((2 * point[1].X * point[2].X - 2 * point[0].X * point[2].X + Math.Pow(point[0].X, 2) + Math.Pow(point[0].Y, 2) - Math.Pow(point[1].X, 2) - Math.Pow(point[1].Y, 2)) / (2 * (point[0].Y - point[1].Y))));

            if (Math.Abs(xFant - point[2].X) < Math.Abs(yFant - point[2].Y))
            {
                point[2].X = xFant;
            }
            else
            {
                point[2].Y = yFant;
            }

            for (int i = 1; i < point.Length; i++)
            {
                DrawMyLine(drawArea, pen, new Point[] { point[i - 1], point[i] });
            }

            FilUp(drawArea, new Pen((Color)figureColor.SelectedItem), point);
        }

        public void DrawMyStar(Graphics graph, Pen pen, Point center, Point p, int tops)
        {
            double radius = Math.Sqrt(Math.Pow((center.X - p.X), 2) + Math.Pow((center.Y - p.Y), 2));
            tops *= 2;
            Point[] point = new Point[tops + 1];
            point[0].X = center.X;
            point[0].Y = (int)Math.Round(center.Y - radius);

            double alfa = 2 * Math.PI / tops;

            for (int i = 1; i <= ((point.Length - 1) / 2); i++)
            {
                if (i % 2 == 0)
                {
                    point[i].X = (int)Math.Round(center.X + radius * Math.Sin(i * alfa));
                    point[i].Y = (int)Math.Round(center.Y - radius * Math.Cos(i * alfa));
                }
                else
                {
                    point[i].X = (int)Math.Round(center.X + radius * Math.Sin(i * alfa) / 2);
                    point[i].Y = (int)Math.Round(center.Y - radius * Math.Cos(i * alfa) / 2);
                }
                if (point.Length - 1 - i == i)
                {
                    continue;
                }
                point[point.Length - 1 - i].X = 2 * center.X - point[i].X;
                point[point.Length - 1 - i].Y = point[i].Y;
            }

            point[point.Length - 1] = point[0];

            for (int i = 1; i < point.Length; i++)
            {
                DrawMyLine(drawArea, pen, new Point[] { point[i - 1], point[i] });
            }

            FilUp(drawArea, new Pen((Color)figureColor.SelectedItem), point);
        }

        public void FilUp(Graphics drawArea, Pen pen, Point[] point)
        {
            int yMin = int.MaxValue,
                yMax = int.MinValue,
                x;
        
            for (int i = 0; i < point.Length; i++)
            {
                if (point[i].Y < yMin)
                {
                    yMin = point[i].Y;
                }
                if (point[i].Y > yMax)
                {
                    yMax = point[i].Y;
                }
            }
        
            List<int>[] line = new List<int>[yMax - yMin - 1]; // over flow
            double[] b = new double[point.Length - 1];
            double[] k = new double[point.Length - 1];
            int dx;

            for (int i = 1; i < point.Length; i++)
            {
                dx = point[i].X - point[i - 1].X;

                if (dx == 0)
                {
                    dx = 1;
                }

                b[i - 1] = ((point[i - 1].Y - point[i].Y * point[i - 1].X / point[i].X) * point[i].X) / dx; // divide by zero
                k[i - 1] = (point[i].Y - b[i - 1]) / point[i].X;
            }
            
            for (int y = yMin + 1; y < yMax; y++)
			{
			    for (int j = 0; j < point.Length - 1; j++)
			    {
                    if (((y > point[j].Y) && (y < point[j + 1].Y)) || ((y < point[j].Y) && (y > point[j + 1].Y)))
                    {
                        x = (int)Math.Round((y - b[j]) / k[j]);

                        if (line[y - yMin - 1] == null)
                        {
                            line[y - yMin - 1] = new List<int>();
                            line[y - yMin - 1].Add(x);
                        }
                        else
                        {
                            line[y - yMin - 1].Add(x);
                        }

                        line[y - yMin - 1].Sort();
                    }
			    }

                if (line[y - yMin - 1] != null)
                {
                    for (int i = 1; i < line[y - yMin - 1].Count; i += 2)
                    {
                        if (line[y - yMin - 1][i - 1] != line[y - yMin - 1][i])
                        {
                            DrawMyLine(drawArea, pen, new Point[] { new Point(line[y - yMin - 1][i - 1], y), new Point(line[y - yMin - 1][i], y) });
                        }
                    }
                }
			}
        }
    }
}
