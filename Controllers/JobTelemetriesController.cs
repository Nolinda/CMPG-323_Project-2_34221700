using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _34221700_Project2_CMPG323.Models;

namespace _34221700_Project2_CMPG323.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTelemetriesController : ControllerBase
    {
        private readonly NWUTrendsContext _context;

        public JobTelemetriesController(NWUTrendsContext context)
        {
            _context = context;
        }

        // GET: api/JobTelemetries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetries
                .Include(jt => jt.Project)
                .Include(jt => jt.Client)
                .ToListAsync();
        }

        // GET: api/JobTelemetries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(Guid id)
        {
            var jobTelemetry = await _context.JobTelemetries
                .Include(jt => jt.Project)
                .Include(jt => jt.Client)
                .FirstOrDefaultAsync(jt => jt.Id == id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // PUT: api/JobTelemetries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTelemetry(Guid id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTelemetry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // POST: api/JobTelemetries
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobTelemetry), new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // DELETE: api/JobTelemetries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(Guid id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/JobTelemetries/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(Guid id, [FromBody] JobTelemetry updatedJobTelemetry)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            // Update properties if they are not null
            jobTelemetry.ProcessId = updatedJobTelemetry.ProcessId ?? jobTelemetry.ProcessId;
            jobTelemetry.JobId = updatedJobTelemetry.JobId ?? jobTelemetry.JobId;
            jobTelemetry.QueueId = updatedJobTelemetry.QueueId ?? jobTelemetry.QueueId;
            jobTelemetry.StepDescription = updatedJobTelemetry.StepDescription ?? jobTelemetry.StepDescription;
            jobTelemetry.UniqueReference = updatedJobTelemetry.UniqueReference ?? jobTelemetry.UniqueReference;
            jobTelemetry.UniqueReferenceType = updatedJobTelemetry.UniqueReferenceType ?? jobTelemetry.UniqueReferenceType;
            jobTelemetry.BusinessFunction = updatedJobTelemetry.BusinessFunction ?? jobTelemetry.BusinessFunction;
            jobTelemetry.Geography = updatedJobTelemetry.Geography ?? jobTelemetry.Geography;
            jobTelemetry.ExcludeFromTimeSaving = updatedJobTelemetry.ExcludeFromTimeSaving;
            jobTelemetry.AdditionalInfo = updatedJobTelemetry.AdditionalInfo ?? jobTelemetry.AdditionalInfo;

            // Save changes
            _context.Entry(jobTelemetry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content on successful update
        }

        // GET: api/JobTelemetries/GetSavings
        [HttpGet("GetSavings")]
        public async Task<ActionResult> GetSavings(Guid projectId, DateTime startDate, DateTime endDate)
        {
            var savings = await (from jt in _context.JobTelemetries
                                 where jt.ProjectID == projectId &&
                                       jt.EntryDate >= startDate &&
                                       jt.EntryDate <= endDate
                                 group jt by jt.ProjectID into g
                                 select new
                                 {
                                     ProjectID = g.Key,
                                     TotalTimeSaved = g.Sum(jt => !string.IsNullOrEmpty(jt.HumanTime) ? (double.Parse(jt.HumanTime)) : 0)
                                 }).FirstOrDefaultAsync();
            if (savings != null)
            {
                return Ok(savings);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/JobTelemetries/GetClientSavings
        [HttpGet("GetClientSavings")]
        public async Task<ActionResult> GetClientSavings(Guid clientId, DateTime startDate, DateTime endDate)
        {
            var savings = await (from jt in _context.JobTelemetries
                                 where jt.ClientId == clientId &&
                                       jt.EntryDate >= startDate &&
                                       jt.EntryDate <= endDate
                                 group jt by jt.ClientId into g
                                 select new
                                 {
                                     ClientID = g.Key,
                                     TotalTimeSaved = g.Sum(jt => !string.IsNullOrEmpty(jt.HumanTime) ? (double.Parse(jt.HumanTime)) : 0)
                                 }).FirstOrDefaultAsync();
            if (savings != null)
            {
                return Ok(savings);
            }
            else
            {
                return NotFound();
            }
        }

        private bool JobTelemetryExists(Guid id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }
    }
}
