using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nesne_Prog_Proje
{
	public class Vector3
	{
		private double x;
		private double y;
		private double z;

		public Vector3(double x, double y)//2 boyutlu çizim
		{
			this.X = x;
			this.Y = y;
			this.Z = 0.0;
		}

		public Vector3(double x, double y, double z)
			: this(x, y)
		{
			this.Z = z;
		}


		public double Z
		{
			get { return z; }
			set { z = value; }
		}
		public double Y
		{
			get { return y; }
			set { y = value; }
		}
		public double X
		{
			get { return x; }
			set { x = value; }
		}

		public System.Drawing.PointF ToPointF
		{
			get
			{
				return new System.Drawing.PointF((float)X, (float)Y);
			}
		}

		public static Vector3 Zero
		{
			get { return new Vector3(0.0, 0.0, 0.0); }
		}

		public double DistanceForm(Vector3 v)
		{
			double dx =  v.X - X;
			double dy = v.Y - Y;
			double dz = v.Z - Z;
			return Math.Sqrt(dx * dx + dy * dy + dz * dz);
		}

		public Vector2 ToVector2
		{
			get { return new Vector2(X, Y); }
		}
        public override string ToString()
        {
			return string.Format("{0}, {1}, {2}", X, Y, Z);
        }
    }
}