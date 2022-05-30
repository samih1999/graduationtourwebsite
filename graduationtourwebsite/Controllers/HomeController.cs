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
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> Index()
        {
            var plc = await _context.Contacts.Select(con => new contact
            {
              FullName = con.FullName, 
              Subject = con.Subject,
              EMail = con.EMail,
              Message = con.Message,
              PhoneNumber = con.PhoneNumber
                



            }).ToListAsync();



            return View(plc);
        }

        public IActionResult aboutus()
        {

            return View();
        }
       
        public async Task<IActionResult> ourtourguides()
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

        public IActionResult addplace()
        {

            return View();
        }
        [HttpPost]
        public IActionResult addplace(string name, string description, string moreinfoURL, string aboutplace ,string photoURL)
        {

            place p = new place
            {
               name = name,
               description = description,
               moreinfoURL = moreinfoURL,
               aboutplace = aboutplace,
                photoURL = photoURL,

            };
            _context.Add(p);
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

        [Authorize(Roles = "user")]
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

            var plc = await _context.places.Select(plc => new place
            {

                Id = plc.Id,
                name = plc.name,
                aboutplace = plc.aboutplace,
                description = plc.description,
                moreinfoURL = plc.moreinfoURL,



            }).ToListAsync();
            var t = new Tuple<List<ApplicationUser>, List<place>>(userst, plc);

            return View(t);
        }



        [HttpPost]
        public async Task<IActionResult> CreateTour(DateTime from, DateTime to , string tourguide, string p,string nameoncard,int cardnum,DateTime exp,int cvv)
        {
            var user = await _userManager.GetUserAsync(User);
            string idf = user.FirstName +" "+ user.LastName;
            string cphone=user.PhoneNumber;
            var tourguided = await _userManager.FindByIdAsync(tourguide);
            string torgudename = tourguided.FirstName + " " + tourguided.LastName;
            string tphone = tourguided.PhoneNumber;   
            string cusid = user.Id;
           



            var numofdayes = (to - from).TotalDays;



              var tour = _context.tours.Where(x=> x.FromDate==from && x.ToDate==to && x.tourguides==tourguide).FirstOrDefault();
            string co = "not confirmed";

            var placeprice=_context.places.Where(x=> x.name==p).FirstOrDefault();
            double pprice = placeprice.price;
           
            if (tour != null)
            {
                
                ViewData["erorrmessage"] = "this time was booked ";
            }
            else
            {
                tour t = new tour
                {
                    exp = exp,
                    cvv = cvv,
                    nameoncard = nameoncard,
                    cardnumber = cardnum,
                    clientphone = cphone,
                    tourguides = tourguide,
                    custid = idf,
                    FromDate = from,
                    ToDate = to,
                    plces = p,
                    tourguidename = torgudename,
                    customerid = cusid,
                    tourguidephone = tphone,
                    price = numofdayes * pprice,
                    status=co
                    
                  
                    
                };
                _context.Add(t);
                _context.SaveChanges();
            }

               
            
          
           
            return RedirectToAction("CreateTour");

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
