using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class DistrictGroup
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}