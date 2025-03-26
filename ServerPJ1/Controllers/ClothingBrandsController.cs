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
    public class ClothingBrandsController : ControllerBase
    {
        private readonly ClothingBrandContext _context;

        public ClothingBrandsController(ClothingBrandContext context)
        {
            _context = context;
        }

        // GET: api/ClothingBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothingBrand>>> GetClothingBrands()
        {
            return await _context.ClothingBrands.ToListAsync();
        }

        // GET: api/ClothingBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingBrand>> GetClothingBrand(int id)
        {
            var clothingBrand = await _context.ClothingBrands.FindAsync(id);

            if (clothingBrand == null)
            {
                return NotFound();
            }

            return clothingBrand;
        }

        // PUT: api/ClothingBrands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothingBrand(int id, ClothingBrand clothingBrand)
        {
            if (id != clothingBrand.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothingBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothingBrandExists(id))
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

        // POST: api/ClothingBrands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothingBrand>> PostClothingBrand(ClothingBrand clothingBrand)
        {
            _context.ClothingBrands.Add(clothingBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothingBrand", new { id = clothingBrand.Id }, clothingBrand);
        }

        // DELETE: api/ClothingBrands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingBrand(int id)
        {
            var clothingBrand = await _context.ClothingBrands.FindAsync(id);
            if (clothingBrand == null)
            {
                return NotFound();
            }

            _context.ClothingBrands.Remove(clothingBrand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothingBrandExists(int id)
        {
            return _context.ClothingBrands.Any(e => e.Id == id);
        }
    }
}
