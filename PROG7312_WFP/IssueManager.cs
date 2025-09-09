using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_WFP
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachedFilePath { get; set; }
        public DateTime DateReported { get; set; }
        public string Status { get; set; }

        public Issue()
        {
            DateReported = DateTime.Now;
            Status = "Submitted";
            Location = "";
            Category = "";
            Description = "";
            AttachedFilePath = "";
        }

        public Issue(string location, string category, string description, string filePath = "")
        {
            Location = location ?? "";
            Category = category ?? "";
            Description = description ?? "";
            AttachedFilePath = filePath ?? "";
            DateReported = DateTime.Now;
            Status = "Submitted";
        }

        public override string ToString()
        {
            return $"Issue #{IssueId}: {Category} at {Location} - {Status}";
        }

        public string GetSummary()
        {
            return $"ID: {IssueId}\n" +
                   $"Location: {Location}\n" +
                   $"Category: {Category}\n" +
                   $"Description: {Description}\n" +
                   $"Date: {DateReported:yyyy-MM-dd HH:mm}\n" +
                   $"Status: {Status}\n" +
                   $"Attachment: {(string.IsNullOrEmpty(AttachedFilePath) ? "None" : "Yes")}";
        }
    }

    public static class IssueManager
    {
        private static List<Issue> reportedIssues = new List<Issue>();

        private static int nextId = 1001;

        public static void AddIssue(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            issue.IssueId = nextId++;
            reportedIssues.Add(issue);
        }

        public static Issue CreateAndAddIssue(string location, string category, string description, string filePath = "")
        {
            var issue = new Issue(location, category, description, filePath);
            AddIssue(issue);
            return issue;
        }

        public static List<Issue> GetAllIssues()
        {
            return new List<Issue>(reportedIssues); 
        }

        public static Issue GetIssueById(int id)
        {
            return reportedIssues.FirstOrDefault(issue => issue.IssueId == id);
        }

        public static int GetTotalIssueCount()
        {
            return reportedIssues.Count;
        }

        public static List<Issue> GetIssuesByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<Issue>();

            return reportedIssues.Where(issue =>
                issue.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Issue> GetIssuesByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return new List<Issue>();

            return reportedIssues.Where(issue =>
                issue.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Issue> GetIssuesByDateRange(DateTime startDate, DateTime endDate)
        {
            return reportedIssues.Where(issue =>
                issue.DateReported >= startDate && issue.DateReported <= endDate).ToList();
        }

        public static bool UpdateIssueStatus(int issueId, string newStatus)
        {
            var issue = GetIssueById(issueId);
            if (issue != null)
            {
                issue.Status = newStatus ?? "Submitted";
                return true;
            }
            return false;
        }

        public static Dictionary<string, int> GetCategorySummary()
        {
            return reportedIssues
                .GroupBy(issue => issue.Category)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public static Dictionary<string, int> GetStatusSummary()
        {
            return reportedIssues
                .GroupBy(issue => issue.Status)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public static List<Issue> SearchIssues(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return new List<Issue>();

            searchText = searchText.ToLower();
            return reportedIssues.Where(issue =>
                issue.Location.ToLower().Contains(searchText) ||
                issue.Description.ToLower().Contains(searchText) ||
                issue.Category.ToLower().Contains(searchText)).ToList();
        }

        public static bool RemoveIssue(int issueId)
        {
            var issue = GetIssueById(issueId);
            if (issue != null)
            {
                return reportedIssues.Remove(issue);
            }
            return false;
        }

        public static void ClearAllIssues()
        {
            reportedIssues.Clear();
            nextId = 1001;
        }
        //
        public static List<Issue> GetRecentIssues(int count = 10)
        {
            return reportedIssues
                .OrderByDescending(issue => issue.DateReported)
                .Take(count)
                .ToList();
        }
    }
} 