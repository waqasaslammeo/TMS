using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class AssignmentComment
    {
        public int Id { get; set; }
        public int AssingmentId { get; set; }
        public virtual Assignment Assignments{ get; set; }
        public string CommentBy { get; set; }
        public DateTime CommentDate { get; set; }
        public string Comment { get; set; }
    }
}