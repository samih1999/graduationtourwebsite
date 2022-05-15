using graduationtourwebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using graduationtourwebsite.Models;
using Microsoft.AspNetCore.Identity;


namespace graduationtourwebsite.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        touguidecontext _context;


        public HomeController(ILogger<HomeController> logger,touguidecontext tor)
        {
            _context = tor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult aboutus()
        {

            return View();
        }

        public IActionResult Places()
        {

            return View();
        }
        

        public IActionResult All_tourguides()
        {

            return View();
        }
        public IActionResult TG_REG()
        {

            return View();
        }
        [HttpPost]
        public IActionResult TG_REG(string firstname, string lastname, string email, string phonenumber, string cv)
        {
            TourGuideREGMod TGREG = new TourGuideREGMod()
            {
                FirstName = firstname,
                LastName = lastname,
                EMail = email,
                PhoneNumber = phonenumber,
                CvLink = cv,

            };
            _context.Add(TGREG);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult contactus()
        {

            return View();
        }
        [HttpPost]
        public IActionResult contactus (string ?name, string subject,string email,string message,string phonenumber)
        {
            
            contact con = new contact { 
            FullName = name,    
            Subject = subject,  
            Message = message,
            EMail= email,
            PhoneNumber=phonenumber,

            };
            _context.Add(con);
            _context.SaveChanges();
            return RedirectToAction("Index");

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
