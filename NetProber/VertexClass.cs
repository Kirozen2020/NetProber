using System.Drawing;

namespace NetProber
{
    /// <summary>
    /// Represents a vertex of a line or an arc in a graphical context.
    /// </summary>
    public class VertexClass
    {
        public enum Type
        {
            LINE,
            ARC
        }
        public Type shapeType {  get; set; }

        public PointF start { get; set; }
        public PointF end { get; set; }
        public PointF center { get; set; }
        public double raduis {  get; set; }
        public int width { get; set; }

        /// <summary>
        /// Constructor for a line vertex.
        /// </summary>
        public VertexClass(Type shapeType, PointF start, PointF end, int width)
        {
            this.shapeType = shapeType;
            this.start = start;
            this.end = end;
            this.width = width;
        }

        /// <summary>
        /// Constructor for an arc vertex.
        /// </summary>
        public VertexClass(Type shapeType, PointF start, PointF end, PointF center, double raduis, int width)
        {
            this.shapeType = shapeType;
            this.start = start;
            this.end = end;
            this.center = center;
            this.raduis = raduis;
            this.width = width;
        }
    }
}
