using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public ApplicationStatusController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationStatus>>> GetApplicationStatuses()
        {
            return await _context.ApplicationStatuses.ToListAsync();
        }

        // GET: api/ApplicationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationStatus>> GetApplicationStatus(int id)
        {
            var applicationStatus = await _context.ApplicationStatuses.FindAsync(id);

            if (applicationStatus == null)
            {
                return NotFound();
            }

            return applicationStatus;
        }

        // PUT: api/ApplicationStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationStatus>> PutApplicationStatus(int id, ApplicationStatus applicationStatus)
        {
            if (id != applicationStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.ApplicationStatuses.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ApplicationStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApplicationStatus>> PostApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.ApplicationStatuses.Add(applicationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationStatus", new { id = applicationStatus.Id }, applicationStatus);
        }

        // DELETE: api/ApplicationStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationStatus>> DeleteApplicationStatus(int id)
        {
            var applicationStatus = await _context.ApplicationStatuses.FindAsync(id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            _context.ApplicationStatuses.Remove(applicationStatus);
            await _context.SaveChangesAsync();

            return applicationStatus;
        }

        private bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatuses.Any(e => e.Id == id);
        }
    }
}
