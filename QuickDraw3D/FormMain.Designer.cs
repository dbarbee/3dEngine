using dbarbee.GraphicsEngine._2DCanvas.Doc;

namespace dbarbee.GraphicsEngine.QuickDraw3D
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usePerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillSurfacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawEdgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawVerticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CameraHorizontal = new System.Windows.Forms.HScrollBar();
            this.CameraVertical = new System.Windows.Forms.VScrollBar();
            this.canvas1 = new dbarbee.GraphicsEngine._2DCanvas.Doc.Canvas();
            this.button1 = new System.Windows.Forms.Button();
            this.CameraDistanceSb = new System.Windows.Forms.HScrollBar();
            this.ViewScreenDistanceSb = new System.Windows.Forms.HScrollBar();
            this.CameraHorizontalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsRotation = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.redrawToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveAsToolStripMenuItem.Text = "Save As..";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewportToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.canvasToolStripMenuItem,
            this.usePerspectiveToolStripMenuItem,
            this.fillSurfacesToolStripMenuItem,
            this.drawEdgesToolStripMenuItem,
            this.drawVerticesToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // viewportToolStripMenuItem
            // 
            this.viewportToolStripMenuItem.Name = "viewportToolStripMenuItem";
            this.viewportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.viewportToolStripMenuItem.Text = "Viewport...";
            this.viewportToolStripMenuItem.Click += new System.EventHandler(this.setupViewportToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cameraToolStripMenuItem.Text = "Camera...";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.setupCameraToolStripMenuItem_Click);
            // 
            // canvasToolStripMenuItem
            // 
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.canvasToolStripMenuItem.Text = "Canvas..";
            this.canvasToolStripMenuItem.Click += new System.EventHandler(this.setupCanvasToolStripMenuItem_Click);
            // 
            // usePerspectiveToolStripMenuItem
            // 
            this.usePerspectiveToolStripMenuItem.Checked = true;
            this.usePerspectiveToolStripMenuItem.CheckOnClick = true;
            this.usePerspectiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.usePerspectiveToolStripMenuItem.Name = "usePerspectiveToolStripMenuItem";
            this.usePerspectiveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.usePerspectiveToolStripMenuItem.Text = "Use Perspective";
            this.usePerspectiveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.usePerspectiveToolStripMenuItem_CheckedChanged);
            // 
            // fillSurfacesToolStripMenuItem
            // 
            this.fillSurfacesToolStripMenuItem.Checked = true;
            this.fillSurfacesToolStripMenuItem.CheckOnClick = true;
            this.fillSurfacesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fillSurfacesToolStripMenuItem.Name = "fillSurfacesToolStripMenuItem";
            this.fillSurfacesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fillSurfacesToolStripMenuItem.Text = "Fill Surfaces";
            this.fillSurfacesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.fillSurfacesToolStripMenuItem_CheckedChanged);
            // 
            // drawEdgesToolStripMenuItem
            // 
            this.drawEdgesToolStripMenuItem.Checked = true;
            this.drawEdgesToolStripMenuItem.CheckOnClick = true;
            this.drawEdgesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawEdgesToolStripMenuItem.Name = "drawEdgesToolStripMenuItem";
            this.drawEdgesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.drawEdgesToolStripMenuItem.Text = "Draw Edges";
            this.drawEdgesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.drawEdgesToolStripMenuItem_CheckedChanged);
            // 
            // drawVerticesToolStripMenuItem
            // 
            this.drawVerticesToolStripMenuItem.Checked = true;
            this.drawVerticesToolStripMenuItem.CheckOnClick = true;
            this.drawVerticesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawVerticesToolStripMenuItem.Name = "drawVerticesToolStripMenuItem";
            this.drawVerticesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.drawVerticesToolStripMenuItem.Text = "Draw Vertices";
            this.drawVerticesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.drawVerticesToolStripMenuItem_CheckedChanged);
            // 
            // redrawToolStripMenuItem
            // 
            this.redrawToolStripMenuItem.Name = "redrawToolStripMenuItem";
            this.redrawToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.redrawToolStripMenuItem.Text = "Redraw!";
            this.redrawToolStripMenuItem.Click += new System.EventHandler(this.redrawToolStripMenuItem_Click);
            // 
            // CameraHorizontal
            // 
            this.CameraHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraHorizontal.LargeChange = 15;
            this.CameraHorizontal.Location = new System.Drawing.Point(0, 596);
            this.CameraHorizontal.Maximum = 180;
            this.CameraHorizontal.Minimum = -180;
            this.CameraHorizontal.Name = "CameraHorizontal";
            this.CameraHorizontal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CameraHorizontal.Size = new System.Drawing.Size(567, 17);
            this.CameraHorizontal.TabIndex = 2;
            this.CameraHorizontal.ValueChanged += new System.EventHandler(this.CameraHorizontal_ValueChanged);
            // 
            // CameraVertical
            // 
            this.CameraVertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraVertical.LargeChange = 15;
            this.CameraVertical.Location = new System.Drawing.Point(567, 24);
            this.CameraVertical.Maximum = 180;
            this.CameraVertical.Minimum = -180;
            this.CameraVertical.Name = "CameraVertical";
            this.CameraVertical.Size = new System.Drawing.Size(17, 570);
            this.CameraVertical.TabIndex = 3;
            this.CameraVertical.ValueChanged += new System.EventHandler(this.CameraVertical_ValueChanged_1);
            // 
            // canvas1
            // 
            this.canvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas1.Location = new System.Drawing.Point(0, 24);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(567, 570);
            this.canvas1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(570, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 16);
            this.button1.TabIndex = 4;
            this.button1.Text = "*";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CameraDistanceSb
            // 
            this.CameraDistanceSb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraDistanceSb.Location = new System.Drawing.Point(0, 618);
            this.CameraDistanceSb.Maximum = 280;
            this.CameraDistanceSb.Name = "CameraDistanceSb";
            this.CameraDistanceSb.Size = new System.Drawing.Size(567, 17);
            this.CameraDistanceSb.TabIndex = 5;
            this.CameraDistanceSb.Value = 140;
            this.CameraDistanceSb.ValueChanged += new System.EventHandler(this.CameraDistanceSb_ValueChanged);
            // 
            // ViewScreenDistanceSb
            // 
            this.ViewScreenDistanceSb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewScreenDistanceSb.Location = new System.Drawing.Point(0, 645);
            this.ViewScreenDistanceSb.Maximum = 340;
            this.ViewScreenDistanceSb.Name = "ViewScreenDistanceSb";
            this.ViewScreenDistanceSb.Size = new System.Drawing.Size(567, 17);
            this.ViewScreenDistanceSb.TabIndex = 5;
            this.ViewScreenDistanceSb.Value = 170;
            this.ViewScreenDistanceSb.ValueChanged += new System.EventHandler(this.ViewScreenDistanceSb_ValueChanged);
            // 
            // CameraHorizontalToolTip
            // 
            this.CameraHorizontalToolTip.ToolTipTitle = "Camera Horizontal";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRotation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsRotation
            // 
            this.tsRotation.Name = "tsRotation";
            this.tsRotation.Size = new System.Drawing.Size(574, 17);
            this.tsRotation.Spring = true;
            this.tsRotation.Text = "Rotation: {x},{y},{z}";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 696);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ViewScreenDistanceSb);
            this.Controls.Add(this.CameraDistanceSb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CameraVertical);
            this.Controls.Add(this.CameraHorizontal);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redrawToolStripMenuItem;
        private Canvas canvas1;
        private System.Windows.Forms.HScrollBar CameraHorizontal;
        private System.Windows.Forms.VScrollBar CameraVertical;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar CameraDistanceSb;
        private System.Windows.Forms.HScrollBar ViewScreenDistanceSb;
        private System.Windows.Forms.ToolTip CameraHorizontalToolTip;
        private System.Windows.Forms.ToolStripMenuItem usePerspectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillSurfacesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawEdgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawVerticesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsRotation;
    }
}

