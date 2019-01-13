using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.DB.Interaction
{
    public class DBInteraction
    {
        private EventContext eventContext;

        public DBInteraction()
        {
            eventContext = SingeltonContext.getInstance();
        }

        public void CreateUser(string userName, string userEmail, string userPassword)
        {
            User user = new User();
            user.UserId = GenerateId();
            user.Name = userName;
            user.Email = userEmail;
            user.ConfirmedEmail = false;
            user.Password = userPassword;

            eventContext.Users.Add(user);
            SaveChanges();
        }

        public void SignToEvent(string userId, string eventId, string description)
        {
            EventRecord eventRecord = new EventRecord();
            eventRecord.RecordId = GenerateId();
            eventRecord.RecordDescription = description;
            eventRecord.Event = FindEvent(eventId);
            eventRecord.EventId = eventId;
            eventRecord.User = FindUser(userId);
            eventRecord.UserId = userId;

            eventContext.EventRecords.Add(eventRecord);
            SaveChanges();
        }

        public void SetEmailConfirm(string userId)
        {
            FindUser(userId).ConfirmedEmail = true;
            SaveChanges();
        }

        public void DeleteUser(string UserId)
        {
            eventContext.Users.Remove(FindUser(UserId));
            SaveChanges();
        }
        
        public User FindUser(string UserId)
        {
            return eventContext.Users.Find(UserId);
        }

        public Event FindEvent(string EventId)
        {
            return eventContext.Events.Find(EventId);
        }

        public List<Event> ListOfEvent()
        {
            return eventContext.Events.ToList();
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void SaveChanges()
        {
            eventContext.SaveChanges();
        }
    }
}