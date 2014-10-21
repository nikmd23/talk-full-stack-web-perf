using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using MiLB.Web.Models;

namespace MiLB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext dataContext = new DataContext();

        public ActionResult Index()
        {
            Trace.TraceInformation("Displaying home page.");
            return View(dataContext.Mascots.Where(m => m.IsHero).Single());
        }

        public ActionResult All()
        {
            Trace.TraceInformation("Displaying all mascots.");
            return View(dataContext.Mascots.ToList());
        }

        public ActionResult League(string id)
        {
            Trace.TraceInformation("Displaying mascots from league with id: " + id);
            var mascots = dataContext.Mascots
                    .Where(m => m.Team.League.Slug.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            return View(mascots.ToList());
        }

        public ActionResult Mascot(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var mascot = dataContext.Mascots.Single(m => m.Slug == id);

            return View(mascot);
        }

        public void ThirdPartyScript()
        {
            Thread.Sleep(3000);

            Response.ContentType = "application/javascript";
            Response.Write("console.log('Downloaded 3rd party script.'); function init(){ console.log('Initialized 3rd party script.'); }");
        }

        public ActionResult Champions()
        {
            Trace.TraceInformation("Displaying Mascot Mania winners.");
            var mascots = dataContext.Mascots.Where(m => m.IsChampion).ToList();

            return View(mascots);
        }

        protected override void Dispose(bool disposing)
        {
            dataContext.Dispose();
        }
    }
}