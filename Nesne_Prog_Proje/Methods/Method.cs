using Nesne_Prog_Proje.Entities;
using Nesne_Prog_Proje.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;

namespace Nesne_Prog_Proje.Methods
{
    public static class Method
    {
        public static double LineAngle(Vector3 start,Vector3 end)
        {
            double angle = Math.Atan2((end.Y - start.Y), (end.X - start.X)) * 180.0 / Math.PI;
            if (angle<0.0)            
                angle += 360.0;
                return angle;
        }

        public static Entities.Ellipse GetEllipse(Vector3 center, Vector3 firstPoint, Vector3 secondPoint)
        {
            double major = center.DistanceForm(firstPoint);
            double minor = center.DistanceForm(secondPoint);
            double angle = LineAngle(center, firstPoint);
            Entities.Ellipse elp = new Entities.Ellipse(center, major, minor);
            elp.Rotation = angle;
            return elp;
        }

        public static Vector3 LineLineIntesection(Entities.Line line1,Entities.Line line2,bool extended = false)
        {
            Vector3 result;
            Vector3 p1 = line1.StartPoint;
            Vector3 p2 = line1.EndPoint;
            Vector3 p3 = line2.StartPoint;
            Vector3 p4 = line2.EndPoint;

            double dx12 = p2.X - p1.X;//birinci line ın endpointtinden startpointini çıkarıp ...
            double dy12 = p2.Y - p1.Y;//yine aynı şekilde 2.line ın end inden start ını çıkarıp elde ettiğimiz lokasyondan kesişimi elde ediyoruz
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            double denominator = (dy12 * dx34 - dx12 * dy34);//payda
            double k1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

            if (double.IsInfinity(k1))
                return new Vector3(double.NaN, double.NaN);

            result = new Vector3(p1.X + dx12 *k1,p1.Y + dy12 * k1);

            if (extended)
                return result;
            else
            {
                if(IsPointOnLine(line1,result) && IsPointOnLine(line2,result))
                    return result;
                else
                    return new Vector3(double.NaN, double.NaN);
            }

        }

        private static bool IsPointOnLine(Line line1, Vector3 point)
        {
            return IsEqual(line1.Length, line1.StartPoint.DistanceForm(point) + line1.EndPoint.DistanceForm(point));
        }
        private static double Epsilon = 1e-12;
        private static bool IsEqual(double d1, double d2)
        {
            return IsEqual(d1, d2, Epsilon);
        }

        private static bool IsEqual(double d1, double d2, double epsilon)
        {
            return IsZero(d1 - d2, epsilon);
        }

        private static bool IsZero(double d,double epsilon)
        {
            return d >= -epsilon && d <= epsilon;
        }

        public static Circle GetCircleWith3Point(Vector3 p1,Vector3 p2, Vector3 p3)
        {
            double x1 = (p1.X + p2.X) / 2;
            double y1 = (p1.Y + p2.Y) / 2;
            double dx1 = p2.X - p1.X;
            double dy1 = p2.Y - p1.Y;

            double x2 = (p2.X + p3.X) / 2;
            double y2 = (p2.Y + p3.Y) / 2;
            double dx2 = p3.X - p2.X;
            double dy2 = p3.Y - p2.Y;

            Line line1 = new Line(new Vector3(x1,y1), new Vector3(x1 - dy1, y1 + dx1 ));
            Line line2 = new Line(new Vector3(x2, y2), new Vector3(x2 - dy2, y2 + dx2));

            Vector3 center = LineLineIntesection(line1, line2, true);

            double dx = center.X - p1.X;
            double dy= center.Y - p1.Y;

            double radius = Math.Sqrt(dx * dx + dy * dy);

            return new Circle(center,radius);
        }

        public static Arc GetArcWith3Points(Vector3 p1,Vector3 p2,Vector3 p3)
        {
            double start, end;
            Arc result = new Arc();

            Circle c = GetCircleWith3Point(p1,p2,p3);

            if (c.Radius >  0)
            {
                if (DeterminePointOfLine(new Line(p1, p3),p2) < 0)
                        {
                    start = LineAngle(c.Center, p3);
                    end= LineAngle(c.Center, p1);
                }
                else
                {
                    start = LineAngle(c.Center, p1);
                    end = LineAngle(c.Center, p3);
                }
                if (end > start)
                    end -= start;
                else
                    end += 360.0 - start;

                result = new Arc(c.Center, c.Radius, start, end);
            }
         
            return result;
        }

