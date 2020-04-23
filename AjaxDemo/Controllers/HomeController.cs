using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxDemo.Models;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRandomPeople(int count)
        {
            var list = new List<Person>();
            for (int i = 1; i <= count; i++)
            {
                list.Add(new Person
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Age = Faker.RandomNumber.Next(20, 75)
                });
            }

            return Json(list);
        }

        public IActionResult Reverse(string text)
        {
            var reversed = new string(text.Reverse().ToArray());

            var jsonObject = new
            {
                reversedText = reversed
            };
            return Json(jsonObject);
        }
    }
}
