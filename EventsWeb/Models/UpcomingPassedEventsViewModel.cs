using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsWeb.Models
{
    public class UpcomingPassedEventsViewModel
    {
        public IEnumerable<EventViewModel> UpComingEvents {get; set;}
        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}