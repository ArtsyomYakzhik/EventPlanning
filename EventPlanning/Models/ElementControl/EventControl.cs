using EventPlanning.Models.DB.Interaction;
using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.ElementControl
{
    static public class EventControl
    {
        static private DBInteraction dBInteraction = new DBInteraction();

        static public void CreateNewEvent(Event newEvent, string[] fieldName, string[] fieldText)
        {
            AddEventFields(dBInteraction.CreateEvent(newEvent), fieldName, fieldText);
        }

        static private void AddEventFields(string eventId, string[] fieldName, string[] fieldText)
        {
            if (fieldName != null)
            {
                int countOfFields = fieldName.Length;
                for (int i = 0; i < countOfFields; i++)
                {
                    dBInteraction.AddEventField(eventId, fieldName[i], fieldText[i]);
                }
            }
        }

        static public List<Event> GetUserEvents(string userId)
        {
            ICollection<Event> events = dBInteraction.FindUser(userId).Events;
            return events != null? events.ToList(): new List<Event>();
        }

        static public List<Event> GetEventsWithFreeSpace()
        {
            return dBInteraction.ListOfEventWithFreeSpace();
        }
    }
}