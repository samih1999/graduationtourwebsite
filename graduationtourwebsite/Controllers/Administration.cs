using graduationtourwebsite.Data;
using graduationtourwebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace graduationtourwebsite.Controllers
{ [Authorize (Roles ="Admin")]
    public class Administration : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;





        private readonly ILogger<Administration> _logger;

        touguidecontext _context;
        ApplicationDbContext _db;

        public Administration(ILogger<Administration> logger, touguidecontext tor, ApplicationDbContext a, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = a;
            _context = tor;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {
            if (ModelState.IsValid) {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                IdentityResult result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            return View(model);
        }


        public async Task<IActionResult> index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult Index_admin()
        {
              int y = _userManager.Users.Count();
            return View(y);
        }


        public IActionResult widgets()
        {
            return View();
        }


        public async Task<IActionResult> trg()
        {
          
            var trgr = await _context.TGReg.Select (TourGuideREGMod => new TourGuideREGMod
            {
               FirstName = TourGuideREGMod.FirstName,
               LastName = TourGuideREGMod.LastName, 
               EMail = TourGuideREGMod.EMail,
               CvLink = TourGuideREGMod.CvLink,
               Feedback=TourGuideREGMod.Feedback,
               PhoneNumber=TourGuideREGMod.PhoneNumber,
               Id    =TourGuideREGMod.Id,
               Rate =TourGuideREGMod.Rate

            }).ToListAsync();

            return View(trgr);
        }


        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _db.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tour = await _db.Users.FindAsync(id);
            _db.Users.Remove(tour);
            await _db.SaveChangesAsync();
            return RedirectToAction("index", "Users");
        }

        private bool tourExists(string id)
        {
            return _db.Users.Any(e => e.Id == id);
        }



    }




}
