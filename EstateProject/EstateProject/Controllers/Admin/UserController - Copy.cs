using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateProject.Common;
using EstateProject.Controllers.Admin;
using EstateProject.Dao;
using EstateProject.Models;

namespace EstateProject.Controllers
{
    public class UserController : BaseController
    {    
        [HttpGet]
        public ActionResult ListUser(string search)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "ADMIN")
                {                  
                    var dao = new UserDao();                                
                    var data = dao.GetUser(search);
                    if(search!= null)
                    {
                        ViewBag.Search = search.Trim();
                    }
                   
                    return View(data);
                }
            }
            Response.StatusCode = 404;
            return null;
        }


        public ActionResult Profile()
        {
            if(Session["UserName"] != null)
            {
                var dao = new UserDao();
                var user = dao.GetById(Session["UserName"].ToString());
                return View(user);
            }
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public ActionResult profile(string fullname, string email, string phone, HttpPostedFileBase imageFile)
        {
            if (Session["UserName"] != null)
            {             
                var dao = new UserDao();                
                var user = dao.GetById(Session["UserName"].ToString());
                var filename = "";
                var ok = "";
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    filename = imageFile.FileName;
                    filename = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + filename).ToString();
                    // Path upload
                    string path = Path.Combine(Server.MapPath("~/Assets/Upload/Avartar"),
                                           Path.GetFileName(filename));
                    //Move ava to folder
                    imageFile.SaveAs(path);
                    // path save db
                    var strPath = "Assets/Upload/Avartar/";
                    ok = strPath + filename;
                }                                      
                dao.UpdateProfile(user, fullname, email, phone, ok);
               
                Session["FullName"] = user.fullname;
                TempData["OK"] = "Update user successful!!";
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult ChangePassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult changePassWord(PasswordModel pass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    var user = dao.GetById(Session["UserName"].ToString());
                    if (Encrytor.MD5Hash(pass.oldPassword) == user.password)
                    {
                        dao.Update(user, pass.newPassword);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật Khẩu cũ sai");
                        return View("ChangePassWord");
                    }
                }
                return View("ChangePassWord");
            }
            catch
            {
                return View();
            }

        }  
        [HttpGet]
        public ActionResult EditUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(user user)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "ADMIN")
                {
                    if (ModelState.IsValid)
                    {
                        var dao = new UserDao();
                        user.status = (user.status != null) ? user.status : 0;
                        user.password = Encrytor.MD5Hash(user.password);
                        if(dao.Insert(user) == 1)
                        {
                            TempData["OK"] = "Add new user successfull!!";
                            return RedirectToAction("EditUser");
                        }
                        ModelState.AddModelError("", "Username already exist");
                        return View("EditUser");
                    }
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public JsonResult DeleteUser(int[] data)
        {
            if (data != null && data.Length > 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var dao = new UserDao();
                    dao.DeleteUser(data[i]);
                }
                return Json(new { data = data, Status = 1 }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = 0 }, JsonRequestBehavior.AllowGet);
        }
    }
}