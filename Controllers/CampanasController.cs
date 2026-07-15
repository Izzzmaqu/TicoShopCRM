using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicoShopCRM.Data;
using TicoShopCRM.Models;

namespace TicoShopCRM.Controllers
{
    public class CampanasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampanasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Campanas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var campana = await _context.Campanas.FirstOrDefaultAsync(m => m.Id == id);

            if (campana == null)
                return NotFound();

            return View(campana);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campana campana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(campana);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var campana = await _context.Campanas.FindAsync(id);

            if (campana == null)
                return NotFound();

            return View(campana);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Campana campana)
        {
            if (id != campana.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(campana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(campana);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var campana = await _context.Campanas.FirstOrDefaultAsync(m => m.Id == id);

            if (campana == null)
                return NotFound();

            return View(campana);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campana = await _context.Campanas.FindAsync(id);

            if (campana != null)
            {
                _context.Campanas.Remove(campana);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}