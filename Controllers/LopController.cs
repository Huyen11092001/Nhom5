using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QUANLYSINHVIEN.Models;
using QUANLYSINHVIEN.Models.Process;

namespace QUANLYSINHVIEN.Controllers
{
    public class LopController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private StringProcess strPro = new StringProcess();

        public LopController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Lop
        public async Task<IActionResult> Index()
        {
              return _context.Lop != null ? 
                          View(await _context.Lop.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.Lop'  is null.");
        }

        // GET: Lop/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Lop == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop
                .FirstOrDefaultAsync(m => m.Malop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // GET: Lop/Create
        public IActionResult Create()
        {
            var newMaLop= "ML001";
            var countLop = _context.Lop.Count();
            if(countLop>0)
            {
                var MaLop = _context.Lop.OrderByDescending(m =>m.Malop).First().Malop;
                // sinh ma tu dong
                newMaLop = strPro.AutoGenerateCode(MaLop);
            }
            ViewBag.newLop = newMaLop;
            return View(); 
        }

        // POST: Lop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Malop,Tenlop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lop);
        }

        // GET: Lop/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Lop == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop.FindAsync(id);
            if (lop == null)
            {
                return NotFound();
            }
            return View(lop);
        }

        // POST: Lop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Malop,Tenlop")] Lop lop)
        {
            if (id != lop.Malop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopExists(lop.Malop))
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
            return View(lop);
        }

        // GET: Lop/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Lop == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop
                .FirstOrDefaultAsync(m => m.Malop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // POST: Lop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Lop == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Lop'  is null.");
            }
            var lop = await _context.Lop.FindAsync(id);
            if (lop != null)
            {
                _context.Lop.Remove(lop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopExists(string id)
        {
          return (_context.Lop?.Any(e => e.Malop == id)).GetValueOrDefault();
        }
    }
}
