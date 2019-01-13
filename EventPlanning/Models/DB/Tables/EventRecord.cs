using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.DB.Tables
{
    public class EventRecord
    {
        [Key]
        public string RecordId { get; set; }

        public string RecordDescription { get; set; }

        [ForeignKey("Event")]
        public string EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}