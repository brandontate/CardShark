using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShark.Model
{
    public partial class Match
    {
        public string FirstOppenent { get; set; }
        public string SecondOppenent { get; set; }
        public string Winner { get; set; }

        [Key]
        public int MatchID { get; set; }
        public int EventID { get; set; }

        public Match()
        {

        }
    }
}
