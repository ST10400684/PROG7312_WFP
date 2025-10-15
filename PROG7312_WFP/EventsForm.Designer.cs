namespace PROG7312_WFP
{
    partial class EventsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearchKeyword = new System.Windows.Forms.Label();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.panelSort = new System.Windows.Forms.Panel();
            this.lblSort = new System.Windows.Forms.Label();
            this.comboBoxSortOptions = new System.Windows.Forms.ComboBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.richTextBoxEventDetails = new System.Windows.Forms.RichTextBox();
            this.panelRecommendations = new System.Windows.Forms.Panel();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.listBoxRecommendations = new System.Windows.Forms.ListBox();
            this.btnViewRecommendation = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.panelRecommendations.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Events && Announcements";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1070, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Back to Main";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelSearch.Controls.Add(this.lblSearchKeyword);
            this.panelSearch.Controls.Add(this.txtSearchKeyword);
            this.panelSearch.Controls.Add(this.lblCategory);
            this.panelSearch.Controls.Add(this.comboBoxCategory);
            this.panelSearch.Controls.Add(this.lblDate);
            this.panelSearch.Controls.Add(this.dateTimePickerEventDate);
            this.panelSearch.Controls.Add(this.chkUseDate);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.btnClearFilters);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 70);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(10);
            this.panelSearch.Size = new System.Drawing.Size(1200, 100);
            this.panelSearch.TabIndex = 1;
            // 
            // lblSearchKeyword
            // 
            this.lblSearchKeyword.AutoSize = true;
            this.lblSearchKeyword.Location = new System.Drawing.Point(15, 15);
            this.lblSearchKeyword.Name = "lblSearchKeyword";
            this.lblSearchKeyword.Size = new System.Drawing.Size(53, 15);
            this.lblSearchKeyword.TabIndex = 0;
            this.lblSearchKeyword.Text = "Search:";
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Location = new System.Drawing.Point(15, 35);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.PlaceholderText = "Search events...";
            this.txtSearchKeyword.Size = new System.Drawing.Size(200, 23);
            this.txtSearchKeyword.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(235, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(58, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(235, 35);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(180, 23);
            this.comboBoxCategory.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(440, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 15);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Enabled = false;
            this.dateTimePickerEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(440, 35);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(150, 23);
            this.dateTimePickerEventDate.TabIndex = 5;
            // 
            // chkUseDate
            // 
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Location = new System.Drawing.Point(440, 64);
            this.chkUseDate.Name = "chkUseDate";
            this.chkUseDate.Size = new System.Drawing.Size(107, 19);
            this.chkUseDate.TabIndex = 6;
            this.chkUseDate.Text = "Filter by date";
            this.chkUseDate.UseVisualStyleBackColor = true;
            this.chkUseDate.CheckedChanged += new System.EventHandler(this.chkUseDate_CheckedChanged);

            // btnSearch

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(620, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnClearFilters

            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(730, 30);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(100, 30);
            this.btnClearFilters.TabIndex = 8;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);

            // panelSort

            this.panelSort.BackColor = System.Drawing.Color.White;
            this.panelSort.Controls.Add(this.lblSort);
            this.panelSort.Controls.Add(this.comboBoxSortOptions);
            this.panelSort.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSort.Location = new System.Drawing.Point(0, 170);
            this.panelSort.Name = "panelSort";
            this.panelSort.Padding = new System.Windows.Forms.Padding(10);
            this.panelSort.Size = new System.Drawing.Size(1200, 50);
            this.panelSort.TabIndex = 2;

            // lblSort

            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(15, 17);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(50, 15);
            this.lblSort.TabIndex = 0;
            this.lblSort.Text = "Sort by:";

            // comboBoxSortOptions

            this.comboBoxSortOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortOptions.FormattingEnabled = true;
            this.comboBoxSortOptions.Location = new System.Drawing.Point(80, 14);
            this.comboBoxSortOptions.Name = "comboBoxSortOptions";
            this.comboBoxSortOptions.Size = new System.Drawing.Size(180, 23);
            this.comboBoxSortOptions.TabIndex = 1;
            this.comboBoxSortOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortOptions_SelectedIndexChanged);

            // splitContainer

            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 220);
            this.splitContainer.Name = "splitContainer";

            // splitContainer.Panel1

            this.splitContainer.Panel1.Controls.Add(this.listBoxEvents);

            // splitContainer.Panel2

            this.splitContainer.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer.Panel2.Controls.Add(this.panelRecommendations);
            this.splitContainer.Size = new System.Drawing.Size(1200, 506);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 3;

            // listBoxEvents

            this.listBoxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 15;
            this.listBoxEvents.Location = new System.Drawing.Point(0, 0);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(500, 506);
            this.listBoxEvents.TabIndex = 0;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);

            // panelDetails
 
            this.panelDetails.Controls.Add(this.richTextBoxEventDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetails.Size = new System.Drawing.Size(696, 306);
            this.panelDetails.TabIndex = 0;
 
            // richTextBoxEventDetails

            this.richTextBoxEventDetails.BackColor = System.Drawing.Color.White;
            this.richTextBoxEventDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEventDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.richTextBoxEventDetails.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxEventDetails.Name = "richTextBoxEventDetails";
            this.richTextBoxEventDetails.ReadOnly = true;
            this.richTextBoxEventDetails.Size = new System.Drawing.Size(676, 286);
            this.richTextBoxEventDetails.TabIndex = 0;
            this.richTextBoxEventDetails.Text = "Select an event to view details...";

            // panelRecommendations

            this.panelRecommendations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelRecommendations.Controls.Add(this.lblRecommendations);
            this.panelRecommendations.Controls.Add(this.listBoxRecommendations);
            this.panelRecommendations.Controls.Add(this.btnViewRecommendation);
            this.panelRecommendations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRecommendations.Location = new System.Drawing.Point(0, 306);
            this.panelRecommendations.Name = "panelRecommendations";
            this.panelRecommendations.Padding = new System.Windows.Forms.Padding(10);
            this.panelRecommendations.Size = new System.Drawing.Size(696, 200);
            this.panelRecommendations.TabIndex = 1;

            // lblRecommendations

            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecommendations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblRecommendations.Location = new System.Drawing.Point(13, 10);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(176, 19);
            this.lblRecommendations.TabIndex = 0;
            this.lblRecommendations.Text = "⭐ Recommended Events";

            // listBoxRecommendations

            this.listBoxRecommendations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecommendations.FormattingEnabled = true;
            this.listBoxRecommendations.ItemHeight = 15;
            this.listBoxRecommendations.Location = new System.Drawing.Point(13, 35);
            this.listBoxRecommendations.Name = "listBoxRecommendations";
            this.listBoxRecommendations.Size = new System.Drawing.Size(670, 109);
            this.listBoxRecommendations.TabIndex = 1;

            // btnViewRecommendation
 
            this.btnViewRecommendation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewRecommendation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnViewRecommendation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRecommendation.ForeColor = System.Drawing.Color.White;
            this.btnViewRecommendation.Location = new System.Drawing.Point(13, 155);
            this.btnViewRecommendation.Name = "btnViewRecommendation";
            this.btnViewRecommendation.Size = new System.Drawing.Size(150, 30);
            this.btnViewRecommendation.TabIndex = 2;
            this.btnViewRecommendation.Text = "View Selected";
            this.btnViewRecommendation.UseVisualStyleBackColor = false;
            this.btnViewRecommendation.Click += new System.EventHandler(this.btnViewRecommendation_Click);

            // statusStrip

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 726);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";

            // lblStatus

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";

            // EventsForm

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 748);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelSort);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip);
            this.Name = "EventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements";
            this.Load += new System.EventHandler(this.EventsForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelSort.ResumeLayout(false);
            this.panelSort.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelRecommendations.ResumeLayout(false);
            this.panelRecommendations.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearchKeyword;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.CheckBox chkUseDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel panelSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox comboBoxSortOptions;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.RichTextBox richTextBoxEventDetails;
        private System.Windows.Forms.Panel panelRecommendations;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.ListBox listBoxRecommendations;
        private System.Windows.Forms.Button btnViewRecommendation;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}