using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace TMStesting.Common
{

    public class TaskStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }



    public static class TmsEnum
    {

        public enum TaskStatus
        {
            Pending = 1,
            InProcess = 2,
            Closed=3,
            Cancelled =4,
            Completed=5,
            NeedClearification=6
        }

       

    }
}