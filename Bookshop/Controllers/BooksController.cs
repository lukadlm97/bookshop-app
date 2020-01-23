using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        //GET Book/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //GET EDIT BOOK
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);

             if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        //GET DELETE BOOK
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        //EDIT DELETE
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBook(int? id)
        {
           
                var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
                _context.Books.Remove(book);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
          //  return View(book);
        }
    }
}