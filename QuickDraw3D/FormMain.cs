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

            scene.DrawList.Add(new Surface(new Point[] { new Point(30, 30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F7F0000));
            scene.DrawList.Add(new Surface(new Point[] { new Point(-0, -30, 0), new Point(30, 30, 0), new Point(-30, 30, 0) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F7F7F7F));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F007F00));
            scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0x3F00007F));

            //scene.DrawList.Add(new Surface(new Point[] { new Point(30, 30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFFFF0000));
            //scene.DrawList.Add(new Surface(new Point[] { new Point(-0, -30, 0), new Point(30, 30, 0), new Point(-30, 30, 0) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF7F7F7F));
            //scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(-30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF00FF00));
            //scene.DrawList.Add(new Surface(new Point[] { new Point(0, -30, 0), new Point(30, 30, 0), new Point(0, 0, 60) }, true, 0xFFFFFFFF, 0x3FBEBEBE, 0xFF0000FF));

            scene.DrawList.Add(new Pyramid(new Point(35, 10, 0), 20, 20, 20));

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
        }

        private void CameraVertical_ValueChanged_1(object sender, EventArgs e)
        {
            camera1.ZRotation = CameraVertical.Value;
            if (!UpdateOff)
            {
                camera1.Render();
                canvas1.Invalidate();
            }
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
    }
}