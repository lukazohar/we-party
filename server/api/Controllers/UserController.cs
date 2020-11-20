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
    public class UserController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public UserController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUseres()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var previousUser = await _context.Users.FindAsync(id);

            UpdateProperties(previousUser, user);

            _context.Entry(previousUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.Users.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.CreatedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            foreach (var application in user.Applications)
            {
                _context.Applications.Remove(application);
            }
            foreach (var party in user.Parties)
            {
                _context.Parties.Remove(party);
            }

            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private void UpdateProperties(User previousUser, User updatedUser)
        {
            if (updatedUser.Username != null) previousUser.Username = updatedUser.Username;
            if (updatedUser.FirstName!= null) previousUser.FirstName = updatedUser.FirstName;
            if (updatedUser.LastName != null) previousUser.LastName = updatedUser.LastName;
            if (updatedUser.BirthDate!= null) previousUser.BirthDate = updatedUser.BirthDate;
            if (updatedUser.Description!= null) previousUser.Description = updatedUser.Description;
        }
    }
}
