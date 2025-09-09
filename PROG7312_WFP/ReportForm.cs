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
        private string attachedFilePath = string.Empty;
        private ProgressBar progressBar;
        private Label engagementLabel;
        private System.Windows.Forms.Timer encouragementTimer;
        private string[] encouragementMessages = {
            "Thank you for helping improve our community! 🌟",
            "Your voice matters - keep reporting! 💪",
            "Together we make our city better! 🏙️",
            "Every report helps us serve you better! ⭐",
            "You're making a difference! 🎯"
        };
        private int messageIndex = 0;

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
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Sanitation");
            cmbCategory.Items.Add("Roads");
            cmbCategory.Items.Add("Utilities");
            cmbCategory.Items.Add("Parks & Recreation");
            cmbCategory.Items.Add("Street Lighting");
            cmbCategory.Items.Add("General");
        }

        private void InitializeEngagementFeatures()
        {
            // Create and configure progress bar
            progressBar = new ProgressBar();
            progressBar.Location = new Point(240, 320);
            progressBar.Size = new Size(200, 23);
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Continuous;
            this.Controls.Add(progressBar);

            // Create engagement label
            engagementLabel = new Label();
            engagementLabel.Location = new Point(150, 350);
            engagementLabel.Size = new Size(400, 20);
            engagementLabel.Text = "Fill out the form to report your issue!";
            engagementLabel.ForeColor = Color.DarkBlue;
            engagementLabel.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(engagementLabel);

            // Setup timer for rotating encouragement messages
            encouragementTimer = new System.Windows.Forms.Timer();
            encouragementTimer.Interval = 3000; // 3 seconds
            encouragementTimer.Tick += EncouragementTimer_Tick;
            encouragementTimer.Start();

            // Update progress when form loads
            UpdateProgress();
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

        private void EncouragementTimer_Tick(object sender, EventArgs e)
        {
            engagementLabel.Text = encouragementMessages[messageIndex];
            messageIndex = (messageIndex + 1) % encouragementMessages.Length;
        }

        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                progress += 25;

            if (cmbCategory.SelectedItem != null)
                progress += 25;

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                progress += 25;

            if (!string.IsNullOrEmpty(attachedFilePath))
                progress += 25;

            progressBar.Value = progress;

            // Update engagement message based on progress
            if (progress == 0)
                engagementLabel.Text = "Let's get started! Please fill in your issue details.";
            else if (progress < 50)
                engagementLabel.Text = "Great start! Keep going... 📝";
            else if (progress < 100)
                engagementLabel.Text = "Almost there! You're doing great! 🎯";
            else
                engagementLabel.Text = "Perfect! All fields completed. Ready to submit! ✅";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            ofdAttachment.Title = "Select an image or document";
            ofdAttachment.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Document Files|*.pdf;*.doc;*.docx;*.txt|All Files|*.*";

            if (ofdAttachment.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = ofdAttachment.FileName;
                btnUpload.Text = "✓ File Attached";
                btnUpload.BackColor = Color.ForestGreen;
                UpdateProgress();
                MessageBox.Show($"File attached successfully: {Path.GetFileName(attachedFilePath)}",
                    "Attachment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cmbCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please complete all required fields before submitting.\n\n" +
                    "Required: Location, Category, and Description",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new issue object
            Issue newIssue = new Issue(
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                attachedFilePath
            );

            // Add to issue manager
            IssueManager.AddIssue(newIssue);

            // Create detailed report summary
            string reportSummary = $"🎉 Issue Successfully Submitted!\n\n" +
                                   $"Issue ID: #{newIssue.IssueId}\n" +
                                   $"Location: {newIssue.Location}\n" +
                                   $"Category: {newIssue.Category}\n" +
                                   $"Description: {newIssue.Description}\n" +
                                   $"Date Submitted: {newIssue.DateReported:yyyy-MM-dd HH:mm}\n" +
                                   $"Status: {newIssue.Status}\n" +
                                   $"Attachment: {(string.IsNullOrEmpty(attachedFilePath) ? "None" : Path.GetFileName(attachedFilePath))}\n\n" +
                                   $"Total Issues Reported: {IssueManager.GetTotalIssueCount()}\n\n" +
                                   $"Thank you for helping improve our community! 🌟";

            MessageBox.Show(reportSummary, "Report Submitted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset the form for next entry
            ResetForm();
        }

        private void ResetForm()
        {
            txtLocation.Clear();
            rtbDescription.Clear();
            cmbCategory.SelectedIndex = -1;
            attachedFilePath = string.Empty;
            btnUpload.Text = "Upload File";
            btnUpload.BackColor = Color.CornflowerBlue;
            UpdateProgress();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        // Event handler to clean up timer when form is closing
        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            encouragementTimer?.Stop();
            encouragementTimer?.Dispose();
        }

        // Event handlers to update progress as user types/selects
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        // Empty event handlers for designer compatibility
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) { }
    }
}