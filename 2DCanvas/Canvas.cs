using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public partial class Canvas : Panel, ICanvas
    {
        public Canvas()
        {
            InitializeComponent();

            //this.Paint += new PaintEventHandler(Canvas_Paint);

            szViewport = new flPoint(110, 110);
            szScreen = new flPoint(-1, -1);
            ptViewport = new flPoint(55, 55);

            CurrentPen = Pens.Black;
            CurrentBrush = Brushes.LightGray;
        }

        private Graphics _graphics = null;

        public static implicit operator Graphics(Canvas c)
        {
            return c._graphics;
        }

        public IClassFactory ClassFactory
        {
            get { return _2DCanvas.ClassFactory.Instance; }
        }

        public Dictionary<string, IDrawingObject> ObjectList = new Dictionary<string, IDrawingObject>();

        public IflPoint szViewport { get; set; }
        public IflPoint ptViewport { get; set; }
        private IflPoint szScreen { get; set; }

        private Point viewportToScreen(Point p)
        {
            Point value = new Point();
            value.X = (int)Math.Round((szScreen.X * (p.X + ptViewport.X)) / szViewport.X);
            value.Y = (int)Math.Round(szScreen.Y - (szScreen.Y * (p.Y + ptViewport.Y)) / szViewport.Y);

            return value;
        }

        private Point viewportToScreen(IflPoint p)
        {
            Point value = new Point();
            value.X = (int)Math.Round((szScreen.X * (p.X + ptViewport.X)) / szViewport.X);
            value.Y = (int)Math.Round(szScreen.Y - (szScreen.Y * (p.Y + ptViewport.Y)) / szViewport.Y);

            return value;
        }

        private Point[] viewportToScreen(Point[] p)
        {
            Point[] value = new Point[p.Length];
            for (int idx = 0; idx < p.Length; idx++)
            {
                value[idx] = viewportToScreen(p[idx]);
            }
            return value;
        }

        private Point[] viewportToScreen(IflPoint[] p)
        {
            Point[] value = new Point[p.Length];
            for (int idx = 0; idx < p.Length; idx++)
            {
                value[idx] = viewportToScreen(p[idx]);
            }
            return value;
        }

        private flPoint scaleToScreen(Size s)
        {
            //return p;

            flPoint value = new flPoint();
            value.X = (szScreen.X * s.Width) / szViewport.X;
            value.Y = ((szScreen.Y * s.Height) / szViewport.Y);

            return value;
        }

        private flPoint scaleToScreen(Point p)
        {
            //return p;

            flPoint value = new flPoint();
            value.X = (szScreen.X * p.X) / szViewport.X;
            value.Y = ((szScreen.Y * p.Y) / szViewport.Y);

            return value;
        }

        private flPoint scaleToScreen(flPoint p)
        {
            //return p;

            flPoint value = new flPoint();
            value.X = (int)Math.Round((szScreen.X * p.X) / szViewport.X);
            value.Y = (int)Math.Round((szScreen.Y * p.Y) / szViewport.Y);

            return value;
        }

        public void DrawPoint(IflPoint p)
        {
            Graphics g = this;
            Point scrCenter = viewportToScreen(p);
            flPoint scrRadii = scaleToScreen(new flPoint(.5, .5));
            System.Drawing.Rectangle boundingRec = new System.Drawing.Rectangle(
                (int)Math.Round(scrCenter.X - scrRadii.X), (int)Math.Round(scrCenter.Y - scrRadii.Y),
                (int)Math.Round(2 * scrRadii.X), (int)Math.Round(2 * scrRadii.Y));
            //g.DrawEllipse(CurrentPen as Pen, boundingRec);
            g.FillEllipse(CurrentBrush as Brush, boundingRec);
        }

        // Lines
        // Draw an individual point on the screen as a small filled circle 
        //  with diameter of 1 logical unit
        public void DrawLine(Point p1, Point p2)
        {
            Graphics g = this;
            g.DrawLine(CurrentPen as Pen, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(IflPoint p1, IflPoint p2)
        {
            Graphics g = this;
            g.DrawLine(CurrentPen as Pen, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(ILine l)
        {
            DrawLine(l.P1, l.P2);
        }
        public void DrawPolyLine(Point[] points)
        {
            Graphics g = this;
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(points[idx], points[idx + 1]);
            }
        }

        public void DrawPolyLine(IflPoint[] points)
        {
            Graphics g = this;
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(points[idx], points[idx + 1]);
            }
        }

        public void DrawLines(ILine[] lines)
        {
            Graphics g = this;
            for (int idx = 0; idx < lines.Length; idx++)
            {
                DrawLine(lines[idx]);
            }
        }

        public void DrawPolygon(Point[] points, bool fill = false)
        {
            Graphics g = this;
            Point[] screenPoints = viewportToScreen(points);
            g.DrawPolygon(CurrentPen as Pen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush as Brush, screenPoints);
            }
        }

        public void DrawPolygon(IflPoint[] points, bool fill = false)
        {
            Graphics g = this;
            Point[] screenPoints = viewportToScreen(points);
            g.DrawPolygon(CurrentPen as Pen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush as Brush, screenPoints);
            }
        }

        public void DrawPolygon(IPolygon polygon, bool fill = false)
        {
            Graphics g = this;
            Point[] screenPoints = viewportToScreen(polygon.Points);
            g.DrawPolygon(CurrentPen as Pen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush as Brush, screenPoints);
            }
        }

        public void DrawCircle(IflPoint c, double r, bool fill = false)
        {
            Graphics g = this;
            Point scrCenter = viewportToScreen(c);
            flPoint scrRadii = scaleToScreen(new flPoint(r, r));
            System.Drawing.Rectangle boundingRec = new System.Drawing.Rectangle(
                (int)Math.Round(scrCenter.X - scrRadii.X), (int)Math.Round(scrCenter.Y - scrRadii.Y),
                (int)Math.Round(2 * scrRadii.X), (int)Math.Round(2 * scrRadii.Y));
            g.DrawEllipse(CurrentPen as Pen, boundingRec);
            if (fill)
            {
                g.FillEllipse(CurrentBrush as Brush, boundingRec);
            }

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
            // // second quadrant
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

        public object CurrentPen { get; set; }
        public object CurrentBrush { get; set; }

        private void DrawGrid(Graphics g)
        {
            g.DrawRectangle(CurrentPen as Pen, new System.Drawing.Rectangle(0, 0, (int)szScreen.X, (int)szScreen.Y));

            Pen p1 = new Pen(Color.White, 1);
            Pen p2 = new Pen(Color.White, 2);

            double gridSpacing = 10;

            double x = -(ptViewport.X);
            if (x % 10 != 0)
            {
                x -= (ptViewport.X % 10);
            }
            for (; x <= szViewport.X - ptViewport.X; x += gridSpacing)
            {
                g.DrawLine(x != 0 ? p1 : p2,
                           viewportToScreen(new flPoint(x, -ptViewport.Y)),
                           viewportToScreen(new flPoint(x, szScreen.Y)));
            }
            for (x = -(ptViewport.X); x <= szViewport.X - ptViewport.X; x += 1)
            {
                double hashSize = 1;
                if (x % 5 == 0)
                    hashSize = 2;
                g.DrawLine(x != 0 ? p1 : p2,
                           viewportToScreen(new flPoint(x, -hashSize)),
                           viewportToScreen(new flPoint(x, hashSize)));
            }

            double y = -(ptViewport.Y);
            if (y % 10 != 0)
            {
                y -= (ptViewport.Y % 10);
            }
            for (; y <= szViewport.Y - ptViewport.Y; y += gridSpacing)
            {
                g.DrawLine(y != 0 ? p1 : p2,
                           viewportToScreen(new flPoint(-ptViewport.X, y)),
                           viewportToScreen(new flPoint(szScreen.X, y)));
            }
            for (y = -(ptViewport.Y); y <= szViewport.Y - ptViewport.Y; y += 1)
            {
                double hashSize = 1;
                if (y % 5 == 0)
                    hashSize = 2;
                g.DrawLine(y != 0 ? p1 : p2,
                           viewportToScreen(new flPoint(-hashSize, y)),
                           viewportToScreen(new flPoint(hashSize, y)));
            }
        }

        public void Canvas_Paint(Object sender, PaintEventArgs e)
        {
            try
            {
                _graphics = e.Graphics;

                if (szScreen.X <= 0 || szScreen.Y <= 0)
                {
                    Size sz = this.Size;
                    // force a square aspect ratio for now
                    if (sz.Height > sz.Width)
                    {
                        sz.Height = sz.Width;
                    }
                    else
                    {
                        sz.Width = sz.Height;
                    }
                    szScreen = new flPoint(sz);
                }

                DrawGrid(e.Graphics);

                foreach (IDrawingObject o in ObjectList.Values)
                {
                    o.Draw(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OOPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //               _graphics = null;
            }
        }

        private void Canvas_SizeChanged(object sender, EventArgs e)
        {
            Size sz = this.Size;
            // force a square aspect ratio for now
            if (sz.Height > sz.Width)
            {
                sz.Height = sz.Width;
            }
            else
            {
                sz.Width = sz.Height;
            }
            szScreen = new flPoint(sz);

            Invalidate();
        }
    }
}
