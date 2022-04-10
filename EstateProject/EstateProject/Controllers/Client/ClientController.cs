using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers.Client
{
    public class ClientController : Controller
    {
        EstateDbContext db = new EstateDbContext();
        // GET: Client
        public ActionResult Index()
        {
            List<building> lstBuilding = db.building.Where(n => n.levels == "1").OrderBy(n => n.name).ToList();
            //int pagesize = 12; //số sản phẩm trong 1 trang
            //int pagenumber = (page ?? 1);     // số trang
            if (lstBuilding.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.lstSanPham = db.building.ToList();
            return View(lstBuilding/*.ToPagedList(pagenumber, pagesize)*/);
        }

        public ActionResult AllBuilding()
        {
            List<building> lstBuilding = db.building.OrderBy(n => n.name).ToList();
            //int pagesize = 12; //số sản phẩm trong 1 trang
            //int pagenumber = (page ?? 1);     // số trang
            if (lstBuilding.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.lstSanPham = db.building.ToList();
            return View(lstBuilding/*.ToPagedList(pagenumber, pagesize)*/);
        }
        public ViewResult BuildingDetail1(int id)
        {
            building building = db.building.SingleOrDefault(n => n.id == id);

            //user idUser = db.user.Find(id);
            //List<user> user = db.user.Where(n => n.role == "STAFF").ToList();
            //var selectList = new SelectList(user, "id", "fullname", idUser.id);

            //ViewData["user_id"] = selectList;

            //ViewData["user_idCheck"] = building.user_id;

            if (building == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(building);
        }
        [HttpGet]
        public ActionResult AddContact(building building)
        {
            ViewBag.user_id = new SelectList(db.user.Where(n => n.role == "STAFF").ToList(), "id", "fullname");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact([Bind(Include = "id, user_id, email, fullname, phone, title , status, messages, createddate, modifieddate")] contacts contact)
        {
            if (ModelState.IsValid)
            {
                contact.title = "ok";
                contact.status = "0";
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //List<user> user = db.user.OrderBy(n => n.fullname).ToList();
            //var selectList = new SelectList(user, "id", "fullname", idUser.id);

            //ViewData["user_id"] = selectList;
            ViewBag.user_id = new SelectList(db.user.Where(n => n.role == "STAFF").ToList(), "id", "fullname"); //
            return View( );
        }

        public PartialViewResult BrokerPartial()
        {
            return PartialView(db.user.Where(n => n.role == "STAFF").ToList());
        }

    }
}