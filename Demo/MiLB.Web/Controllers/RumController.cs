using System.IO;
using System.Net;
using System.Web.Mvc;
using MiLB.Web.Models;
using Newtonsoft.Json;

namespace MiLB.Web.Controllers
{
    public class RumController : Controller
    {
        public ActionResult Index()
        {
            return Content("More to come...");
        }

        [HttpPost]
        public ActionResult Submit()
        {
            var serializer = new JsonSerializer();
            Rum obj;
            using (var sr = new StreamReader(Request.InputStream))
            using (var tr = new JsonTextReader(sr))
            {
                obj = serializer.Deserialize<Rum>(tr);
            }

            // user agent
            // referer

            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
        }
    }
}