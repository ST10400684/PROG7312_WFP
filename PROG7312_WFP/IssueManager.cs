using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


// ---------- COPILOT Edited this class for me to make it that it saves the requests to a text file because mine was not saving for some reason
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
        private static readonly LinkedList<Issue> allReportedIssues = new LinkedList<Issue>();
        private static int nextAvailableIssueId = 1001;
        private static readonly object syncLock = new object();

        // Persistence file path inside AppData\PROG7312_WFP\issues.json
        private static readonly string storageFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "PROG7312_WFP",
            "issues.json"
        );

        static IssueManager()
        {
            LoadIssuesFromFile();
        }

        public static void AddIssue(Issue issueToAdd)
        {
            if (issueToAdd == null)
                throw new ArgumentNullException(nameof(issueToAdd));

            lock (syncLock)
            {
                issueToAdd.IssueId = nextAvailableIssueId++;
                allReportedIssues.AddLast(issueToAdd);
                SaveIssuesToFile();
            }
        }

        public static Issue CreateIssueAndAddToList(string location, string category, string description, string filePath = "")
        {
            var newIssue = new Issue(location, category, description, filePath);
            AddIssue(newIssue);
            return newIssue;
        }

        public static Issue GetIssueById(int issueId)
        {
            lock (syncLock)
            {
                return allReportedIssues.FirstOrDefault(issue => issue.IssueId == issueId);
            }
        }

        public static List<Issue> GetAllIssues()
        {
            lock (syncLock)
            {
                return allReportedIssues.ToList();
            }
        }

        public static bool UpdateIssueStatus(int issueId, string newStatus)
        {
            lock (syncLock)
            {
                var issueToUpdate = GetIssueById(issueId);
                if (issueToUpdate != null)
                {
                    issueToUpdate.Status = newStatus ?? "Submitted";
                    SaveIssuesToFile();
                    return true;
                }
                return false;
            }
        }

        public static bool RemoveIssue(int issueId)
        {
            lock (syncLock)
            {
                var issueToRemove = GetIssueById(issueId);
                if (issueToRemove != null)
                {
                    var removed = allReportedIssues.Remove(issueToRemove);
                    if (removed) SaveIssuesToFile();
                    return removed;
                }
                return false;
            }
        }

        public static int GetTotalIssueCount()
        {
            lock (syncLock)
            {
                return allReportedIssues.Count;
            }
        }

        public static Dictionary<string, int> GetCategorySummary()
        {
            lock (syncLock)
            {
                return allReportedIssues
                    .GroupBy(issue => issue.Category)
                    .ToDictionary(categoryGroup => categoryGroup.Key, categoryGroup => categoryGroup.Count());
            }
        }

        public static Dictionary<string, int> GetStatusSummary()
        {
            lock (syncLock)
            {
                return allReportedIssues
                    .GroupBy(issue => issue.Status)
                    .ToDictionary(statusGroup => statusGroup.Key, statusGroup => statusGroup.Count());
            }
        }

        public static List<Issue> SearchIssues(string searchKeyword)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
                return new List<Issue>();

            searchKeyword = searchKeyword.ToLower();
            lock (syncLock)
            {
                return allReportedIssues.Where(issue =>
                    issue.Location.ToLower().Contains(searchKeyword) ||
                    issue.Description.ToLower().Contains(searchKeyword) ||
                    issue.Category.ToLower().Contains(searchKeyword)).ToList();
            }
        }

        public static List<Issue> GetIssuesReverseChronological()
        {
            lock (syncLock)
            {
                return allReportedIssues.Reverse().ToList();
            }
        }

        public static void ClearAllIssues()
        {
            lock (syncLock)
            {
                allReportedIssues.Clear();
                nextAvailableIssueId = 1001;
                SaveIssuesToFile();
            }
        }

        // Persistence helpers
        private class IssueStore
        {
            public List<Issue> Issues { get; set; } = new List<Issue>();
            public int NextId { get; set; }
        }

        private static void SaveIssuesToFile()
        {
            try
            {
                var dir = Path.GetDirectoryName(storageFilePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var store = new IssueStore
                {
                    Issues = allReportedIssues.ToList(),
                    NextId = nextAvailableIssueId
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(store, options);
                File.WriteAllText(storageFilePath, json);
            }
            catch
            {
                // Silent catch to avoid crashing the UI; in production consider logging properly.
            }
        }

        private static void LoadIssuesFromFile()
        {
            try
            {
                if (!File.Exists(storageFilePath)) return;

                var json = File.ReadAllText(storageFilePath);
                if (string.IsNullOrWhiteSpace(json)) return;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var store = JsonSerializer.Deserialize<IssueStore>(json, options);
                if (store != null)
                {
                    lock (syncLock)
                    {
                        allReportedIssues.Clear();
                        foreach (var issue in store.Issues.OrderBy(i => i.IssueId))
                            allReportedIssues.AddLast(issue);

                        // Restore next id; if missing or lower than existing max, compute next
                        if (store.NextId > 0)
                            nextAvailableIssueId = store.NextId;
                        else if (allReportedIssues.Any())
                            nextAvailableIssueId = allReportedIssues.Max(i => i.IssueId) + 1;
                        else
                            nextAvailableIssueId = 1001;
                    }
                }
            }
            catch
            {
                // Silent catch to avoid crashing the UI; in production consider logging properly.
            }
        }
    }
}