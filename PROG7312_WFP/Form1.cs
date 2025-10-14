using System;
using System.Windows.Forms;

namespace PROG7312_WFP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form load logic
        }

        private void knoppie1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Report Issues menu item
            ShowReportForm();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Local Events and Announcements menu item
            ShowEventsForm();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Service Request Status menu item (To be implemented in Part 3)
            MessageBox.Show("Service Request Status feature will be implemented in Part 3.",
                "Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ShowReportForm()
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            this.Hide();
        }

        private void ShowEventsForm()
        {
            EventsForm eventsForm = new EventsForm();
            eventsForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Unused
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // Unused
        }
    }
}