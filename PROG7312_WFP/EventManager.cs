using PROG7312_WFP;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_WFP
{
    public static class EventManager
    {
        private static SortedDictionary<DateTime, List<Event>> eventsGroupedByDate = new SortedDictionary<DateTime, List<Event>>();
        private static Dictionary<string, List<Event>> eventsGroupedByCategory = new Dictionary<string, List<Event>>();
        private static HashSet<string> allCategories = new HashSet<string>();
        private static Stack<Event> recentlyViewedEvents = new Stack<Event>();
        private static Queue<Event> featuredEventsQueue = new Queue<Event>();
        private static Dictionary<string, int> searchCountByCategory = new Dictionary<string, int>();
        private static Dictionary<DateTime, int> searchCountByDate = new Dictionary<DateTime, int>();
        private static int nextAvailableEventId = 5001;

        public static void InitializeSampleData()
        {
            ClearAllData();

            // Add diverse sample events (20+ entries)
            var events = new List<Event>
            {
                new Event(nextAvailableEventId++, "City Council Meeting", "Government", new DateTime(2025, 10, 15, 18, 0, 0), "Monthly council meeting to discuss municipal matters", "City Hall", "Cape Town Municipality", true),
                new Event(nextAvailableEventId++, "Community Clean-Up Day", "Community", new DateTime(2025, 10, 20, 9, 0, 0), "Join us for a neighborhood clean-up initiative", "Greenpoint Park", "Community Services", true),
                new Event(nextAvailableEventId++, "Water Conservation Workshop", "Education", new DateTime(2025, 10, 22, 14, 0, 0), "Learn about water-saving techniques", "Municipal Library", "Water Department", false),
                new Event(nextAvailableEventId++, "Heritage Day Celebration", "Culture", new DateTime(2025, 10, 24, 10, 0, 0), "Celebrate our diverse heritage with food and music", "Grand Parade", "Cultural Affairs", true),
                new Event(nextAvailableEventId++, "Road Maintenance Notice", "Infrastructure", new DateTime(2025, 10, 18, 6, 0, 0), "Main Road closure for repairs", "Main Road", "Public Works", false),
                new Event(nextAvailableEventId++, "Youth Sports Tournament", "Sports", new DateTime(2025, 10, 28, 8, 0, 0), "Annual youth soccer and netball tournament", "Sports Complex", "Recreation Department", false),
                new Event(nextAvailableEventId++, "Small Business Workshop", "Business", new DateTime(2025, 11, 2, 13, 0, 0), "Support for local entrepreneurs", "Business Hub", "Economic Development", false),
                new Event(nextAvailableEventId++, "Public Safety Forum", "Safety", new DateTime(2025, 11, 5, 19, 0, 0), "Community safety discussion with local police", "Community Center", "Metro Police", true),
                new Event(nextAvailableEventId++, "Environmental Awareness Day", "Environment", new DateTime(2025, 11, 8, 10, 0, 0), "Learn about local environmental initiatives", "Botanical Gardens", "Environmental Services", false),
                new Event(nextAvailableEventId++, "Arts & Crafts Market", "Culture", new DateTime(2025, 11, 12, 9, 0, 0), "Local artisans showcase their work", "Waterfront", "Arts Council", false),
                new Event(nextAvailableEventId++, "Budget Public Hearing", "Government", new DateTime(2025, 11, 15, 18, 30, 0), "Annual budget presentation and public input", "City Hall", "Finance Department", true),
                new Event(nextAvailableEventId++, "Health Screening Day", "Health", new DateTime(2025, 11, 18, 8, 0, 0), "Free health screenings for residents", "Civic Centre", "Health Department", false),
                new Event(nextAvailableEventId++, "Traffic Law Workshop", "Education", new DateTime(2025, 11, 20, 15, 0, 0), "Understanding local traffic regulations", "Training Center", "Metro Police", false),
                new Event(nextAvailableEventId++, "Senior Citizens Tea", "Community", new DateTime(2025, 11, 22, 14, 0, 0), "Social gathering for senior residents", "Senior Center", "Social Services", false),
                new Event(nextAvailableEventId++, "Marathon Event", "Sports", new DateTime(2025, 11, 25, 6, 0, 0), "Annual Cape Town Marathon", "City Center", "Sports Commission", true),
                new Event(nextAvailableEventId++, "Recycling Initiative Launch", "Environment", new DateTime(2025, 11, 28, 11, 0, 0), "New recycling program introduction", "Municipal Offices", "Waste Management", false),
                new Event(nextAvailableEventId++, "Holiday Market", "Business", new DateTime(2025, 12, 5, 9, 0, 0), "Festive shopping market", "Town Square", "Business Association", true),
                new Event(nextAvailableEventId++, "Fire Safety Training", "Safety", new DateTime(2025, 12, 8, 10, 0, 0), "Basic fire safety for residents", "Fire Station", "Fire Department", false),
                new Event(nextAvailableEventId++, "Christmas Carols Concert", "Culture", new DateTime(2025, 12, 15, 18, 0, 0), "Community caroling event", "City Hall Steps", "Cultural Affairs", true),
                new Event(nextAvailableEventId++, "New Year Planning Session", "Government", new DateTime(2025, 12, 20, 16, 0, 0), "2026 municipal planning overview", "Council Chambers", "City Manager", false)
            };

            foreach (var currentEvent in events)
            {
                AddEvent(currentEvent);
            }
        }

        public static void AddEvent(Event eventToAdd)
        {
            if (eventToAdd == null) return;

            // Check if event already exists (prevent duplicates)
            var existingEvents = GetAllEvents();
            if (existingEvents.Any(existingEvent => existingEvent.EventId == eventToAdd.EventId))
            {
                return; // Event already exists, skip adding
            }

            // Add to sorted dictionary by date
            DateTime dateKey = eventToAdd.EventDate.Date;
            if (!eventsGroupedByDate.ContainsKey(dateKey))
            {
                eventsGroupedByDate[dateKey] = new List<Event>();
            }
            eventsGroupedByDate[dateKey].Add(eventToAdd);

            // Add to category dictionary
            if (!eventsGroupedByCategory.ContainsKey(eventToAdd.Category))
            {
                eventsGroupedByCategory[eventToAdd.Category] = new List<Event>();
            }
            eventsGroupedByCategory[eventToAdd.Category].Add(eventToAdd);

            // Add to unique categories set
            allCategories.Add(eventToAdd.Category);

            // Add featured events to queue
            if (eventToAdd.IsFeatured && eventToAdd.EventDate >= DateTime.Now)
            {
                featuredEventsQueue.Enqueue(eventToAdd);
            }
        }

        public static void RecordEventView(Event viewedEvent)
        {
            if (viewedEvent != null && (recentlyViewedEvents.Count == 0 || recentlyViewedEvents.Peek().EventId != viewedEvent.EventId))
            {
                recentlyViewedEvents.Push(viewedEvent);
                if (recentlyViewedEvents.Count > 10)
                {
                    var tempList = recentlyViewedEvents.ToList();
                    tempList.RemoveAt(tempList.Count - 1);
                    recentlyViewedEvents = new Stack<Event>(tempList.Reverse<Event>());
                }
            }
        }

        public static void RecordSearchActivity(string category = null, DateTime? date = null)
        {
            if (!string.IsNullOrEmpty(category))
            {
                if (searchCountByCategory.ContainsKey(category))
                    searchCountByCategory[category]++;
                else
                    searchCountByCategory[category] = 1;
            }

            if (date.HasValue)
            {
                DateTime dateKey = date.Value.Date;
                if (searchCountByDate.ContainsKey(dateKey))
                    searchCountByDate[dateKey]++;
                else
                    searchCountByDate[dateKey] = 1;
            }
        }

        public static List<Event> GetAllEvents()
        {
            return eventsGroupedByDate.Values.SelectMany(eventList => eventList).ToList();
        }

        public static List<Event> SearchEvents(string category = null, DateTime? date = null, string searchText = null)
        {
            RecordSearchActivity(category, date);

            var searchResults = GetAllEvents();

            if (!string.IsNullOrEmpty(category) && category != "All Categories")
            {
                searchResults = searchResults.Where(currentEvent => currentEvent.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (date.HasValue)
            {
                searchResults = searchResults.Where(currentEvent => currentEvent.EventDate.Date == date.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower();
                searchResults = searchResults.Where(currentEvent =>
                    currentEvent.Title.ToLower().Contains(searchText) ||
                    currentEvent.Description.ToLower().Contains(searchText) ||
                    currentEvent.Location.ToLower().Contains(searchText)).ToList();
            }

            return searchResults;
        }

        public static List<Event> SortEvents(List<Event> eventsToSort, string sortBy)
        {
            return sortBy switch
            {
                "Date (Ascending)" => eventsToSort.OrderBy(currentEvent => currentEvent.EventDate).ToList(),
                "Date (Descending)" => eventsToSort.OrderByDescending(currentEvent => currentEvent.EventDate).ToList(),
                "Title (A-Z)" => eventsToSort.OrderBy(currentEvent => currentEvent.Title).ToList(),
                "Title (Z-A)" => eventsToSort.OrderByDescending(currentEvent => currentEvent.Title).ToList(),
                "Category" => eventsToSort.OrderBy(currentEvent => currentEvent.Category).ThenBy(currentEvent => currentEvent.EventDate).ToList(),
                _ => eventsToSort
            };
        }

        public static HashSet<string> GetAllCategories()
        {
            return new HashSet<string>(allCategories);
        }

        public static List<Event> GetRecentlyViewed()
        {
            return recentlyViewedEvents.ToList();
        }

        public static List<Event> GetFeaturedEvents()
        {
            return featuredEventsQueue.ToList();
        }

        public static List<Event> GetRecommendedEvents()
        {
            var recommendations = new List<Event>();
            var allEvents = GetAllEvents();

            // Get top 3 searched categories
            var topSearchedCategories = searchCountByCategory
                .OrderByDescending(categoryGroup => categoryGroup.Value)
                .Take(3)
                .Select(categoryGroup => categoryGroup.Key)
                .ToList();

            // Get events from top categories not in recently viewed
            var recentlyViewedIds = new HashSet<int>(recentlyViewedEvents.Select(currentEvent => currentEvent.EventId));

            foreach (var category in topSearchedCategories)
            {
                var categoryEvents = allEvents
                    .Where(currentEvent => currentEvent.Category == category &&
                                !recentlyViewedIds.Contains(currentEvent.EventId) &&
                                currentEvent.EventDate >= DateTime.Now)
                    .OrderBy(currentEvent => currentEvent.EventDate)
                    .Take(2);

                recommendations.AddRange(categoryEvents);
            }

            // If no search history, recommend featured events
            if (recommendations.Count == 0)
            {
                recommendations = allEvents
                    .Where(currentEvent => currentEvent.IsFeatured && currentEvent.EventDate >= DateTime.Now)
                    .OrderBy(currentEvent => currentEvent.EventDate)
                    .Take(5)
                    .ToList();
            }

            return recommendations.Distinct().Take(6).ToList();
        }

        public static Dictionary<string, int> GetCategoryStatistics()
        {
            return eventsGroupedByCategory.ToDictionary(categoryGroup => categoryGroup.Key, categoryGroup => categoryGroup.Value.Count);
        }

        public static int GetTotalEventCount()
        {
            return GetAllEvents().Count;
        }

        public static void ClearAllData()
        {
            eventsGroupedByDate.Clear();
            eventsGroupedByCategory.Clear();
            allCategories.Clear();
            recentlyViewedEvents.Clear();
            featuredEventsQueue.Clear();
            searchCountByCategory.Clear();
            searchCountByDate.Clear();
            nextAvailableEventId = 5001;
        }
    }
}