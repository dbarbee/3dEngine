using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbarbee.GraphicsEngine._2DCanvas.Data;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{
    public partial class Canvas : Panel, ICanvas
    {
        public Canvas()
        {
            InitializeComponent();

            //this.Paint += new PaintEventHandler(Canvas_Paint);

            szViewport = new Point(110, 110);
            szScreen = new Point(-1, -1);
            ptViewport = new Point(55, 55);

            CurrentPen = System.Drawing.Pens.Black;

            System.Drawing.Color c = System.Drawing.Color.FromArgb(127, System.Drawing.Color.LightGray);
            CurrentBrush = new System.Drawing.SolidBrush(c);// System.Drawing.Brushes.LightGray;
        }

        private System.Drawing.Graphics _graphics = null;

        public static implicit operator System.Drawing.Graphics(Canvas c)
        {
            return c._graphics;
        }

        public Dictionary<string, IDrawingObject> ObjectList = new Dictionary<string, IDrawingObject>();

        public void ClearObjects()
        {
            ObjectList.Clear();
        }

        private int _nextId=0;
        public void AddObject(IDrawingObject o)
        {
            ObjectList.Add(_nextId++.ToString("D10"), o);
        }
        public void AddObject(string key, IDrawingObject o)
        {
            ObjectList.Add(key, o);
        }

        public Point szViewport { get; set; }
        public Point ptViewport { get; set; }
        private Point szScreen { get; set; }

        private System.Drawing.Point viewportToScreen(System.Drawing.Point p)
        {
            System.Drawing.Point value = new System.Drawing.Point();
            value.X = (int)Math.Round((szScreen.X * (p.X + ptViewport.X)) / szViewport.X);
            value.Y = (int)Math.Round(szScreen.Y - (szScreen.Y * (p.Y + ptViewport.Y)) / szViewport.Y);

            return value;
        }

        private System.Drawing.Point viewportToScreen(Point p)
        {
            System.Drawing.Point value = new System.Drawing.Point();
            value.X = (int)Math.Round((szScreen.X * (p.X + ptViewport.X)) / szViewport.X);
            value.Y = (int)Math.Round(szScreen.Y - (szScreen.Y * (p.Y + ptViewport.Y)) / szViewport.Y);

            return value;
        }

        private System.Drawing.Point[] viewportToScreen(System.Drawing.Point[] p)
        {
            System.Drawing.Point[] value = new System.Drawing.Point[p.Length];
            for (int idx = 0; idx < p.Length; idx++)
            {
                value[idx] = viewportToScreen(p[idx]);
            }
            return value;
        }

        private System.Drawing.Point[] viewportToScreen(Point[] p)
        {
            System.Drawing.Point[] value = new System.Drawing.Point[p.Length];
            for (int idx = 0; idx < p.Length; idx++)
            {
                value[idx] = viewportToScreen(p[idx]);
            }
            return value;
        }

        private Point scaleToScreen(System.Drawing.Size s)
        {
            return new Point((szScreen.X * s.Width) / szViewport.X, (szScreen.Y * s.Height) / szViewport.Y);
        }

        private Point scaleToScreen(System.Drawing.Point p)
        {
            return new Point((szScreen.X * p.X) / szViewport.X, (szScreen.Y * p.Y) / szViewport.Y);
        }

        private Point scaleToScreen(Point p)
        {
            return new Point((szScreen.X * p.X) / szViewport.X, (szScreen.Y * p.Y) / szViewport.Y);

            //Point value = new Point();
            //value.X = (int)Math.Round((szScreen.X * p.X) / szViewport.X);
            //value.Y = (int)Math.Round((szScreen.Y * p.Y) / szViewport.Y);

            //return value;
        }

        private System.Drawing.Color ToSysColor(UInt32 c)
        {
            return System.Drawing.Color.FromArgb((Int32)c);
        }
        private System.Drawing.Color ToSysColor(UInt32? c)
        {
            return System.Drawing.Color.FromArgb((Int32)c.Value);
        }
        // Draw an individual point on the screen as a small filled circle 
        //  with diameter of 1 logical unit
        public void DrawPoint(Point p)
        {
            System.Drawing.Graphics g = this;
            System.Drawing.Point scrCenter = viewportToScreen(p);
            Point scrRadii = scaleToScreen(new Point(.5, .5));
            System.Drawing.Rectangle boundingRec = new System.Drawing.Rectangle(
                (int)Math.Round(scrCenter.X - scrRadii.X), (int)Math.Round(scrCenter.Y - scrRadii.Y),
                (int)Math.Round(2 * scrRadii.X), (int)Math.Round(2 * scrRadii.Y));
            //g.DrawEllipse(CurrentPen as System.Drawing.Pen, boundingRec);
            System.Drawing.Brush b = CurrentBrush as System.Drawing.Brush;
            if (p.Color!= null)
            {
                b = new System.Drawing.SolidBrush(ToSysColor(p.Color));
            }
            g.FillEllipse(b, boundingRec);
        }

        // Lines
        public void DrawLine(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            System.Drawing.Graphics g = this;
            g.DrawLine(CurrentPen as System.Drawing.Pen, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(Point p1, Point p2, UInt32? c = null)
        {
            System.Drawing.Graphics g = this;
            System.Drawing.Pen p = CurrentPen as System.Drawing.Pen;
            if (c != null)
            {
                p = new System.Drawing.Pen(ToSysColor(c));
            }
            else if (p1.Color != null)
            {
                p = new System.Drawing.Pen(ToSysColor(p1.Color));
            }
            g.DrawLine(p, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(Line l)
        {
            DrawLine(l.P1, l.P2, l.Color);
        }
        public void DrawPolyLine(System.Drawing.Point[] points)
        {
            System.Drawing.Graphics g = this;
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(points[idx], points[idx + 1]);
            }
        }

        public void DrawPolyLine(Point[] points, UInt32? c = null)
        {
            System.Drawing.Graphics g = this;
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(points[idx], points[idx + 1],c);
            }
        }

        public void DrawLines(Line[] lines)
        {
            System.Drawing.Graphics g = this;
            for (int idx = 0; idx < lines.Length; idx++)
            {
                DrawLine(lines[idx]);
            }
        }

        public void DrawPolygon( System.Drawing.Point[] points, bool fill = false)
        {
            System.Drawing.Graphics g = this;
            System.Drawing.Point[] screenPoints = viewportToScreen(points);
            g.DrawPolygon(CurrentPen as System.Drawing.Pen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush as System.Drawing.Brush, screenPoints);
            }
        }

        public void DrawPolygon(Point[] points, UInt32? edgeColor = null, UInt32? fillColor = null)
        {
            System.Drawing.Graphics g = this;
            System.Drawing.Point[] screenPoints = viewportToScreen(points);
            System.Drawing.Pen p = CurrentPen as System.Drawing.Pen;
            if (edgeColor != null)
            {
                p = new System.Drawing.Pen(ToSysColor(edgeColor));
            }
            g.DrawPolygon(p, screenPoints);
            if (fillColor != null)
            {
                System.Drawing.Brush b = new System.Drawing.SolidBrush(ToSysColor(fillColor));
                g.FillPolygon(b, screenPoints);
            }
        }

        public void DrawPolygon(Polygon polygon)
        {
            DrawPolygon(polygon.Points, polygon.EdgeColor, polygon.FillColor);
        }

        public void DrawCircle(Point c, double r, UInt32? edgeColor = null, UInt32? fillColor = null)
        {
            System.Drawing.Graphics g = this;
            System.Drawing.Point scrCenter = viewportToScreen(c);
            Point scrRadii = scaleToScreen(new Point(r, r));
            System.Drawing.Rectangle boundingRec = new System.Drawing.Rectangle(
                (int)Math.Round(scrCenter.X - scrRadii.X), (int)Math.Round(scrCenter.Y - scrRadii.Y),
                (int)Math.Round(2 * scrRadii.X), (int)Math.Round(2 * scrRadii.Y));
            System.Drawing.Pen p = CurrentPen as System.Drawing.Pen;
            if (edgeColor != null)
            {
                p = new System.Drawing.Pen(ToSysColor(edgeColor));
            }
            g.DrawEllipse(p, boundingRec);
            if (fillColor != null)
            {
                System.Drawing.Brush b = new System.Drawing.SolidBrush(ToSysColor(fillColor));
                g.FillEllipse(b, boundingRec);
            }

            // Point[] circle = new Point[circularTessellation];
            // Point[] quarterCircle = new Point[circularTessellation/4];
            // double deltaAngle = (2 * Math.PI) / circularTessellation;
            // // first half quadrent
            // for (int idx = 0; idx < circularTessellation / 8; idx++)
            // {
            //     double angle = (deltaAngle * idx) + (deltaAngle/2);
            //     double x = Math.Sin(angle) * r;
            //     double y = Math.Cos(angle) * r;
            //     quarterCircle[idx] = new Point(x, y);
            //     circle[idx] = quarterCircle[idx].Translate(c);
            // }
            // //DrawPolygon(g, circle);
            // // second half quadrent
            // for (int idx = 0; idx < circularTessellation / 8; idx++)
            // {
            //     quarterCircle[idx + circularTessellation / 8] =
            //         new Point(quarterCircle[(circularTessellation / 8) - idx - 1].Y,
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
        public void DrawCircle(Circle c)
        {
            DrawCircle(c.Center, c.Radius, c.EdgeColor, c.FillColor);
        }
        public object CurrentPen { get; set; }
        public object CurrentBrush { get; set; }

        public bool IncludeGrid { get; set; }

        private void DrawGrid(System.Drawing.Graphics g)
        {
            g.DrawRectangle(CurrentPen as System.Drawing.Pen, new System.Drawing.Rectangle(0, 0, (int)szScreen.X, (int)szScreen.Y));

            System.Drawing.Pen p1 = new System.Drawing.Pen(System.Drawing.Color.White, 1);
            System.Drawing.Pen p2 = new System.Drawing.Pen(System.Drawing.Color.White, 2);

            double gridSpacing = 10;

            double x = -(ptViewport.X);
            if (x % 10 != 0)
            {
                x -= (ptViewport.X % 10);
            }
            for (; x <= szViewport.X - ptViewport.X; x += gridSpacing)
            {
                g.DrawLine(x != 0 ? p1 : p2,
                           viewportToScreen(new Point(x, -ptViewport.Y)),
                           viewportToScreen(new Point(x, szScreen.Y)));
            }
            for (x = -(ptViewport.X); x <= szViewport.X - ptViewport.X; x += 1)
            {
                double hashSize = 1;
                if (x % 5 == 0)
                    hashSize = 2;
                g.DrawLine(x != 0 ? p1 : p2,
                           viewportToScreen(new Point(x, -hashSize)),
                           viewportToScreen(new Point(x, hashSize)));
            }

            double y = -(ptViewport.Y);
            if (y % 10 != 0)
            {
                y -= (ptViewport.Y % 10);
            }
            for (; y <= szViewport.Y - ptViewport.Y; y += gridSpacing)
            {
                g.DrawLine(y != 0 ? p1 : p2,
                           viewportToScreen(new Point(-ptViewport.X, y)),
                           viewportToScreen(new Point(szScreen.X, y)));
            }
            for (y = -(ptViewport.Y); y <= szViewport.Y - ptViewport.Y; y += 1)
            {
                double hashSize = 1;
                if (y % 5 == 0)
                    hashSize = 2;
                g.DrawLine(y != 0 ? p1 : p2,
                           viewportToScreen(new Point(-hashSize, y)),
                           viewportToScreen(new Point(hashSize, y)));
            }
        }

        public void Canvas_Paint(Object sender, PaintEventArgs e)
        {
            try
            {
                _graphics = e.Graphics;

                if (szScreen.X <= 0 || szScreen.Y <= 0)
                {
                    System.Drawing.Size sz = this.Size;
                    // force a square aspect ratio for now
                    if (sz.Height > sz.Width)
                    {
                        sz.Height = sz.Width;
                    }
                    else
                    {
                        sz.Width = sz.Height;
                    }
                    szScreen = new Point(sz.Width,sz.Height);
                }

                if (IncludeGrid)
                {
                    DrawGrid(e.Graphics);
                }

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
            System.Drawing.Size sz = this.Size;
            // force a square aspect ratio for now
            if (sz.Height > sz.Width)
            {
                sz.Height = sz.Width;
            }
            else
            {
                sz.Width = sz.Height;
            }
            szScreen = new Point(sz.Width, sz.Height);

            Invalidate();
        }
    }
}
