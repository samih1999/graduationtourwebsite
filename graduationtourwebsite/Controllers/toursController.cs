using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using graduationtourwebsite.Models;

namespace graduationtourwebsite.Controllers
{
    public class toursController : Controller
    {
        private readonly touguidecontext _context;

        public toursController(touguidecontext context)
        {
            _context = context;
        }

        // GET: tours
       

        // GET: tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

      

        // GET: tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.tours
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _context.tours.FindAsync(id);
            _context.tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction("mytoursuser", "Users");
        }

        private bool tourExists(int id)
        {
            return _context.tours.Any(e => e.Id == id);
        }


        public async Task<IActionResult> pay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }


        [HttpPost, ActionName("pay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> post(int id)
        {
            var tour = await _context.tours.FindAsync(id);
            tour.balance = tour.balance - tour.price;
            tour.status = "confirmed";
            await _context.SaveChangesAsync();
            return RedirectToAction("mytoursuser", "Users");
          
        }

    }
}
