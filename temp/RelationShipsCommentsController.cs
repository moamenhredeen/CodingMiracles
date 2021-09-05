using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArabCoders.Data;
using ArabCoders.Models;

namespace ArabCoders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationShipsCommentsController : ControllerBase
    {
        private readonly DataContext _context;

        public RelationShipsCommentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RelationShipsComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationShipsComment>>> GetRelationShipsComment()
        {
            return await _context.RelationShipsComments.ToListAsync();
        }

        // GET: api/RelationShipsComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelationShipsComment>> GetRelationShipsComment(int id)
        {
            var relationShipsComment = await _context.RelationShipsComments.FindAsync(id);

            if (relationShipsComment == null)
            {
                return NotFound();
            }

            return relationShipsComment;
        }

        // PUT: api/RelationShipsComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationShipsComment(int id, RelationShipsComment relationShipsComment)
        {
            if (id != relationShipsComment.id)
            {
                return BadRequest();
            }

            _context.Entry(relationShipsComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationShipsCommentExists(id))
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

        // POST: api/RelationShipsComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RelationShipsComment>> PostRelationShipsComment(RelationShipsComment relationShipsComment)
        {
            _context.RelationShipsComments.Add(relationShipsComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelationShipsComment", new { id = relationShipsComment.id }, relationShipsComment);
        }

        // DELETE: api/RelationShipsComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationShipsComment(int id)
        {
            var relationShipsComment = await _context.RelationShipsComments.FindAsync(id);
            if (relationShipsComment == null)
            {
                return NotFound();
            }

            _context.RelationShipsComments.Remove(relationShipsComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RelationShipsCommentExists(int id)
        {
            return _context.RelationShipsComments.Any(e => e.id == id);
        }
    }
}
