using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
    }
}