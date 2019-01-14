using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.DB.Tables
{
    public class Event
    {
        [Key]
        public string EventId { get; set; }

        public string EventName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public int MaxPeopleCount { get; set; }

        [ForeignKey("User")]
        public string CreatorId { get; set; }
        public User User { get; set; }

        public ICollection<EventField> eventFields { get; set; }

        public ICollection<EventRecord> eventRecords { get; set; }
    }
}