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

        public ActionResult League(string id = null)
        {
            return Content(id);
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