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
using graduationtourwebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace graduationtourwebsite.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;





        private readonly ILogger<HomeController> _logger;

        touguidecontext _context;
        ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, touguidecontext tor, ApplicationDbContext a, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = a;
            _context = tor;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult aboutus()
        {

            return View();
        }

        public async Task<IActionResult> Places()
        {

            var plc = await _context.places.Select(plc => new place
            {

                Id = plc.Id,
                name = plc.name,
                aboutplace = plc.aboutplace,
                description = plc.description,
                moreinfoURL = plc.moreinfoURL,



            }).ToListAsync();
            return View(plc);


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
        public IActionResult contactus(string? name, string subject, string email, string message, string phonenumber)
        {

            contact con = new contact
            {
                FullName = name,
                Subject = subject,
                Message = message,
                EMail = email,
                PhoneNumber = phonenumber,

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


        public async Task<IActionResult> CreateTour()
        {

            //var item = _db.Users.Include(e=> e.Id.)


            var Users = _userManager.Users;
            var userst = await (from user in _db.Users
                                join userRole in _db.UserRoles
                                on user.Id equals userRole.UserId
                                join role in _db.Roles
                                on userRole.RoleId equals role.Id
                                where role.Name == "tourguide"
                                select user).ToListAsync();

            return View(userst);
        }

        public ActionResult sami()
        {
            tour t = new tour()
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(1),
            };
            return View(t);
        }

        [HttpPost]
        public ActionResult sami(tour v)
        {
            return Content(((v.ToDate - v.FromDate).TotalDays).ToString());
        }

    }
}
