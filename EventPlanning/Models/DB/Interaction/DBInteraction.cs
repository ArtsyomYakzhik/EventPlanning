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

        public string CreateEvent(Event newEvent)
        {
            newEvent.EventId = GenerateId();
            eventContext.Events.Add(newEvent);
            SaveChanges();
            return newEvent.EventId;
        }

        public void AddEventField(string eventId, string fieldName, string fieldText)
        {
            EventField eventField = new EventField() {
                FieldId = GenerateId(),
                FieldName = fieldName,
                FieldText = fieldText
            };
            eventContext.EventFields.Add(eventField);
            SaveChanges();
            AttachEventField(eventId, FindEventField(eventField.FieldId));
        }
        
        private void AttachEventField(string eventId, EventField eventField)
        {
            Event findedEvent = FindEvent(eventId);
            eventField.Event = findedEvent;
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

        public void DeleteUser(string userId)
        {
            eventContext.Users.Remove(FindUser(userId));
            SaveChanges();
        }
        
        public User FindUser(string userId)
        {
            return eventContext.Users.Find(userId);
        }

        public User FindUserByEmail(string email)
        {
           return eventContext.Users
                .Where(s => s.Email == email)
                .SingleOrDefault();
        }

        public Event FindEvent(string eventId)
        {
            return eventContext.Events.Find(eventId);
        }

        public EventField FindEventField(string eventFieldId)
        {
            return eventContext.EventFields.Find(eventFieldId);
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