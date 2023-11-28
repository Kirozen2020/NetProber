using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NetProber
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Gets the selected file path.
        /// </summary>
        /// <value>
        /// The selected file path.
        /// </value>
        public string selectedFilePath { get; private set; } = string.Empty;
        /// <summary>
        /// The last selected folder
        /// </summary>
        private string lastSelectedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// The dictionary of shapse
        /// </summary>
        private Dictionary<string, Dictionary<string, List<VertexClass>>> dictionaryOfShapse;
        //info - Dictionary<Subclass name, Dictionary<Refdes name, List<VertexClass>>>

        /*-------------------------------------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Click event of the shapesFileToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
