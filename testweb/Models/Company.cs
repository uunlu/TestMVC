using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testweb.Models
{
    public class Company:BaseClass
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Streetnumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int CompanyType { get; set; }
    }
}