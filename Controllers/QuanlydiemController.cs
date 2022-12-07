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
    public class QuanlydiemController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private ExcelsProcess _excelProcess = new ExcelsProcess();
        public QuanlydiemController(ApplicationDbcontext context)
        {
            _context = context;
        }

        // GET: Quanlydiem
        public async Task<IActionResult> Index()
        {
              return _context.Quanlydiem != null ? 
                          View(await _context.Quanlydiem.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbcontext.Quanlydiem'  is null.");
        }

        //GET: Update file excel
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
                            var Qld = new Quanlydiem();
                            // set values for attrinutes
                            Qld.Sothutu= Convert.ToInt32(dt.Rows[i][0].ToString());
                            Qld.MaSV= dt.Rows[i][1].ToString();
                            Qld.TenSV= dt.Rows[i][2].ToString();
                            Qld.Tenmonhoc= dt.Rows[i][3].ToString();
                            Qld.Diem= Convert.ToInt32(dt.Rows[i][4].ToString());
                           
                             //add object to Context
                             _context.Quanlydiem.Add(Qld);
                        }
                        //save to database 
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }

        // GET: Quanlydiem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quanlydiem == null)
            {
                return NotFound();
            }

            var quanlydiem = await _context.Quanlydiem
                .FirstOrDefaultAsync(m => m.Sothutu == id);
            if (quanlydiem == null)
            {
                return NotFound();
            }

            return View(quanlydiem);
        }

        // GET: Quanlydiem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quanlydiem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sothutu,MaSV,TenSV,Tenmonhoc,Diem")] Quanlydiem quanlydiem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanlydiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanlydiem);
        }

        // GET: Quanlydiem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quanlydiem == null)
            {
                return NotFound();
            }

            var quanlydiem = await _context.Quanlydiem.FindAsync(id);
            if (quanlydiem == null)
            {
                return NotFound();
            }
            return View(quanlydiem);
        }

        // POST: Quanlydiem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sothutu,MaSV,TenSV,Tenmonhoc,Diem")] Quanlydiem quanlydiem)
        {
            if (id != quanlydiem.Sothutu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanlydiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanlydiemExists(quanlydiem.Sothutu))
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
            return View(quanlydiem);
        }

        // GET: Quanlydiem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quanlydiem == null)
            {
                return NotFound();
            }

            var quanlydiem = await _context.Quanlydiem
                .FirstOrDefaultAsync(m => m.Sothutu == id);
            if (quanlydiem == null)
            {
                return NotFound();
            }

            return View(quanlydiem);
        }

        // POST: Quanlydiem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quanlydiem == null)
            {
                return Problem("Entity set 'ApplicationDbcontext.Quanlydiem'  is null.");
            }
            var quanlydiem = await _context.Quanlydiem.FindAsync(id);
            if (quanlydiem != null)
            {
                _context.Quanlydiem.Remove(quanlydiem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanlydiemExists(int id)
        {
          return (_context.Quanlydiem?.Any(e => e.Sothutu == id)).GetValueOrDefault();
        }
    }
}
