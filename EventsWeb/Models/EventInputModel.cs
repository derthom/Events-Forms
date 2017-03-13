using Events.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsWeb.Models
{
    public class EventInputModel
    {
        [Required(ErrorMessage = "Title is mandatory")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Date & Time")]
        public DateTime StartTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsPublic { get; set; }
        public static EventInputModel CreateFromEvent(Event e)
        {
            return new EventInputModel()
            {
                Title = e.Title,
                StartTime = e.StartDateTime,
                Duration = e.Duration,
                Location = e.Location,
                Description = e.Description,
                IsPublic = e.IsPublic
            };
        }
    }
}