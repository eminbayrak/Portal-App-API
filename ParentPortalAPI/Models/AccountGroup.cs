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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TeamName { get; set; }
        public string TeamCode { get; set; }
        public DateTime AccountDate { get; set; }
        public Account Account { get; set; }
    }
}