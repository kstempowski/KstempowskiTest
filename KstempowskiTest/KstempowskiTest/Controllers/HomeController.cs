using KstempowskiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KstempowskiTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleContext _context;
        public HomeController(PeopleContext context)
        {
            _context = context;
        }
    

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonList()
        {
            var person = _context.People.ToList();
            return View("PersonForm", person);
        }

        public IActionResult AddPerson(Person human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
            return RedirectToAction("PersonList", human);
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
