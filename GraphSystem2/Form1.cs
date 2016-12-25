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
                            ProcDrawLine(drawArea, pen, point[0].X, point[0].Y, point[1].X, point[1].Y);

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
                            DrawBezie(drawArea,pen,point);

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
            if (figureColor.Text == "Transparent")
            {
                return;
            }
        }

        public void ProcDrawLine(Graphics drawArea, Pen pen, int x1, int y1, int x2, int y2)
        {
            drawArea = CreateGraphics();
            drawArea.SmoothingMode = SmoothingMode.HighQuality;
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;
            bool tr = true;
            Sx = Math.Sign(dx); Sy = Math.Sign(dy);
            if (Sx > 0)
                dFx = dy;
            else
                dFx = -dy;
            if (Sy > 0)
                dFy = dx;
            else
                dFy = -dx;
            x = x1;
            y = y1;
            F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                // угол наклона <= 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    Draw(drawArea, pen, x, y);
                    if (x == x2)
                        break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F))
                        F = Fx;
                    else
                        y = y + Sy;
                } while (tr);
            }
            else // угол наклона > 45 градусов 
            {
                do { //Вывести пиксель с координатами х, у
                    Draw(drawArea, pen, x, y);
                    if (y == y2)
                        break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F))
                        F = Fy;
                    else x = x + Sx;
                } while (tr);
            }
        }

        // Вывод точки (квадрата)
        public void Draw(Graphics drawArea, Pen pen, int x, int y)
        {
            drawArea.DrawRectangle(pen, x, y, thickness.SelectedIndex + 1, thickness.SelectedIndex + 1);
        }

        public void DrawBezie(Graphics drawArea, Pen pen, Point[] point)
        {
            double[] pX = new double[100],
                     pY = new double[100];
            double del = 0.01;
            drawArea = CreateGraphics();
            for (int t = 0; t < 100; t++)
            {
                pX[t] = Math.Pow((1 - t * del), 3) * point[0].X + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].X + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].X + t * t * t * Math.Pow(del, 3) * point[3].X;
                pY[t] = Math.Pow((1 - t * del), 3) * point[0].Y + 3 * Math.Pow((1 - t * del), 2) * t * del * point[1].Y + 3 * (1 - t * del) * Math.Pow((t * del), 2) * point[2].Y + t * t * t * Math.Pow(del, 3) * point[3].Y;
                if (t != 0)
                {
                    ProcDrawLine(drawArea, pen, (int)pX[t - 1], (int)pY[t - 1], (int)pX[t], (int)pY[t]);
                }
            }
            
        }
    }
}
