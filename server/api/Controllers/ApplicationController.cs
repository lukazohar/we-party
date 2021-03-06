﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Authorize]
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly WePartyDBContext _context;

        public ApplicationController(WePartyDBContext context)
        {
            _context = context;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            var user = (ApplicationUser)HttpContext.Items.First().Value;
            return await _context.Applications.Where(application => application.UserId == user.Id).ToListAsync();
        }

        // GET: api/Application/pending
        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<Application>>> GetPendingApplications()
        {
            var user = (ApplicationUser)HttpContext.Items.First().Value;
            return await _context.Applications.Where(application => application.UserId == user.Id).ToListAsync();
        }

        // GET: api/Application/receiving
        [HttpGet("received")]
        public async Task<ActionResult<IEnumerable<Application>>> GetReceivingApplications()
        {
            var user = (ApplicationUser)HttpContext.Items.First().Value;
            return await _context.Applications.Where(application => application.Party.UserId == user.Id).ToListAsync();
        }

        // GET: api/Application/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: api/Application/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Application>> PutApplication(int id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            var previousApplication = await _context.Applications.FindAsync(id);

            UpdateProperties(previousApplication, application);

            _context.Entry(previousApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return await _context.Applications.FindAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Application
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            application.AppliedAt = DateTime.Now;
            var user = (ApplicationUser)HttpContext.Items.First().Value;
            application.UserId = user.Id;
            application.Status = "Pending";


            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: api/Application/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return application;
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }

        private void UpdateProperties(Application previousApplication, Application updatedApplication)
        {
            previousApplication.Rate = updatedApplication.Rate;
            previousApplication.Status = updatedApplication.Status;
        }
    }
}
