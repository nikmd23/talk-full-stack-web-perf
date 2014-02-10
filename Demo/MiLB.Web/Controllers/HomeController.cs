using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult All()
        {
            return View(dataContext.Mascots.ToList());
        }

        public ActionResult League(string id)
        {
            var mascots = dataContext.Mascots
                    .Where(m => m.Team.League.Name.Equals(id, StringComparison.InvariantCultureIgnoreCase));

            return View(mascots.ToList());
        }

        public void Script()
        {
            Thread.Sleep(3000);

            Response.ContentType = "application/javascript";
            Response.Write("console.log('Loose alert'); function loaded(){console.log('in function');}");
        }

        protected override void Dispose(bool disposing)
        {
            dataContext.Dispose();
        }
    }
}