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
            List<building> lstBuilding = db.building.Where(n => n.note == "1").OrderBy(n => n.name).ToList();
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
            building sanpham = db.building.SingleOrDefault(n => n.id == id);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

    }
}