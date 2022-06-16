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
    public class UserDatasController : Controller
    {
        private readonly DataContext _context;

        public UserDatasController(DataContext context)
        {
            _context = context;
        }

        // GET: UserDatas
        public async Task<IActionResult> Index()
        {
              return _context.UserData != null ? 
                          View(await _context.UserData.ToListAsync()) :
                          Problem("Entity set 'DataContext.UserData'  is null.");
        }

        // GET: UserDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserData == null)
            {
                return NotFound();
            }

            var userData = await _context.UserData
                .FirstOrDefaultAsync(m => m.userID == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // GET: UserDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userID,name,email,password")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserData == null)
            {
                return NotFound();
            }

            var userData = await _context.UserData.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userID,name,email,password")] UserData userData)
        {
            if (id != userData.userID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDataExists(userData.userID))
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
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserData == null)
            {
                return NotFound();
            }

            var userData = await _context.UserData
                .FirstOrDefaultAsync(m => m.userID == id);
            if (userData == null)
            {
                return NotFound();
            }

            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserData == null)
            {
                return Problem("Entity set 'DataContext.UserData'  is null.");
            }
            var userData = await _context.UserData.FindAsync(id);
            if (userData != null)
            {
                _context.UserData.Remove(userData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDataExists(int id)
        {
          return (_context.UserData?.Any(e => e.userID == id)).GetValueOrDefault();
        }
    }
}
