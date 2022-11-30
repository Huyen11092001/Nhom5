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
    public class QldController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private ExcelsProcess _excelProcess = new ExcelsProcess();
        public QldController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Qld
        public async Task<IActionResult> Index()
        {   return View(await _context.Qld.ToListAsync()) ;
            //   return _context.Qld != null ? 
            //               View(await _context.Qld.ToListAsync()) :
            //               Problem("Entity set 'ApplicationDbcontext.Qld'  is null.");
        }

        //GET: Update
         public async Task<IActionResult>Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension !=".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename
                    var fileName = DateTime.Now.ToShortTimeString() +fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath,FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        // read data from
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for (int i=0; i< dt.Rows.Count;i++)
                        {
                            //create a new Customer object
                            var Qld = new Qld();
                            // set values for attrinutes
                            Qld.MaSV= dt.Rows[i][0].ToString();
                            Qld.TenSV= dt.Rows[i][1].ToString();
                            Qld.Tenmonhoc= dt.Rows[i][2].ToString();
                            Qld.Diem= dt.Rows[i][3].ToString();
                             //add object to Context
                             _context.Qld.Add(Qld);
                        }
                        //save to database 
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }

        // GET: Qld/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Qld == null)
            {
                return NotFound();
            }

            var qld = await _context.Qld
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (qld == null)
            {
                return NotFound();
            }

            return View(qld);
        }

        // GET: Qld/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qld/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSV,TenSV,Tenmonhoc,Diem")] Qld qld)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qld);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qld);
        }

        // GET: Qld/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Qld == null)
            {
                return NotFound();
            }

            var qld = await _context.Qld.FindAsync(id);
            if (qld == null)
            {
                return NotFound();
            }
            return View(qld);
        }

        // POST: Qld/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,TenSV,Tenmonhoc,Diem")] Qld qld)
        {
            if (id != qld.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qld);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QldExists(qld.MaSV))
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
            return View(qld);
        }

        // GET: Qld/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Qld == null)
            {
                return NotFound();
            }

            var qld = await _context.Qld
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (qld == null)
            {
                return NotFound();
            }

            return View(qld);
        }

        // POST: Qld/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Qld == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Qld'  is null.");
            }
            var qld = await _context.Qld.FindAsync(id);
            if (qld != null)
            {
                _context.Qld.Remove(qld);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QldExists(string id)
        {
          return (_context.Qld?.Any(e => e.MaSV == id)).GetValueOrDefault();
        }
    }
}
