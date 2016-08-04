using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TMS.Models;


namespace TMS.Context
{
    public class TMSContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentComment> AssignmentComments { get; set; }
        public DbSet<AssignmentAttachment> AssignmentAttachments { get; set; }
    }
}