using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASSESSS2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASSESSS2.Controllers
{
    public class firstController : Controller
    {
        private RMSContext R = null;
        public firstController(RMSContext _RM)
        {
            R = _RM;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAirline()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewAirline(Airline A)
        {
            try
            {

                R.Airline.AddAsync(A);
                R.SaveChangesAsync();
                ViewBag.Message = A.Name + " airline saved Succeesfully";
                ViewBag.MessageType = "s";

            }
            catch (Exception)
            {
                ViewBag.Message = "unable to save the Airline";
                ViewBag.MessageType = "e";

            }
            return View();
        }
        public IActionResult AllAirlines()
        {
            return View(R.Airline.ToList());
        }
    }  

}
    