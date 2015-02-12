using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark
{
    class Organization
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public Organization(int r, string n)
        {
            Rank = r;
            Name = n;
        }
    }
}
