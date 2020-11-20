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
            if (updatedParty.Title != null) previousParty.Title = updatedParty.Title;
            if (updatedParty.Description != null) previousParty.Description = updatedParty.Description;
            if (updatedParty.Date != null) previousParty.Date = updatedParty.Date;
            if (updatedParty.Price != 0 && previousParty.Price != 0) previousParty.Price = updatedParty.Price;
            if (updatedParty.Location != null) previousParty.Location = updatedParty.Location;
            if (updatedParty.Capacity != 0 && previousParty.Capacity != 0) previousParty.Capacity = updatedParty.Capacity;
            if (updatedParty.IsPublic) previousParty.IsPublic = updatedParty.IsPublic;
            if (updatedParty.UserId != 0 && previousParty.UserId != 0) previousParty.UserId = updatedParty.UserId;
            if (updatedParty.PartyStatusId != 0 && previousParty.PartyStatusId != 0) previousParty.PartyStatusId = updatedParty.PartyStatusId;
            
        }
    }
}
