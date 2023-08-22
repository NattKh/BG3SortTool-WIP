using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using BG3LootTableGenerator.DataStructures;

namespace BG3LootTableGenerator
{
    public partial class UserControl1 : UserControl
    {
    private LootTableGenerator _lootTableGenerator = new();

    // ... rest of the code ...
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            // Open a FolderBrowserDialog to choose the source directory
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxSource.Text = fbd.SelectedPath;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open a FolderBrowserDialog to choose the destination directory
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestination.Text = fbd.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ensure that both source and destination directories are selected
            if (string.IsNullOrEmpty(textBoxSource.Text) || string.IsNullOrEmpty(textBoxDestination.Text))
            {
                MessageBox.Show("Please select both source and destination directories.");
                return;
            }

            // Call the function to process the data from the source and save to the destination
            ProcessData(textBoxSource.Text, textBoxDestination.Text);

            MessageBox.Show("Processing Completed!");
        }

        private void ProcessData(string sourceDir, string destDir)
        {
            _lootTableGenerator.Generate(sourceDir, destDir);
        }
    }
}
