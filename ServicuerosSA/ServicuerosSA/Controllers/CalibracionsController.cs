using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class CalibracionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CalibracionModels listaclasiweb;
        private CalibracionModels clasecalibra;
        private CalibracionModels listacalibra;

        public CalibracionsController(ApplicationDbContext context)
        {
            _context = context;
            listaclasiweb = new CalibracionModels(context);
            clasecalibra = new CalibracionModels(context);
            listacalibra = new CalibracionModels(context);
        }
        public List<ClasificacionWB> controladorlistaweb()
        {
            return listaclasiweb.Modelolistaclasiwb();
        }
       
        public List<IdentityError> controladorguardacalibra(int clasiweb, DateTime fecha, int bombo, int cantiA, int cantiB, string codigolote)
        {
            return clasecalibra.Claseguardacalibracion(clasiweb, fecha, bombo, cantiA, cantiB, codigolote);
        }
        public List<object[]> listaIndexCalibra()
        {
            return listacalibra.ModelolistaindexCalibrado();
        }
        // GET: Calibracions
        public async Task<IActionResult> Index()
        {
           // var applicationDbContext = _context.Calibracion.Include(c => c.ClasificacionWB);
            return View(await _context.Calibracion.ToListAsync());
        }

        // GET: Calibracions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracion = await _context.Calibracion
                .Include(c => c.ClasificacionWB)
                .SingleOrDefaultAsync(m => m.CalibracionId == id);
            if (calibracion == null)
            {
                return NotFound();
            }

            return View(calibracion);
        }

        // GET: Calibracions/Create
        public IActionResult Create()
        {
            ViewData["ClasificacionwbId"] = new SelectList(_context.ClasificacionWB, "ClasificacionwbId", "ClasificacionwbId");
            return View();
        }

        // POST: Calibracions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalibracionId,Fechacalibracion,bombo,CantidadA,CantidadB,ClasificacionwbId")] Calibracion calibracion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calibracion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasificacionwbId"] = new SelectList(_context.ClasificacionWB, "ClasificacionwbId", "ClasificacionwbId", calibracion.ClasificacionwbId);
            return View(calibracion);
        }

        // GET: Calibracions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracion = await _context.Calibracion.SingleOrDefaultAsync(m => m.CalibracionId == id);
            if (calibracion == null)
            {
                return NotFound();
            }
            ViewData["ClasificacionwbId"] = new SelectList(_context.ClasificacionWB, "ClasificacionwbId", "ClasificacionwbId", calibracion.ClasificacionwbId);
            return View(calibracion);
        }

        // POST: Calibracions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalibracionId,Fechacalibracion,bombo,CantidadA,CantidadB,ClasificacionwbId")] Calibracion calibracion)
        {
            if (id != calibracion.CalibracionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calibracion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalibracionExists(calibracion.CalibracionId))
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
            ViewData["ClasificacionwbId"] = new SelectList(_context.ClasificacionWB, "ClasificacionwbId", "ClasificacionwbId", calibracion.ClasificacionwbId);
            return View(calibracion);
        }

        // GET: Calibracions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracion = await _context.Calibracion
                .Include(c => c.ClasificacionWB)
                .SingleOrDefaultAsync(m => m.CalibracionId == id);
            if (calibracion == null)
            {
                return NotFound();
            }

            return View(calibracion);
        }

        // POST: Calibracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calibracion = await _context.Calibracion.SingleOrDefaultAsync(m => m.CalibracionId == id);
            _context.Calibracion.Remove(calibracion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalibracionExists(int id)
        {
            return _context.Calibracion.Any(e => e.CalibracionId == id);
        }

        public Muestradatos ControladorUnclasiweb(int id)
        {
            Muestradatos lista = (from claswb in _context.ClasificacionWB
                                  join sele in _context.ClasificacionesWebblue on claswb.clasiwebId equals sele.clasiwebId
                                  join escu in _context.Escurrido on claswb.EscurridoId equals escu.EscurridoId
                                  join cur in _context.Curtido on escu.CurtidoId equals cur.CurtidoId
                                  join bo1 in _context.Bombo on cur.BomboId equals bo1.BomboId
                                  join clatri in _context.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                                  join tripa in _context.ClasificacionTripa on clatri.ClasificacionTripaId equals tripa.ClasificacionTripaId
                                  where claswb.ClasificacionwbId == id
                                  select new Muestradatos
                                  {
                                      fecha = cur.Fecha,
                                      cantidad = Convert.ToInt32(cur.NPieles),
                                      detalle = sele.Detalle,
                                      bombo = bo1.Num_bombo,
                                      tipo = tripa.Detalle
                                  }).First();


            return lista;



        }
    }
}
