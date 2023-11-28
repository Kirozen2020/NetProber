
using System.Collections.Generic;
using System.Drawing;

namespace NetProber
{
    internal class ShapesParser
    {
        public string filePath;
        public List<string> lines = new List<string>();
        public Dictionary<string, Dictionary<string, List<VertexClass>>> shapes;//info - Dictionary<Subclass name, Dictionary<Refdes name, List<VertexClass>>>

        public ShapesParser(string filePath)
        {
            this.filePath = filePath;

            FileReader fileReader = new FileReader(filePath);
            this.lines = fileReader.TextReader();
        }

        public void FillShapesList()
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

        public VertexClass CreateObj(string[] element)
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
