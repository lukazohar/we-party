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
    public class PartyStatusController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public PartyStatusController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/FriendshipStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyStatus>>> GetPartyStatuses()
        {
            return await _context.PartyStatuses.ToListAsync();
        }

        // GET: api/PartyStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartyStatus>> GetPartyStatus(int id)
        {
            var partyStatus = await _context.PartyStatuses.FindAsync(id);

            if (partyStatus == null)
            {
                return NotFound();
            }

            return partyStatus;
        }

        // PUT: api/PartyStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PartyStatus>> PutPartyStatus(int id, PartyStatus partyStatus)
        {
            if (id != partyStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(partyStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.PartyStatuses.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/PartyStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PartyStatus>> PostPartyStatus(PartyStatus partyStatus)
        {
            _context.PartyStatuses.Add(partyStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartyStatus", new { id = partyStatus.Id }, partyStatus);
        }

        // DELETE: api/PartyStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartyStatus>> DeletePartyStatus(int id)
        {
            var partyStatus = await _context.PartyStatuses.FindAsync(id);
            if (partyStatus == null)
            {
                return NotFound();
            }

            _context.PartyStatuses.Remove(partyStatus);
            await _context.SaveChangesAsync();

            return partyStatus;
        }

        private bool PartyStatusExists(int id)
        {
            return _context.PartyStatuses.Any(e => e.Id == id);
        }
    }
}
