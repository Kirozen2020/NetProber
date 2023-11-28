using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NetProber
{
    public partial class Form1 : Form
    {

        public string selectedFilePath { get; private set; } = string.Empty;

        private string lastSelectedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private Dictionary<string, Dictionary<string, List<VertexClass>>> dictionaryOfShapse;
        //info - Dictionary<Subclass name, Dictionary<Refdes name, List<VertexClass>>>

        /*-------------------------------------------------------------------------------------------------------------------------*/

        public Form1()
        {
            InitializeComponent();
        }

        private void shapesFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = lastSelectedFolder;
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.lastSelectedFolder = Path.GetDirectoryName(openFileDialog.FileName);
                    this.selectedFilePath = openFileDialog.FileName;
                    ShapesParser shapesParser = new ShapesParser(this.selectedFilePath);
                    this.dictionaryOfShapse = shapesParser.shapes;
                }
            }
        }
    }
}
