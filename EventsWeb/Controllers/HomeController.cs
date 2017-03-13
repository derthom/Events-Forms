using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Data;
using EventsWeb.Models;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity;

namespace EventsWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var events = this.db.Events.OrderBy(e => e.StartDateTime).Select(EventViewModel.ViewModel);
            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);
            return View(new UpcomingPassedEventsViewModel()
            {
                UpComingEvents = upcomingEvents,
                PassedEvents=passedEvents
            });
        }
        public ActionResult EventDetailsById(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventDetails = this.db.Events.Where(e => e.ID == id).Where(e => e.IsPublic || isAdmin || (e.AuthorID != null && e.AuthorID == currentUserId))
                .Select(EventDetailsViewModel.ViewModel).FirstOrDefault();
            var isOwner = (eventDetails != null && eventDetails.AuthorId != null && eventDetails.AuthorId == currentUserId);
            this.ViewBag.CanEdit = isOwner || isAdmin;
            return this.PartialView("_EventDetails", eventDetails);


        }
    }
   

    
}