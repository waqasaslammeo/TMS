using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TMS.Context;
using TMS.Models;
using TMStesting.Common;

namespace TMStesting.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        [HttpGet]
        public ActionResult Department(int id = 0)
        {
            var user1 = Session["AppUser"] as User;
            if (user1 == null)
            {
                return RedirectToAction("Login");
            }
            var DepartmentList = Common.TMSRepository.GetDepartmentList();
            var department = new Department();
            if (id > 0)
            {
                department = Common.TMSRepository.GetDepartmentById(id);
            }
            else
            {
                department.Id = -1;
                department.DepartmentName = "";
            }
            ViewBag.DepartmentList = DepartmentList;
            ViewBag.Department = department;
            return View();
        }

        [HttpPost]
        public ActionResult Department(Department department)
        {
            var user1 = Session["AppUser"] as User;
            if (user1 == null)
            {
                return RedirectToAction("Login");
            }
            if (department.Id > -1)
            {
                Common.TMSRepository.UpdateDepartment(department);
            }
            else
            {
                Common.TMSRepository.InsertDepartment(department);
            }
            var departmentList = Common.TMSRepository.GetDepartmentList();
            ViewBag.DepartmentList = departmentList;
            department.Id = -1;
            department.DepartmentName = "";
            ViewBag.Department = department;
            return View();
        }


        public ActionResult DepartmentDelete(int id)
        {
            var user1 = Session["AppUser"] as User;
            if (user1 == null)
            {
                return RedirectToAction("Login");
            }
            Common.TMSRepository.DeleteDepartment(id);
            return RedirectToAction("Department");
        }

        [HttpGet]
        public ActionResult User(int id = 0)
        {
            var user1 = Session["AppUser"] as User;
            if (user1 == null)
            {
                return RedirectToAction("Login");
            }
            var userList = Common.TMSRepository.GetUserList();
            var user = new User();
            var departmentList = TMSRepository.GetDepartmentList();
            var department = new Department();
            if (id > 0)
            {
                user = Common.TMSRepository.GetUserById(id);
            }
            else
            {
                user.Id = -1;
                user.FirstName = "";
                user.LastName =  "";
                user.EmailAddress =  "";
                user.Phone =  "";
                user.Mobile =  "";
                user.Address =  "";
                user.ContactPerson =  "";
                user.SupervisorId = -1;
                user.DepartmentId = -1;
                user.Designation =  "";
            }
            ViewBag.DepartmentList = departmentList;
            ViewBag.userList = userList;
            ViewBag.Department = department;
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        public ActionResult User(User usr)
        {
            var user1 = Session["AppUser"] as User;
            if (user1 == null)
            {
                return RedirectToAction("Login");
            }
            var userList = Common.TMSRepository.GetUserList();
            var user = new User();
            var departmentList = TMSRepository.GetDepartmentList();
            var department = new Department();
            if (usr.Id > 0)
            {
                Common.TMSRepository.UpdateUser(usr);
            }
            else
            {
                Common.TMSRepository.InsertUser(usr);
            }

           
        
            ViewBag.DepartmentList = departmentList;
            ViewBag.userList = userList;
            ViewBag.Department = department;


            return RedirectToAction("User");
        }

        public ActionResult UserDelete(int id=0)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            Common.TMSRepository.DeleteUser(id);
            return RedirectToAction("User");
        }

        [HttpGet]
        public ActionResult Assignment(int id = 0)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var userLst = TMSRepository.GetUserList();
            var statusLst = TMSRepository.GetTaskStatusList();
            //var assignment = TMSRepository.GetAssignmentById(id);
            var assignmentList = TMSRepository.GetAssignmentList();
            var statusList = TMSRepository.GetTaskStatusList();
            var taskList = TMSRepository.GetAssignmentList();

            ViewBag.userList = userLst;
            ViewBag.statusLst = statusLst;
           // ViewBag.assignment = assignment;
            ViewBag.assignmentList = assignmentList;
            ViewBag.statusList = statusList;
            ViewBag.taskList = taskList;

            return View();
        }

        [HttpPost]
        public ActionResult Assignment(Assignment assignment, List<HttpPostedFileBase> filesCollection)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var id = TMSRepository.InsertAssignment(assignment);



            foreach (HttpPostedFileBase item in filesCollection)
            {
                if (item.ContentLength > 0)
                {
                    string filename = DateTime.Now.Date.Millisecond.ToString() + Guid.NewGuid() + System.IO.Path.GetFileName(item.FileName);
                    /*Saving the file in server folder*/
                    string path = System.IO.Path.Combine(Server.MapPath("~/Attachment") , filename);
                    item.SaveAs(path);
                    string filepathtosave = "/Attachment/" + filename;

                    var c = new AssignmentComment();
                    c.CommentDate = DateTime.Now.Date;
                    c.AssingmentId = id;
                    c.Comment = "This " + assignment.Title + " task has been assigned to you.";
                    c.CommentBy = assignment.AssignedBy;

                    var cid = TMSRepository.InsertAssignmentComment(c);

                    var a = new AssignmentAttachment();
                    a.FilePath = filepathtosave;
                    a.AttachedBy = assignment.AssignedBy;
                    a.AttachedDate = DateTime.Now.Date;
                    a.CommentId = cid;
                     TMSRepository.InsertAssignmentAttachment(a);

                }
            }



            var userLst = TMSRepository.GetUserList();
            var statusLst = TMSRepository.GetTaskStatusList();
            var assignment1 = TMSRepository.GetAssignmentById(id);
            var assignmentList = TMSRepository.GetAssignmentList();
            var statusList = TMSRepository.GetTaskStatusList();
            var taskList = TMSRepository.GetAssignmentList();
            ViewBag.userList = userLst;
            ViewBag.statusLst = statusLst;
            ViewBag.assignment = assignment1;
            ViewBag.assignmentList = assignmentList;
            ViewBag.statusList = statusList;
            ViewBag.taskList = taskList;

            return View();
        }

        public ActionResult DeleteAssignment(int id)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            TMSRepository.DeleteAssignment(id);
            return RedirectToAction("Assignment");
        }
        [HttpGet]
        public ActionResult Gallery(int id = 0)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Gallery()
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Calendar(int id = 0)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Calendar()
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public JavaScriptResult GetEvents()
        {
           
            
            var taskList = TMSRepository.GetAssignmentList();
            var task = "";
            foreach (var t in taskList)
            {
                task = task + @" {
                                    title: '" + t.Title + @"',
                                    url: '/Admin/Taskboard/" + t.Id + @"',
                                    start: '" + t.AssignmentDate.Year + "-" + t.AssignmentDate.Month + "-" + t.AssignmentDate.Day + @"'
                                },";
            }

            task = task + @"{}";

            task = task.Replace(",{}", "");

            string str = @" var aaa = [
        " + task + @"
    ];

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultDate: '" +  DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + @"',
        events: aaa
    });";

             return JavaScript(str);
        }

       

        public ActionResult TaskBoard(int id=0)
        {
            var user = Session["AppUser"] as User;
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            
            var userLst = TMSRepository.GetUserList();
            var statusLst = TMSRepository.GetTaskStatusList();
            if (id > 0)
            {
                var assignment1 = TMSRepository.GetAssignmentById(id);
                ViewBag.assignment = assignment1;
                var chatList = TMSRepository.GetAssignmentCommentList(id);
                var attachementList = TMSRepository.GetAssignmentAttachmentList(id);

                List<ChatPanelitem> objLst = new List<ChatPanelitem>();
                foreach (var c in chatList.OrderByDescending(x => x.Id))
                {
                    ChatPanelitem obj = new ChatPanelitem();
                    obj.comment = c.Comment;
                    obj.commentDate = c.CommentDate.ToString();
                    if (user.Id == Convert.ToInt32(c.CommentBy))
                    {
                        obj.isMine = true;
                    }
                    else
                    {
                        obj.isMine = false;
                    }

                    var attachement = attachementList.Where(x => x.CommentId == c.Id).FirstOrDefault();
                    if (attachement != null)
                    {
                        obj.attachment = attachement.FilePath;
                    }
                    else
                    {
                        obj.attachment = "";
                    }

                    objLst.Add(obj);
                }

                ViewBag.Chat = objLst;
            }
         
            var assignmentList = TMSRepository.GetAssignmentList();
            var statusList = TMSRepository.GetTaskStatusList();
            var taskList = TMSRepository.GetAssignmentList();
            ViewBag.userList = userLst;
            ViewBag.statusLst = statusLst;
         
            ViewBag.assignmentList = assignmentList;
            ViewBag.statusList = statusList;
            ViewBag.taskList = taskList;

           
        

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string uname , string password)
        {

            using (TMSContext db = new TMSContext())
            {
                var a = db.Users.Where(x => x.EmailAddress == uname && x.Password == password).FirstOrDefault();

                if (a != null)
                {
                    Session["AppUser"] = a;
                    return RedirectToAction("Calendar");
                }
            }

            return View();
        }


        [HttpPost]
        public ActionResult Chat(string msg, List<HttpPostedFileBase> filesCollection, int TaskId2)
        {

             var user = Session["AppUser"] as User;
            foreach (HttpPostedFileBase item in filesCollection)
            {
                if (item.ContentLength > 0)
                {
                    string filename = DateTime.Now.Date.Millisecond.ToString() + Guid.NewGuid() + System.IO.Path.GetFileName(item.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Attachment"), filename);
                    item.SaveAs(path);
                    string filepathtosave = "/Attachment/" + filename;

                    var comment = new AssignmentComment();
                    comment.AssingmentId = TaskId2;
                    comment.CommentDate = DateTime.Now;
                    comment.CommentBy = user.Id.ToString();
                    comment.Comment = msg;

                    var commentid = TMSRepository.InsertAssignmentComment(comment);
                    var attach = new AssignmentAttachment();
                    attach.CommentId = commentid;
                    attach.AttachedDate = DateTime.Now;
                    attach.AttachedBy = user.Id.ToString();
                    attach.FilePath = filepathtosave;

                    TMSRepository.InsertAssignmentAttachment(attach);

                }
                else
                {
                    var comment = new AssignmentComment();
                    comment.AssingmentId = TaskId2;
                    comment.CommentDate = DateTime.Now;
                    comment.CommentBy = user.Id.ToString();
                    comment.Comment = msg;
                }
            }

            return RedirectToAction("TaskBoard", "Admin", new {id = TaskId2});

        }

         [HttpPost]
        public PartialViewResult GetChatPanel(int taskId)
        {

            var user = Session["AppUser"] as User;
            var assignmentList = TMSRepository.GetAssignmentList();
            ViewBag.assignmentList = assignmentList;

            var chatList = TMSRepository.GetAssignmentCommentList(taskId);
            var attachementList = TMSRepository.GetAssignmentAttachmentList(taskId);

            List<ChatPanelitem> objLst = new List<ChatPanelitem>();
            foreach (var c in chatList.OrderByDescending(x => x.Id))
            {
                ChatPanelitem obj = new ChatPanelitem();
                obj.comment = c.Comment;
                obj.commentDate = c.CommentDate.ToString();
                if (user.Id == Convert.ToInt32(c.CommentBy))
                {
                    obj.isMine = true;
                }
                else
                {
                    obj.isMine = false;
                }

                var attachement = attachementList.Where(x => x.CommentId == c.Id).FirstOrDefault();
                if (attachement != null)
                {
                    obj.attachment = attachement.FilePath;
                }
                else
                {
                    obj.attachment = "";
                }

                objLst.Add(obj);
            }

            ViewBag.Chat = objLst;


            return PartialView("chatpanelsection");
        }


        [HttpPost]
         public ActionResult UpdateTask(string AssignmentDate, string AssignmentTo, string Status, string TaskId)
        {

            TMSRepository.UpdateAssignment(TaskId, AssignmentDate, AssignmentTo, Status);

            return RedirectToAction("TaskBoard", "Admin", new { id = TaskId });
        }

    }


   

}
