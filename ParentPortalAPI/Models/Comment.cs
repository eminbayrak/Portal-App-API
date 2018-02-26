using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
	    public string Content { get; set; }
        public string CreatedDateTime { get; set; }
        public string ModifiedDateTime { get; set; }
        public int TopicId { get; set; }
	    public Account User { get; set; }
    }
}