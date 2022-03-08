using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
            ViewBag.UserMessage = "Mail Sent";
            ModelState.Clear();

        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
           return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send the email
                _mailService.SendMessage("machaba.nokubonga@gmail.com", model.Subject, $"From: {model.Name} - { model.Email}, Message: {model.Message}");
            }
            
            return View();
        }
        
        public IActionResult About()
        {
            ViewBag.Title = "About us";  
            return View();
        }
    }
}
