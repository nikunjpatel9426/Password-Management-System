﻿using System;
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
    public class UserDetailsController : Controller
    {
        private readonly DataContext _context;

        public UserDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
              return _context.UserDetails != null ? 
                          View(await _context.UserDetails.ToListAsync()) :
                          Problem("Entity set 'DataContext.UserDetails'  is null.");
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.userId == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userId,name,email,password")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,name,email,password")] UserDetails userDetails)
        {
            if (id != userDetails.userId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailsExists(userDetails.userId))
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
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.userId == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserDetails == null)
            {
                return Problem("Entity set 'DataContext.UserDetails'  is null.");
            }
            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailsExists(int id)
        {
          return (_context.UserDetails?.Any(e => e.userId == id)).GetValueOrDefault();
        }
    }
}
