using EstateProject.Common;
using EstateProject.Controllers.Admin;
using EstateProject.Dao;
using EstateProject.Dto;
using EstateProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;

using System.Web;
using System.Web.Mvc;

namespace EstateProject.Controllers
{
    public class BuildingController : BaseController
    {
        EstateDbContext db = new EstateDbContext();

       
   
        public ActionResult ListBuilding( BuildingDto searchDto )
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "STAFF")
                {
                    searchDto.UserId = (int)Session["UserId"];
                }
            }
            var dao = new BuildingDao();
            searchDto.totalItems = dao.countBySearch(searchDto);
            searchDto.totalPage = (int)Math.Ceiling((double)searchDto.totalItems / searchDto.limit);
            var model = dao.findAll(searchDto);
            ViewBag.ListBuildings = model;
            SetViewBag();
            return View(searchDto);


        }

        public ActionResult MyListBuilding()
        {
            return View();
        }

        public ActionResult DetailBuilding(int? id)
        {
            var building = new BuildingDao().findById(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            BuildingDto buildingDto = BuildingConverter.converterToDto(building);
            SetViewBag();
            return View(buildingDto);
        }

        public ActionResult EditBuilding(int? id )
        {
             
                
                
                if (id == null)
                {
                    SetViewBag();
                    return View(new BuildingDto());
                }
                var building = new BuildingDao().findById(id);
                if (building == null)
                {
                        return HttpNotFound();
                }
                BuildingDto buildingDto = BuildingConverter.converterToDto(building);
                SetViewBag();
                return View(buildingDto);
           
        }

        public void SetViewBag(int? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserID = new SelectList(dao.findByRoleAndStatus("STAFF", 1), "id", "fullname", selectedId);

        }

        [HttpGet]
        public JsonResult getAll()
        {
            try
            {
             
                var data = db.building.ToList();
                
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult Insert(BuildingDto building )
        {
            try
            {
                bool status = false;
                if (Session["Role"] != null)
                {
                    if (Session["Role"].ToString() == "ADMIN")
                    {
                        var dao = new BuildingDao();
                        dao.save(building);
                        status = true;
                    }
                }
                return Json(new { status = status });
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPut]
        public JsonResult Edit(BuildingDto building )
        {
            try
            {
                bool status = false;
                if (Session["Role"] != null)
                {

                        
                        var dao = new BuildingDao();

                        dao.Update(building.id, building);
                       status = true;

                }
              
                
                return Json(new { status = status, id = building.id });
                
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpDelete]
        public JsonResult Delete(List<int> ids)
        {
            try
            {
                bool status = false;
                if (Session["Role"] != null)
                {
                    if (Session["Role"].ToString() == "ADMIN")
                    {
                        var dao = new BuildingDao();
                        dao.delete(ids);

                        status = true;
                    }
                }
               
                return Json(new { status = status });
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult ImageUpload(BuildingDto model)
        {

            try
            {
                var file = model.imageFile;

                if (file != null)
                {
                  
                    file.SaveAs(Server.MapPath("~/Assets/Upload/Building/" + file.FileName));

                }

                return Json(file.FileName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, mes = e.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string[] path = new string[files.Count];

            for(var i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string rootPath = "~/Assets/Upload/Building/" + file.FileName;
                path[i] = rootPath.Substring(1);
                file.SaveAs(Server.MapPath(rootPath));

            }
            return Json(path, JsonRequestBehavior.AllowGet);
        }


        

    }
}