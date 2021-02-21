using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spice.DataLayer;
using Spice.DomainModel;
using SpiceProject.Models;
using SpiceProject.ViewModels;
using System.Data.Entity;

namespace SpiceProject.Controllers
{
    public class SubContollerController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: SubContoller
        public ActionResult Index()
        {
            var subCategories = db.SubCategory.Include(s => s.Category).ToList();
            return View(subCategories);
        }
        public ActionResult Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = db.Category.ToList(),
                SubCategory = new SubCategory(),
                SubCategoryList = db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToList()
            };

            return View(model);
        }

        //POST - CREATE
        [HttpPost]
        public ActionResult Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = db.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);

                if (doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    model.StatusMessage = "Error : Sub Category exists under " + doesSubCategoryExists.First().Category.Name + " category. Please use another name.";
                }
                else
                {
                   db.SubCategory.Add(model.SubCategory);
                    db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = db.Category.ToList(),
                SubCategory = model.SubCategory,
                SubCategoryList = db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToList(),
                StatusMessage = model.StatusMessage
            };
            return View(modelVM);
        }


        [ActionName("GetSubCategory")]
        public  ActionResult GetSubCategory(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories =  (from subCategory in db.SubCategory
                                   where subCategory.CategoryId == id
                                   select subCategory).ToList();
            return Json(new SelectList(subCategories, "Id", "Name"));
        }


        //GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var subCategory = db.SubCategory.SingleOrDefault(m => m.Id == id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            return View(subCategory);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var subCategory = db.SubCategory.SingleOrDefault(m => m.Id == id);
            db.SubCategory.Remove(subCategory);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
