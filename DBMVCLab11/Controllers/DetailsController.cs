using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMVCLab11.Models;

namespace DBMVCLab11.Controllers
{
    public class DetailsController : Controller
    {
        private readonly EnterpriseContext _context;

        public DetailsController(EnterpriseContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            var enterpriseContext = _context.Detail.Include(d => d.product);
            return View(await enterpriseContext.ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["productID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailID,productID,Amount,price,subtotal")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.productID);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            ViewData["productID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.productID);
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailID,productID,Amount,price,subtotal")] Detail detail)
        {
            if (id != detail.DetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.DetailID))
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
            ViewData["productID"] = new SelectList(_context.Products, "ProductID", "ProductID", detail.productID);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detail == null)
            {
                return Problem("Entity set 'EnterpriseContext.Detail'  is null.");
            }
            var detail = await _context.Detail.FindAsync(id);
            if (detail != null)
            {
                _context.Detail.Remove(detail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
          return (_context.Detail?.Any(e => e.DetailID == id)).GetValueOrDefault();
        }
    }
}
