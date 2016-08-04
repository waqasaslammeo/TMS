using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Mobile{ get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public int SupervisorId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }

    }
}


        

       