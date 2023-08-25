/*using System.IO;
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
            this.Cursor = Cursors.WaitCursor; // Set the cursor to wait mode

            try
            {
                if (string.IsNullOrEmpty(textBoxSource.Text) || string.IsNullOrEmpty(textBoxDestination.Text))
                {
                    MessageBox.Show("Please select both source and destination directories.");
                    return;
                }

                // Call the function to process the data from the source and save to the destination
                ProcessData(textBoxSource.Text, textBoxDestination.Text);

                MessageBox.Show("Processing Completed!");
            }
            finally
            {
                this.Cursor = Cursors.Default; // Ensure the cursor is reset even if there's an error
            }
        }

        private void ProcessData(string sourceDir, string destDir)
        {
            string localizationPath = Path.Combine(sourceDir, "English/Localization/English/english.xml");
            _lootTableGenerator.Generate(sourceDir, destDir, localizationPath);
        }

        private void textBoxDestination_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
*/