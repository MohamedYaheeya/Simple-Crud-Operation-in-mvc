using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRUD.Controllers
{
    public class StudentController : Controller
    {
        LearnigConnectionEntities con = new LearnigConnectionEntities();
        // GET: Student
        public ActionResult Index()
        {
            var ListData = con.Studentdts.ToList();
            return View(ListData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //var ListData = con.Studentdts.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Studentdt model)
        {
            if (ModelState.IsValid)
            {
                con.Studentdts.Add(model);
                con.SaveChanges();
                ViewBag.Result = "Data Submitted Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = con.Studentdts.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Studentdt std)
        {
            var data = con.Studentdts.Where(x => x.Id == std.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = std.Id;
                data.Name = std.Name;
                data.Age = std.Age;
                data.Address = std.Address;
                con.SaveChanges();
            };
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = con.Studentdts.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = con.Studentdts.Where(x => x.Id == id).FirstOrDefault();
            con.Studentdts.Remove(data);
            con.SaveChanges();
            ViewBag.Result = "Deleted Success Fully";
            return RedirectToAction("Index");
        }




    }
}
