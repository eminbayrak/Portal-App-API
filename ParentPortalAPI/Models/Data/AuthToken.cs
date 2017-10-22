using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models.Data
{
    [Table("AuthToken")]
    public class AuthToken
    {
        [Key]
        public int Id { get; set; }
        public string Method { get; set; }
        public string Uri { get; set; }
        public string Data { get; set; }
    }
}