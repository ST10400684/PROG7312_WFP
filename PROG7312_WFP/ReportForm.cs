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
        private string selectedFilePath = string.Empty;
        private ProgressBar formCompletionProgressBar;
        private Label motivationalMessageLabel;
        private System.Windows.Forms.Timer motivationalMessageTimer;
        private string[] motivationalMessages = {
            "Thank you for helping improve our community! 🌟",
            "Your voice matters - keep reporting! 💪",
            "Together we make our city better! 🏙️",
            "Every report helps us serve you better! ⭐",
            "You're making a difference! 🎯"
        };
        private int currentMessageIndex = 0;

        public ReportForm()
        {
            InitializeComponent();
            InitializeCategories();
            InitializeEngagementFeatures();
            SetupFormStyling();

            // Setup form closing event to clean up timer
            this.FormClosing += ReportForm_FormClosing;
        }

        private void InitializeCategories()
        {
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add("Sanitation");
            comboBoxCategory.Items.Add("Roads");
            comboBoxCategory.Items.Add("Utilities");
            comboBoxCategory.Items.Add("Parks & Recreation");
            comboBoxCategory.Items.Add("Street Lighting");
            comboBoxCategory.Items.Add("General");
        }

        private void InitializeEngagementFeatures()
        {
            // Create and configure progress bar
            formCompletionProgressBar = new ProgressBar();
            formCompletionProgressBar.Location = new Point(240, 320);
            formCompletionProgressBar.Size = new Size(200, 23);
            formCompletionProgressBar.Minimum = 0;
            formCompletionProgressBar.Maximum = 100;
            formCompletionProgressBar.Value = 0;
            formCompletionProgressBar.Style = ProgressBarStyle.Continuous;
            this.Controls.Add(formCompletionProgressBar);

            // Create engagement label
            motivationalMessageLabel = new Label();
            motivationalMessageLabel.Location = new Point(150, 350);
            motivationalMessageLabel.Size = new Size(400, 20);
            motivationalMessageLabel.Text = "Fill out the form to report your issue!";
            motivationalMessageLabel.ForeColor = Color.DarkBlue;
            motivationalMessageLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(motivationalMessageLabel);

            // Setup timer for rotating encouragement messages
            motivationalMessageTimer = new System.Windows.Forms.Timer();
            motivationalMessageTimer.Interval = 3000; // 3 seconds
            motivationalMessageTimer.Tick += RotateMotivationalMessage;
            motivationalMessageTimer.Start();

            // Update progress when form loads
            UpdateFormCompletionProgress();
        }

        private void SetupFormStyling()
        {
            // Set form properties
            this.Text = "Report Municipal Issue";
            this.BackColor = Color.AliceBlue;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Update label texts - using try-catch to handle potential missing controls
            try
            {
                label1.Text = "Location:";
                label2.Text = "Category:";
                label3.Text = "Description:";
            }
            catch
            {
                // If labels don't exist, they'll be created by the designer
            }

            // Style buttons
            btnSubmit.BackColor = Color.Green;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Segoe UI", 9);

            btnUpload.BackColor = Color.CornflowerBlue;
            btnUpload.ForeColor = Color.White;
        }

        private void RotateMotivationalMessage(object sender, EventArgs e)
        {
            motivationalMessageLabel.Text = motivationalMessages[currentMessageIndex];
            currentMessageIndex = (currentMessageIndex + 1) % motivationalMessages.Length;
        }

        private void UpdateFormCompletionProgress()
        {
            int completionProgress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                completionProgress += 25;

            if (comboBoxCategory.SelectedItem != null)
                completionProgress += 25;

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                completionProgress += 25;

            if (!string.IsNullOrEmpty(selectedFilePath))
                completionProgress += 25;

            formCompletionProgressBar.Value = completionProgress;

            // Update engagement message based on progress
            if (completionProgress == 0)
                motivationalMessageLabel.Text = "Let's get started! Please fill in your issue details.";
            else if (completionProgress < 50)
                motivationalMessageLabel.Text = "Great start! Keep going... 📝";
            else if (completionProgress < 100)
                motivationalMessageLabel.Text = "Almost there! You're doing great! 🎯";
            else
                motivationalMessageLabel.Text = "Perfect! All fields completed. Ready to submit! ✅";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            fileAttachmentDialog.Title = "Select an image or document";
            fileAttachmentDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Document Files|*.pdf;*.doc;*.docx;*.txt|All Files|*.*";

            if (fileAttachmentDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = fileAttachmentDialog.FileName;
                btnUpload.Text = "✓ File Attached";
                btnUpload.BackColor = Color.ForestGreen;
                UpdateFormCompletionProgress();
                MessageBox.Show($"File attached successfully: {Path.GetFileName(selectedFilePath)}",
                    "Attachment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                comboBoxCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please complete all required fields before submitting.\n\n" +
                    "Required: Location, Category, and Description",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new issue object
            Issue newIssueReport = new Issue(
                txtLocation.Text.Trim(),
                comboBoxCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                selectedFilePath
            );

            // Add to issue manager
            IssueManager.AddIssue(newIssueReport);

            // Create detailed report summary
            string reportSummary = $"🎉 Issue Successfully Submitted!\n\n" +
                                   $"Issue ID: #{newIssueReport.IssueId}\n" +
                                   $"Location: {newIssueReport.Location}\n" +
                                   $"Category: {newIssueReport.Category}\n" +
                                   $"Description: {newIssueReport.Description}\n" +
                                   $"Date Submitted: {newIssueReport.DateReported:yyyy-MM-dd HH:mm}\n" +
                                   $"Status: {newIssueReport.Status}\n" +
                                   $"Attachment: {(string.IsNullOrEmpty(selectedFilePath) ? "None" : Path.GetFileName(selectedFilePath))}\n\n" +
                                   $"Total Issues Reported: {IssueManager.GetTotalIssueCount()}\n\n" +
                                   $"Thank you for helping improve our community! 🌟";

            MessageBox.Show(reportSummary, "Report Submitted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset the form for next entry
            ResetFormFields();
        }

        private void ResetFormFields()
        {
            txtLocation.Clear();
            rtbDescription.Clear();
            comboBoxCategory.SelectedIndex = -1;
            selectedFilePath = string.Empty;
            btnUpload.Text = "Upload File";
            btnUpload.BackColor = Color.CornflowerBlue;
            UpdateFormCompletionProgress();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainMenuForm = new Form1();
            mainMenuForm.Show();
            this.Close();
        }

        // Event handler to clean up timer when form is closing
        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            motivationalMessageTimer?.Stop();
            motivationalMessageTimer?.Dispose();
        }

        // Event handlers to update progress as user types/selects
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateFormCompletionProgress();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormCompletionProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateFormCompletionProgress();
        }

        // Empty event handlers for designer compatibility
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) { }
    }
}