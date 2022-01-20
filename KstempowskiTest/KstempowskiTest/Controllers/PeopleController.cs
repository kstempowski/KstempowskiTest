using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KstempowskiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace KstempowskiTest.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleContext _context;
        public PeopleController(PeopleContext context)
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
            return View("Person", person);
        }

        public IActionResult CreateJelly(Person human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
            return RedirectToAction("PersonList", human);
        }
    }
}
