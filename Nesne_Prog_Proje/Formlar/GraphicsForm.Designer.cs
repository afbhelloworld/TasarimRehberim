namespace Nesne_Prog_Proje.Formlar
{
    partial class GraphicsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsForm));
            this.popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBoundary = new System.Windows.Forms.ToolStripMenuItem();
            this.saveThisDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbon = new System.Windows.Forms.Ribbon();
            this.drawTab = new System.Windows.Forms.RibbonTab();
            this.drawPanel = new System.Windows.Forms.RibbonPanel();
            this.zoomPanel = new System.Windows.Forms.RibbonPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.vS = new System.Windows.Forms.VScrollBar();
            this.hS = new System.Windows.Forms.HScrollBar();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.arcButton = new System.Windows.Forms.RibbonButton();
            this.arcBtn11 = new System.Windows.Forms.RibbonButton();
            this.circleButton = new System.Windows.Forms.RibbonButton();
            this.circleBtn21 = new System.Windows.Forms.RibbonButton();
            this.CircleBtn22 = new System.Windows.Forms.RibbonButton();
            this.ellipseButton = new System.Windows.Forms.RibbonButton();
            this.ellipseButton31 = new System.Windows.Forms.RibbonButton();
            this.lineButton = new System.Windows.Forms.RibbonButton();
            this.polylineButton = new System.Windows.Forms.RibbonButton();
            this.polygonButton = new System.Windows.Forms.RibbonButton();
            this.pointButton = new System.Windows.Forms.RibbonButton();
            this.rectangleButton = new System.Windows.Forms.RibbonButton();
            this.zoomminBtn = new System.Windows.Forms.RibbonButton();
            this.zoomOutBtn = new System.Windows.Forms.RibbonButton();
            this.zoomWinBtn = new System.Windows.Forms.RibbonButton();
            this.drawing = new System.Windows.Forms.PictureBox();
            this.popup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // popup
            // 
            this.popup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelBtn,
            this.closeBoundary,
            this.saveThisDrawingToolStripMenuItem});
            this.popup.Name = "menuStrip";
            this.popup.Size = new System.Drawing.Size(200, 76);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(199, 24);
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // closeBoundary
            // 
            this.closeBoundary.Name = "closeBoundary";
            this.closeBoundary.Size = new System.Drawing.Size(199, 24);
            this.closeBoundary.Text = "Close";
            this.closeBoundary.Click += new System.EventHandler(this.closeBoundary_Click);
            // 
            // saveThisDrawingToolStripMenuItem
            // 
            this.saveThisDrawingToolStripMenuItem.Name = "saveThisDrawingToolStripMenuItem";
            this.saveThisDrawingToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.saveThisDrawingToolStripMenuItem.Text = "Save This Drawing";
            this.saveThisDrawingToolStripMenuItem.Click += new System.EventHandler(this.saveThisDrawingToolStripMenuItem_Click);
            // 
            // ribbon
            // 
            this.ribbon.CaptionBarVisible = false;
            this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Minimized = false;
            this.ribbon.Name = "ribbon";
            // 
            // 
            // 
            this.ribbon.OrbDropDown.BorderRoundness = 8;
            this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon.OrbDropDown.Name = "";
            this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon.OrbDropDown.TabIndex = 0;
            // 
            // 
            // 
            this.ribbon.QuickAccessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon.Size = new System.Drawing.Size(1285, 145);
            this.ribbon.TabIndex = 10;
            this.ribbon.Tabs.Add(this.drawTab);
            this.ribbon.Text = "ribbon1";
            // 
            // drawTab
            // 
            this.drawTab.Name = "drawTab";
            this.drawTab.Panels.Add(this.drawPanel);
            this.drawTab.Panels.Add(this.zoomPanel);
            this.drawTab.Text = "Drawing";
            // 
            // drawPanel
            // 
            this.drawPanel.ButtonMoreEnabled = false;
            this.drawPanel.ButtonMoreVisible = false;
            this.drawPanel.Items.Add(this.arcButton);
            this.drawPanel.Items.Add(this.circleButton);
            this.drawPanel.Items.Add(this.ellipseButton);
            this.drawPanel.Items.Add(this.lineButton);
            this.drawPanel.Items.Add(this.polylineButton);
            this.drawPanel.Items.Add(this.polygonButton);
            this.drawPanel.Items.Add(this.pointButton);
            this.drawPanel.Items.Add(this.rectangleButton);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Text = "";
            // 
            // zoomPanel
            // 
            this.zoomPanel.ButtonMoreVisible = false;
            this.zoomPanel.Items.Add(this.zoomminBtn);
            this.zoomPanel.Items.Add(this.zoomOutBtn);
            this.zoomPanel.Items.Add(this.zoomWinBtn);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 715);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1285, 35);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip";
            // 
            // coordinate
            // 
            this.coordinate.AutoSize = false;
            this.coordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(250, 29);
            this.coordinate.Text = "0.000,0.000,0.000";
            // 
            // vS
            // 
            this.vS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vS.Location = new System.Drawing.Point(1270, 145);
            this.vS.Name = "vS";
            this.vS.Size = new System.Drawing.Size(15, 540);
            this.vS.TabIndex = 12;
            this.vS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vS_Scroll);
            // 
            // hS
            // 
            this.hS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hS.Location = new System.Drawing.Point(0, 700);
            this.hS.Name = "hS";
            this.hS.Size = new System.Drawing.Size(1267, 15);
            this.hS.TabIndex = 13;
            this.hS.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hS_Scroll);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // arcButton
            // 
            this.arcButton.DropDownItems.Add(this.arcBtn11);
            this.arcButton.Image = ((System.Drawing.Image)(resources.GetObject("arcButton.Image")));
            this.arcButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcButton.LargeImage")));
            this.arcButton.Name = "arcButton";
            this.arcButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcButton.SmallImage")));
            this.arcButton.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.arcButton.Text = "Arc";
            // 
            // arcBtn11
            // 
            this.arcBtn11.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn11.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn11.Image")));
            this.arcBtn11.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.LargeImage")));
            this.arcBtn11.Name = "arcBtn11";
            this.arcBtn11.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.SmallImage")));
            this.arcBtn11.Text = "3-Point";
            this.arcBtn11.Click += new System.EventHandler(this.ArcButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.DropDownItems.Add(this.circleBtn21);
            this.circleButton.DropDownItems.Add(this.CircleBtn22);
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleButton.LargeImage")));
            this.circleButton.Name = "circleButton";
            this.circleButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleButton.SmallImage")));
            this.circleButton.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.circleButton.Text = "Circle";
            // 
            // circleBtn21
            // 
            this.circleBtn21.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn21.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn21.Image")));
            this.circleBtn21.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.LargeImage")));
            this.circleBtn21.Name = "circleBtn21";
            this.circleBtn21.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.SmallImage")));
            this.circleBtn21.Text = "Center, Radius";
            this.circleBtn21.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // CircleBtn22
            // 
            this.CircleBtn22.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CircleBtn22.Image = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.Image")));
            this.CircleBtn22.LargeImage = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.LargeImage")));
            this.CircleBtn22.Name = "CircleBtn22";
            this.CircleBtn22.SmallImage = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.SmallImage")));
            this.CircleBtn22.Text = "3-Points";
            this.CircleBtn22.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.DropDownItems.Add(this.ellipseButton31);
            this.ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton.Image")));
            this.ellipseButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseButton.LargeImage")));
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseButton.SmallImage")));
            this.ellipseButton.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.ellipseButton.Text = "Ellipse";
            // 
            // ellipseButton31
            // 
            this.ellipseButton31.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ellipseButton31.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton31.Image")));
            this.ellipseButton31.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseButton31.LargeImage")));
            this.ellipseButton31.Name = "ellipseButton31";
            this.ellipseButton31.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseButton31.SmallImage")));
            this.ellipseButton31.Text = "Full Ellipse";
            this.ellipseButton31.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("lineButton.LargeImage")));
            this.lineButton.Name = "lineButton";
            this.lineButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("lineButton.SmallImage")));
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.Image = ((System.Drawing.Image)(resources.GetObject("polylineButton.Image")));
            this.polylineButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("polylineButton.LargeImage")));
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("polylineButton.SmallImage")));
            this.polylineButton.Text = "Polyline";
            this.polylineButton.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.Image = ((System.Drawing.Image)(resources.GetObject("polygonButton.Image")));
            this.polygonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("polygonButton.LargeImage")));
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("polygonButton.SmallImage")));
            this.polygonButton.Text = "Polygon";
            this.polygonButton.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // pointButton
            // 
            this.pointButton.Image = ((System.Drawing.Image)(resources.GetObject("pointButton.Image")));
            this.pointButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("pointButton.LargeImage")));
            this.pointButton.Name = "pointButton";
            this.pointButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pointButton.SmallImage")));
            this.pointButton.Text = "Point";
            this.pointButton.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("rectangleButton.LargeImage")));
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("rectangleButton.SmallImage")));
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // zoomminBtn
            // 
            this.zoomminBtn.Image = global::Nesne_Prog_Proje.Properties.Resources.icons8_zoom_out_64;
            this.zoomminBtn.LargeImage = global::Nesne_Prog_Proje.Properties.Resources.icons8_zoom_out_64;
            this.zoomminBtn.Name = "zoomminBtn";
            this.zoomminBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomminBtn.SmallImage")));
            this.zoomminBtn.Text = "Zoom in";
            this.zoomminBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Image = global::Nesne_Prog_Proje.Properties.Resources.icons8_zoom_in_64;
            this.zoomOutBtn.LargeImage = global::Nesne_Prog_Proje.Properties.Resources.icons8_zoom_in_64;
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomOutBtn.SmallImage")));
            this.zoomOutBtn.Text = "Zoom out";
            this.zoomOutBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // zoomWinBtn
            // 
            this.zoomWinBtn.Image = global::Nesne_Prog_Proje.Properties.Resources.icons8_search_64;
            this.zoomWinBtn.LargeImage = global::Nesne_Prog_Proje.Properties.Resources.icons8_search_64;
            this.zoomWinBtn.Name = "zoomWinBtn";
            this.zoomWinBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomWinBtn.SmallImage")));
            this.zoomWinBtn.Text = "Zoom win";
            this.zoomWinBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // drawing
            // 
            this.drawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawing.BackColor = System.Drawing.SystemColors.Window;
            this.drawing.ContextMenuStrip = this.popup;
            this.drawing.Location = new System.Drawing.Point(0, 145);
            this.drawing.Name = "drawing";
            this.drawing.Size = new System.Drawing.Size(1273, 552);
            this.drawing.TabIndex = 0;
            this.drawing.TabStop = false;
            this.drawing.Click += new System.EventHandler(this.drawing_Click);
            this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
            this.drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseDown);
            this.drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseMove);
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 750);
            this.Controls.Add(this.hS);
            this.Controls.Add(this.vS);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.drawing);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphicsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphicsForm";
            this.Load += new System.EventHandler(this.GraphicsForm_Load);
            this.popup.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawing;
        private System.Windows.Forms.ContextMenuStrip popup;
        private System.Windows.Forms.ToolStripMenuItem cancelBtn;
        private System.Windows.Forms.Ribbon ribbon;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonTab drawTab;
        private System.Windows.Forms.RibbonPanel drawPanel;
        private System.Windows.Forms.RibbonButton arcButton;
        private System.Windows.Forms.RibbonButton arcBtn11;
        private System.Windows.Forms.RibbonButton circleButton;
        private System.Windows.Forms.RibbonButton circleBtn21;
        private System.Windows.Forms.RibbonButton CircleBtn22;
        private System.Windows.Forms.RibbonButton ellipseButton;
        private System.Windows.Forms.RibbonButton lineButton;
        private System.Windows.Forms.RibbonButton polylineButton;
        private System.Windows.Forms.RibbonButton polygonButton;
        private System.Windows.Forms.RibbonButton pointButton;
        private System.Windows.Forms.RibbonButton rectangleButton;
        private System.Windows.Forms.RibbonButton ellipseButton31;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel coordinate;
        private System.Windows.Forms.VScrollBar vS;
        private System.Windows.Forms.HScrollBar hS;
        private System.Windows.Forms.ToolStripMenuItem closeBoundary;
        private System.Windows.Forms.ToolStripMenuItem saveThisDrawingToolStripMenuItem;
        private System.Windows.Forms.RibbonPanel zoomPanel;
        private System.Windows.Forms.RibbonButton zoomminBtn;
        private System.Windows.Forms.RibbonButton zoomOutBtn;
        private System.Windows.Forms.RibbonButton zoomWinBtn;
    }
}