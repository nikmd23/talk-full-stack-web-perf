using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CourtesyFlush;
using MiLB.Web.Models;

namespace MiLB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext dataContext = new DataContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Items["actionTimer"] = Stopwatch.StartNew();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var stopwatch = filterContext.HttpContext.Items["actionTimer"] as Stopwatch;
            if (stopwatch != null)
                filterContext.Controller.ViewBag.ActionTime = stopwatch.ElapsedMilliseconds;
        }

        [FlushHead(Title = "Home Page")]
        [OutputCache(Duration = 7200)]
        public ActionResult Index()
        {
            Trace.TraceInformation("Displaying home page.");

            var stopwatch = Stopwatch.StartNew();
            var hero = dataContext.Mascots.Where(m => m.IsHero).Single();
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;
            
            return View(hero);
        }

        [FlushHead(Title = "All Mascots")]
        [OutputCache(Duration = 7200)]
        public ActionResult All()
        {
            Trace.TraceInformation("Displaying all mascots.");

            var stopwatch = Stopwatch.StartNew();
            var allMascots = dataContext.Mascots.ToList();
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;

            return View(allMascots);
        }

        public ActionResult Search(string q)
        {
            ViewBag.Title = "Mascot Search: '" + Server.HtmlEncode(q) + "'";
            this.FlushHead();

            ViewBag.Query = q;
            Trace.TraceInformation("Mascots search: '" + Server.HtmlEncode(q) + "'");

            var stopwatch = Stopwatch.StartNew();
            var allMascots = dataContext.Mascots.Where(m => m.Name.Contains(q)).ToList();
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;

            return View(allMascots);
        }

        [OutputCache(Duration = 7200)]
        public ActionResult League(string id)
        {
            Trace.TraceInformation("Displaying mascots from league with id: " + id);

            var stopwatch = Stopwatch.StartNew();
            var mascots = dataContext.Mascots
                    .Where(m => m.Team.League.Slug.Equals(id, StringComparison.InvariantCultureIgnoreCase)).ToList();
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;

            return View(mascots);
        }

        [OutputCache(Duration = 7200)]
        public ActionResult Mascot(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            var stopwatch = Stopwatch.StartNew();
            var mascot = dataContext.Mascots.Single(m => m.Slug == id);
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;

            return View(mascot);
        }

        public void ThirdPartyScript()
        {
            Thread.Sleep(3000);

            Response.ContentType = "application/javascript";
            Response.Write("console.log('Downloaded 3rd party script.'); function init(){ console.log('Initialized 3rd party script.'); }");
        }

        [OutputCache(Duration = 7200)]
        public ActionResult Champions()
        {
            ViewBag.Title = string.Format("Champions ({0})", DateTime.Now.Year);
            this.FlushHead();

            Trace.TraceInformation("Displaying Mascot Mania winners.");

            var stopwatch = Stopwatch.StartNew();
            var mascots = dataContext.Mascots.Where(m => m.IsChampion).ToList();
            ViewBag.QueryTime = stopwatch.ElapsedMilliseconds;

            return View(mascots);
        }

        protected override void Dispose(bool disposing)
        {
            dataContext.Dispose();
        }
    }
}