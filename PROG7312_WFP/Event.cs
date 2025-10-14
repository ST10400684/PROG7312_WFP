using System;

namespace PROG7312_WFP
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public bool IsFeatured { get; set; }

        public Event()
        {
            Title = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            Location = string.Empty;
            Organizer = string.Empty;
            EventDate = DateTime.Now;
            IsFeatured = false;
        }

        public Event(int id, string title, string category, DateTime date, string description, string location, string organizer, bool featured = false)
        {
            EventId = id;
            Title = title ?? string.Empty;
            Category = category ?? string.Empty;
            EventDate = date;
            Description = description ?? string.Empty;
            Location = location ?? string.Empty;
            Organizer = organizer ?? string.Empty;
            IsFeatured = featured;
        }

        public override string ToString()
        {
            return $"{Title} - {EventDate:MMM dd, yyyy} ({Category})";
        }

        public string GetDetailedInfo()
        {
            return $"Event ID: {EventId}\n" +
                   $"Title: {Title}\n" +
                   $"Category: {Category}\n" +
                   $"Date: {EventDate:dddd, MMMM dd, yyyy}\n" +
                   $"Time: {EventDate:hh:mm tt}\n" +
                   $"Location: {Location}\n" +
                   $"Organizer: {Organizer}\n" +
                   $"Description: {Description}\n" +
                   $"Featured: {(IsFeatured ? "Yes" : "No")}";
        }
    }
}