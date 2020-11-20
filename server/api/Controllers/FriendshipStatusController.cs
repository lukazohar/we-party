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
    public class FriendshipStatusController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public FriendshipStatusController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/FriendshipStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendshipStatus>>> GetFriendshipStatuses()
        {
            return await _context.FriendshipStatuses.ToListAsync();
        }

        // GET: api/FriendshipStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendshipStatus>> GetFriendshipStatus(int id)
        {
            var friendshipStatus = await _context.FriendshipStatuses.FindAsync(id);

            if (friendshipStatus == null)
            {
                return NotFound();
            }

            return friendshipStatus;
        }

        // PUT: api/FriendshipStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FriendshipStatus>> PutFriendshipStatus(int id, FriendshipStatus friendshipStatus)
        {
            if (id != friendshipStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(friendshipStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.FriendshipStatuses.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendshipStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/FriendshipStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FriendshipStatus>> PostFriendshipStatus(FriendshipStatus friendshipStatus)
        {
            _context.FriendshipStatuses.Add(friendshipStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendshipStatus", new { id = friendshipStatus.Id }, friendshipStatus);
        }

        // DELETE: api/FriendshipStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FriendshipStatus>> DeleteFriendshipStatus(int id)
        {
            var friendshipStatus = await _context.FriendshipStatuses.FindAsync(id);
            if (friendshipStatus == null)
            {
                return NotFound();
            }

            _context.FriendshipStatuses.Remove(friendshipStatus);
            await _context.SaveChangesAsync();

            return friendshipStatus;
        }

        private bool FriendshipStatusExists(int id)
        {
            return _context.FriendshipStatuses.Any(e => e.Id == id);
        }
    }
}
