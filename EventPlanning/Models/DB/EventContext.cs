using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EventPlanning.Models.DB.Tables;

namespace EventPlanning.Models.DB
{
    public class EventContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventField> EventFields { get; set; }
        public DbSet<EventRecord> EventRecords { get; set; }

        public EventContext(): base("EventPlanning")
        { }
    }
}