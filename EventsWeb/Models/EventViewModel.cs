using Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using EventsWeb.Models;

namespace EventsWeb.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }
        
        
        public string Title { get; set; }
        
        public DateTime StartDateTime { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
       
        public string Description { set; get; }
        
        
        public string Location { get; set; }

        public static Expression<Func<Event, EventViewModel>> ViewModel
        {
            get
            {
                return e => new EventViewModel()
                {
                    ID = e.ID,
                    Title = e.Title,
                    StartDateTime = e.StartDateTime,
                    Duration = e.Duration,
                    Author = e.Author.FullName,
                    Location = e.Location
                };
            }
        }
        
    }
}