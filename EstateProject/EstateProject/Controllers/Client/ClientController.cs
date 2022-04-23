using EstateProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers.Client
{
    //[HandleError]
    public class ClientController : Controller
    {
        EstateDbContext db = new EstateDbContext();
        // GET: Client
        public ActionResult Index(string name, string district)
        {
            List<building> lstBuilding = db.building.Where(n => n.levels == "1" && n.status != 2).OrderBy(n => n.name).ToList();
            if (lstBuilding.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.lstSanPham = db.building.ToList();
            //search
            List<District> districtss = new List<District>();
            var D = db.building.Select(s => s.district).Distinct().ToList();
            foreach (var item in D)
            {
                districtss.Add(new District(item));
            }
            ViewBag.ListDistricts = districtss;
            if ((name != null && name != "") || (district != null && district != ""))
            {
                
                name = name.Trim();
                ViewBag.Name = name.Trim();
                district = district.Trim();
                if(district == "-")
                {
                    district = "";
                }
                TempData["District"] = district.Trim();
                lstBuilding = lstBuilding.Where(x => x.levels == "1" && x.status != 2 && x.name.Contains(name) && x.district.Contains(district)).ToList();
            }
            return View(lstBuilding);
        }

        public ActionResult AllBuilding(string name, string district)
        {
            List<building> lstBuilding = db.building.Where(n=>n.status!=2).OrderBy(n => n.name).ToList();
            if (lstBuilding.Count == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.lstSanPham = db.building.ToList();
            //search
            List<District> districtss = new List<District>();
            var D = db.building.Select(s => s.district).Distinct().ToList();
            foreach (var item in D)
            {
                districtss.Add(new District(item));
            }
            ViewBag.ListDistricts = districtss;
            if ((name != null && name != "") || (district != null && district != ""))
            {
                name = name.Trim();
                ViewBag.Name = name.Trim();
                district = district.Trim();
                if (district == "-")
                {
                    district = "";
                }
                TempData["District"] = district.Trim();
                lstBuilding = lstBuilding.Where(x => x.name.Contains(name) && x.status!= 2 && x.district.Contains(district)).ToList();
            }
            return View(lstBuilding);
            
                
        }
        public ViewResult BuildingDetail1(int id)
        {
            building building = db.building.Single(n => n.id == id);

            if (TempData["Building_idUser"] != null)
            {
                TempData.Remove("Building_idUser");
            }
            TempData["Building_idUser"] = building.user_id;
            if (building == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(building);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            List<users> user = db.users.Where(n => n.role == "STAFF").ToList();
            ViewBag.user = user;
            //ViewBag.user_id = new SelectList(db.user.Where(n => n.role == "STAFF").ToList(), "id", "fullname");
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
                return RedirectToAction("AddContact");
            }
            List<users> user = db.users.Where(n => n.role == "STAFF").ToList();
            ViewBag.user = user;
            //ViewBag.user_id = new SelectList(db.user.Where(n => n.role == "STAFF").ToList(), "id", "fullname"); //
            return View();
        }

    }
}