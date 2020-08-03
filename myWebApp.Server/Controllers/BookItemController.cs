using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myWebApp.Server.Data;
using myWebApp.Shared.Models;

namespace myWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BookItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBookModels()
        {
            return await _context.BookModels.ToListAsync();
        }

        // GET: api/BookItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBookModel(Guid id)
        {
            var bookModel = await _context.BookModels.FindAsync(id);

            if (bookModel == null)
            {
                return NotFound();
            }

            return bookModel;
        }

        // PUT: api/BookItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookModel(Guid id, BookModel bookModel)
        {
            if (id != bookModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBookModel(BookModel bookModel)
        {
            _context.BookModels.Add(bookModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookModel", new { id = bookModel.Id }, bookModel);
        }

        // DELETE: api/BookItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookModel>> DeleteBookModel(Guid id)
        {
            var bookModel = await _context.BookModels.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }

            _context.BookModels.Remove(bookModel);
            await _context.SaveChangesAsync();

            return bookModel;
        }

        private bool BookModelExists(Guid id)
        {
            return _context.BookModels.Any(e => e.Id == id);
        }
    }
}
