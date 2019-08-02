using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academia.Models;

namespace Academia.Controllers
{
    public class HojadevidasController : Controller
    {
        private readonly AcademiaContext _context;

        public HojadevidasController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Hojadevidas
        public async Task<IActionResult> Index()
        {
            var academiaContext = _context.Hojadevida.Include(h => h.Empleado);
            return View(await academiaContext.ToListAsync());
        }

        // GET: Hojadevidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojadevida = await _context.Hojadevida
                .Include(h => h.Empleado)
                .FirstOrDefaultAsync(m => m.HojadevidaID == id);
            if (hojadevida == null)
            {
                return NotFound();
            }

            return View(hojadevida);
        }

        // GET: Hojadevidas/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre");
            return View();
        }

        // POST: Hojadevidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HojadevidaID,EmpleadoID,Especialidad,TiempoExperiencia")] Hojadevida hojadevida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hojadevida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", hojadevida.EmpleadoID);
            return View(hojadevida);
        }

        // GET: Hojadevidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojadevida = await _context.Hojadevida.FindAsync(id);
            if (hojadevida == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", hojadevida.EmpleadoID);
            return View(hojadevida);
        }

        // POST: Hojadevidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HojadevidaID,EmpleadoID,Especialidad,TiempoExperiencia")] Hojadevida hojadevida)
        {
            if (id != hojadevida.HojadevidaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojadevida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojadevidaExists(hojadevida.HojadevidaID))
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
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", hojadevida.EmpleadoID);
            return View(hojadevida);
        }

        // GET: Hojadevidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojadevida = await _context.Hojadevida
                .Include(h => h.Empleado)
                .FirstOrDefaultAsync(m => m.HojadevidaID == id);
            if (hojadevida == null)
            {
                return NotFound();
            }

            return View(hojadevida);
        }

        // POST: Hojadevidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojadevida = await _context.Hojadevida.FindAsync(id);
            _context.Hojadevida.Remove(hojadevida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojadevidaExists(int id)
        {
            return _context.Hojadevida.Any(e => e.HojadevidaID == id);
        }
    }
}
