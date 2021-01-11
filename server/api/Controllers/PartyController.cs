using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Authorize]
    [Route("api/parties")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public PartyController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/Party
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Party>>> GetPartyes()
        {
            return await _context.Parties.ToListAsync();
        }

        // GET: api/Party/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Party>> GetParty(int id)
        {
            var party = await _context.Parties.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            return party;
        }

        // PUT: api/Party/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Party>> PutParty(int id, Party party)
        {
            if (id != party.Id)
            {
                return BadRequest();
            }

            var previousParty = await _context.Parties.FindAsync(id);

            UpdateProperties(previousParty, party);

            _context.Entry(previousParty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.Parties.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PartyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
        }

        // POST: api/Party
        [HttpPost]
        public async Task<ActionResult<Party>> PostParty(Party party)
        {
            party.Date = DateTime.Now;
            party.CreatedAt = DateTime.Now;

            _context.Parties.Add(party);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParty", new { id = party.Id }, party);
        }

        // DELETE: api/Party/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Party>> DeleteParty(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }

            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();

            return party;
        }

        private bool PartyExists(int id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }
        
        private void UpdateProperties(Party previousParty, Party updatedParty)
        {
            previousParty.Title = updatedParty.Title;
            previousParty.Description = updatedParty.Description;
            previousParty.Date = updatedParty.Date;
            previousParty.Price = updatedParty.Price;
            previousParty.Location = updatedParty.Location;
            previousParty.Capacity = updatedParty.Capacity;
            previousParty.IsPublic = updatedParty.IsPublic;
            previousParty.UserId = updatedParty.UserId;
            previousParty.Status = updatedParty.Status;
        }
    }
}
