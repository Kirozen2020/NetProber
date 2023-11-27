using System.Drawing;

namespace NetProber
{
    internal class VertexClass
    {
        public enum Type
        {
            LINE,
            ARC
        }
        public Type shapeType {  get; set; }

        public PointF startX { get; set; }
        public PointF startY { get; set; }
        public PointF endX { get; set; }
        public PointF endY { get; set; }
        public PointF centerX { get; set; }
        public PointF centerY { get; set; }
        public double raduis {  get; set; }
        public int width { get; set; }

        public VertexClass(Type shapeType ,PointF startX, PointF startY, PointF endX, PointF endY, PointF centerX, PointF centerY, double raduis, int width)
        {
            this.shapeType = shapeType;
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
            this.centerX = centerX;
            this.centerY = centerY;
            this.raduis = raduis;
            this.width = width;
        }
    }
}
