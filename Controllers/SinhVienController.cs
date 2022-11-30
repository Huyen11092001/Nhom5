using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QUANLYSINHVIEN.Models;

namespace QUANLYSINHVIEN.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public SinhVienController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
              return _context.SinhVien != null ? 
                          View(await _context.SinhVien.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.SinhVien'  is null.");
        }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            ViewData["Tenlop"] = new SelectList(_context.Lop,"Malop","Tenlop");
            ViewData["Tenkhoa"] = new SelectList(_context.Khoa,"Makhoa","Tenkhoa");
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSV,Hovaten,Address,Tenlop,Tenkhoa")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tenlop"] = new SelectList(_context.Lop, "Malop", "Tenlop", sinhVien.Tenlop);
             ViewData["Tenkhoa"] = new SelectList(_context.Khoa, "Makhoa", "Tenkhoa", sinhVien.Tenkhoa);
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,Hovaten,Address,Tenlop,Tenkhoa")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSV))
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
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SinhVien == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.SinhVien'  is null.");
            }
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SinhVien?.Any(e => e.MaSV == id)).GetValueOrDefault();
        }
    }
}
