using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ParentPortalAPI.Models
{
    public class Event
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("EndDateTime")]
        public string EndDateTime { get; set; }

        [JsonProperty("GroupId")]
        public string GroupId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("LocationId")]
        public string LocationId { get; set; }

        [JsonProperty("StartDateTime")]
        public string StartDateTime { get; set; }
    }
}