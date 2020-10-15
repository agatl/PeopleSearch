using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity
{
    public class People
    {
        [Key]
        public int PeopleID { get; set; }
        [MaxLength(20)]
        [Required, Display(Name="First Name")]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [Required, Display(Name="Last Name")]
        public string LastName { get; set; }
        [Range(0,99)]
        public int Age { get; set; }
        
        public PeopleAddress Address { get; set; }
        // One to many relationship between People and People Interests
        public virtual List<PeopleInterests> Interests { get; set; }
        // One to One relationship between People and People Image
        public virtual PeopleImage PeopleImage { get; set; }
    }
}
