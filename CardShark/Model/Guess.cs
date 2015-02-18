using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark.Model
{
    public partial class Guess
    {
        public string guess { get; set; }

        [Key]
        public int id { get; set; }
        public int MatchID { get; set; }

        public Guess()
        {

        }
    }
}
