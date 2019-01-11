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

        public void SignToEvent(string UserId, string EventId)
        {
            EventRecord eventRecord = new EventRecord();
            eventRecord.RecordId = GenerateId();
            eventRecord.Event = FindEvent(EventId);
            eventRecord.EventId = EventId;
            eventRecord.User = FindUser(UserId);
            eventRecord.UserId = UserId;

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