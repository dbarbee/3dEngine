using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using dbarbee.GraphicsEngine._2DCanvas.Data;
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
    public class Camera : I3DCamera
    {
        public _2DCanvas.Data.ICanvas Canvas { get; private set; }
        public Scene Scene { get; private set; }

        private Camera()
        {
            _canvasOffset = 50;
            _offset = 25;
            DrawVertices = true;
            DrawEdges = true;
            FillSurfaces = true;
        }

        public Camera(_2DCanvas.Data.ICanvas canvas, Scene scene)
            : this()
        {
            Canvas = canvas;
            Scene = scene;
        }
        private double _canvasOffset;
        /// <summary>
        /// How far is the surface of the canvas from the origin
        /// 
        /// Note the canvas must be closer to the origin then the camera
        /// </summary>
        public double CanvasOffset
        {
            get { return _canvasOffset; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Canvas offset must be a positive number");
                }
                _canvasOffset = value;
            }
        }

        public bool DrawVertices { get; set; }
        public bool DrawEdges { get; set; }
        public bool FillSurfaces { get; set; }

        private double _offset;
        /// <summary>
        /// How far out the camera from the canvas
        /// 
        /// Note the canvas must be closer to the origin then the camera
        /// </summary>
        public double Offset
        {
            get { return _offset; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Camera offset must be a positive number");
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

        bool _usePerspective = true;
        public bool UsePerspective
        {
            get { return _usePerspective; }
            set { _usePerspective = value; }
        }
        /// <summary>
        /// Map a 3D point to the canvas using perspective
        /// </summary>
        /// <remarks>
        /// Map from 3D space to a point on the screen uidng perspective. Distance from the 
        /// from the camera is  calculated as the camera's offset + the y coordinate of the 
        /// point.
        /// </remarks>
        /// <param name="p">Teh 3D point</param>
        /// <returns>The point on the 'screen' that maps to the point in 3D</returns>
        public _2DCanvas.Data.Point MapPointToCanvas(Point p)
        {
            double scalefactor = _usePerspective ? _canvasOffset / (_canvasOffset + _offset + p.y) : 1.0;
            double Sx = p.x * scalefactor;
            double Sz = p.z * scalefactor;

            return new _2DCanvas.Data.Point(Sx, Sz, p.Color);
        }

        public void DrawPoint(Point p)
        {
            _2DCanvas.Data.Point canvasPoint = MapPointToCanvas(p);

            Canvas.AddObject(canvasPoint);
        }

        public void DrawLine(Line l)
        {
            _2DCanvas.Data.Point P1 = MapPointToCanvas(l.P1); ;
            _2DCanvas.Data.Point P2 = MapPointToCanvas(l.P2); ;

            Canvas.AddObject(new _2DCanvas.Data.Line(P1, P2, l.Color));
        }

        public void DrawSurface(Surface s)
        {
            _2DCanvas.Data.Point[] vertices = new _2DCanvas.Data.Point[s.Vertices.Length];
            _2DCanvas.Data.Line[] edges = new _2DCanvas.Data.Line[s.Edges.Length];

            for (int idx = 0; idx < s.Vertices.Length; idx++)
            {
                vertices[idx] = MapPointToCanvas(s.Vertices[idx]);
                if (DrawVertices)
                {
                    Canvas.AddObject(vertices[idx]);
                }
            }
            if (DrawEdges || FillSurfaces)
            {
                UInt32? edgeColor = DrawEdges ? (UInt32?)s.EdgeColor : null;
                UInt32? fillColor = FillSurfaces ? (UInt32?)s.FillColor : null;
                _2DCanvas.Data.Polygon polygon = new _2DCanvas.Data.Polygon(vertices, edgeColor, fillColor);
                Canvas.AddObject(polygon);
            }
        }


        private void DrawGrid()
        {
            Line lx = new Line(new Point(-100, 0, 0), new Point(100, 0, 0), 0x7FFF0000);//0x7F7F7F7F);
            Line ly = new Line(new Point(0, -100, 0), new Point(0, 100, 0), 0x7F00FF00);//0x7F7F7F7F);
            Line lz = new Line(new Point(0, 0, -100), new Point(0, 0, 100), 0x7F0000FF);//0x7F7F7F7F);

            Scene.DrawList.AddRange(new Line[] { lx, ly, lz });
        }

        public void Render()
        {
            Canvas.ClearObjects();

            DrawGrid();

            foreach (I3DObject o in Scene.DrawList)
            {

                I3DObject or = o;
                if (YRotation != 0)
                    or = or.RotateXZ(YRotation);
                if (XRotation != 0)
                    or = or.RotateXY(XRotation);
                if (ZRotation != 0)
                    or = or.RotateYZ(ZRotation);

                or.Render(this);
            }
        }
    }
}
