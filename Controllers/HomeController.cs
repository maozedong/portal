using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        PortalEntities portalDB = new PortalEntities();
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var services = portalDB.Services.Include("Images").ToList();
            return View(services);
        }

        //
        // GET: /Home/Browse?service=1

        public ActionResult Browse (string service)
        {
            var serviceModel = portalDB.Services.Include("Images").Single(s => s.Name == service);
            return View(serviceModel);
        }
    }
}
