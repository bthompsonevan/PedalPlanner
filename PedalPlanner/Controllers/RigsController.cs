using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedalPlanner.Data;
using PedalPlanner.Models;

namespace PedalPlanner.Controllers
{
    public class RigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;



        public RigsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Rigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rig.ToListAsync());
        }

        public async Task<IActionResult> MyRigsAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            List<Rig> allRigs = await _context.Rig.Where(r => r.CreatedBy.Equals(user.ToString())).ToListAsync();

            ViewData["Rig"] = user;

            return View(allRigs);
        }

        // GET: Rigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rig = await _context.Rig
                .FirstOrDefaultAsync(m => m.RigID == id);
            if (rig == null)
            {
                return NotFound();
            }

            return View(rig);
        }

        // GET: Rigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RigID,Instrument,BoardSize,CreatedBy")] Rig rig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rig);
        }

        // GET: Rigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rig = await _context.Rig.FindAsync(id);
            if (rig == null)
            {
                return NotFound();
            }
            return View(rig);
        }

        // POST: Rigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RigID,Instrument,BoardSize")] Rig rig)
        {
            if (id != rig.RigID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RigExists(rig.RigID))
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
            return View(rig);
        }

        // GET: Rigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rig = await _context.Rig
                .FirstOrDefaultAsync(m => m.RigID == id);
            if (rig == null)
            {
                return NotFound();
            }

            return View(rig);
        }

        // POST: Rigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rig = await _context.Rig.FindAsync(id);
            _context.Rig.Remove(rig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RigExists(int id)
        {
            return _context.Rig.Any(e => e.RigID == id);
        }
    }
}
