using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSLogParser
{
    public partial class Form1 : Form
    {
        private Test mainTest = new Test("Log");
        private ImageList imageList = new ImageList();
        private TreeNode m_OldSelectNode;
        public Form1()
        {
            InitializeComponent();
            this.AllowTransparency = true;
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.Images.Add(new Icon("icons/bullet.ico"));
            imageList.Images.Add(new Icon("icons/checkmark.ico"));
            imageList.Images.Add(new Icon("icons/exclamation.ico"));
            imageList.Images.Add(new Icon("icons/x.ico"));
            imageList.Images.Add(new Icon("icons/skipped.ico"));
            treeView.ImageList = imageList;
            treeView.Nodes.Add(mainTest);
            if (canLoadFromClipboard())
            {
                loadFromClipboard();
            }
            else {
                loadFromFile();
            }
        }


        private void toolLoadFile_Click(object sender, EventArgs e)
        {
            loadFromFile();
        }

        private void toolLoadClip_Click(object sender, EventArgs e)
        {
            loadFromClipboard();
        }
        private void loadFromFile()
        {
            string path = "log.txt";

            if (File.Exists(path))
            {
                string input = File.ReadAllText(path);
                if (!String.IsNullOrEmpty(input))
                {
                    loadLog(input);
                    mainTest.Text = "Log (From File)";
                }
            }
            else {
                MessageBox.Show("Error loading from file. Could not find 'log.txt' file.");
            }
        }
        private void loadFromClipboard()
        {
            String returnText = null;
            if (canLoadFromClipboard())
            {
                returnText = Clipboard.GetText();
                loadLog(returnText);
                mainTest.Text = "Log (From Clipboard)";
            }
            else {
                MessageBox.Show("Error loading from clipboard. Could not find valid log data.");
            }
        }
    
        private bool canLoadFromClipboard()
        {
            return (Clipboard.ContainsText() && Clipboard.GetText().Contains("Executing test: "));
        }
        private void loadLog(string logStr)
        {
            mainTest.Nodes.Clear();
            logStr.Replace("\r\n", "\n");
            List<string> logLines = new List<string>(logStr.Split('\n'));
            mainTest.parse(logLines);
            mainTest.Expand();
        }

        private void toolTraceError_Click(object sender, EventArgs e)
        {
            bool done = false;
            TreeNode node = treeView.SelectedNode;
            while (!done)
            {
                done = true;
                foreach(TreeNode child in node.Nodes)
                {
                    if (child.ForeColor == Color.Red)
                    {
                        node = child;
                        treeView.SelectedNode = child;
                        child.Expand();
                        done = false;
                    }
                }
            }
        }

        private void toolExpandAll_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.ExpandAll();
        }

        private void treeView_MouseUp(object sender, MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeView.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    m_OldSelectNode = treeView.SelectedNode;
                    treeView.SelectedNode = node;

                    // Find the appropriate ContextMenu depending on the selected node.

                            contextNodeMenu.Show(treeView, p);


                    // Highlight the selected node.
                    treeView.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }

        private void contextNodeMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treeView.SelectedNode.ForeColor == Color.Red)
            {
                toolTraceError.Visible = true;
            } else
            {

                toolTraceError.Visible = false;
            }

           /* if (treeView.SelectedNode.Nodes.Count > 0)
            {
                toolExpandAll.Visible = true;
            }
            else
            {

                toolExpandAll.Visible = false;
            }*/
        }
    }
}
