using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicoShopCRM.Data;
using TicoShopCRM.Models;

namespace TicoShopCRM.Controllers
{
    public class CasosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Casos.Include(c => c.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var caso = await _context.Casos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (caso == null)
                return NotFound();

            return View(caso);
        }

        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Caso caso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", caso.ClienteId);
            return View(caso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var caso = await _context.Casos.FindAsync(id);

            if (caso == null)
                return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", caso.ClienteId);
            return View(caso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Caso caso)
        {
            if (id != caso.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(caso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", caso.ClienteId);
            return View(caso);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var caso = await _context.Casos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (caso == null)
                return NotFound();

            return View(caso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caso = await _context.Casos.FindAsync(id);

            if (caso != null)
            {
                _context.Casos.Remove(caso);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}