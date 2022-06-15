using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1CRUD.Data;
using Assignment1CRUD.Models;

namespace Assignment1CRUD.Controllers
{
    public class PassManagesController : Controller
    {
        private readonly DataContext _context;

        public PassManagesController(DataContext context)
        {
            _context = context;
        }

        // GET: PassManages
        public async Task<IActionResult> Index()
        {
              return _context.PassManage != null ? 
                          View(await _context.PassManage.ToListAsync()) :
                          Problem("Entity set 'DataContext.PassManage'  is null.");
        }

        // GET: PassManages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PassManage == null)
            {
                return NotFound();
            }

            var passManage = await _context.PassManage
                .FirstOrDefaultAsync(m => m.id == id);
            if (passManage == null)
            {
                return NotFound();
            }

            return View(passManage);
        }

        // GET: PassManages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PassManages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,userName,password,link,description")] PassManage passManage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passManage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passManage);
        }

        // GET: PassManages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PassManage == null)
            {
                return NotFound();
            }

            var passManage = await _context.PassManage.FindAsync(id);
            if (passManage == null)
            {
                return NotFound();
            }
            return View(passManage);
        }

        // POST: PassManages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,userName,password,link,description")] PassManage passManage)
        {
            if (id != passManage.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passManage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassManageExists(passManage.id))
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
            return View(passManage);
        }

        // GET: PassManages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PassManage == null)
            {
                return NotFound();
            }

            var passManage = await _context.PassManage
                .FirstOrDefaultAsync(m => m.id == id);
            if (passManage == null)
            {
                return NotFound();
            }

            return View(passManage);
        }

        // POST: PassManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PassManage == null)
            {
                return Problem("Entity set 'DataContext.PassManage'  is null.");
            }
            var passManage = await _context.PassManage.FindAsync(id);
            if (passManage != null)
            {
                _context.PassManage.Remove(passManage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassManageExists(int id)
        {
          return (_context.PassManage?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
