using System;
//copilot wrote this sample data fro me
namespace PROG7312_WFP
{
    public static class IssueSampleData
    {
        public static void InitializeSampleIssueData()
        {
            // Only load if no issues exist yet
            if (IssueManager.GetTotalIssueCount() > 0)
                return;

            // Create sample issues with varied dates and statuses
            var sampleIssues = new[]
            {
                new
                {
                    Location = "Main Street & 5th Avenue",
                    Category = "Roads",
                    Description = "Large pothole causing traffic hazard. Approximately 2 feet wide and 6 inches deep.",
                    Status = "Under Review",
                    DaysBeforeToday = 2
                },
                new
                {
                    Location = "Greenpoint Park",
                    Category = "Sanitation",
                    Description = "Overflowing trash bins near children's playground. Needs immediate attention.",
                    Status = "In Progress",
                    DaysBeforeToday = 1
                },
                new
                {
                    Location = "Sunset Boulevard",
                    Category = "Street Lighting",
                    Description = "Three consecutive street lights not working. Area is very dark at night.",
                    Status = "Submitted",
                    DaysBeforeToday = 0
                },
                new
                {
                    Location = "Community Center, Oak Street",
                    Category = "Utilities",
                    Description = "Water leak detected near the building foundation. Water pooling on sidewalk.",
                    Status = "In Progress",
                    DaysBeforeToday = 5
                },
                new
                {
                    Location = "Riverside Park",
                    Category = "Parks & Recreation",
                    Description = "Broken swing set in children's area. Two swings have damaged chains.",
                    Status = "Submitted",
                    DaysBeforeToday = 3
                },
                new
                {
                    Location = "Market Square",
                    Category = "Sanitation",
                    Description = "Graffiti on public benches and walls. Requires cleaning and repainting.",
                    Status = "Under Review",
                    DaysBeforeToday = 7
                },
                new
                {
                    Location = "High Street",
                    Category = "Roads",
                    Description = "Damaged road sign making it difficult to read. Sign is bent and faded.",
                    Status = "Submitted",
                    DaysBeforeToday = 4
                },
                new
                {
                    Location = "Central Library Parking",
                    Category = "Street Lighting",
                    Description = "Parking lot lighting insufficient. Several dark spots creating safety concerns.",
                    Status = "Resolved",
                    DaysBeforeToday = 14
                },
                new
                {
                    Location = "Beach Road",
                    Category = "Utilities",
                    Description = "Storm drain blocked with debris. Water not draining properly after rain.",
                    Status = "In Progress",
                    DaysBeforeToday = 6
                },
                new
                {
                    Location = "Northside Community Pool",
                    Category = "Parks & Recreation",
                    Description = "Pool area fence has damaged section. Gap in fence near gate entrance.",
                    Status = "Under Review",
                    DaysBeforeToday = 8
                },
                new
                {
                    Location = "Pine Street Intersection",
                    Category = "Roads",
                    Description = "Traffic light timing issue causing congestion during peak hours.",
                    Status = "Submitted",
                    DaysBeforeToday = 1
                },
                new
                {
                    Location = "Downtown Transit Stop",
                    Category = "Sanitation",
                    Description = "Bus shelter needs cleaning. Trash accumulated and benches dirty.",
                    Status = "Resolved",
                    DaysBeforeToday = 10
                },
                new
                {
                    Location = "Valley View Road",
                    Category = "Roads",
                    Description = "Faded road markings making lanes difficult to see at night and in rain.",
                    Status = "Under Review",
                    DaysBeforeToday = 9
                },
                new
                {
                    Location = "Elmwood Park",
                    Category = "Parks & Recreation",
                    Description = "Picnic tables need repair and maintenance. Several have loose or broken boards.",
                    Status = "Submitted",
                    DaysBeforeToday = 2
                },
                new
                {
                    Location = "Commerce Street",
                    Category = "Utilities",
                    Description = "Fire hydrant leaking water continuously. Creating puddle on sidewalk.",
                    Status = "In Progress",
                    DaysBeforeToday = 3
                }
            };

            foreach (var sampleIssue in sampleIssues)
            {
                var newIssue = new Issue(
                    sampleIssue.Location,
                    sampleIssue.Category,
                    sampleIssue.Description,
                    "" // No file attachment for sample data
                );

                // Adjust the date to be in the past
                newIssue.DateReported = DateTime.Now.AddDays(-sampleIssue.DaysBeforeToday);

                IssueManager.AddIssue(newIssue);
                IssueManager.UpdateIssueStatus(newIssue.IssueId, sampleIssue.Status);
            }
        }
    }
}