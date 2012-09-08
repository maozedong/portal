using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
using System.IO;

namespace Portal.Controllers.Admin
{ 
    public class ImagesController : Controller
    {
        private PortalEntities db = new PortalEntities();

        //
        // GET: /Images/

        public ViewResult Index()
        {
            return View(db.Images.ToList());
        }

        //
        // GET: /Images/Details/5

        public ViewResult Details(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // GET: /Images/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Images/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
          
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                }
          
            return View();
        }
        
        //
        // GET: /Images/Edit/5
 
        public ActionResult Edit(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // POST: /Images/Edit/5

        [HttpPost]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        //
        // GET: /Images/Delete/5
 
        public ActionResult Delete(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // POST: /Images/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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