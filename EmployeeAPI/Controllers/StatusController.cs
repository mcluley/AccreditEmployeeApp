using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeShared.Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public StatusController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/GetStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.OrderBy(s => s.StatusDescription).ToListAsync(); 
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // POST: api/Status
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatus), new { id = status.StatusID }, status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, Status status)
        {
            if (id != status.StatusID)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Statuses.Any(e => e.StatusID == id && e.IsActive == true))
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

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}