using DevExpress.Utils.CodedUISupport;
using Nesne_Prog_Proje.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nesne_Prog_Proje.Entities;
using System.Drawing.Imaging;
using Nesne_Prog_Proje.Entity;
using System.Net.Mail;
//using DevExpress.XtraCharts.Native;



namespace Nesne_Prog_Proje.Formlar
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm()
        {
            InitializeComponent();
        }//kodlarımızı daha iyi katogorize etmek için ekledik region endregion
        #region " Variables"
        //Lists
     //   private List<Entities.Point> points = new List<Entities.Point>();//liste şeklinde çizdiriyoruz
        //private List<Entities.Line> lines = new List<Entities.Line>();        
        //private List<Entities.Circle> circles = new List<Entities.Circle>();
        //private List<Entities.Ellipse> ellipses = new List<Entities.Ellipse>();
        //private List<Entities.Arc> arcs = new List<Entities.Arc>();
        //private List<LwPolyline> polylines = new List<LwPolyline>();

        private List<EntityObject> entity = new List<EntityObject>();

        private LwPolyline tempPolyline = new LwPolyline();
        // vector3
        private Vector3 firstPoint;
        private Vector3 secondPoint;
        private Vector3 currentPosition;//anlık konum
        // system point
        private System.Drawing.Point firstCorner;
        //ints
        private int DrawIndex = -1;
        private int ClickNum = 1;
        private int zoomClick = 1;
        private int direction;
        private int sidesQty = 5;
        private int inscribed = 0;
        //floats
        private float XScrool;
        private float YScrool;
        private float ScaleFactor = 1.0f;
        //bool
        private bool active_drawing = false;
        private bool active_zoom = false;
        // base size of drawing
        private SizeF drawingSize = new SizeF(297,210);
        #endregion

        #region "PictureBox events"

        #region Mouse Down
        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (active_zoom)
                {
                    switch (zoomClick)
                    {
                        case 1:
                            firstCorner = e.Location;
                            zoomClick++;
                            break;
                        case 2:
                            SetZoomWin(firstCorner,e.Location);
                            active_zoom = false;
                            zoomClick = 1;
                            break;
                    }
                }

                if (active_drawing && !active_zoom)
                {
                    switch (DrawIndex)
                    {
                        case 3: //Line 
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;// line bir çizgi çizer
                                    ClickNum++;
                                    break;
                                case 2:                                  
                                    entity.Add(new Line(firstPoint, currentPosition)); //her line ın sonuna nokta koyar
                                    firstPoint = currentPosition;

                                    break;
                            }

                            break;
                        case 4://Lw polyline
                            firstPoint = currentPosition;
                            tempPolyline.Vertexes.Add(new LwPolylineVertex(firstPoint.ToVector2));
                            ClickNum = 2;
                            break; 
                        case 5:  //polygon
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    using (var setpolygon = new EntityForms.SetPolygonValuesForm())
                                    {
                                        var result = setpolygon.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {
                                            sidesQty = setpolygon.SidesQty;
                                            inscribed = setpolygon.Inscribed;
                                        }
                                        else
                                            CancelAll();
                                    }
                                        break;
                                case 2:
                                    entity.Add(Method.GetPolygon(firstPoint,currentPosition,sidesQty,inscribed));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 6:  //Nokta
                            entity.Add(new Entities.Point(currentPosition));
                            break;
                        case 7: //rectangle
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    entity.Add(Method.PointToRect(firstPoint, currentPosition, out direction));
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 11://arc
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    Entities.Arc a = Methods.Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
                                    entity.Add(a);
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 21: // Daire
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                        break;
                                case 2:
                                    double r=firstPoint.DistanceForm(currentPosition);
                                    entity.Add(new Entities.Circle(firstPoint, r));
                                    ClickNum = 1;
                                    break;
                            }
                            break;
                        case 22: // 3 noktada circle
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    Entities.Circle c = Methods.Method.GetCircleWith3Point(firstPoint, secondPoint, currentPosition);
                                    entity.Add(c);
                                    CancelAll();
                                    break;
                            }
                            break;
                        case 31: // Elips
                            switch (ClickNum)
                            {
                                case 1:
                                    firstPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 2:
                                    secondPoint = currentPosition;
                                    ClickNum++;
                                    break;
                                case 3:
                                    Entities.Ellipse ellipse = Methods.Method.GetEllipse(firstPoint,secondPoint,currentPosition);
                                    entity.Add(ellipse);
                                    ClickNum = 1;
                                    active_drawing = false;
                                    drawing.Cursor = Cursors.Default;
                                    break;
                            }
                            break;
                    }
                   
                }
                drawing.Refresh();
            }
        }
        #endregion

        #region Paint
        private void drawing_Click(object sender, EventArgs e)
        {

        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(XScrool,YScrool,ScaleFactor , Pixel_to_Mn(drawing.Height));
            Pen pen = new Pen(Color.Blue, 0.1f);
            Pen extpen = new Pen(Color.Gray, 0.1f);
            extpen.DashPattern = new float[] { 1.0f, 2.0f };

            // test line dan uzaklık 
            if (entity.Count  > 0)
            {
                foreach(EntityObject ent in entity)
                {
                    if(ent is Line)
                    {
                        double d = Method.DistanceFromLine(ent as Line, currentPosition, out Vector3 v, true);
                        e.Graphics.DrawPoint(new Pen(Color.Red, 1), new Entities.Point(v));
                        Text = d.ToString();
                    }
                }
            }


            //noktaları(entities) çiz
            if (entity.Count > 0)
            {
                foreach(EntityObject entities in entity)
                {
                    e.Graphics.DrawEntity(pen, entities);
                }
            }
          
            //draw temppolyline
            if(tempPolyline.Vertexes.Count > 1)
            {
                e.Graphics.DrawLwPolyline(pen, tempPolyline);
            }
           
            #region Extended
                //line extended
                //line ın startpoint ini verdikten sonra endpoint bırakana kadar anlık konumu takip etmesi
            switch (DrawIndex)
            {
                case 3: //line
                     case 4: // polyline
                    if (ClickNum == 2)
                    {
                        Entities.Line line = new Entities.Line(firstPoint, currentPosition);
                        e.Graphics.DrawLine(extpen, line);
                    }                   
                    break;
                case 5: //Polygon
                    if (ClickNum == 2)
                    {
                        Entities.Line line = new Entities.Line(firstPoint, currentPosition);
                        e.Graphics.DrawLine(extpen, line);
                        LwPolyline lw = Method.GetPolygon(firstPoint,currentPosition,sidesQty,inscribed);
                        e.Graphics.DrawLwPolyline(extpen, lw);
                    }
                    break;
                case 7: //rectangle
                    if(ClickNum == 2)
                    {
                        LwPolyline lw = Method.PointToRect(firstPoint, currentPosition, out direction);
                        e.Graphics.DrawLwPolyline(extpen, lw);
                    }    
                    break;
                case 11:
                    switch (ClickNum)
                    {
                        case 2:
                            Entities.Line line = new Entities.Line(firstPoint, currentPosition);
                            e.Graphics.DrawLine(extpen, line);
                            break;
                        case 3:
                            Arc a = Method.GetArcWith3Points(firstPoint, secondPoint, currentPosition);
                            e.Graphics.DrawArc(extpen, a);
                            break;
                    }
                    break;
                case 21:
                    switch (ClickNum) 
                    {
                        case 2:
                            Entities.Line line1 = new Entities.Line(firstPoint, currentPosition);
                            e.Graphics.DrawLine(extpen, line1);
                            double r = firstPoint.DistanceForm(currentPosition);
                            Entities.Circle circle = new Entities.Circle(firstPoint, r);
                            e.Graphics.DrawCircle(extpen, circle);
                            break;
                    }
                    break;
                case 22:
                    switch (ClickNum)
                    {
                        case 2:
                            Entities.Line line = new Entities.Line(firstPoint, currentPosition);
                            e.Graphics.DrawLine(extpen, line);
                            break;
                        case 3:
                            Entities.Circle c = Methods.Method.GetCircleWith3Point(firstPoint, secondPoint, currentPosition);
                            e.Graphics.DrawCircle(extpen, c);
                            break;
                    }
                    break;
                case 31:
                    switch (ClickNum)
                    {
                        case 2:
                            Entities.Line line = new Entities.Line(firstPoint, currentPosition);
                            e.Graphics.DrawLine(extpen, line);
                            break;
                        case 3:
                            Entities.Line line1 = new Entities.Line(firstPoint, currentPosition);
                            e.Graphics.DrawLine(extpen, line1);
                            Entities.Ellipse elp = Method.GetEllipse(firstPoint,secondPoint,currentPosition);
                            e.Graphics.DrawEllipse(extpen, elp);
                            break;
                    }
                    break;
                  
            
            }
            //test line line kesişimi
            //if (entity.Count > 0)
            //{
            //    foreach(Entities.Line l1 in entity)
            //    {
            //        foreach(Entities.Line l2 in entity)
            //        {
            //            Vector3 v= Methods.Method.LineLineIntesection(l1, l2, true);
            //            Entities.Point p = new Entities.Point(v);
            //            e.Graphics.DrawPoint(new Pen(Color.Red, 0), p);
            //        }
            //    }
            //}
            #endregion

            #region draw zoom rect
            if (active_zoom)
            {
                switch (zoomClick)
                {

                    case 2:
                        LwPolyline rect = Method.PointToRect(PointToCartesian(firstCorner), currentPosition, out direction);
                        e.Graphics.DrawLwPolyline(new Pen(Color.Red, 0),rect );
                        break;
                }
            }
        #endregion
        }




        #endregion

        #region Mouse Move
        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            coordinate.Text = string.Format("{0,0:F3}, {1,0:F3}, {2,0:F3}", currentPosition.X, currentPosition.Y, currentPosition.Z);
            drawing.Refresh();
        }
        #endregion

        #endregion

        #region " Custom Medhods "

        #region Sistem Noktasi donusturme
        //sistem noktasını dönüştürme
        private Vector3 PointToCartesian(System.Drawing.Point point)
        {
            return new Vector3((Pixel_to_Mn(point.X) + XScrool) / ScaleFactor, Pixel_to_Mn(drawing.Height - point.Y - YScrool) / ScaleFactor);
        }
        #endregion

        #region pixel to milimetre
        // pixelleri milimetrelere dönüştürme
        private float Pixel_to_Mn(float pixel)
        {
            return pixel * 25.4f / DPI;
        }
        #endregion


        #region milimetre to pixel
        // pixelleri milimetrelere dönüştürme
        private float Mn_to_Pixel(float pixel)
        {
            return pixel / 25.4f * DPI;
        }
        #endregion

        #region Komut Iptal
        private void CancelAll(int index = 1)
        {
            DrawIndex = -1;
            active_drawing = false;
            ActiveCursor(0);
            ClickNum = 1;
            LwPolylineCloseStatus(index);
        }
        #endregion

        #region Iptal Button
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CancelAll();
        }
        #endregion

        #region Get dpi
        //ekran dpi 'ını al
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;//13.hafta değiştirilemeyen deişkenli geriye döndüren method
            }
        }
        #endregion

        #region cursor aktif et
        private void ActiveCursor(int index, float size = 15)
        {
            Cursor cursor = Cursors.Default;
            if (index > 0)
                cursor = new Cursor(Method.SetCursor(index, Mn_to_Pixel(size), Color.Red).GetHicon());
            drawing.Cursor = cursor;
        }
        #endregion

        #region Zoom window
        private void SetZoomWin(System.Drawing.Point firstCorner,System.Drawing.Point secondCorner)
        {
            Vector3 p1 = PointToCartesian(firstCorner);
            Vector3 p2 = PointToCartesian(secondCorner);

            float minX = Math.Min(p1.ToPointF.X,p2.ToPointF.X);
            float minY = Math.Min(p1.ToPointF.Y, p2.ToPointF.Y);

            float w = Math.Abs(firstCorner.X - secondCorner.X);
            float h = Math.Abs(firstCorner.Y - secondCorner.Y);

            float widht = drawing.ClientSize.Width / w;
            float height = drawing.ClientSize.Height / h;

            float min = Math.Min(widht, height);

            ScaleFactor *= min;
            float wl = (drawing.ClientSize.Width - w * min) / 2;
            float hl = (drawing.ClientSize.Height - h * min) / 2;

            XScrool = ScaleFactor * minX - Pixel_to_Mn(wl);
            YScrool = -ScaleFactor * minY - Pixel_to_Mn(hl);

            SetScroolBarValues();

        }

        #endregion

        #region Zoom in & out
        private void SetZoomInOut(int index)
        {
            float scale = (index == 0) ? 1 / 1.25f : 1.25f;
            
            ScaleFactor*=scale;

            float widht = drawing.ClientSize.Width * scale;
            float height = drawing.ClientSize.Height * scale;

            float wl = (drawing.ClientSize.Width - widht) / 2;
            float hl = (drawing.ClientSize.Height - height) / 2;

            XScrool = XScrool * scale - Pixel_to_Mn(wl);
            YScrool = YScrool * scale + Pixel_to_Mn(hl);

            SetScroolBarValues();
        }

        #endregion Set Zoom Events

        #region set zoom events
        private void ZoomEvents(int index)
        {
            switch (index)
            {
                case 0: //zoom in
                case 1: // zoom out
                    SetZoomInOut(index);
                    break;
                case 2: // zoom window
                    active_zoom = true;
                    ActiveCursor(1);
                    break;
            }
        }
        #endregion

        #region Set scrool bar values
        private void SetScroolBarValues()
        {
            float width = Math.Max(0, drawingSize.Width * ScaleFactor - Pixel_to_Mn(drawing.ClientSize.Width)) + 50 *ScaleFactor;
            float height = Math.Max(0,drawingSize.Height*ScaleFactor-Pixel_to_Mn(drawing.ClientSize.Height))+ 59 * ScaleFactor;

            hS.Maximum = (int)width;
            hS.Minimum = (int)(50 * ScaleFactor);

            vS.Maximum = (int)(59 * ScaleFactor);
            vS.Minimum = -(int)height;

            try
            {
                hS.Minimum = (int)Math.Min(XScrool, hS.Minimum);
                hS.Maximum = (int)Math.Max(XScrool, hS.Maximum);
                vS.Minimum = (int)Math.Min(YScrool, vS.Minimum);
                vS.Maximum = (int)Math.Max(YScrool, vS.Maximum);

                hS.Value = (int)XScrool;
                vS.Value = (int)YScrool;

            }
            catch { }
            drawing.Refresh();
           
        }
        #endregion

        #endregion

        #region " Form Load"
        private void GraphicsForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region " Graphics Form Compenent event"

        #region Draw Buttons
        private void arcBtn_Click(object sender, EventArgs e)
        {
            //DrawIndex = 0;
            //active_drawing = true;
            //drawing.Cursor = Cursors.Cross;
            //active_drawing = true;
            //drawing.Cursor = Cursors.Cross;
        }


        private void DrawBtn_Click(Object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = drawPanel.Items.IndexOf(item);
            active_drawing = true;
            ActiveCursor(1);

        }
        #endregion

        #region Arc Button
        private void ArcButton_Click(object sender, EventArgs e)
        {
            //DrawIndex = 0;
            //active_drawing = true;
            //drawing.Cursor = Cursors.Cross;
            //active_drawing = true;
            //drawing.Cursor = Cursors.Cross;
            var item = sender as RibbonButton;
            DrawIndex = arcButton.DropDownItems.IndexOf(item) + 11;
            active_drawing = true;
            ActiveCursor(1);
        }
        #endregion

        #region Circle Button
        private void CircleButton_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = circleButton.DropDownItems.IndexOf(item) + 21;
            active_drawing = true;
            ActiveCursor(1);
        }
        #endregion

        #region Ellipse Button
        private void EllipseButton_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            DrawIndex = ellipseButton.DropDownItems.IndexOf(item) + 31;
            active_drawing = true;
            ActiveCursor(1);
        }
        #endregion

        #region Yatay scroll bar
        private void hS_Scroll(object sender, ScrollEventArgs e)
        {
            XScrool = (sender as HScrollBar).Value;
            drawing.Refresh();
        }
        #endregion

        #region Dikey scroll bar
        private void vS_Scroll(object sender, ScrollEventArgs e)
        {
            YScrool = (sender as VScrollBar).Value;
            drawing.Refresh();

        }
        #endregion

        #region zoom buttons click
        private void ZoomBtn_Click(object sender, EventArgs e)
        {
            var item = sender as RibbonButton;
            int index = zoomPanel.Items.IndexOf(item);
            ZoomEvents(index);
        }
        #endregion

        #endregion

        private void closeBoundary_Click(object sender, EventArgs e)
        {
            switch (DrawIndex)
            {
                case 3:   //line
                    break;
                case 4:     //Lwpolyline
                    CancelAll(2);
                    break;
            }
        }

        private void LwPolylineCloseStatus(int index)
        {
            List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
            foreach (LwPolylineVertex lw in tempPolyline.Vertexes)
                vertexes.Add(lw);
            if (vertexes.Count > 1)
            {
                switch (index)
                {
                    case 1:
                        entity.Add(new LwPolyline(vertexes, false));
                        break;
                    case 2:
                        if (vertexes.Count > 2)
                            entity.Add(new LwPolyline(vertexes, true));
                        else
                            entity.Add(new LwPolyline(vertexes, false));
                        break;                     
                }
            }
            tempPolyline.Vertexes.Clear();
        }

        DbTasarimRehberimEntities db = new DbTasarimRehberimEntities();
        private void saveThisDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap foto = new Bitmap(1900,764);
            Graphics grafik = Graphics.FromImage(foto);
            grafik.CopyFromScreen(0, 246, 0, 0, new Size(1900, 764));
            //drawing.Image = foto;
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg) |*.jpg|(*.*|*.*)";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                foto.Save(sfd.FileName,ImageFormat.Jpeg);
            }
            TblCizim t = new TblCizim();
            t.Resim = sfd.FileName;           
            db.TblCizim.Add(t);
            db.SaveChanges();
        }
    }
}
