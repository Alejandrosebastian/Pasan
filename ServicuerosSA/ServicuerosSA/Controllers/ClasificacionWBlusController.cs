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
    public class ClasificacionWBlusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClasificacionModelsWB listacurtidos;
        private ClasificacionModelsWB listaindex;
        private ClasificacionModelsWB guardawb;



        public ClasificacionWBlusController(ApplicationDbContext context)
        {
            _context = context;
            listacurtidos = new ClasificacionModelsWB(context);
            guardawb = new ClasificacionModelsWB(context);
            listaindex = new ClasificacionModelsWB(context);
            

        }
        public List<Escurrido> Controladorlistaescurrido()
        {
            return listacurtidos.Claselistamodelescurrido();
        }

        public List<IdentityError> ControladorguardaWB(DateTime fecha, int numeropieles, string observaciones, int bodega, int bombo,  int tipo, int personal, string codigolote, int escurrido)
        {
            return guardawb.claseguardaweb(fecha, numeropieles, observaciones, bodega, bombo,  tipo, personal, codigolote, escurrido);
    }
        public List<object[]> ControladorindexWB()
        {
            return listaindex.ModelolistaindexclasiWB();
        }
        // GET: ClasificacionWBlus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClasificacionWB.ToListAsync());
        }

        // GET: ClasificacionWBlus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB
                .SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }

            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClasificacionWBlus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificacionwbId,Fecha,NumeroPieles,Observaciones")] ClasificacionWB clasificacionWB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacionWB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB.SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }
            return View(clasificacionWB);
        }

        // POST: ClasificacionWBlus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificacionwbId,Fecha,NumeroPieles,Observaciones")] ClasificacionWB clasificacionWB)
        {
            if (id != clasificacionWB.ClasificacionwbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacionWB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionWBExists(clasificacionWB.ClasificacionwbId))
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
            return View(clasificacionWB);
        }

        // GET: ClasificacionWBlus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasificacionWB = await _context.ClasificacionWB
                .SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            if (clasificacionWB == null)
            {
                return NotFound();
            }

            return View(clasificacionWB);
        }

        // POST: ClasificacionWBlus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasificacionWB = await _context.ClasificacionWB.SingleOrDefaultAsync(m => m.ClasificacionwbId == id);
            _context.ClasificacionWB.Remove(clasificacionWB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionWBExists(int id)
        {
            return _context.ClasificacionWB.Any(e => e.ClasificacionwbId == id);
        }

        public MostrarDatos Controladorunescurre(string id)
        {
            MostrarDatos lista = (from ex in _context.Escurrido
                                        join b in _context.Bombo on ex.BomboId equals b.BomboId
                                        where ex.CodigoLote == id
                                        select new MostrarDatos
                                        {
                                            bombo = b.Num_bombo.ToString(),
                                            cantidad = ex.Cantidad,
                                            codigo = ex.CodigoLote,
                                            fecha = ex.Fecha

                                        }).First();
            return lista;
        }

    }
    

}
