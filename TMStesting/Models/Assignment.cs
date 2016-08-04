using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedBy  { get; set; }
        public string AssignedTo { get; set; }
        public int StatusAlterSpan { get; set; }
        public int Status { get; set; }
        public bool IsOfHighPriority { get; set; }
    }
}