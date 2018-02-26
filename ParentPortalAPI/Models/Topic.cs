using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParentPortalAPI.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Group Group { get; set; }
        public Account User { get; set; }
        public ICollection<TopicComment> TopiComments { get; set; }
    }
}