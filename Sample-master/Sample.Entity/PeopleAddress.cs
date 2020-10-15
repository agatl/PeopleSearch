using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entity
{

    [ComplexType]
    public class PeopleAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
    }
}
