using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark.Model
{
    public partial class Event
    {
        public List<Match> Matches { get; set; }
        public int id { get; set; }
        public string eventName { get; set; }
        public DateTime eventDate { get; set; }

        public int OrganizationID { get; set; }
        public Organization Organization { get; set; }

        public Event()
        {
            this.Matches = new List<Match>();
        }
    }
}
