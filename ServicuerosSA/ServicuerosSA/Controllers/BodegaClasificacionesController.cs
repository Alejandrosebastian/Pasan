﻿using System;
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
    public class BodegaClasificacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BodegaClasificacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BodegaClasificaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bodega1.Include(b => b.Bodegas).Include(b => b.Clasificaciones).Include(b => b.Lotes).Where(B1 => B1.activo == true).Where(b => b.activo == true);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BodegaClasificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega1 = await _context.Bodega1
                .Include(b => b.Bodegas)
                .Include(b => b.Clasificaciones)
                .Include(b => b.Lotes)
                .Include(b => b.Medida)
                .Include(b => b.TipoPiel)
                .SingleOrDefaultAsync(m => m.Bodega1Id == id);
            if (bodega1 == null)
            {
                return NotFound();
            }

            return View(bodega1);
        }

        // GET: BodegaClasificaciones/Create
        public IActionResult Create()
        {
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega");
            ViewData["ClasificacionId"] = new SelectList(_context.Clasificacion, "ClasificacionId", "Selecciones");
            ViewData["LoteId"] = new SelectList(_context.Lote.Where(l => l.estado == true), "LoteId", "Codigolote");
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura");
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle");
            return View();
        }

        // POST: BodegaClasificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bodega1Id,BodegaId,LoteId,ClasificacionId,MedidaId,Fechaingreso,NumeroEstanteria,NumeroPieles,Peso,Observaciones,activo,TipoPielId")] Bodega1 bodega1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", bodega1.BodegaId);
            ViewData["ClasificacionId"] = new SelectList(_context.Clasificacion, "ClasificacionId", "Selecciones", bodega1.ClasificacionId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", bodega1.LoteId);
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", bodega1.MedidaId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", bodega1.TipoPielId);
            return View(bodega1);
        }

        // GET: BodegaClasificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega1 = await _context.Bodega1.SingleOrDefaultAsync(m => m.Bodega1Id == id);
            if (bodega1 == null)
            {
                return NotFound();
            }
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", bodega1.BodegaId);
            ViewData["ClasificacionId"] = new SelectList(_context.Clasificacion, "ClasificacionId", "Selecciones", bodega1.ClasificacionId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", bodega1.LoteId);
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", bodega1.MedidaId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", bodega1.TipoPielId);
            return View(bodega1);
        }

        // POST: BodegaClasificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bodega1Id,BodegaId,LoteId,ClasificacionId,MedidaId,Fechaingreso,NumeroEstanteria,NumeroPieles,Peso,Observaciones,activo,TipoPielId")] Bodega1 bodega1)
        {
            if (id != bodega1.Bodega1Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Bodega1Exists(bodega1.Bodega1Id))
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
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", bodega1.BodegaId);
            ViewData["ClasificacionId"] = new SelectList(_context.Clasificacion, "ClasificacionId", "Selecciones", bodega1.ClasificacionId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteId", "Codigolote", bodega1.LoteId);
            ViewData["MedidaId"] = new SelectList(_context.Medida, "MedidaId", "Abreviatura", bodega1.MedidaId);
            ViewData["TipoPielId"] = new SelectList(_context.TipoPiel, "TipoPielId", "Detalle", bodega1.TipoPielId);
            return View(bodega1);
        }

        // GET: BodegaClasificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega1 = await _context.Bodega1
                .Include(b => b.Bodegas)
                .Include(b => b.Clasificaciones)
                .Include(b => b.Lotes)
                .Include(b => b.Medida)
                .Include(b => b.TipoPiel)
                .SingleOrDefaultAsync(m => m.Bodega1Id == id);
            if (bodega1 == null)
            {
                return NotFound();
            }

            return View(bodega1);
        }

        // POST: BodegaClasificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodega1 = await _context.Bodega1.SingleOrDefaultAsync(m => m.Bodega1Id == id);
            _context.Bodega1.Remove(bodega1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Bodega1Exists(int id)
        {
            return _context.Bodega1.Any(e => e.Bodega1Id == id);
        }
    }
}
