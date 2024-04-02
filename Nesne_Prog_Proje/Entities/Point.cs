using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesne_Prog_Proje.Entities
{
    public class Point
		:EntityObject
    {
		private Vector3 position;
		private double thickness;

		public Point()
            : base(EntityType.Point)
        {
			this.Position = Vector3.Zero;
			this.Thickness = 0.0;
		}

		public Point(Vector3 position) 
			:base(EntityType.Point)
		{
			this.Position = position;
			this.Thickness = 0.0;
		}
		public double Thickness //Kalınlık verme
		{
			get { return thickness; }
			set { thickness = value; }
		}

		public Vector3 Position
		{
			get { return position; }
			set { position = value; }
		}

        public override object Clone()
        {
			return new Entities.Point
			{
				Position = this.Position,
				Thickness = this.Thickness,
			     //entity object özellikleri
				IsVisible = this.IsVisible
			};
        }
    }
}
