using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity
{
    public class PeopleImage
    {
        [Key]
        public int ImageID { get; set; }
        public int PeopleID { get; set; }
        public byte[] Image { get; set; }
    }
}
