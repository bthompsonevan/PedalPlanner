﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedalPlanner.Data;
using PedalPlanner.Models;

namespace PedalPlanner.Controllers
{
    public class PedalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PedalsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
       
        // GET: Pedals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedal.ToListAsync());
        }

        public async Task<IActionResult> MyPedalsAsync()
        {
            
            var user = await _userManager.GetUserAsync(HttpContext.User);

            List<Pedal> allPedals = await _context.Pedal.Where(p => p.CreatedBy.Equals(user.ToString())).ToListAsync();
               
            ViewData["User"] = user;

            return View(allPedals);
        }

        // GET: Pedals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedal = await _context.Pedal
                .FirstOrDefaultAsync(m => m.PedalID == id);
            if (pedal == null)
            {
                return NotFound();
            }

            return View(pedal);
        }

        // GET: Pedals/Create
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewBag.User = user;

            return View();
        }

        // POST: Pedals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedalID,PedalName,PedalType,PedalSubType,PedalColor,CreatedBy")] Pedal pedal)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(HttpContext.User);

                _context.Add(pedal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(pedal);
        }

        // GET: Pedals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedal = await _context.Pedal.FindAsync(id);
            if (pedal == null)
            {
                return NotFound();
            }
            return View(pedal);
        }

        // POST: Pedals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedalID,PedalName,PedalType,PedalSubType,PedalColor")] Pedal pedal)
        {
            if (id != pedal.PedalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedalExists(pedal.PedalID))
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
            return View(pedal);
        }

        // GET: Pedals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedal = await _context.Pedal
                .FirstOrDefaultAsync(m => m.PedalID == id);
            if (pedal == null)
            {
                return NotFound();
            }

            return View(pedal);
        }

        // POST: Pedals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedal = await _context.Pedal.FindAsync(id);
            _context.Pedal.Remove(pedal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedalExists(int id)
        {
            return _context.Pedal.Any(e => e.PedalID == id);
        }
    }
}
