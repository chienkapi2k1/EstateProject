using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Controllers.Admin;
using EstateProject.Dao;
using System.Linq;
using EstateProject.Models;
using System.Threading.Tasks;

namespace EstateProject.Controllers.Admin
{
    public class ContactController : Controller
    {
        EstateDbContext dbContext = new EstateDbContext();
        // GET: Contact
        public ActionResult ListContact(string email)
        {
            if (Session["Role"] != null)
            {
                var dao = new UserDao();
                var users = dbContext.user.Select(x => x).ToList();
                var contacts = dbContext.contacts.Select(x => x).ToList();
                int id = int.Parse(Session["UserId"].ToString());
                var data = (from a in contacts
                            join b in users on a.user_id equals b.id
                            select new
                            {
                                id = a.id,
                                email = a.email,
                                name = a.fullname,
                                phone = a.phone,
                                title = a.title,
                                messages = a.messages,
                                status = a.status,
                                user_name = b.fullname,
                            }).OrderBy(c => c.status);
                if (Session["Role"].ToString() != "ADMIN")
                {
                    data = (from a in contacts
                            join b in users on a.user_id equals b.id
                            where a.user_id == id
                            select new
                            {
                                id = a.id,
                                email = a.email,
                                name = a.fullname,
                                phone = a.phone,
                                title = a.title,
                                messages = a.messages,
                                status = a.status,
                                user_name = b.fullname,
                            }).OrderBy(c => c.status);
                }

                List<ListContact> listContact = new List<ListContact>();
                foreach (var item in data)
                {
                    ListContact ok = new ListContact(item.id, item.user_name, item.email, item.name, item.phone, item.title, item.status, item.messages);
                    listContact.Add(ok);
                }

                //search
                if (email != null && email != "")
                {
                    email = email.Trim();
                    ViewBag.Search = email.Trim();
                    listContact = listContact.Where(x => x.email.Contains(email)).ToList();
                }

                return View(listContact);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPut]
        public JsonResult saveContact(int id, string status)
        {
            contacts contact = dbContext.contacts.SingleOrDefault(x => x.id == id);
            if (contact != null)
            {
                contact.status = status;
                dbContext.SaveChanges();
                if (contact.status == "1")
                    return Json(new { status = 1, message = "Contacted" }, JsonRequestBehavior.AllowGet); // đã liên hệ
                if (contact.status == "2")
                    return Json(new { status = 2, message = "Cancelled" }, JsonRequestBehavior.AllowGet); // hủy
            }
            return Json(new { status = 0, message = "Error" }, JsonRequestBehavior.AllowGet);
        }

        public void Status1Contact(int[] id)
        {
            foreach (var item in id)
            {
                contacts contact = dbContext.contacts.SingleOrDefault(x => x.id == item);   // Single : trả về 1 phần tử, nếu k tìm thấy hoặc tìm thấy > 1 => sẽ đưa ra không hợp lệ
                contact.status = "1";
            }
            dbContext.SaveChanges();
        }

        public async Task<JsonResult> sendMail(string[] data, string subject, string message, int[] id)
        {
            try
            {
                if (data != null && id != null && subject != "" && message != "")
                {
                    List<Task> lstTask = new List<Task>();

                    foreach (var item in data)
                    {
                        Task t = Common.SendMail.sendMail(item, subject, message);
                        lstTask.Add(t);
                    }
                    Status1Contact(id);
                    lstTask.ToArray();
                    await Task.WhenAll(lstTask);
                    return Json(new { ok = true, lstEmail = data }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ok = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
