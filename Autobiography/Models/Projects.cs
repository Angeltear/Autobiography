using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autobiography.Models
{
    public class Projects
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }
        public string GitHub { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentID { get; set; }
        public string SubmittedBy { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey("Projects")]
        public int ProjectID { get; set; }

        public Projects Projects { get; set; }
    }

    public class PendingComments
    {
        public int ID { get; set; }
        public string SubmittedBy { get; set; }
        public string CommentContent { get; set; }
        public int ProjectID { get; set; }
    }
}