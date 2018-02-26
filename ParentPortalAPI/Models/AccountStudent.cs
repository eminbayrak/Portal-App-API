using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class AccountStudent
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}