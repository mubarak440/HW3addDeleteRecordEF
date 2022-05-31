using HW3addDeleteRecordEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HW3addDeleteRecordEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        /*
         * //load and open class
            var contexts = new Db.ContactsContext();//get access to the database
            
            var results = contexts.Contacts;
            return View(results);
         */

        [HttpGet]
        public IActionResult Contacts()
        {

            //load and open class
            var contexts = new Db.ContactsContext();//get access to the database

            var results = contexts.Contacts.ToList();
            int txt = results.Count();
            //.Include(t => t.ContactName)
            //.OrderBy(t => t.ContactName);
            contexts.SaveChanges();
            
            return View(results);
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}