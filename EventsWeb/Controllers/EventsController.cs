using Events.Data;
using EventsWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventsWeb.Extensions;

namespace EventsWeb.Controllers
{
    [Authorize]
    public class EventsController : BaseController
    {
        // GET: Events
        
        public ActionResult Create(EventInputModel model)
        {
            if(model!=null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorID = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    Description = model.Description,
                    StartDateTime = model.StartTime,
                    Duration = model.Duration,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };
                this.db.Events.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event Created",NotificationType.INFO);
                return this.RedirectToAction("My");
            }
            return this.View(model);
        }
        public ActionResult My()
        {
            string currentUserId = this.User.Identity.GetUserId();
            var events = this.db.Events
                .Where(e => e.AuthorID == currentUserId)
                .OrderBy(e => e.StartDateTime)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);
            return View(new UpcomingPassedEventsViewModel()
            {
                UpComingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.LoadEvent(id);
            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            var model = EventInputModel.CreateFromEvent(eventToEdit);
            return this.View(model);
        }
        private Event LoadEvent(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventToEdit = this.db.Events
                .Where(e => e.ID == id)
                .FirstOrDefault(e => e.AuthorID == currentUserId || isAdmin);
            return eventToEdit;
        }

    }
}