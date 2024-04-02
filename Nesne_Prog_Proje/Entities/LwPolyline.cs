using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesne_Prog_Proje.Entities
{
    public class LwPolyline
        :EntityObject
    {
        private List<LwPolylineVertex> vertexes;
        private PolylineTypeFlags flags;
        private double thickness;

        public LwPolyline()
            :this(new List<LwPolylineVertex>(),false)
        { 
        }
        public LwPolyline(List<LwPolylineVertex> vertexes, bool IsClosed)
            :base(EntityType.LwPolyline)
        {
            if (vertexes == null)
                throw new ArgumentNullException(nameof(vertexes));
            this.vertexes = vertexes;
            this.flags = IsClosed ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline;
            this.thickness = 0.0;
        }

        public List<LwPolylineVertex> Vertexes
        {
            get { return this.vertexes; }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(vertexes));
                this.vertexes = value;               
            }
        }
        internal PolylineTypeFlags Flags
        {
            get { return this.flags; }
            set { this.flags = value; }
        }

        public bool IsClosed //open or closed
        {
            get { return (this.flags & PolylineTypeFlags.CloseLwPolyline) == PolylineTypeFlags.CloseLwPolyline; }
            set { this.flags = value ? PolylineTypeFlags.CloseLwPolyline : PolylineTypeFlags.OpenLwPolyline; }
        }
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public override object Clone()
        {
            List<LwPolylineVertex> vertexes_copy = new List<LwPolylineVertex>();
            foreach (LwPolylineVertex vertex in this.vertexes)
            {
                vertexes_copy.Add((LwPolylineVertex)vertex.Clone());
            }
            return new LwPolyline
            {
                Vertexes = vertexes_copy,
                Flags = this.flags,
                Thickness = this.thickness,
                //Entity Object özellikleri
                IsVisible = this.isVisible
            };
        }
    }
}
