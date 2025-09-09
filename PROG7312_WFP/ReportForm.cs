using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PROG7312_WFP
{
    public partial class ReportForm : Form
    {
        // Private field to store the path of the attached file
        private string attachedFilePath = string.Empty;

        public ReportForm()
        {
            InitializeComponent();
            // Call the method to populate the ComboBox when the form loads
            InitializeCategories();
        }

        private void InitializeCategories()
        {
            // Add categories to the dropdown list.
            cmbCategory.Items.Add("Sanitation");
            cmbCategory.Items.Add("Roads");
            cmbCategory.Items.Add("Utilities");
            cmbCategory.Items.Add("General");
        }

        // Event handler for the "Upload" button (btnUpload).
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Set up the OpenFileDialog to filter for specific file types.
            ofdAttachment.Title = "Select an image or document";
            ofdAttachment.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|Document Files|*.pdf;*.doc;*.docx|All Files|*.*";

            // Show the file dialog and check if the user selected a file.
            if (ofdAttachment.ShowDialog() == DialogResult.OK)
            {
                // Store the full path of the selected file.
                attachedFilePath = ofdAttachment.FileName;
                MessageBox.Show($"File attached: {Path.GetFileName(attachedFilePath)}", "Attachment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for the "SUBMIT" button (btnSubmit).
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Validate required fields to ensure all are filled out.
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cmbCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please complete all fields before submitting.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without submitting.
            }

            // 2. Data Handling (For now, we'll just show a message to confirm it works).
            string location = txtLocation.Text;
            string category = cmbCategory.SelectedItem.ToString();
            string description = rtbDescription.Text;

            string reportSummary = $"Report Details:\n\n" +
                                   $"Location: {location}\n" +
                                   $"Category: {category}\n" +
                                   $"Description: {description}\n" +
                                   $"Attachment: {(string.IsNullOrEmpty(attachedFilePath) ? "No" : "Yes")}";

            MessageBox.Show(reportSummary, "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Reset the form for a new entry.
            txtLocation.Clear();
            rtbDescription.Clear();
            cmbCategory.SelectedIndex = -1; // Deselects the item in the dropdown.
            attachedFilePath = string.Empty;
        }

        // Event handler for the "Back" button (btnBack).
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show(); // Show the Main menu form.
            // This closes the current form, taking the user back to the Main menu.
            this.Close();
        }

        // These empty event handlers are kept to match the designer file.
        // It's best to leave them to avoid future synchronization issues.
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void rtbDescription_TextChanged(object sender, EventArgs e) { }
        private void txtLocation_TextChanged(object sender, EventArgs e) { }
    }
}