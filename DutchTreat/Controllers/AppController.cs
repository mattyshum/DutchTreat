using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailservice;

        public AppController(IMailService mailservice)
        {
            _mailservice = mailservice;            
        }

        public IActionResult Index()
        {
            // throw new InvalidProgramException("Things are not working");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailservice.SendMessage("email@thingy.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
          
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
