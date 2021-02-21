using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spice.DataLayer;
using Spice.DomainModel;
using SpiceProject.Models;

namespace SpiceProject.Controllers
{
    public class CategoryController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var category = db.Category.ToList();
            return View(category);
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        
        
        //POST - CREATE
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //if valid
                db.Category.Add(category);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(category);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var emp = db.Category.SingleOrDefault(e => e.Id == id);
            //var category = db.Category.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);

        }

        [HttpPost]
        public  ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                var updatedRes = db.Category.Where(e => e.Id == category.Id).FirstOrDefault();
                updatedRes.Name = category.Name;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        //GET - DELETE
        public ActionResult Delete(int? id)
        {
            var deleteCat = db.Category.Where(e => e.Id == id).FirstOrDefault();
            return View(deleteCat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id,Category c)
        {
            var del = db.Category.Where(r => r.Id == id).FirstOrDefault();
            db.Category.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

    }
}