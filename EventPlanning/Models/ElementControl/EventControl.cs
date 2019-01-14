using EventPlanning.Models.DB.Interaction;
using EventPlanning.Models.DB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.ElementControl
{
    static public class EventControl
    {
        static private DBInteraction dBInteraction = new DBInteraction();

        static public void CreateNewEvent(Event newEvent, string[] fieldName, string[] fieldText)
        {
            dBInteraction.CreateEvent(newEvent);
            AddEventFields(newEvent.CreatorId, fieldName, fieldText);
        }

        static private void AddEventFields(string eventId, string[] fieldName, string[] fieldText)
        {
            int countOfFields = fieldName.Length;
            for(int i = 0; i < countOfFields; i++)
            {
                dBInteraction.AddEventField(eventId, fieldName[i], fieldText[i]);
            }
        }
    }
}