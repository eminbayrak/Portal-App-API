﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class GroupEvent
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}