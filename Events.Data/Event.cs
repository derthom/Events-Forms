using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Events.Data;

namespace Events.Data
{
    public class Event
    {
        //private bool IsPublic;
        //private DateTime StartDateTime;

        public Event()
        {
            this.IsPublic = true;
            this.StartDateTime = DateTime.Now;
            this.Comments = new HashSet<Comment>();
        }
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public string AuthorID { get; set; }
        public TimeSpan? Duration { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public string Description { set; get; }
        [Required]
        [MaxLength(200)]
        public string Location { get; set; }
        public bool IsPublic { get; set; }
        public virtual ICollection<Comment> Comments { get;  set; }
    }
}
