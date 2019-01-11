using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Models.DB.Tables
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool ConfirmedEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<EventRecord> eventRecords { get; set; }
    }
}