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
        
        public IActionResult Weather()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormResult()
        {
            ViewData["text1"] = Request.Form["text1"];
            ViewData["select1"] = Request.Form["select1"];
            ViewData["radio1"] = Request.Form["radio1"];
            ViewData["checkbox1"] = (Request.Form["checkbox1"] == "on") ? 1 : 0;
            ViewData["checkbox2"] = (Request.Form["checkbox2"] == "on") ? 1 : 0;
            ViewData["checkbox3"] = (Request.Form["checkbox3"] == "on") ? 1 : 0;


            foreach (var item in Request.Form)
            {
                //if (!key.ToString().StartsWith("checkbox")) continue;
                System.Diagnostics.Debug.WriteLine(item.Key + " = " + item.Value);
            }
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
