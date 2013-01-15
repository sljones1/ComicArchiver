using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicArchiver.Models;

namespace ComicArchiver.Controllers
{ 
    public class Default1Controller : Controller
    {
        private ComicSeriesDbContext db = new ComicSeriesDbContext();

        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(db.ComicsOwned.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(int id)
        {
            ComicSeries comicseries = db.ComicsOwned.Find(id);
            return View(comicseries);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(ComicSeries comicseries)
        {
            if (ModelState.IsValid)
            {
                db.ComicsOwned.Add(comicseries);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(comicseries);
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(int id)
        {
            ComicSeries comicseries = db.ComicsOwned.Find(id);
            return View(comicseries);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(ComicSeries comicseries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comicseries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comicseries);
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(int id)
        {
            ComicSeries comicseries = db.ComicsOwned.Find(id);
            return View(comicseries);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ComicSeries comicseries = db.ComicsOwned.Find(id);
            db.ComicsOwned.Remove(comicseries);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}