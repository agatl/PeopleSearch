using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Entity;

namespace Sample.Web.Models
{
    public class PeopleViewModel
    {
        public People People { get; set; }
        public string[] PeopleInterest { get; set; }
    }
}