using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbarbee.GraphicsEngine._2DCanvas
{
    public partial class Canvas : Panel, ICanvas
    {
        public Canvas()
        {
            InitializeComponent();

            //this.Paint += new PaintEventHandler(Canvas_Paint);

            szViewport = new Size(100, 100);
            szScreen = new Size(-1, -1);
            ptViewport = new Point(50, 50);

            CurrentPen = Pens.Black;
            CurrentBrush = Brushes.LightGray;
        }

        private Graphics _graphics = null;

        public static implicit operator Graphics(Canvas c)
        {
            return c._graphics;
        }

        public Dictionary<string, IDrawingObject> ObjectList = new Dictionary<string, IDrawingObject>();

        public Size szViewport { get; set; }
        public Point ptViewport { get; set; }
        private Size szScreen { get; set; }

        private Point viewportToScreen(Point p)
        {
            Point value = new Point();
            value.X = (szScreen.Width * (p.X + ptViewport.X)) / szViewport.Width;
            value.Y = szScreen.Height - ((szScreen.Height * (p.Y + ptViewport.Y)) / szViewport.Height);

            return value;
        }

        private Point viewportToScreen(flPoint p)
        {
            Point value = new Point();
            value.X = (int)Math.Round((szScreen.Width * (p.X + ptViewport.X)) / szViewport.Width);
            value.Y = szScreen.Height - (int)Math.Round((szScreen.Height * (p.Y + ptViewport.Y)) / szViewport.Height);

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

        private Point[] viewportToScreen(flPoint[] p)
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
            value.X = (szScreen.Width * s.Width) / szViewport.Width;
            value.Y = ((szScreen.Height * s.Height) / szViewport.Height);

            return value;
        }

        private flPoint scaleToScreen(Point p)
        {
            //return p;

            flPoint value = new flPoint();
            value.X = (szScreen.Width * p.X) / szViewport.Width;
            value.Y = ((szScreen.Height * p.Y) / szViewport.Height);

            return value;
        }

        private flPoint scaleToScreen(flPoint p)
        {
            //return p;

            flPoint value = new flPoint();
            value.X = (int)Math.Round((szScreen.Width * p.X) / szViewport.Width);
            value.Y = (int)Math.Round((szScreen.Height * p.Y) / szViewport.Height);

            return value;
        }

        public void DrawLine(Point p1, Point p2)
        {
            Graphics g = this;
            g.DrawLine(CurrentPen, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(flPoint p1, flPoint p2)
        {
            Graphics g = this;
            g.DrawLine(CurrentPen, viewportToScreen(p1), viewportToScreen(p2));
        }
        public void DrawLine(Line l)
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

        public void DrawPolyLine(flPoint[] points)
        {
            Graphics g = this;
            for (int idx = 0; idx < points.Length - 1; idx++)
            {
                DrawLine(points[idx], points[idx + 1]);
            }
        }

        public void DrawLines(Line[] lines)
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
            g.DrawPolygon(CurrentPen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush, screenPoints);
            }
        }

        public void DrawPolygon(flPoint[] points, bool fill = false)
        {
            Graphics g = this;
            Point[] screenPoints = viewportToScreen(points);
            g.DrawPolygon(CurrentPen, screenPoints);
            if (fill)
            {
                g.FillPolygon(CurrentBrush, screenPoints);
            }
        }

        public void DrawCircle(flPoint c, double r, bool fill = false)
        {
            Graphics g = this;
            Point scrCenter = viewportToScreen(c);
            flPoint scrRadii = scaleToScreen(new flPoint(r, r));
            System.Drawing.Rectangle boundingRec = new System.Drawing.Rectangle(
                (int)Math.Round(scrCenter.X - scrRadii.X), (int)Math.Round(scrCenter.Y - scrRadii.Y),
                (int)Math.Round(2 * scrRadii.X), (int)Math.Round(2 * scrRadii.Y));
            g.DrawEllipse(CurrentPen, boundingRec);
            if (fill)
            {
                g.FillEllipse(CurrentBrush, boundingRec);
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

        public Pen CurrentPen { get; set; }
        public Brush CurrentBrush { get; set; }

        private void DrawGrid(Graphics g)
        {
            g.DrawRectangle(CurrentPen, new System.Drawing.Rectangle(0, 0, szScreen.Width, szScreen.Height));

            Pen p2 = new Pen(Color.Gray, 2);

            flPoint gridSpacing = scaleToScreen(new Point(10, 10));
            for (double x = 0; x < szScreen.Width; x += gridSpacing.X)
            {
                g.DrawLine(Pens.Gray, (int)Math.Round(x), 0, (int)Math.Round(x), szScreen.Height);
            }
            for (double y = 0; y < szScreen.Height; y += gridSpacing.Y)
            {
                g.DrawLine(Pens.Gray, 0, (int)Math.Round(y), szScreen.Width, (int)Math.Round(y));
            }
        }
        public void Canvas_Paint(Object sender, PaintEventArgs e)
        {
            try
            {
                _graphics = e.Graphics;

                if (szScreen.Width <= 0 || szScreen.Height <= 0)
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
                    szScreen = sz;
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
    }
}
