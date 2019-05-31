using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class BodegaCarnazasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private BodegaCarnazaModel listaCarnaza;
        private ClasificacionTripaModel listatipotripa;
        private BodegaCarnazaModel guardaCarnaza;
        public BodegaCarnazasController(ApplicationDbContext context)
        {
            _context = context;
            listaCarnaza = new BodegaCarnazaModel(context);
            listatipotripa = new ClasificacionTripaModel(context);
            guardaCarnaza = new BodegaCarnazaModel(context);
        }
        //GuardaCarnaza
        public List<IdentityError> ControladorGuardaCarnaza(string codigo, decimal peso)
        {
            return guardaCarnaza.ClaseguardaCarnaza(codigo, peso);
        }
        public List<Descarne> Controladorlistadescarne()
        {
            return listatipotripa.Claselistadescarnes();
        }
        // GET: BodegaCarnazas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BodegaCarnaza_1.Include(b => b.Bodegatripas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BodegaCarnazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaCarnaza = await _context.BodegaCarnaza_1
                .Include(b => b.Bodegatripas)
                .SingleOrDefaultAsync(m => m.BodegaCarnazaId == id);
            if (bodegaCarnaza == null)
            {
                return NotFound();
            }

            return View(bodegaCarnaza);
        }

        // GET: BodegaCarnazas/Create
        public IActionResult Create()
        {
            ViewData["BodegaTripaId"] = new SelectList(_context.Bodegatripa, "BodegaTripaId", "BodegaTripaId");
            return View();
        }

        // POST: BodegaCarnazas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BodegaCarnazaId,Cantidad,Codigo,BodegaTripaId")] BodegaCarnaza bodegaCarnaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodegaCarnaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodegaTripaId"] = new SelectList(_context.Bodegatripa, "BodegaTripaId", "BodegaTripaId", bodegaCarnaza.BodegaTripaId);
            return View(bodegaCarnaza);
        }

        // GET: BodegaCarnazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaCarnaza = await _context.BodegaCarnaza_1.SingleOrDefaultAsync(m => m.BodegaCarnazaId == id);
            if (bodegaCarnaza == null)
            {
                return NotFound();
            }
            ViewData["BodegaTripaId"] = new SelectList(_context.Bodegatripa, "BodegaTripaId", "BodegaTripaId", bodegaCarnaza.BodegaTripaId);
            return View(bodegaCarnaza);
        }

        // POST: BodegaCarnazas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodegaCarnazaId,Cantidad,Codigo,BodegaTripaId")] BodegaCarnaza bodegaCarnaza)
        {
            if (id != bodegaCarnaza.BodegaCarnazaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodegaCarnaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaCarnazaExists(bodegaCarnaza.BodegaCarnazaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodegaTripaId"] = new SelectList(_context.Bodegatripa, "BodegaTripaId", "BodegaTripaId", bodegaCarnaza.BodegaTripaId);
            return View(bodegaCarnaza);
        }

        // GET: BodegaCarnazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodegaCarnaza = await _context.BodegaCarnaza_1
                .Include(b => b.Bodegatripas)
                .SingleOrDefaultAsync(m => m.BodegaCarnazaId == id);
            if (bodegaCarnaza == null)
            {
                return NotFound();
            }

            return View(bodegaCarnaza);
        }

        // POST: BodegaCarnazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodegaCarnaza = await _context.BodegaCarnaza_1.SingleOrDefaultAsync(m => m.BodegaCarnazaId == id);
            _context.BodegaCarnaza_1.Remove(bodegaCarnaza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaCarnazaExists(int id)
        {
            return _context.BodegaCarnaza_1.Any(e => e.BodegaCarnazaId == id);
        }
    }
}
