using System.Collections.Generic;
using System.Drawing;

namespace NetProber
{
    internal class ShapesParser
    {
        /// <summary>
        /// The lines
        /// </summary>
        private List<string> lines = new List<string>();
        /// <summary>
        /// The shapes
        /// </summary>
        public Dictionary<string, Dictionary<string, List<VertexClass>>> shapes;//info - Dictionary<Subclass name, Dictionary<Refdes name, List<VertexClass>>>        
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapesParser"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public ShapesParser(string filePath)
        {
            FileReader fileReader = new FileReader(filePath);
            this.lines = fileReader.TextReader();

            FillShapesList();
        }
        /// <summary>
        /// Fills the shapes list.
        /// </summary>
        private void FillShapesList()
        {
            this.shapes = new Dictionary<string, Dictionary<string, List<VertexClass>>>();
            foreach (var line in this.lines)
            {
                string[] element = line.Split(' ');
                string subclass = element[1];
                string refDes = element[9];
                VertexClass temp = CreateObj(element);

                if (this.shapes.ContainsKey(subclass))
                {
                    if (this.shapes[subclass].ContainsKey(element[0]))
                    {
                        this.shapes[subclass][refDes].Add(temp);
                    }
                    else
                    {
                        this.shapes[subclass][refDes] = new List<VertexClass>() { temp };
                    }
                }
                else
                {
                    this.shapes[subclass].Add(refDes, new List<VertexClass>() { temp });
                }
            }
        }
        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private VertexClass CreateObj(string[] element)
        {
            PointF 
                start = new PointF(float.Parse(element[3]), float.Parse(element[4])),
                end = new PointF(float.Parse(element[5]), float.Parse(element[6])), 
                center;
            double radius;
            int width;
            switch (element[2])
            {
                case "ARC":
                    center = new PointF(float.Parse(element[7]), float.Parse(element[8]));
                    radius = double.Parse(element[9]);
                    width = int.Parse(element[10]);

                    return new VertexClass(VertexClass.Type.ARC, start, end, center, radius, width);

                case "LINE":
                    width = int.Parse(element[7]);

                    return new VertexClass(VertexClass.Type.LINE, start, end, width);
            }
            return null;
        }
    }
}
