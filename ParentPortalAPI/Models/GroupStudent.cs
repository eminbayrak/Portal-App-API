﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class GroupStudent
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}