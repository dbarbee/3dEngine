using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using dbarbee.GraphicsEngine._2DCanvas.Data;
using dbarbee.GraphicsEngine._2DCanvas.Doc;

namespace dbarbee.GraphicsEngine.QuickDraw.Doc
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            int objIdx = 0;
            canvas1.ObjectList.Add((++objIdx).ToString(), new Rectangle(new Point(0, 0), new Point(50, 50),0,new Color(0xFFFFFFFF)));
            canvas1.ObjectList.Add((++objIdx).ToString(), new Circle(new Point(0, 0), 20, new Color(0xFF7F0000), new Color(0x7F7F0000)));
            canvas1.ObjectList.Add((++objIdx).ToString(), new IsoscelesTriangle(new Point(0, 0), new Point(40, 40)));
            canvas1.ObjectList.Add((++objIdx).ToString(), new EquilateralTriangle(new Point(0, 0), 30));
            canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new Point(0, 0), new Point(40, 20)));
            canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new Point(0, 0), new Point(40, 20),90));
            canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new Point(0, 0), new Point(20, 40)));
            canvas1.ObjectList.Add((++objIdx).ToString(), new RightTriangle(new Point(0, 0), new Point(20, 40),90));

            int angleDelta = 3;
            UInt32 colorDelta = (UInt32) (0x00FFFFFF / (360 / angleDelta));
            UInt32 rgb = 0xFF000000;
            for (int angle = 0; angle < 360; angle += angleDelta, rgb += colorDelta)
            {
                canvas1.ObjectList.Add((++objIdx).ToString(), new RegularPolygon(new Point(0, 0), 6, Math.Abs(Math.Sin(angle*Math.PI/180))*25, angle,new Color(rgb)));
            }
            //for (int angle = 0; angle < 360; angle += 30)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new Triangle(new Point(50, 50), new Point(20, 20), false, angle));
            //}
            //for (int angle = 0; angle < 360; angle += 2)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Rectangle(new Point(50, 50), new Point(75, 75), false, angle));
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
    }
}