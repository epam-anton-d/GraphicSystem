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
                            pointCounter = 0;
                            drawArea = CreateGraphics();
                            pen = new Pen((Color)figureColor.SelectedItem);
                            //drawArea.SmoothingMode = SmoothingMode.HighQuality;
                            DrawMyIsoScalesTriangle(drawArea, point);
                            
                            //drawArea.FillPolygon(brush, p);
                            return;
                        default:
                            pointCounter = 0;
                            return;
                    }
                    return;
                }
            }
        }

        private void figureColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (figureColor.Text == "Transparent")
            {
                return;
            }
        }

        public void DrawMyLine(Graphics drawArea, Pen pen, Point[] point)
        {
            drawArea = CreateGraphics();
            drawArea.SmoothingMode = SmoothingMode.HighQuality;
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
            //double[] pX = new double[100],
             //        pY = new double[100];
            Point[] pXY = new Point[100];

            double del = 0.01;
            drawArea = CreateGraphics();
            for (int t = 0; t < 100; t++)
            {
                pXY[t].X = (int)Math.Round(Math.Pow((1 - t * del), 3) * point[0].X + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].X + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].X + t * t * t * Math.Pow(del, 3) * point[3].X);
                pXY[t].Y = (int)Math.Round(Math.Pow((1 - t * del), 3) * point[0].Y + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].Y + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].Y + t * t * t * Math.Pow(del, 3) * point[3].Y);
                if (t != 0)
                {
                    //DrawMyLine(drawArea, pen, (int)pX[t - 1], (int)pY[t - 1], (int)pX[t], (int)pY[t]);
                    DrawMyLine(drawArea, pen, new Point[] { pXY[t - 1], pXY[t] });
                }
            }
            
        }

        public void DrawMyIsoScalesTriangle(Graphics graph, Point[] point)
        {
            int yFant;
            int xFant;

            //xFant = (int)(Math.Round((2 * p1.Y * p3.Y - Math.Pow(p1.X, 2) - Math.Pow(p1.Y, 2) + Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2) - 2 * p2.Y * p3.Y) / (2 * (p2.X - p1.X))));
            xFant = (int)(Math.Round((2 * point[0].Y * point[2].Y - Math.Pow(point[0].X, 2) - Math.Pow(point[0].Y, 2) + Math.Pow(point[1].X, 2) + Math.Pow(point[1].Y, 2) - 2 * point[1].Y * point[2].Y) / (2 * (point[1].X - point[0].X))));
            //yFant = (int)(Math.Round((2 * p2.X * p3.X - 2 * p1.X * p3.X + Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2) - Math.Pow(p2.X, 2) - Math.Pow(p2.Y, 2)) / (2 * (p1.Y - p2.Y))));
            yFant = (int)(Math.Round((2 * point[1].X * point[2].X - 2 * point[0].X * point[2].X + Math.Pow(point[0].X, 2) + Math.Pow(point[0].Y, 2) - Math.Pow(point[1].X, 2) - Math.Pow(point[1].Y, 2)) / (2 * (point[0].Y - point[1].Y))));

            if (Math.Abs(xFant - point[2].X) < Math.Abs(yFant - point[2].Y))
            {
                point[2].X = xFant;
            }
            else
            {
                point[2].Y = yFant;
            }

            DrawMyLine(drawArea, pen, new Point[] { point[0], point[1] });
            DrawMyLine(drawArea, pen, new Point[] { point[1], point[2] });
            DrawMyLine(drawArea, pen, new Point[] { point[2], point[0] });
        }
    }
}
