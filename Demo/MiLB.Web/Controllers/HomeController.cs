using System.Data.Entity;
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
            var mascots = dataContext.Mascots.ToList();

            var mascot = mascots.First();
            var league = mascot.Team.League;

            dataContext.Leagues.Include(l => l.Teams);

            var teams = dataContext.Teams.ToList();

            var mascot1 = teams.First().Mascot;

            return View();
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