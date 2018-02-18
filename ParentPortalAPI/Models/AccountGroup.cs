using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class AccountGroup
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string AccountId { get; set; }
        public ApplicationUser Account { get; set; }
    }
}