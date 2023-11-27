using System;
using System.IO;
using System.Windows.Forms;

namespace NetProber
{
    public partial class Form1 : Form
    {
        public string selectedFilePath { get; private set; } = string.Empty;

        private string lastSelectedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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
                }
            }
        }
    }
}
