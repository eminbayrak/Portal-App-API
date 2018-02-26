using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class TopicComment
    {
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}