using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace ParentPortalAPI.Models
{
    public class Event
    {
        public string Note { get; set; }

        public string LocationAddress { get; set; }

        public string PlaceId { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }

        public string EventIcon { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public string TeamName { get; set; }

        public string OpponentTeamName { get; set; }
        //public string GroupId { get; set; }
        public int Id { get; set; }
        public ICollection<AccountEvent> AccountEvents { get; set; }
        //public Account User { get; set; }
    }
}