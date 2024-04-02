using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesne_Prog_Proje.Entities
{
    public class Line
		:EntityObject
    {
		private Vector3 startPoint;// line başlangıç noktası
		private Vector3 endPoint;// line bitiş noktası 2 tik
		private double thickness;


		public Line()
			:this(Vector3.Zero,Vector3.Zero)
		{
		}
		public Line(Vector3 start, Vector3 end) 
			:base(EntityType.Line)
		{
			this.startPoint = start;
			this.endPoint = end;
			this.thickness = 0.0;
		}
		public Vector3 EndPoint
		{
			get { return endPoint; }
			set { endPoint = value; }
		}

		public Vector3 StartPoint
		{
			get { return startPoint; }
			set { startPoint = value; }
		}

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

		public double Length
		{
			get
			{
				double dx = endPoint.X - startPoint.X;
				double dy = endPoint.Y - startPoint.Y;
				double dz = endPoint.Z - startPoint.Z;

				return Math.Sqrt(dx * dx + dy * dy + dz * dz);
			}
		}

        public override object Clone()
        {
			return new Line
			{
				StartPoint = this.StartPoint,
				EndPoint = this.EndPoint,
				Thickness = this.Thickness,
				//entity Object Özellikleri
				isVisible = this.isVisible,
			};
        }
    }
}
