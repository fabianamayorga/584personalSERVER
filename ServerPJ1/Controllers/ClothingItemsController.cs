using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace ServerPJ1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingItemsController : ControllerBase
    {
        private readonly ClothingBrandContext _context;

        public ClothingItemsController(ClothingBrandContext context)
        {
            _context = context;
        }

        // GET: api/ClothingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingItem>>> GetClothingItems()
        {
            return await _context.ClothingItems.ToListAsync();
        }

        // GET: api/ClothingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingItem>> GetClothingItem(int id)
        {
            var clothingItem = await _context.ClothingItems.FindAsync(id);

            if (clothingItem == null)
            {
                return NotFound();
            }

            return clothingItem;
        }

        // PUT: api/ClothingItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingItem(int id, ClothingItem clothingItem)
        {
            if (id != clothingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingItemExists(id))
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

        // POST: api/ClothingItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingItem>> PostClothingItem(ClothingItem clothingItem)
        {
            _context.ClothingItems.Add(clothingItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClothingItemExists(clothingItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClothingItem", new { id = clothingItem.Id }, clothingItem);
        }

        // DELETE: api/ClothingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingItem(int id)
        {
            var clothingItem = await _context.ClothingItems.FindAsync(id);
            if (clothingItem == null)
            {
                return NotFound();
            }

            _context.ClothingItems.Remove(clothingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingItemExists(int id)
        {
            return _context.ClothingItems.Any(e => e.Id == id);
        }
    }
}
