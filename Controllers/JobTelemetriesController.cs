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
            return await _context.JobTelemetries.ToListAsync();
        }

        // GET: api/JobTelemetries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // PUT: api/JobTelemetries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTelemetry(int id, JobTelemetry jobTelemetry)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTelemetry", new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // DELETE: api/JobTelemetries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
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

        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        // PATCH: api/JobTelemetries/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, [FromBody] JobTelemetry updatedJobTelemetry)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            // Update properties
            if (updatedJobTelemetry.ProccesId != null)
            {
                jobTelemetry.ProccesId = updatedJobTelemetry.ProccesId;
            }

            if (updatedJobTelemetry.JobId != null)
            {
                jobTelemetry.JobId = updatedJobTelemetry.JobId;
            }

            if (updatedJobTelemetry.QueueId != null)
            {
                jobTelemetry.QueueId = updatedJobTelemetry.QueueId;
            }

            if (updatedJobTelemetry.StepDescription != null)
            {
                jobTelemetry.StepDescription = updatedJobTelemetry.StepDescription;
            }

            if (updatedJobTelemetry.HumanTime.HasValue)
            {
                jobTelemetry.HumanTime = updatedJobTelemetry.HumanTime.Value;
            }

            if (updatedJobTelemetry.UniqueReference != null)
            {
                jobTelemetry.UniqueReference = updatedJobTelemetry.UniqueReference;
            }

            if (updatedJobTelemetry.UniqueReferenceType != null)
            {
                jobTelemetry.UniqueReferenceType = updatedJobTelemetry.UniqueReferenceType;
            }

            if (updatedJobTelemetry.BusinessFunction != null)
            {
                jobTelemetry.BusinessFunction = updatedJobTelemetry.BusinessFunction;
            }

            if (updatedJobTelemetry.Geography != null)
            {
                jobTelemetry.Geography = updatedJobTelemetry.Geography;
            }

            if (updatedJobTelemetry.ExcludeFromTimeSaving.HasValue)
            {
                jobTelemetry.ExcludeFromTimeSaving = updatedJobTelemetry.ExcludeFromTimeSaving.Value;
            }

            if (updatedJobTelemetry.AdditionalInfo != null)
            {
                jobTelemetry.AdditionalInfo = updatedJobTelemetry.AdditionalInfo;
            }

            // Save changes
            _context.Entry(jobTelemetry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content on successful update
        }
        private bool TelemetryExist(int telemetryId)
        {
            // Replace with your data access logic
            var telemetry = _context.JobTelemetries.Find(telemetryId);
            return telemetry != null;
        }
       // [HttpGet("GetSavings")]
        //public async Task<ActionResult> GetSavings(Guid projectId, DateTime startDate, DateTime endDate)
        //{
           // var savings = await (from jt in _context.JobTelemetries
                                 //join p in _context.Projects
                                // on jt.JobId equals p.ProjectId // Ensure correct matching fields//
                                 //where p.ProjectID == projectId &&
                                       //jt.EntryDate >= startDate &&
                                       //jt.EntryDate <= endDate
                                 //group jt by p.ProjectID into g
                                // select new
                                // {
                                    // ProjectID = g.Key,
                                    // TotalTimeSaved = g.Sum(jt => jt.HumanTime) ?? 0,
                                     // TotalCostSaved = g.Sum(jt => jt.CostSaved) // Replace with actual field if available
                                 //}).FirstOrDefaultAsync();

            //if (savings == null)
            //{
               // return NotFound("No telemetry data found for the specified project and date range.");
            //}

           // return Ok(savings);
        //}
    }
}

