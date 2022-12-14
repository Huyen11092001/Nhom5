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
    public class QlmhController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private StringProcess strPro = new StringProcess();
        public QlmhController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Qlmh
        public async Task<IActionResult> Index()
        {
              return _context.Qlmh != null ? 
                          View(await _context.Qlmh.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.Qlmh'  is null.");
        }

        // GET: Qlmh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Qlmh == null)
            {
                return NotFound();
            }

            var qlmh = await _context.Qlmh
                .FirstOrDefaultAsync(m => m.Mamonhoc == id);
            if (qlmh == null)
            {
                return NotFound();
            }

            return View(qlmh);
        }

        // GET: Qlmh/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
         public IActionResult Create()
        {
            var newMamonhoc= "MH001";
            var countQlmh = _context.Qlmh.Count();
            if(countQlmh>0)
            {
                var Mamonhoc = _context.Qlmh.OrderByDescending(m =>m.Mamonhoc).First().Mamonhoc;
                // sinh ma tu dong
                newMamonhoc = strPro.AutoGenerateCode(Mamonhoc);
            }
            ViewBag.newID = newMamonhoc;
            return View(); 
            // ViewData["Mamonhoc"]=new SelectList (_context.Mamonhoc, "FacultyID", "FacultyName");
        }

        // POST: Qlmh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mamonhoc,Tenmonhoc")] Qlmh qlmh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qlmh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qlmh);
        }

        // GET: Qlmh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Qlmh == null)
            {
                return NotFound();
            }

            var qlmh = await _context.Qlmh.FindAsync(id);
            if (qlmh == null)
            {
                return NotFound();
            }
            return View(qlmh);
        }

        // POST: Qlmh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mamonhoc,Tenmonhoc")] Qlmh qlmh)
        {
            if (id != qlmh.Mamonhoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qlmh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QlmhExists(qlmh.Mamonhoc))
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
            return View(qlmh);
        }

        // GET: Qlmh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Qlmh == null)
            {
                return NotFound();
            }

            var qlmh = await _context.Qlmh
                .FirstOrDefaultAsync(m => m.Mamonhoc == id);
            if (qlmh == null)
            {
                return NotFound();
            }

            return View(qlmh);
        }

        // POST: Qlmh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Qlmh == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Qlmh'  is null.");
            }
            var qlmh = await _context.Qlmh.FindAsync(id);
            if (qlmh != null)
            {
                _context.Qlmh.Remove(qlmh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QlmhExists(string id)
        {
          return (_context.Qlmh?.Any(e => e.Mamonhoc == id)).GetValueOrDefault();
        }
    }
}
