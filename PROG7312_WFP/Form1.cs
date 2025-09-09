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

        private void button1_Click(object sender, EventArgs e)
        {
            // The button is no longer needed, but we can reuse its logic.
            ShowReportForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Add logic for 'Local Events and Announcements' here.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add logic for 'Service Request Status' here.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This event is unused, but you can keep it empty if you want.
        }

        private void knoppie1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportForm();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // This is the menu item for "Local Events and Announcements".
            // Add logic here.
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // This is the menu item for "Service Request Status".
            // Add logic here.
        }

        private void ShowReportForm()
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}