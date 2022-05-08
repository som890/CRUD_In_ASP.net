using AppSoccer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSoccer.Controllers
{
    public class SoccerController : Controller
    {
        // GET: Student
        public ActionResult Index(string strSearch)
        {
            SoccerList stuList = new SoccerList();
            List<Soccer> obj = stuList.GetStudents(string.Empty);
            if (!string.IsNullOrEmpty(strSearch))
            {
                obj = obj.Where(x => x.TenDoi.Contains(strSearch)).ToList();
            }
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Soccer stu, HttpPostedFileBase LoGo)
            
        {
            if (ModelState.IsValid)
            {
                if (LoGo != null && LoGo.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(LoGo.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload/images"), _FileName);
                    LoGo.SaveAs(_path);
                    stu.LoGo = _FileName;
                }
                SoccerList stuList = new SoccerList();
                stuList.AddStudent(stu);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id = "")
        {
            SoccerList stuList = new SoccerList();
            List<Soccer> obj = stuList.GetStudents(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Soccer stu, HttpPostedFileBase LoGo, FormCollection form)
        {
            if (LoGo != null)
            {
                string _FileName = Path.GetFileName(LoGo.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload/images"), _FileName);
                LoGo.SaveAs(_path);
                stu.LoGo = _FileName;
                // get Path of old image for deleting it
                _path = Path.Combine(Server.MapPath("~/Upload/images"), form["oldimages"]);
                if (System.IO.File.Exists(_path))
                    System.IO.File.Delete(_path);

            }
            else
                stu.LoGo = form["oldimages"];
                SoccerList stuList = new SoccerList();
                stuList.UpdateStudent(stu);
                return RedirectToAction("Index");
        }


        public ActionResult Detai(string id = "")
        {
            SoccerList stuList = new SoccerList();
            List<Soccer> obj = stuList.GetStudents(id);
            return View(obj.FirstOrDefault());
        }

        public ActionResult Delete(string id = "")
        {
            SoccerList stuList = new SoccerList();
            List<Soccer> obj = stuList.GetStudents(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(Soccer stu)
        {
            SoccerList studentList = new SoccerList();
            studentList.DeleteStudent(stu);
            return RedirectToAction("Index");
        }
    }
}