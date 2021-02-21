using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spice.DataLayer;

namespace SpiceProject.Controllers
{
    public class MenuItemController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: MenuItem
        public ActionResult Index()
        {
            var category = db.MenuItems.ToList();
            return View(category);
        }

    }
}