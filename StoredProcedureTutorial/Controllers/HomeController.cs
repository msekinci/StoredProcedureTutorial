using StoredProcedureTutorial.Models;
using StoredProcedureTutorial.Models.ManagerModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoredProcedureTutorial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            db.Books.ToList();

            Book book = new Book()
            {
                Name = "TestBook",
                Description = "A Test Book's Description",
                PublishedData = DateTime.Now
            };

            db.Books.Add(book);
            db.SaveChanges();

            return View();
        }
    }

}