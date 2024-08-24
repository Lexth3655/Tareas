using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMPRESA.Models;

namespace EMPRESA.Controllers
{
    public class EmpleadosTiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosTiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpleadosTipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpleadosTipos.ToListAsync());
        }

        // GET: EmpleadosTipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosTipos = await _context.EmpleadosTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleadosTipos == null)
            {
                return NotFound();
            }

            return View(empleadosTipos);
        }

        // GET: EmpleadosTipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosTipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("descripcion,Id,FechaCreado,FechaModifica,Activo")] EmpleadosTipos empleadosTipos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleadosTipos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleadosTipos);
        }

        // GET: EmpleadosTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosTipos = await _context.EmpleadosTipos.FindAsync(id);
            if (empleadosTipos == null)
            {
                return NotFound();
            }
            return View(empleadosTipos);
        }

        // POST: EmpleadosTipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("descripcion,Id,FechaCreado,FechaModifica,Activo")] EmpleadosTipos empleadosTipos)
        {
            if (id != empleadosTipos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleadosTipos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosTiposExists(empleadosTipos.Id))
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
            return View(empleadosTipos);
        }

        // GET: EmpleadosTipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosTipos = await _context.EmpleadosTipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleadosTipos == null)
            {
                return NotFound();
            }

            return View(empleadosTipos);
        }

        // POST: EmpleadosTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleadosTipos = await _context.EmpleadosTipos.FindAsync(id);
            if (empleadosTipos != null)
            {
                _context.EmpleadosTipos.Remove(empleadosTipos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosTiposExists(int id)
        {
            return _context.EmpleadosTipos.Any(e => e.Id == id);
        }
    }
}
