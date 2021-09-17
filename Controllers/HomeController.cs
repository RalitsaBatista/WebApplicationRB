using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http;
using WebApplicationRB.Models;

namespace WebApplicationRB.Controllers
{
    public class HomeController : BaseController
    {
        
        
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Setlang(HttpRequestMessage request, string lang = "en-US")
        {
            base.SetLanguage(lang);
            string referer = Request.Headers["Referer"];
            
            if (referer != null)
            {
                return Redirect(referer.ToString());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
