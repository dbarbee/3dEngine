using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbarbee.GraphicsEngine._2DCanvas;
using dbarbee.GraphicsEngine._2DCanvas.Interfaces;
using dbarbee.GraphicsEngine._3DEngine;

namespace dbarbee.GraphicsEngine._3DView
{
    /// <summary>
    /// A camera maps a view of objects in 3d space onto a 2d Canvas
    /// 
    /// The x axis is left(-) to right(+) on the canvas 
    /// The y axis is out(-) to in(+) of the canvas (depth)
    /// the z axis is down(-) to up(+) on the canvas
    /// 
    /// An unrotated camera sits out from the canvas on the y axis
    /// Rotating the camera around any of the axises will move it
    /// to a new vantage point (for x and z rotations) or tilt the
    /// camera (for y rotations)
    /// </summary>
    public class Camera
    {
        public ICanvas Canvas { get; private set; }

        private Camera() { }

        public Camera(ICanvas canvas)
        {
            Canvas = canvas;
        }
        private double _canvasOffset;
        /// <summary>
        /// How far is the surface of the canvas from the origin
        /// 
        /// Note the canvas must be closer to the origin then the camera
        /// </summary>
        public double CanvasOffset {
            get { return _canvasOffset; }

            set {
                if (value >= Offset)
                {
                    throw new ArgumentOutOfRangeException("value", "Canvas offset must be < camera offset");
                }
                _canvasOffset = value;
            }
        }

        private double _offset;
        /// <summary>
        /// How far is the camera from the origin
        /// 
        /// Note the canvas must be closer to the origin then the camera
        /// </summary>
        public double Offset
        {
            get { return _offset; }

            set
            {
                if (value <= _canvasOffset)
                {
                    throw new ArgumentOutOfRangeException("value", "Canvas offset must be < camera offset");
                }
                _offset = value;
            }
        }/// <summary>
        /// Rotation of the camera around the x axis
        /// 
        /// 
        /// </summary>
        public double XRotation { get; set; }
        public double YRotation { get; set; }
        public double ZRotation { get; set; }

        public void DrawPoint(Point p)
        {
            Tuple<double, double> s = p.Draw(_canvasOffset);
            IflPoint canvasPoint = Canvas.ClassFactory.NewflPoint(s.Item1, s.Item2);

            Canvas.DrawPoint(canvasPoint);
        }

        public void DrawLine(Line l)
        {
            Tuple<double, double> t1 = l.P1.Draw(_canvasOffset);
            IflPoint P1 = Canvas.ClassFactory.NewflPoint(t1.Item1, t1.Item2);

            Tuple<double, double> t2 = l.P2.Draw(_canvasOffset);
            IflPoint P2 = Canvas.ClassFactory.NewflPoint(t2.Item1, t2.Item2);

            Canvas.DrawLine(P1, P2);
        }

        public void DrawSurface(Surface s)
        {
            IflPoint[] points = new IflPoint[s.Vertices.Length];
            
            for (int idx = 0; idx<s.Edges.Length ;idx++)
            {
                Tuple<double, double> p = s.Vertices[idx].Draw(_canvasOffset);
                points[idx] = Canvas.ClassFactory.NewflPoint(p.Item1, p.Item2);
            }
            IPolygon polygon = Canvas.ClassFactory.NewPolygon(points, true);

            Canvas.DrawPolygon(points, true);
        }
    }
}
