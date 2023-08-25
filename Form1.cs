using BG3LootTableGenerator.DataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BG3LootTableGenerator
{


    public partial class Form1 : Form
    {
        private LootTableGenerator _lootTableGenerator;
        private Tags _tags;

        public Form1()
        {
            InitializeComponent();

            // Check if there's a saved XML path in the settings
            string savedXmlPath = Properties.Settings.Default.XmlFilePath;
            if (!string.IsNullOrEmpty(savedXmlPath))
            {
                // Initialize the LootTableGenerator with the saved path
                _lootTableGenerator = new LootTableGenerator(savedXmlPath);
            }
            else
            {
                // Initialize the LootTableGenerator without a path
                _lootTableGenerator = new LootTableGenerator();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // in case I want to add a note
            // MessageBox.Show("Form has been loaded!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Your existing logic for button1
        }

        private void itemsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Add the DisplayItemDetails method here
        private void DisplayItemDetails()
        {
            if (itemsGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = itemsGrid.SelectedRows[0];
                ItemEntry selectedItem = (ItemEntry)selectedRow.DataBoundItem;

                nameLabel.Text = selectedItem.Name;
                inheritanceLabel.Text = selectedItem.Inheritance ?? "N/A";
                mapKeyLabel.Text = selectedItem.MapKey;
                pathTextBox.Text = selectedItem.Path;

                // Displaying the Stats from ItemEntryData for simplicity. Adjust as needed.
                dataTextBox.Text = selectedItem.Data.Stats ?? "N/A";

                // Displaying the DisplayName from ItemEntryLocalization for simplicity. Adjust as needed.
                localizationTextBox.Text = selectedItem.Localization.DisplayName ?? "N/A";
            }
        }


        private void itemsGrid_SelectionChanged(object sender, EventArgs e)
        {
            DisplayItemDetails();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void inheritanceLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void mapKeyLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void inheritanceDescriptorLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadItemsToGrid(List<ItemEntry> items)
        {
            itemsGrid.DataSource = null; // Clear the existing data source
            itemsGrid.DataSource = items; // Bind the new data source
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            // Get the user's search query from the text box
            string query = searchTextBox.Text;

            // Use the LootTableGenerator to search for items
            var matchingItems = _lootTableGenerator.SearchItems(query);

            // Display the matching items in your grid or list
            LoadItemsToGrid(matchingItems.ToList());
        }

        private void LoadTagsButton_Click(object sender, EventArgs e)
        {
            _tags = new Tags(_lootTableGenerator.LoadOrder);
            UpdateTagList();
        }

        private void UpdateTagList()
        {
            tagList.Items.Clear();
            foreach (var tagName in _tags.GetAllTagNames())
            {
                tagList.Items.Add(tagName);
            }
        }


        private void tagsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void loadXmlButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                Title = "Select the XML file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;

                // Save the path to the settings
                Properties.Settings.Default.XmlFilePath = selectedPath;
                Properties.Settings.Default.Save();

                // Re-initialize the LootTableGenerator with the new path
                _lootTableGenerator = new LootTableGenerator(selectedPath);
                MessageBox.Show("XML file loaded successfully!");

                // Update the label with the item count
                lblItemCount.Text = $"Total Items: {_lootTableGenerator.ItemCount}";
            }
        }


        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        //Loadtagslogic
        //call for loottablegenerator logic
    }
}

