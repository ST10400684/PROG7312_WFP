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
            Location = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            AttachedFilePath = string.Empty;
        }

        public Issue(string location, string category, string description, string filePath = "")
        {
            Location = location ?? string.Empty;
            Category = category ?? string.Empty;
            Description = description ?? string.Empty;
            AttachedFilePath = filePath ?? string.Empty;
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
        private static LinkedList<Issue> reportedIssues = new LinkedList<Issue>();
        private static int nextId = 1001;

        public static void AddIssue(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            issue.IssueId = nextId++;
            reportedIssues.AddLast(issue);
        }

        public static Issue CreateAndAddIssue(string location, string category, string description, string filePath = "")
        {
            var issue = new Issue(location, category, description, filePath);
            AddIssue(issue);
            return issue;
        }

        public static Issue GetIssueById(int id)
        {
            return reportedIssues.FirstOrDefault(issue => issue.IssueId == id);
        }

        public static List<Issue> GetAllIssues()
        {
            return reportedIssues.ToList();
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

        public static bool RemoveIssue(int issueId)
        {
            var issue = GetIssueById(issueId);
            if (issue != null)
            {
                return reportedIssues.Remove(issue);
            }
            return false;
        }

        public static int GetTotalIssueCount()
        {
            return reportedIssues.Count;
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

        public static List<Issue> GetIssuesReverseChronological()
        {
            return reportedIssues.Reverse().ToList();
        }

        public static void ClearAllIssues()
        {
            reportedIssues.Clear();
            nextId = 1001;
        }
    }
}