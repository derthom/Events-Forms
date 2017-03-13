using Events.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Data
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }
        [Required]
        public string AuthorID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public int EventID { get; set; }
        public virtual ApplicationUser Author{get;set;}
        [Required]
        public string Text { get; set; }
        [Required]
        public virtual Event Event { get; set; }
    }
}
