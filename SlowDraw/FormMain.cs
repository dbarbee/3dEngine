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

namespace dbarbee.GraphicsEngine.D2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void setupCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setupViewportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setupCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Size szViewport = new Size(100, 100);
        Size szScreen = new Size(-1, -1);
        private Point viewportToScreen(Point p)
        {
            //return p;

            Point value = new Point();
            value.X = (szScreen.Width * p.X) / szViewport.Width;
            value.Y = szScreen.Height - ((szScreen.Height * p.Y) / szViewport.Height);
            //value.Y = (szScreen.Height - (szScreen.Height * p.Y) / szViewport.Height) * -1;

            return value;
        }

        private Point viewportToScreen(flPoint p)
        {
            //return p;

            Point value = new Point();
            value.X = (int) Math.Round((szScreen.Width * p.X) / szViewport.Width);
            value.Y = szScreen.Height - (int) Math.Round((szScreen.Height * p.Y) / szViewport.Height);
            //value.Y = (szScreen.Height - (szScreen.Height * p.Y) / szViewport.Height) * -1;

            return value;
        }
        private Size scaleToScreen(flPoint p)
        {
            //return p;

            Size value = new Size();
            value.Width = (int)Math.Round((szScreen.Width * p.X) / szViewport.Width);
            value.Height = (int)Math.Round((szScreen.Height * p.Y) / szViewport.Height);

            return value;
        }

        private Pen currentPen = Pens.Black;
        private void DrawLine(Graphics g, Point p1, Point p2)
        {
            g.DrawLine(currentPen, viewportToScreen(p1), viewportToScreen(p2));
        }
        private void DrawLine(Graphics g, flPoint p1, flPoint p2)
        {
            g.DrawLine(currentPen, viewportToScreen(p1), viewportToScreen(p2));
        }

        private void DrawPolyLine(Graphics g, Point[] points)
        {
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(g, points[idx], points[idx + 1]);
            }
        }

        private void DrawPolyLine(Graphics g, flPoint[] points)
        {
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(g, points[idx], points[idx + 1]);
            }
        }

        private void DrawLines(Graphics g, Line[] lines)
        {
            for (int idx = 0; idx < lines.Length; idx++)
            {
                DrawLine(g, lines[idx].P1, lines[idx].P2);
            }
        }

        private void DrawPolygon(Graphics g, Point[] points)
        {
            DrawPolyLine(g, points);
            DrawLine(g, points[points.Length - 1], points[0]);
        }

        private void DrawPolygon(Graphics g, flPoint[] points)
        {
            DrawPolyLine(g, points);
            DrawLine(g, points[points.Length - 1], points[0]);
        }

        // Tessellation 
        private const int circularTessellation = 1440;
        private void DrawCircle(Graphics g, Point c, int r)
        {
            DrawCircle(g, new flPoint(c), (double)r);
        }
        private void DrawCircle(Graphics g, flPoint c, double r)
        {
            Point scrCenter = viewportToScreen(c);
            Size scrRadii = scaleToScreen(new flPoint(r, r));
            Rectangle boundingRec = new Rectangle(scrCenter.X - scrRadii.Width, scrCenter.Y - scrRadii.Height,
                2 * scrRadii.Width, 2 * scrRadii.Height);
            g.DrawEllipse(currentPen, boundingRec);

            // flPoint[] circle = new flPoint[circularTessellation];
            // flPoint[] quarterCircle = new flPoint[circularTessellation/4];
            // double deltaAngle = (2 * Math.PI) / circularTessellation;
            // // first half quadrent
            // for (int idx = 0; idx < circularTessellation / 8; idx++)
            // {
            //     double angle = (deltaAngle * idx) + (deltaAngle/2);
            //     double x = Math.Sin(angle) * r;
            //     double y = Math.Cos(angle) * r;
            //     quarterCircle[idx] = new flPoint(x, y);
            //     circle[idx] = quarterCircle[idx].Translate(c);
            // }
            // //DrawPolygon(g, circle);
            // // second half quadrent
            // for (int idx = 0; idx < circularTessellation / 8; idx++)
            // {
            //     quarterCircle[idx + circularTessellation / 8] =
            //         new flPoint(quarterCircle[(circularTessellation / 8) - idx - 1].Y,
            //                     quarterCircle[(circularTessellation / 8) - idx - 1].X);
            //     circle[idx + circularTessellation / 8] = quarterCircle[idx + circularTessellation / 8].Translate(c);
            // }
            // //DrawPolygon(g, circle);
            // // second quadrent
            // for (int idx = 0; idx < circularTessellation / 4; idx++)
            // {
            //     circle[idx + circularTessellation / 4] = quarterCircle[circularTessellation / 4 - idx - 1].Scale(1, -1).Translate(c);
            // }
            // //DrawPolygon(g, circle);
            // // third quadrent
            // for (int idx = 0; idx < circularTessellation / 4; idx++)
            // {
            //     circle[idx + circularTessellation / 2] = quarterCircle[idx].Scale(-1, -1).Translate(c);
            // }
            // //DrawPolygon(g, circle);
            //// fourth quadrent
            // for (int idx = 0; idx < circularTessellation / 4; idx++)
            // {
            //     circle[idx + ((circularTessellation * 3) / 4)] = quarterCircle[circularTessellation / 4 - idx - 1].Scale(-1, 1).Translate(c);
            // }
            // DrawPolygon(g, circle);
        }
        private void DrawArc(Graphics g, Point c, int r, int a)
        {
            DrawArc(g, new flPoint(c), (double)r, (double)a);
        }
        private void DrawArc(Graphics g, flPoint c, double r, double a)
        {
            int tessellation = (int)Math.Ceiling(circularTessellation * Math.Abs(a)/360.0);
            flPoint[] arc = new flPoint[tessellation + 1];
            double deltaAngle = (2 * Math.PI) / circularTessellation;
            if (a < 0)
            {
                deltaAngle *= -1;
            }
            for (int idx = 0; idx <= tessellation; idx++)
            {
                double angle = (deltaAngle * idx);
                double x = Math.Sin(angle) * r + c.X;
                double y = Math.Cos(angle) * r + c.Y;
                arc[idx] = new flPoint(x, y);
            }
            DrawPolyLine(g, arc);
        }
        private void DrawArc(Graphics g, Point c, int r, int a1, int a2)
        {
            DrawArc(g, new flPoint(c), (double)r, (double)a1, (double)a2);
        }
        private void DrawArc(Graphics g, flPoint c, double r, double a1, double a2)
        {
            double a = a2 - a1;
            int tessellation = (int)Math.Ceiling(circularTessellation * Math.Abs(a)/360.0);
            flPoint[] arc = new flPoint[tessellation + 1];
            double deltaAngle = (2 * Math.PI) / circularTessellation;
            if (a<0)
            {
                deltaAngle *= -1;
            }
            a1 = a1 * Math.PI / 180;
            for (int idx = 0; idx <= tessellation; idx++)
            {
                double angle = a1 + (deltaAngle * idx);
                double x = Math.Sin(angle) * r + c.X;
                double y = Math.Cos(angle) * r + c.Y;
                arc[idx] = new flPoint(x, y);
            }
            DrawPolyLine(g, arc);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (szScreen.Width <= 0 || szScreen.Height <= 0)
            {
                szScreen = panel1.Size;
                // force a square aspect ratio for now
                if (szScreen.Height > szScreen.Width)
                {
                    szScreen.Height = szScreen.Width;
                }
                else
                {
                    szScreen.Width = szScreen.Height;
                }
            }
            e.Graphics.FillRectangle(Brushes.White, 0, 0, szScreen.Width,szScreen.Height);

            Point[] points = new Point[] { new Point(25, 25), new Point(25, 75), new Point(75, 75), new Point(75, 25) };
            currentPen = new Pen(Color.Black, 2);

            DrawPolygon(e.Graphics, points);

            DrawCircle(e.Graphics, new Point(50, 50), 25);

            DrawArc(e.Graphics, new flPoint(50, 50), 12.5, -45);

            DrawArc(e.Graphics, new flPoint(50, 50), 37.5, 45, -45);
        }



        private void redrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }

    public struct flPoint
    {
        public double X;
        public double Y;

        public flPoint(double x, double y) { X = x; Y = y; }
        public flPoint(int x, int y) { X = x; Y = y; }
        public flPoint(Point p) { X = p.X; Y = p.Y; }

        public flPoint Translate(flPoint delta)
        {
            return new flPoint(X + delta.X, Y + delta.Y);
        }

        public flPoint Scale(flPoint scale)
        {
            return new flPoint(X * scale.X, Y * scale.Y);
        }

        public flPoint Scale(double sx, double sy)
        {
            return new flPoint(X * sx, Y * sy);
        }
    }

    public struct Line
    {
        public flPoint P1;
        public flPoint P2;

        public Line(flPoint p1, flPoint p2) {P1 = p1; P2 = p2; }
        public Line(Point p1, Point p2) { P1 = new flPoint(p1); P2 = new flPoint(p2); }
        //public flPoint(Point p) { X = p.X; Y = p.Y; }

        public Line Translate(flPoint delta)
        {
            return new Line(P1.Translate(delta), P2.Translate(delta));
        }

        public Line Scale(flPoint scale)
        {
            return new Line(P1.Scale(scale), P2.Scale(scale));
        }

        public Line Scale(double sx, double sy)
        {
            return new Line(P1.Scale(sx, sy), P2.Scale(sx, sy));
        }
    }
}