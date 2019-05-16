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
    public class EscurridosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EscurridoModels listacurtido;
        private CurtidoModels listnumpi;
        private EscurridoModels listaescurrido;
        private EscurridoModels listacheck;
        public EscurridosController(ApplicationDbContext context)
        {
            _context = context;
            listacurtido = new EscurridoModels(context);
            listnumpi = new CurtidoModels(context);
            listaescurrido = new EscurridoModels(context);
            listacheck = new EscurridoModels(context);
            
        }

        // GET: Escurridos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Escurrido.Include(e => e.Bombos);
            return View(await applicationDbContext.ToListAsync());
        }
        public List<object[]> listacurtidoscbx(int id)
        {
            return listacurtido.Modelolistacurtido(id);
        }

        public List<IdentityError> Controaldornumeropieles(int curtidId, int valor)
        {
            return listacurtido.Modelonumeropielescurrido(curtidId, valor);
        }

        public List<object[]> ControladorListaEscurrido()
        {
            return listaescurrido.ModeloListaEscurrido();
        }
        public List<object[]> controladorcheck(int id)
        {
            return listacheck.tablamodeloescurrdio(id);
        }
        public List<object[]> controladorlistacheck(int id)
        {
            List<object[]> lista = new List<object[]>();
            List<ListaEscurridoCheck> datos = new List<ListaEscurridoCheck>();
            if (id == 0)
            {
                datos = (from cur in _context.Curtido
                         join clat in _context.Bodegatripa on cur.BodegaTripaId equals clat.BodegaTripaId
                         join tri in _context.ClasificacionTripa on clat.ClasificacionTripaId equals tri.ClasificacionTripaId
                         where cur.BomboId == id && cur.Activo == true
                         select new ListaEscurridoCheck
                         {
                             CurtidoId = cur.CurtidoId,
                             CodigoLote = cur.codigolote,
                             Cantidad = Convert.ToInt32(cur.NPieles),
                             BomboId = cur.BomboId,
                            Fecha = cur.Fecha,
                            PersonalId = cur.PersonalId

                         }).ToList();
            }else
            {
                datos = (from cur in _context.Curtido
                         join clat in _context.Bodegatripa on cur.BodegaTripaId equals clat.BodegaTripaId
                         join tri in _context.ClasificacionTripa on clat.ClasificacionTripaId equals tri.ClasificacionTripaId
                         where cur.BomboId == id && cur.Activo == true
                         select new ListaEscurridoCheck
                         {
                             CurtidoId = cur.CurtidoId,
                             CodigoLote = cur.codigolote,
                             Cantidad = Convert.ToInt32(cur.NPieles),
                             BomboId = cur.BomboId,
                             Fecha = cur.Fecha,
                             PersonalId = cur.PersonalId

                         }).ToList();
            }
            string html = "";
            foreach ( var item in datos)
            {
                html += "<tr>" +
                    "<td>" +
                    "<input type='checkbox' class='form-control'  value=" + item.CurtidoId + "|" + item.CodigoLote + "|" + item.Cantidad + "|" + item.Fecha + " />" +
                    "</td>" +
                   "<td>" + item.CodigoLote + "</td>" +
                   "<td>" + item.Cantidad + "</td>" +
                   "<td>" + item.Fecha + "</td>" +
                  /// "<td>" + item.Fecha + "</td>" +
                   //"<td>" + item.Peso + "</td>" +

                    "</tr>";
            }
            object[] llena = { html };
            lista.Add(llena);
            return lista;
        }
        // GET: Escurridos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido
                .Include(e => e.Bombos)
                .SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }

            return View(escurrido);
        }

        // GET: Escurridos/Create
        public IActionResult Create()
        {
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId");
            return View();
        }

        // POST: Escurridos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscurridoId,Cantidad,Fecha,CodigoLote,BomboId")] Escurrido escurrido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escurrido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // GET: Escurridos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido.SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // POST: Escurridos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscurridoId,Cantidad,Fecha,CodigoLote,BomboId")] Escurrido escurrido)
        {
            if (id != escurrido.EscurridoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escurrido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscurridoExists(escurrido.EscurridoId))
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
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", escurrido.BomboId);
            return View(escurrido);
        }

        // GET: Escurridos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escurrido = await _context.Escurrido
                .Include(e => e.Bombos)
                .SingleOrDefaultAsync(m => m.EscurridoId == id);
            if (escurrido == null)
            {
                return NotFound();
            }

            return View(escurrido);
        }

        // POST: Escurridos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escurrido = await _context.Escurrido.SingleOrDefaultAsync(m => m.EscurridoId == id);
            _context.Escurrido.Remove(escurrido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscurridoExists(int id)
        {
            return _context.Escurrido.Any(e => e.EscurridoId == id);
        }

        public decimal controladorunescurtidoescurrir(string id)
        {
            return _context.Curtido.Where(c => c.codigolote == id && c.Activo == true).Sum(c => c.NPieles);
        }
        public List<IdentityError> Controladordurdaescurrdio(int bombo, int cantidad, string codigolote, DateTime fecha, string curtido, int personal, string codiuniescurridio)
        {
            return listacurtido.GuardarEscurrido(bombo, cantidad, codigolote, fecha, curtido, personal, codiuniescurridio);
        }


    }
   
}
