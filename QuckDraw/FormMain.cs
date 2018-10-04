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
using dbarbee.GraphicsEngine._2DCanvas;

namespace dbarbee.GraphicsEngine.D2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            int objIdx = 0;
            canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Rectangle(new flPoint(0, 0), new flPoint(50, 50), true));
            canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Circle(new flPoint(0, 0), 20, true));
            canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Triangle(new flPoint(0, 0), new flPoint(40, 40), false));
            for (int angle = 0; angle < 360; angle += 20)
            {
                canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.RegularPolygon(new flPoint(0, 0), 6, 25, false, angle));
            }
            //for (int angle = 0; angle < 360; angle += 30)
            //{
            //    canvas1.ObjectList.Add((++objIdx).ToString(), new _2DCanvas.Triangle(new flPoint(50, 50), new flPoint(20, 20), false, angle));
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
    }
}