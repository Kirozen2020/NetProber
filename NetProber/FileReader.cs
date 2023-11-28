using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetProber
{
    internal class FileReader
    {
        /// <summary>
        /// The file path
        /// </summary>
        private string filePath;
        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public FileReader(string path)
        {
            this.filePath = path;
        }
        /// <summary>
        /// Texts the reader.
        /// </summary>
        /// <returns></returns>
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
