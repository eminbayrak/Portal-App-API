using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ParentPortalAPI.Models
{
    public class Event
    {
        public string Description { get; set; }
        public string EndDateTime { get; set; }
        public string GroupId { get; set; }
        public string Id { get; set; }
        public string LocationId { get; set; }
        public string StartDateTime { get; set; }
    }
}