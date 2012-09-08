using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace Portal.Controllers.Admin
{ 
    public class ServicesManagerController : Controller
    {
        private PortalEntities db = new PortalEntities();

        //
        // GET: /ServicesManager/

        public ViewResult Index()
        {
            return View(db.Services.ToList());
        }

        //
        // GET: /ServicesManager/Details/5

        public ViewResult Details(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }

        //
        // GET: /ServicesManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ServicesManager/Create

        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(service);
        }
        
        //
        // GET: /ServicesManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }

        //
        // POST: /ServicesManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        //
        // GET: /ServicesManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Service service = db.Services.Find(id);
            return View(service);
        }

        //
        // POST: /ServicesManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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