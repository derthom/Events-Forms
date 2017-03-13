using Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EventsWeb.Models
{
    public class EventDetailsViewModel 
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public static Expression<Func<Event, EventDetailsViewModel>> ViewModel
        {
            get
            {
                return e => new EventDetailsViewModel()
                {
                    ID = e.ID,
                    Description = e.Description,
                    AuthorId = e.AuthorID,
                    Comments = e.Comments.AsQueryable().Select(CommentViewModel.ViewModel)
                };
            }
        }

    }

}