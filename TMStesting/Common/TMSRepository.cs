using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Microsoft.Owin.Security.DataProtection;
using TMS.Context;
using TMS.Models;

namespace TMStesting.Common
{
    public static class TMSRepository
    {

        #region Insert

        public static void InsertDepartment(Department department)
        {
            using (TMSContext db = new TMSContext())
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        public static int InsertAssignment(Assignment assignment)
        {
            using (TMSContext db = new TMSContext())
            {
                assignment.EndDate = DateTime.Now;
                db.Assignments.Add(assignment);
                db.SaveChanges();

                return assignment.Id;
            }
        }

        public static int InsertUser(User user)
        {
            using (TMSContext db = new TMSContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user.Id;
            }
        }

        public static int InsertAssignmentComment(AssignmentComment assignmentComment)
        {
            using (TMSContext db = new TMSContext())
            {
                db.AssignmentComments.Add(assignmentComment);
                db.SaveChanges();

                return assignmentComment.Id;
            }
        }

        public static void InsertAssignmentAttachment(AssignmentAttachment assignmentAttachment)
        {
            using (TMSContext db = new TMSContext())
            {
                db.AssignmentAttachments.Add(assignmentAttachment);
                db.SaveChanges();
            }
            
        }
        #endregion

        #region Update

        public static void UpdateDepartment(Department department)
        {
            using (TMSContext db = new TMSContext())
            {
                var Department = db.Departments.Single(x => x.Id == department.Id);
                Department.DepartmentName = department.DepartmentName;
                db.SaveChanges();
            }
        }

        public static void UpdateUser(User user)
        {
            using (TMSContext db= new TMSContext())
            {
                var User = db.Users.Single(x => x.Id == user.Id);
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.EmailAddress = user.EmailAddress;
                User.Phone = user.Phone;
                User.Mobile = user.Mobile;
                User.Address = user.Address;
                User.ContactPerson = user.ContactPerson;
                User.SupervisorId = user.SupervisorId;
                User.DepartmentId = user.DepartmentId;
                User.Designation = user.Designation;
                db.SaveChanges();
            }
           
                
        
        }

        public static void UpdateAssignment(Assignment assignment)
        {
            using (TMSContext db = new TMSContext())
            {
                var Assignment = db.Assignments.Single(x => x.Id == assignment.Id);
                Assignment.Title = assignment.Title;
                Assignment.AssignmentDate = assignment.AssignmentDate;
                Assignment.EndDate = assignment.EndDate;
                Assignment.AssignedBy = assignment.AssignedBy;
                Assignment.AssignedTo = assignment.AssignedTo;
                Assignment.StatusAlterSpan = assignment.StatusAlterSpan;
                Assignment.Status = assignment.Status;
                Assignment.IsOfHighPriority = assignment.IsOfHighPriority;
                db.SaveChanges();
            }
        }

        public static void UpdateAssignment(string TaskId, string AssignmentDate, string AssignmentTo, string Status)
        {
            using (TMSContext db = new TMSContext())
            {
                var Assignment = db.Assignments.Single(x => x.Id == Convert.ToInt16(TaskId));

                Assignment.AssignmentDate = Convert.ToDateTime(AssignmentDate);
                Assignment.AssignedTo = AssignmentTo;
                Assignment.Status = Convert.ToInt32(Status);
                db.SaveChanges();
            }
        }
        #endregion

        #region GetById

        public static Department GetDepartmentById(int departmentId)
        {
            var department = new Department();
            using (TMSContext db = new TMSContext())
            {
                department = db.Departments.Single(x => x.Id == departmentId);
            }
            return department;
        }

        public static User GetUserById(int UserId)
        {
            var user = new User();
            using (TMSContext db = new TMSContext())
            {
                user = db.Users.Single(x => x.Id == UserId);

            }
            return user;
        }

        public static Assignment GetAssignmentById(int AssignmentId)
        {
            var Assignment = new Assignment();
            using (TMSContext db = new TMSContext())
            {
               Assignment = db.Assignments.Single(x => x.Id == AssignmentId);
            }
            return Assignment;
        }

        public static AssignmentComment GetAssignmentCommentById(int CommentId)
        {
            var AssignmentComment = new AssignmentComment();
            using (TMSContext db = new TMSContext())
            {
                AssignmentComment = db.AssignmentComments.Single(x => x.Id == CommentId);
            }
            return AssignmentComment;
        }

        public static AssignmentAttachment GetAssignmentAttachmentById(int AttachmentId)
        {
            var AssignmentAttachment = new AssignmentAttachment();
            using (TMSContext db = new TMSContext())
            {
                AssignmentAttachment = db.AssignmentAttachments.Single(x => x.Id == AttachmentId);
            }
            return AssignmentAttachment;
        }
        #endregion

        #region List

        public static List<Department> GetDepartmentList()
        {
            var DepartmentList = new List<Department>();
            using (TMSContext db = new TMSContext())
            {
                DepartmentList = db.Departments.ToList();

            }
            return DepartmentList;
        }

        public static List<User> GetUserList()
        {
            var UserList = new List<User>();
            using (TMSContext db = new TMSContext())
            {
                UserList = db.Users.ToList();
            }
            return UserList;
        }

        public static List<Assignment> GetAssignmentList()
        {
            var AssignmentList = new List<Assignment>();
            using (TMSContext db = new TMSContext())
            {
                AssignmentList = db.Assignments.ToList();
            }
            return AssignmentList;
        }

        public static List<AssignmentComment> GetAssignmentCommentList(int taskId)
        {
            var AssignmentCommentList = new List<AssignmentComment>();
            using (TMSContext db = new TMSContext())
            {
                AssignmentCommentList = db.AssignmentComments.Where(x=>x.AssingmentId == taskId).ToList();
               
            }
            return AssignmentCommentList;
        }

        public static List<AssignmentAttachment> GetAssignmentAttachmentList(int taskId)
        {
            var AssignmentAttachmentList = new List<AssignmentAttachment>();
            using (TMSContext db = new TMSContext())
            {
                AssignmentAttachmentList = db.AssignmentAttachments.ToList();
            }
            return AssignmentAttachmentList;
        }

        public static List<TaskStatus> GetTaskStatusList()
        {
            var lst = new List<TaskStatus>();

            var obj1 = new TaskStatus();
            var obj2 = new TaskStatus();
            var obj3 = new TaskStatus();
            var obj4 = new TaskStatus();
            var obj5 = new TaskStatus();
            var obj6 = new TaskStatus();

            obj1.Id = 1; obj1.Status = "Pending";
            obj2.Id = 2; obj2.Status = "InProcess";
            obj3.Id = 3; obj3.Status = "Closed";
            obj4.Id = 4; obj4.Status = "Cancelled";
            obj5.Id = 5; obj5.Status = "Completed";
            obj6.Id = 6; obj6.Status = "NeedClearification";

            lst.Add(obj1); lst.Add(obj2); lst.Add(obj3); lst.Add(obj4); lst.Add(obj5); lst.Add(obj6);

            return lst;
        } 

        #endregion

        #region Delete

        public static void DeleteDepartment(int id)
        {
            using (TMSContext db = new TMSContext())
            {
                var dpt = db.Departments.Where(x => x.Id == id).SingleOrDefault();
                db.Departments.Remove(dpt);
                db.SaveChanges();
            }
        }

        public static void DeleteUser(int id)
        {
            using (TMSContext db = new TMSContext())
            {
                var usr = db.Users.Where(x => x.Id == id).SingleOrDefault();
                db.Users.Remove(usr);
                db.SaveChanges();
            }
        }

        public static void DeleteAssignment(int id)
        {
            using (TMSContext db = new TMSContext())
            {
                var a = db.Assignments.Where(x => x.Id == id).SingleOrDefault();
                db.Assignments.Remove(a);
                db.SaveChanges();
            }
        }

        #endregion


    }


    public class ChatPanelitem
    {
        public string comment { get; set; }
        public string commentDate { get; set; }
        public string attachment { get; set; }
        public bool isMine { get; set; }
        //Re public string username;
    }

}