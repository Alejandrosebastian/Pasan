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
    public class MedidoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private MedidoModels listaindex;
        private MedidoModels listacombo;
        private MedidoModels claseguarda;
        private MedidoModels listatipo;
        private MedidoModels listaIndexMedidos;
        public MedidoesController(ApplicationDbContext context)
        {
            _context = context;
            listaindex = new MedidoModels(context);
            listacombo = new MedidoModels(context);
            claseguarda = new MedidoModels(context);
            listatipo = new MedidoModels(context);
            listaIndexMedidos = new MedidoModels(context);
        }
        public List<Calibracion> controladorcombo()
        {
            return listacombo.Modelolistaclasiwb();
        }
        public List<ClasificacionTripa> Controladortipotripa()
        {
            return listatipo.ClaseTripa();
        }
        public List <object[]> ListaIndexMedido()
        {
            return listaIndexMedidos.ModelolistaindexMedido();
        }
            
        public List<IdentityError> ControladorguardaMedido(string codigolote, DateTime fecha, int calibracion, int cantidad, string pallet, Decimal area, int bodega, int personal, string tipo, string clasiweb, int estan, string codiunimedido)
        {
            return claseguarda.ClaseguardaMedido(codigolote, fecha, calibracion, cantidad, pallet, area, bodega, personal,tipo,clasiweb,estan, codiunimedido);
        }
        // GET: Medidoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medido.Include(m => m.Calibracion).Include(m => m.bodega).Include(m => m.personal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Medidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medido = await _context.Medido
                .Include(m => m.Calibracion)
                .Include(m => m.bodega)
                .Include(m => m.personal)
                .SingleOrDefaultAsync(m => m.MedidoId == id);
            if (medido == null)
            {
                return NotFound();
            }

            return View(medido);
        }

        // GET: Medidoes/Create
        public IActionResult Create()
        {
            ViewData["CalibracionId"] = new SelectList(_context.Calibracion, "CalibracionId", "CalibracionId");
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega");
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos");
            return View();
        }

        // POST: Medidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedidoId,Codigolote,BodegaId,PersonalId,Cantidad,Pallet,Area,Fecha,activo,CalibracionId")] Medido medido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalibracionId"] = new SelectList(_context.Calibracion, "CalibracionId", "CalibracionId", medido.CalibracionId);
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", medido.BodegaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", medido.PersonalId);
            return View(medido);
        }

        // GET: Medidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medido = await _context.Medido.SingleOrDefaultAsync(m => m.MedidoId == id);
            if (medido == null)
            {
                return NotFound();
            }
            ViewData["CalibracionId"] = new SelectList(_context.Calibracion, "CalibracionId", "CalibracionId", medido.CalibracionId);
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", medido.BodegaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", medido.PersonalId);
            return View(medido);
        }

        // POST: Medidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedidoId,Codigolote,BodegaId,PersonalId,Cantidad,Pallet,Area,Fecha,activo,CalibracionId")] Medido medido)
        {
            if (id != medido.MedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedidoExists(medido.MedidoId))
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
            ViewData["CalibracionId"] = new SelectList(_context.Calibracion, "CalibracionId", "CalibracionId", medido.CalibracionId);
            ViewData["BodegaId"] = new SelectList(_context.Bodega, "BodegaId", "NombreBodega", medido.BodegaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", medido.PersonalId);
            return View(medido);
        }

        // GET: Medidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medido = await _context.Medido
                .Include(m => m.Calibracion)
                .Include(m => m.bodega)
                .Include(m => m.personal)
                .SingleOrDefaultAsync(m => m.MedidoId == id);
            if (medido == null)
            {
                return NotFound();
            }

            return View(medido);
        }

        // POST: Medidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medido = await _context.Medido.SingleOrDefaultAsync(m => m.MedidoId == id);
            _context.Medido.Remove(medido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedidoExists(int id)
        {
            return _context.Medido.Any(e => e.MedidoId == id);
        }
        public int controladoruncali()
        {
            return _context.Calibracion.Where(me => me.activo == true).Sum(me => me.CantidadA);
        }
        public datosmedido ControladorUncalibrado(int id)
        {
            datosmedido listame = (from cali in _context.Calibracion
                                    join claswb in _context.ClasificacionWB on cali.ClasificacionwbId equals claswb.ClasificacionwbId
                                  join sele in _context.ClasificacionesWebblue on claswb.clasiwebId equals sele.clasiwebId
                                  join escu in _context.Escurrido on claswb.EscurridoId equals escu.EscurridoId
                                  join cur in _context.Curtido on escu.CurtidoId equals cur.CurtidoId
                                  join bo1 in _context.Bombo on cur.BomboId equals bo1.BomboId
                                  join clatri in _context.Bodegatripa on cur.BodegaTripaId equals clatri.BodegaTripaId
                                  join tripa in _context.ClasificacionTripa on clatri.ClasificacionTripaId equals tripa.ClasificacionTripaId
                                  where cali.CalibracionId == id
                                  select new datosmedido
                                  {
                                      fecha = cur.Fecha,
                                      cantidad = Convert.ToInt32(cali.CantidadA),
                                      detalle = sele.Detalle,
                                      bombo = bo1.Num_bombo,
                                      tipo = tripa.Detalle
                                  }).First();


            return listame;



        }


    }
}
