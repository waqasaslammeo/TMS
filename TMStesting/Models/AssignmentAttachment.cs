using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class AssignmentAttachment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public virtual AssignmentComment AssignmentComments { get; set; }
        public string FilePath { get; set; }
        public string AttachedBy { get; set; }
        public DateTime AttachedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}