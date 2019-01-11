using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Models.DB.Interaction
{
    static public class SingeltonContext
    {
        static private EventContext eventContext;

        static public EventContext getInstance()
        {
            if (eventContext == null)
            {
                eventContext = new EventContext();
            }
            return eventContext;
        }
    }
}