using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetProber
{
    internal class FileReader
    {
        private string filePath;

        public FileReader(string path)
        {
            this.filePath = path;
        }

        public List<string> TextReader()
        {
            List<string> lines = new List<string>();
            try
            {
                lines = File.ReadAllLines(this.filePath).ToList();
            }
            catch
            {
                return null;
            }
            return lines;
        }
    }
}
