using PROG7312_WFP;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_WFP
{
    public static class EventManager
    {
        // Sorted Dictionary for efficient date-based organization
        private static SortedDictionary<DateTime, List<Event>> eventsByDate = new SortedDictionary<DateTime, List<Event>>();

        // Dictionary for category-based storage
        private static Dictionary<string, List<Event>> eventsByCategory = new Dictionary<string, List<Event>>();

        // HashSet for unique categories
        private static HashSet<string> uniqueCategories = new HashSet<string>();

        // Stack for recently viewed events
        private static Stack<Event> recentlyViewed = new Stack<Event>();

        // Queue for upcoming featured events
        private static Queue<Event> featuredQueue = new Queue<Event>();

        // User search pattern tracking for recommendations
        private static Dictionary<string, int> categorySearchCount = new Dictionary<string, int>();
        private static Dictionary<DateTime, int> dateSearchCount = new Dictionary<DateTime, int>();

        private static int nextEventId = 5001;

        public static void InitializeSampleData()
        {
            ClearAllData();

            // Add diverse sample events (20+ entries)
            var events = new List<Event>
            {
                new Event(nextEventId++, "City Council Meeting", "Government", new DateTime(2025, 10, 15, 18, 0, 0), "Monthly council meeting to discuss municipal matters", "City Hall", "Cape Town Municipality", true),
                new Event(nextEventId++, "Community Clean-Up Day", "Community", new DateTime(2025, 10, 20, 9, 0, 0), "Join us for a neighborhood clean-up initiative", "Greenpoint Park", "Community Services", true),
                new Event(nextEventId++, "Water Conservation Workshop", "Education", new DateTime(2025, 10, 22, 14, 0, 0), "Learn about water-saving techniques", "Municipal Library", "Water Department", false),
                new Event(nextEventId++, "Heritage Day Celebration", "Culture", new DateTime(2025, 10, 24, 10, 0, 0), "Celebrate our diverse heritage with food and music", "Grand Parade", "Cultural Affairs", true),
                new Event(nextEventId++, "Road Maintenance Notice", "Infrastructure", new DateTime(2025, 10, 18, 6, 0, 0), "Main Road closure for repairs", "Main Road", "Public Works", false),
                new Event(nextEventId++, "Youth Sports Tournament", "Sports", new DateTime(2025, 10, 28, 8, 0, 0), "Annual youth soccer and netball tournament", "Sports Complex", "Recreation Department", false),
                new Event(nextEventId++, "Small Business Workshop", "Business", new DateTime(2025, 11, 2, 13, 0, 0), "Support for local entrepreneurs", "Business Hub", "Economic Development", false),
                new Event(nextEventId++, "Public Safety Forum", "Safety", new DateTime(2025, 11, 5, 19, 0, 0), "Community safety discussion with local police", "Community Center", "Metro Police", true),
                new Event(nextEventId++, "Environmental Awareness Day", "Environment", new DateTime(2025, 11, 8, 10, 0, 0), "Learn about local environmental initiatives", "Botanical Gardens", "Environmental Services", false),
                new Event(nextEventId++, "Arts & Crafts Market", "Culture", new DateTime(2025, 11, 12, 9, 0, 0), "Local artisans showcase their work", "Waterfront", "Arts Council", false),
                new Event(nextEventId++, "Budget Public Hearing", "Government", new DateTime(2025, 11, 15, 18, 30, 0), "Annual budget presentation and public input", "City Hall", "Finance Department", true),
                new Event(nextEventId++, "Health Screening Day", "Health", new DateTime(2025, 11, 18, 8, 0, 0), "Free health screenings for residents", "Civic Centre", "Health Department", false),
                new Event(nextEventId++, "Traffic Law Workshop", "Education", new DateTime(2025, 11, 20, 15, 0, 0), "Understanding local traffic regulations", "Training Center", "Metro Police", false),
                new Event(nextEventId++, "Senior Citizens Tea", "Community", new DateTime(2025, 11, 22, 14, 0, 0), "Social gathering for senior residents", "Senior Center", "Social Services", false),
                new Event(nextEventId++, "Marathon Event", "Sports", new DateTime(2025, 11, 25, 6, 0, 0), "Annual Cape Town Marathon", "City Center", "Sports Commission", true),
                new Event(nextEventId++, "Recycling Initiative Launch", "Environment", new DateTime(2025, 11, 28, 11, 0, 0), "New recycling program introduction", "Municipal Offices", "Waste Management", false),
                new Event(nextEventId++, "Holiday Market", "Business", new DateTime(2025, 12, 5, 9, 0, 0), "Festive shopping market", "Town Square", "Business Association", true),
                new Event(nextEventId++, "Fire Safety Training", "Safety", new DateTime(2025, 12, 8, 10, 0, 0), "Basic fire safety for residents", "Fire Station", "Fire Department", false),
                new Event(nextEventId++, "Christmas Carols Concert", "Culture", new DateTime(2025, 12, 15, 18, 0, 0), "Community caroling event", "City Hall Steps", "Cultural Affairs", true),
                new Event(nextEventId++, "New Year Planning Session", "Government", new DateTime(2025, 12, 20, 16, 0, 0), "2026 municipal planning overview", "Council Chambers", "City Manager", false)
            };

            foreach (var evt in events)
            {
                AddEvent(evt);
            }
        }

        public static void AddEvent(Event evt)
        {
            if (evt == null) return;

            // Check if event already exists (prevent duplicates)
            var existingEvents = GetAllEvents();
            if (existingEvents.Any(e => e.EventId == evt.EventId))
            {
                return; // Event already exists, skip adding
            }

            // Add to sorted dictionary by date
            DateTime dateKey = evt.EventDate.Date;
            if (!eventsByDate.ContainsKey(dateKey))
            {
                eventsByDate[dateKey] = new List<Event>();
            }
            eventsByDate[dateKey].Add(evt);

            // Add to category dictionary
            if (!eventsByCategory.ContainsKey(evt.Category))
            {
                eventsByCategory[evt.Category] = new List<Event>();
            }
            eventsByCategory[evt.Category].Add(evt);

            // Add to unique categories set
            uniqueCategories.Add(evt.Category);

            // Add featured events to queue
            if (evt.IsFeatured && evt.EventDate >= DateTime.Now)
            {
                featuredQueue.Enqueue(evt);
            }
        }

        public static void TrackEventView(Event evt)
        {
            if (evt != null && (recentlyViewed.Count == 0 || recentlyViewed.Peek().EventId != evt.EventId))
            {
                recentlyViewed.Push(evt);
                if (recentlyViewed.Count > 10)
                {
                    var temp = recentlyViewed.ToList();
                    temp.RemoveAt(temp.Count - 1);
                    recentlyViewed = new Stack<Event>(temp.Reverse<Event>());
                }
            }
        }

        public static void TrackSearch(string category = null, DateTime? date = null)
        {
            if (!string.IsNullOrEmpty(category))
            {
                if (categorySearchCount.ContainsKey(category))
                    categorySearchCount[category]++;
                else
                    categorySearchCount[category] = 1;
            }

            if (date.HasValue)
            {
                DateTime dateKey = date.Value.Date;
                if (dateSearchCount.ContainsKey(dateKey))
                    dateSearchCount[dateKey]++;
                else
                    dateSearchCount[dateKey] = 1;
            }
        }

        public static List<Event> GetAllEvents()
        {
            return eventsByDate.Values.SelectMany(list => list).ToList();
        }

        public static List<Event> SearchEvents(string category = null, DateTime? date = null, string searchText = null)
        {
            TrackSearch(category, date);

            var results = GetAllEvents();

            if (!string.IsNullOrEmpty(category) && category != "All Categories")
            {
                results = results.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (date.HasValue)
            {
                results = results.Where(e => e.EventDate.Date == date.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                results = results.Where(e =>
                    e.Title.ToLower().Contains(searchText) ||
                    e.Description.ToLower().Contains(searchText) ||
                    e.Location.ToLower().Contains(searchText)).ToList();
            }

            return results;
        }

        public static List<Event> SortEvents(List<Event> events, string sortBy)
        {
            return sortBy switch
            {
                "Date (Ascending)" => events.OrderBy(e => e.EventDate).ToList(),
                "Date (Descending)" => events.OrderByDescending(e => e.EventDate).ToList(),
                "Title (A-Z)" => events.OrderBy(e => e.Title).ToList(),
                "Title (Z-A)" => events.OrderByDescending(e => e.Title).ToList(),
                "Category" => events.OrderBy(e => e.Category).ThenBy(e => e.EventDate).ToList(),
                _ => events
            };
        }

        public static HashSet<string> GetAllCategories()
        {
            return new HashSet<string>(uniqueCategories);
        }

        public static List<Event> GetRecentlyViewed()
        {
            return recentlyViewed.ToList();
        }

        public static List<Event> GetFeaturedEvents()
        {
            return featuredQueue.ToList();
        }

        public static List<Event> GetRecommendedEvents()
        {
            var recommendations = new List<Event>();
            var allEvents = GetAllEvents();

            // Get top 3 searched categories
            var topCategories = categorySearchCount
                .OrderByDescending(kvp => kvp.Value)
                .Take(3)
                .Select(kvp => kvp.Key)
                .ToList();

            // Get events from top categories not in recently viewed
            var recentIds = new HashSet<int>(recentlyViewed.Select(e => e.EventId));

            foreach (var category in topCategories)
            {
                var categoryEvents = allEvents
                    .Where(e => e.Category == category &&
                                !recentIds.Contains(e.EventId) &&
                                e.EventDate >= DateTime.Now)
                    .OrderBy(e => e.EventDate)
                    .Take(2);

                recommendations.AddRange(categoryEvents);
            }

            // If no search history, recommend featured events
            if (recommendations.Count == 0)
            {
                recommendations = allEvents
                    .Where(e => e.IsFeatured && e.EventDate >= DateTime.Now)
                    .OrderBy(e => e.EventDate)
                    .Take(5)
                    .ToList();
            }

            return recommendations.Distinct().Take(6).ToList();
        }

        public static Dictionary<string, int> GetCategoryStatistics()
        {
            return eventsByCategory.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Count);
        }

        public static int GetTotalEventCount()
        {
            return GetAllEvents().Count;
        }

        public static void ClearAllData()
        {
            eventsByDate.Clear();
            eventsByCategory.Clear();
            uniqueCategories.Clear();
            recentlyViewed.Clear();
            featuredQueue.Clear();
            categorySearchCount.Clear();
            dateSearchCount.Clear();
            nextEventId = 5001;
        }
    }
}