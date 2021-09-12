using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDAspNet.Models;

namespace CRUDAspNet.Controllers
{
    public class EmployeController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Employe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employes.ToListAsync());
        }

        // GET: Employe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeModel = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeModel == null)
            {
                return NotFound();
            }

            return View(employeModel);
        }

        // GET: Employe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Code,Poste,Bureau,Id,CreatedAt,UpdatedAt")] EmployeModel employeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeModel);
        }

        // GET: Employe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeModel = await _context.Employes.FindAsync(id);
            if (employeModel == null)
            {
                return NotFound();
            }
            return View(employeModel);
        }

        // POST: Employe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FullName,Code,Poste,Bureau,Id,CreatedAt,UpdatedAt")] EmployeModel employeModel)
        {
            if (id != employeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeModelExists(employeModel.Id))
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
            return View(employeModel);
        }

        // GET: Employe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeModel = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeModel == null)
            {
                return NotFound();
            }

            return View(employeModel);
        }

        // POST: Employe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeModel = await _context.Employes.FindAsync(id);
            _context.Employes.Remove(employeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeModelExists(int id)
        {
            return _context.Employes.Any(e => e.Id == id);
        }
    }
}
