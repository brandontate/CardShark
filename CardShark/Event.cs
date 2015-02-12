using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark
{
    class Event
    {
        public int eventID { get; private set; }
        public string eventName { get; private set; }
        public string eventDate { get; private set; }

        public Event(int eID, string eName, string eDate)
        {
            eventID = eID;
            eventName = eName;
            eventDate = eDate;
        }
    }
}
