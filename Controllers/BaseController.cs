﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebApplicationRB.Controllers
{
    public class BaseController : Controller
    {
        string[] allowedCultures = new string[] { "en-US", "fi-FI" };
        private IConfiguration configuration;
        public BaseController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public BaseController()
        {

        }
        public void SetLanguage(string lang)
        {
            try
            {

                var cultureInfo = new CultureInfo(lang);
                cultureInfo.NumberFormat.CurrencySymbol = "ˆ";
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Resources.Resource.Culture = cultureInfo;

                //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddYears(1);

                Response.Cookies.Append("lang", cultureInfo.Name, cookieOptions);
                TempData["lang"] = cultureInfo.Name.Split('-').First();
            }
            catch { }
        }

        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

                CultureInfo cultureInfo = new CultureInfo(allowedCultures.First());
                
               
                var cookieLang = Request.Cookies.Where(c => c.Key.Equals("lang")).FirstOrDefault();
                if (cookieLang.Key == null)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Append("lang", cultureInfo.Name, cookieOptions);
                }                
                else
                {
                    cultureInfo = new CultureInfo(cookieLang.Value);
                }
                cultureInfo.NumberFormat.CurrencySymbol = "ˆ";
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
                CultureInfo.CurrentCulture = cultureInfo;
                Resources.Resource.Culture = cultureInfo;

            System.Diagnostics.Debug.WriteLine("current culture: " + CultureInfo.CurrentCulture.Name);
            TempData["lang"] = CultureInfo.CurrentCulture.Name.Split('-').First();
        }
    }
}