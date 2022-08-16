//#define VISUALIZE_INTERSECT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using dbarbee.GraphicsEngine._3DEngine;
using dbarbee.GraphicsEngine._3DView;

namespace dbarbee.GraphicsEngine.QuickDraw3D
{
    public partial class FormMain : Form
    {
        Scene scene;
        Camera camera1;

        public FormMain()
        {
            InitializeComponent();

            scene = new Scene();
            camera1 = new Camera(canvas1, scene);

#if !VISUALIZE_INTERSECT

            scene.DrawList.Add(new Surface(new Point[] { new Point(30, 30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F7F0000));
            scene.DrawList.Add(new Surface(new Point[] { new Point(-0, -30, 0), new Point(30, 30, 0), new Point(-30, 30, 0) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F7F7F7F));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F007F00));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F00007F));

            scene.DrawList.Add(new Surface(new Point[] { new Point(30, 30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFFFF0000));
            scene.DrawList.Add(new Surface(new Point[] { new Point(-0, -30, 0), new Point(30, 30, 0), new Point(-30, 30, 0) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF7F7F7F));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF00FF00));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF0000FF));

            scene.DrawList.Add(new Pyramid(new Point(35, 10, 0), 20, 20, 20));

#else
            // Line Intersection Visualization
            Line l1 = new Line(new Point(-10, -10, 0), new Point(20, 20, 0), 0xFFFF0000);
            Line l2 = new Line(new Point(30, -30, 0), new Point(-15, 15, 0), 0xFF00FF00);
            scene.DrawList.Add(l1);
            scene.DrawList.Add(l2);

            Point Pi = l1.Intersect(l2);
            Pi.Color = 0xFF0000FF;
            scene.DrawList.Add(Pi);

            Vector crossVectors = l1.Direction.Cross(l2.Direction);
            Line crossVectorsLine = new Line(l1.P1, crossVectors, 0xFF0000FF);
            scene.DrawList.Add(crossVectorsLine);

            Line l3 = new Line(l1.P1, l2.P1, 0xFFFF0000);
            Line l4 = new Line(l2.P1, l1.P1, 0xFFFF0000);
            scene.DrawList.Add(l3);

            Vector crossT = (l1.P1 - l2.P1).Cross(l2.Direction);
            Vector crossU = (l2.P1 - l1.P1).Cross(l1.Direction);

            Line l5 = new Line(l2.P1, crossT, 0xFFFF0000);
            scene.DrawList.Add(l5);
#endif
            camera1.FillSurfaces = true;
            camera1.XRotation = 0;
            camera1.ZRotation = 0;

            camera1.Render();

            //int objIdx = 0;
            //canvas1.ObjectList.Add((++objIdx).ToString(), new _2DEngine.Rectangle(new flPoint(0, 0), new flPoint(50, 50), true));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new Circle(new flPoint(0, 0), 20, true));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new IsoscelesTriangle(new flPoint(0, 0), new flPoint(40, 40), false));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new EquilateralTriangle(new flPoint(0, 0), 30, false));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new flPoint(0, 0), new flPoint(40, 20), false));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new flPoint(0, 0), new flPoint(40, 20), false,90));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new flPoint(0, 0), new flPoint(20, 40), false));
            //canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new flPoint(0, 0), new flPoint(20, 40), false,90));
            //for (int angle = 0; angle < 360; angle += 3)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new RegularPolygon(new flPoint(0, 0), 6, Math.Abs(Math.Sin(angle*Math.PI/180))*25, false, angle));
            //}
            //for (int angle = 0; angle < 360; angle += 30)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new Triangle(new flPoint(50, 50), new flPoint(20, 20), false, angle));
            //}
            //for (int angle = 0; angle < 360; angle += 2)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Rectangle(new flPoint(50, 50), new flPoint(75, 75), false, angle));
            //}
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

        private void redrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas1.Invalidate();
        }

        private bool UpdateOff = false;

        private void CameraHorizontal_ValueChanged(object sender, EventArgs e)
        {
            camera1.XRotation = CameraHorizontal.Value;
            if (!UpdateOff)
            {
                camera1.Render();
                canvas1.Invalidate();
            }
            SetRotationText();
        }

        private void CameraVertical_ValueChanged_1(object sender, EventArgs e)
        {
            camera1.ZRotation = CameraVertical.Value;
            if (!UpdateOff)
            {
                camera1.Render();
                canvas1.Invalidate();
            }
            SetRotationText();
        }
        private void SetRotationText()
        {
            tsRotation.Text = string.Format("Tilt:{0}, Pand {1}", CameraVertical.Value, CameraHorizontal.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateOff = true;
                CameraHorizontal.Value = 0;
                CameraVertical.Value = 0;
            }
            finally
            {
                UpdateOff = false;
                camera1.Render();
                canvas1.Invalidate();
            }
        }

        private void CameraDistanceSb_ValueChanged(object sender, EventArgs e)
        {
            camera1.Offset = camera1.CanvasOffset + Math.Pow(10, CameraDistanceSb.Value / 100.0);
            camera1.Render();
            canvas1.Invalidate();
        }

        private void ViewScreenDistanceSb_ValueChanged(object sender, EventArgs e)
        {
            double canvasOffset = Math.Pow(10, ViewScreenDistanceSb.Value / 100.0);
            double cameraOffset = Math.Pow(10, CameraDistanceSb.Value / 100.0);
            camera1.Offset = canvasOffset + cameraOffset;
            camera1.CanvasOffset = canvasOffset;
            camera1.Render();
            canvas1.Invalidate();
        }

        private void usePerspectiveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            camera1.UsePerspective = usePerspectiveToolStripMenuItem.Checked;
            camera1.Render();
            canvas1.Invalidate();
        }

        private void fillSurfacesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            camera1.FillSurfaces = fileToolStripMenuItem.Checked;
            camera1.Render();
            canvas1.Invalidate();
        }

        private void drawEdgesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            camera1.DrawEdges = drawEdgesToolStripMenuItem.Checked;
            camera1.Render();
            canvas1.Invalidate();
        }

        private void drawVerticesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            camera1.DrawVertices = drawVerticesToolStripMenuItem.Checked;
            camera1.Render();
            canvas1.Invalidate();
        }
    }
}