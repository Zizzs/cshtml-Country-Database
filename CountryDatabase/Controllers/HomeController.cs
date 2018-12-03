using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CountryDatabase.Models;

namespace CountryDatabase.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
