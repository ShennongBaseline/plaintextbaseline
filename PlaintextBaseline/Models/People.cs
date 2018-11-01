using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaintextBaseline.Models
{
    public class People
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // M/F
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}