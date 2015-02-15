using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark.Model
{
    public partial class Organization
    {
        public List<Event> Events { get; set; }
        public string Name { get; set; }
        public int id { get; set; }
        public Organization()
        {
            this.Events = new List<Event>();
        }
    }
}
