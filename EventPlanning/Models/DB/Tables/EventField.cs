using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.DB.Tables
{
    public class EventField
    {
        [Key]
        public string FieldId { get; set; }

        public string FieldName { get; set; }

        public string FieldText { get; set; }

        [ForeignKey("Event")]
        public string EventId { get; set; }
        public Event Event { get; set; }

    }
}