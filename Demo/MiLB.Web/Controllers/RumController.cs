using System.IO;
using System.Net;
using System.Web.Mvc;
using MiLB.Web.Models;
using Newtonsoft.Json;

namespace MiLB.Web.Controllers
{
    public class RumController : Controller
    {
        [HttpPost]
        public ActionResult Submit()
        {
            var serializer = new JsonSerializer();
            Rum rum;
            using (var sr = new StreamReader(Request.InputStream))
            using (var tr = new JsonTextReader(sr))
            {
                rum = serializer.Deserialize<Rum>(tr);
            }

            rum.Referrer = Request.UrlReferrer != null ? Request.UrlReferrer.AbsoluteUri : null;
            rum.Agent = Request.UserAgent;
            rum.IpAddress = Request.UserHostAddress;

            // persist rum somewhere...

            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
        }
    }
}