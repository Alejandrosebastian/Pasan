using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class ClasiwebsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClasiwebModel clasiweb; 

        public ClasiwebsController(ApplicationDbContext context)
        {
            _context = context;
            clasiweb = new ClasiwebModel(context);
           
        }
        public List<Clasiweb> Controladortipoweb()
        {
            return clasiweb.Clalisttipo();
        }
        // GET: Clasiwebs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionesWebblue.ToListAsync());
        }

        // GET: Clasiwebs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasiweb = await _context.ClasificacionesWebblue
                .SingleOrDefaultAsync(m => m.clasiwebId == id);
            if (clasiweb == null)
            {
                return NotFound();
            }

            return View(clasiweb);
        }

        // GET: Clasiwebs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasiwebs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("clasiwebId,Detalle")] Clasiweb clasiweb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasiweb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasiweb);
        }

        // GET: Clasiwebs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasiweb = await _context.ClasificacionesWebblue.SingleOrDefaultAsync(m => m.clasiwebId == id);
            if (clasiweb == null)
            {
                return NotFound();
            }
            return View(clasiweb);
        }

        // POST: Clasiwebs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clasiwebId,Detalle")] Clasiweb clasiweb)
        {
            if (id != clasiweb.clasiwebId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasiweb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasiwebExists(clasiweb.clasiwebId))
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
            return View(clasiweb);
        }

        // GET: Clasiwebs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasiweb = await _context.ClasificacionesWebblue
                .SingleOrDefaultAsync(m => m.clasiwebId == id);
            if (clasiweb == null)
            {
                return NotFound();
            }

            return View(clasiweb);
        }

        // POST: Clasiwebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasiweb = await _context.ClasificacionesWebblue.SingleOrDefaultAsync(m => m.clasiwebId == id);
            _context.ClasificacionesWebblue.Remove(clasiweb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasiwebExists(int id)
        {
            return _context.ClasificacionesWebblue.Any(e => e.clasiwebId == id);
        }
    }
}
