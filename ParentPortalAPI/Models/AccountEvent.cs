using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class AccountEvent
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}