        private static double DeterminePointOfLine(Line line, Vector3 v)
        {
            return (v.X - line.StartPoint.X) * (line.EndPoint.Y - line.StartPoint.Y) - (v.Y - line.StartPoint.Y) * (line.EndPoint.X - line.StartPoint.X);

        }

        public static LwPolyline PointToRect(Vector3 firstCorner, Vector3 secondCorner, out int direction)
        {
            double x = Math.Min(firstCorner.X, secondCorner.X);
            double y = Math.Min(firstCorner.Y, secondCorner.Y);
            double widht = Math.Abs(secondCorner.X - firstCorner.X);
            double height = Math.Abs(secondCorner.Y - firstCorner.Y);

            double dx = secondCorner.X - firstCorner.X;

            List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
            vertexes.Add(new LwPolylineVertex(x, y));
            vertexes.Add(new LwPolylineVertex(x + widht, y));
            vertexes.Add(new LwPolylineVertex(x + widht, y + height));// Autocad teki bir rectangle bir lw polyline dır.
            vertexes.Add(new LwPolylineVertex(x, y + height));

            if (dx > 0) direction = 1;
            else if (dx < 0) direction = 2;
            else direction = -1;

            return new LwPolyline(vertexes, true);

        }

        public static LwPolyline GetPolygon(Vector3 center,Vector3 secondPoint, int sidesQty, int inscribed)
        {
            List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
            double sides_angle = 360.0 / sidesQty;
            double radius = center.DistanceForm(secondPoint);
            double lineangle = LineAngle(center, secondPoint);

            if(inscribed == 1)
            {
                lineangle -= sides_angle / 2.0;
                radius /= Math.Cos(sides_angle / 180.0 * Math.PI / 2.0);
            }

            for (int i = 0; i < sidesQty; i++) 
            {
                double x =center.X + radius * Math.Cos(lineangle / 180.0 * Math.PI);
                double y =center.Y + radius * Math.Sin(lineangle/180.0 * Math.PI);

                vertexes.Add(new LwPolylineVertex(x, y));
                lineangle += sides_angle;
            }

            return new LwPolyline(vertexes, true);
        }

        public static Bitmap SetCursor(int index, float size , Color color)
        {
            Bitmap bmp = new Bitmap((int)size + 1, (int)size + 1);
            float cx = size / 2;
            float cy = size / 2;
            PointF[] points;

            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.Transparent);
                switch (index)
                {
                    case 0:  //default cursor
                        break;
                    case 1:  //drawing cursor
                        points = new PointF[]
                        {
                            new PointF(cx,0),
                            new PointF(2*cx,cy),
                            new PointF(cx,2*cy),
                            new PointF(0,cy)
                        };
                        gr.DrawLine(new Pen(color, 2.0f), points[0], points[2]);
                        gr.DrawLine(new Pen(color, 2.0f), points[1], points[3]);
                        break;
                    case 2:  //editing cursor
                        points = new PointF[]
                        {
                            new PointF(1,1),
                            new PointF(2*cx,1),
                            new PointF(2*cx -1,2*cy-1),
                            new PointF(1,2*cy -1)
                        };

                        gr.DrawPolygon(new Pen(color, 2.0f), points);
                        break;
                }
                return bmp;
            }
        }
   
        public static double DistanceFromLine(Line line,Vector3 point , out Vector3 closest, bool IsExtended = false)
        {
            double x1 = line.StartPoint.X;
            double y1 = line.StartPoint.Y;  
            double x2 = line.EndPoint.X;
            double y2 = line.EndPoint.Y;

            double x = point.X;
            double y = point.Y;

            double dx = x2 - x1;
            double dy = y2 - y1;

            if((dx == 0) && (dy == 0))
            {
                closest = line.StartPoint;
                dx = x - x1;
                dy = y - y1;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            double k = ((x - x1) * dx + (y - y1) * dy) / (dx * dx + dy * dy);
            closest = new Vector3(x1 + k * dx, y1 + k * dy);
            dx = x - closest.X;
            dy = y - closest.Y;

            if (!IsExtended)
            {
                if (k < 0)
                {
                    closest = new Vector3(x1, y1);
                    dx = x - x1;
                    dy = y - y1;
                }
                else if (k > 1)
                {
                    closest = new Vector3(x2, y2);
                    dx = x - x2;
                    dy = y - y2;
                }
            }
            return Math.Sqrt(dx * dx + dy * dy);
        }
    
    }
}
