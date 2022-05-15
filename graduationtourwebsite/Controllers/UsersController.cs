using graduationtourwebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace graduationtourwebsite.Controllers
{
    public class UsersController : Controller
    { private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users=await _userManager.Users.Select(user =>new UserviewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,   
                Id = user.Id,
                Roles=_userManager.GetRolesAsync(user).Result
            }).ToListAsync();


            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
                if(user == null)
                return NotFound();
                var roles=await _roleManager.Roles.ToListAsync();
            var viewmodel = new UserRoleviewmodel
            {
                UserId = userId,
                UserName = user.UserName,   
                Roles=roles.Select(role => new Rolesview
                {
                    RoleName = role.Name,
                    RoleId = role.Id,
                    isselected= _userManager.IsInRoleAsync(user,role.Name).Result
                }).ToList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRoleviewmodel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            var userroles = await _userManager.GetRolesAsync(user);
            foreach(var role in model.Roles)
            {
                if (userroles.Any(r => r == role.RoleName) && !role.isselected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                
                
                
                if (!userroles.Any(r => r == role.RoleName) && role.isselected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);



            }
            return RedirectToAction(nameof(Index));
                }



    }
}
