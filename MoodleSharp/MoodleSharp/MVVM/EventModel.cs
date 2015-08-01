using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoodleSharp.MVVM
{
    class EventCategory
    {
        public string Title { get; set; }
        public List<Event> Events { get; set; }
    }

    class Event
    {
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string ImageUri { get; set; }
        [JsonProperty]
        public string Subtitle { get; set; }
        [JsonProperty]
        public string Category { get; set; }
        [JsonProperty]
        public string Description { get; set; }
    }
}
