using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaintextBaseline.Models
{
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gendaer Gendar { get; set; } = Gendaer.Unknown;
        public int Age { get; set; }
    }

    public enum Gendaer
    {
        Unknown = 0,
        Male,
        Female
    }
}