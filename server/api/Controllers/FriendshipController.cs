using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Authorize]
    [Route("api/friendships")]
    [ApiController]
    public class FriendshipController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public FriendshipController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/Friendship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friendship>>> GetFriendshipes()
        {
            return await _context.Friendships.ToListAsync();
        }

        // GET: api/Friendship/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friendship>> GetFriendship(int id)
        {
            var friendship = await _context.Friendships.FindAsync(id);

            if (friendship == null)
            {
                return NotFound();
            }

            return friendship;
        }

        // PUT: api/Friendship/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Friendship>> PutFriendship(int id, Friendship friendship)
        {
            if (id != friendship.Id)
            {
                return BadRequest();
            }

            var previousFriendship = await _context.Friendships.FindAsync(id);

            UpdateProperties(previousFriendship, friendship);

            _context.Entry(previousFriendship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.Friendships.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!FriendshipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
        }

        // POST: api/Friendship
        [HttpPost]
        public async Task<ActionResult<Friendship>> RequestFriendship(Friendship friendship)
        {
            if (
                (friendship.RequesterId == null || friendship.ReceiverId == null)
                && friendship.RequesterId == friendship.ReceiverId
            )
            {
                return BadRequest();
            }

            friendship.CreatedAt = DateTime.Now;
            friendship.Status = "Pending";

            _context.Friendships.Add(friendship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendship", new { id = friendship.Id }, friendship);
        }

        // DELETE: api/Friendship/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFriendship(int id)
        {
            var friendship = await _context.Friendships.FindAsync(id);
            if (friendship == null)
            {
                return NotFound();
            }

            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool FriendshipExists(int id)
        {
            return _context.Friendships.Any(e => e.Id == id);
        }
        
        private void UpdateProperties(Friendship previousFriendship, Friendship updatedFriendship)
        {
            previousFriendship.Status = "Confirmed";
        }
    }
}
