using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Nesne_Prog_Proje.Entities;

namespace Nesne_Prog_Proje
{
    public static class GraphicsExtension
    {
        private static float Height;
        private static float XScroll;
        private static float YScroll;
        private static float ScaleFactor;
        private static Pen extpen = new Pen(Color.Gray, 0);
        //özel çizim method larımızı yazdığımız bölgemiz
        public static void SetParameters(this System.Drawing.Graphics g,float xscroll,float yscroll,float scalefactor, float heigth)
        {
            XScroll = xscroll;
            YScroll = yscroll;
            ScaleFactor = scalefactor;
            Height = heigth;
            extpen.DashPattern = new float[] { 1.5f / scalefactor, 2.0f / scalefactor };
        }

        public static void SetTransform(this System.Drawing.Graphics g)
        {
            g.PageUnit = System.Drawing.GraphicsUnit.Millimeter;
            g.TranslateTransform(0, Height);
            g.ScaleTransform(ScaleFactor, -ScaleFactor);
            g.TranslateTransform(-XScroll / ScaleFactor, YScroll / ScaleFactor);
        }

        public static void DrawPoint(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Point point)
        {
            g.SetTransform();
            System.Drawing.PointF p = point.Position.ToPointF;
            if (!point.IsSelected)
                g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
            else
                g.DrawEllipse(extpen, p.X - 1, p.Y - 1, 2, 2);



            g.ResetTransform();
        }

        public static void DrawLine(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();
            if (!line.IsSelected)
            g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
           else
                g.DrawLine(extpen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            g.ResetTransform();
        }

        public static void DrawCircle(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Circle circle)
        {
            float x = (float)(circle.Center.X - circle.Radius);
            float y = (float)(circle.Center.Y - circle.Radius);
            float d = (float)circle.Diameter;

            g.SetTransform();
            if(!circle.IsSelected)
                g.DrawEllipse(pen, x, y, d, d);
            else
                g.DrawEllipse(extpen, x, y, d, d);
            g.ResetTransform();
        }

        public static void DrawEllipse(this System.Drawing.Graphics g,System.Drawing.Pen pen,Entities.Ellipse ellipse)
        {
            SetTransform(g);
            g.TranslateTransform(ellipse.Center.ToPointF.X,ellipse.Center.ToPointF.Y);
            g.RotateTransform((float)ellipse.Rotation);
            if (!ellipse.IsSelected)
                g.DrawEllipse(pen,-(float)ellipse.MajorAxis,-(float)ellipse.MinorAxis,(float)ellipse.MajorAxis * 2,(float)ellipse.MinorAxis * 2);
            else
                g.DrawEllipse(extpen, -(float)ellipse.MajorAxis, -(float)ellipse.MinorAxis, (float)ellipse.MajorAxis * 2, (float)ellipse.MinorAxis * 2);
            g.ResetTransform();
        }

        public static void DrawArc(this System.Drawing.Graphics g,System.Drawing.Pen pen,Entities.Arc arc)
        {
            float x = (float)(arc.Center.X - arc.Radius);
            float y = (float)(arc.Center.Y - arc.Radius);
            float d = (float)arc.Diameter;
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(x,y,d,d);

            g.SetTransform();
            try
            {
                if(!arc.IsSelected)
                g.DrawArc(pen,rect,(float)arc.StartAngle,(float)arc.EndAngle);
                else
                    g.DrawArc(extpen, rect, (float)arc.StartAngle, (float)arc.EndAngle);
            }
            catch { }
          
            g.ResetTransform();
        }
        public static void DrawLwPolyline(this Graphics g, Pen pen , LwPolyline polyline)
        {
            PointF[] vertexes = new PointF[polyline.Vertexes.Count];

            if (polyline.IsClosed)
            {
                vertexes = new PointF[polyline.Vertexes.Count + 1];
                vertexes[polyline.Vertexes.Count] = polyline.Vertexes[0].Position.ToPointF;
            }

            for (int i=0; i<polyline.Vertexes.Count; i++)
                vertexes[i] = polyline.Vertexes[i].Position.ToPointF;

            g.SetTransform();
            if (!polyline.IsSelected)
            g.DrawLines(pen, vertexes);
            else
                g.DrawLines(extpen, vertexes);
            g.ResetTransform();

        }

        public static void DrawEntity(this Graphics g,Pen pen , EntityObject entity)
        {
            switch (entity.Type)
            {
                case EntityType.Arc:
                    g.DrawArc(pen, entity as Arc);
                    break;
                case EntityType.Ellipse:
                    g.DrawEllipse(pen, entity as Ellipse);
                    break;
                    case EntityType.Circle:
                        g.DrawCircle(pen, entity as Circle);
                    break;
                case EntityType.Line:
                    g.DrawLine(pen, entity as Line);
                    break;
                case EntityType.LwPolyline:
                    g.DrawLwPolyline(pen, entity as LwPolyline);
                    break;
                case EntityType.Point:
                    g.DrawPoint(pen, entity as Entities.Point);
                    break;
            }
        }
    }
}