using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxDemo.Controllers
{
    public class PeopleController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=MyFirstDb;Integrated Security=true;";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPeople()
        {
            var db = new PersonDb(_connectionString);
            return Json(db.GetPeople());
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            var db = new PersonDb(_connectionString);
            db.AddPerson(person);
            return Json(person);
        }
    }
}