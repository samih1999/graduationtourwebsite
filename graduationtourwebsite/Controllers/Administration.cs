using graduationtourwebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace graduationtourwebsite.Controllers
{ [Authorize (Roles ="Admin")]
    public class Administration : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public Administration(RoleManager<IdentityRole> roleManager) { this.roleManager = roleManager; }
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
                IdentityResult result = await roleManager.CreateAsync(role);
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
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }


        public IActionResult Index_admin()
        {
            return View();
        }


        public IActionResult widgets()
        {
            return View();
        }
    }
}
