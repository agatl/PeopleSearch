using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity
{
    public class PeopleInterests
    {
        [Key]
        public int InterestID { get; set; }
        public string Interest { get; set; }
        [ForeignKey("PeopleID")]
        public virtual People People { get; set; }
        public int PeopleID { get; set; }
    }
}
