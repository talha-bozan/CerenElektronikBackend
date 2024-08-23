using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CerenElektronik_Backend.Data;
using CerenElektronik_Backend.Models;
using System.Threading.Tasks;

namespace CerenElektronik_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerformerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PerformerController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST: /Performer
        [HttpPost]
        public async Task<IActionResult> CreatePerformer([FromBody] Performer performer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Performers.Add(performer);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerformer), new { id = performer.Id }, performer);
        }

        // PUT: /Performer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformer(int id, [FromBody] Performer performer)
        {
            if (id != performer.Id)
            {
                return BadRequest("Performer ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPerformer = await _db.Performers.FindAsync(id);
            if (existingPerformer == null)
            {
                return NotFound();
            }

            existingPerformer.TaskName = performer.TaskName;
            existingPerformer.QuotationNo = performer.QuotationNo;
            existingPerformer.InvoiceId = performer.InvoiceId;
            existingPerformer.Customer = performer.Customer;
            existingPerformer.Assignee = performer.Assignee;
            existingPerformer.Region = performer.Region;
            existingPerformer.Location = performer.Location;
            existingPerformer.DueDate = performer.DueDate;
            existingPerformer.Status = performer.Status;
            existingPerformer.Invoiced = performer.Invoiced;
            existingPerformer.StartDate = performer.StartDate;
            existingPerformer.TimeLogged = performer.TimeLogged;
            existingPerformer.TimeLoggedRolledUp = performer.TimeLoggedRolledUp;
            existingPerformer.LeadInstaller = performer.LeadInstaller;
            existingPerformer.SecondInstaller = performer.SecondInstaller;
            existingPerformer.ThirdInstaller = performer.ThirdInstaller;
            existingPerformer.FourthInstaller = performer.FourthInstaller;
            existingPerformer.DeviceName = performer.DeviceName;
            existingPerformer.CompletedDate = performer.CompletedDate;
            existingPerformer.ProjectManager = performer.ProjectManager;
            existingPerformer.ProgressDailyReport = performer.ProgressDailyReport;
            existingPerformer.SafetyDocuments = performer.SafetyDocuments;
            existingPerformer.Iatd1 = performer.Iatd1;
            existingPerformer.Pictures = performer.Pictures;
            existingPerformer.RfTestHandOverD = performer.RfTestHandOverD;
            existingPerformer.ActionRequired = performer.ActionRequired;
            existingPerformer.Explanation = performer.Explanation;
            existingPerformer.CountryCode = performer.CountryCode;

            _db.Performers.Update(existingPerformer);
            await _db.SaveChangesAsync();

            return Ok(existingPerformer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformer(int id)
        {
            var performer = await _db.Performers.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }

            return Ok(performer);
        }
        [HttpGet()]
        public async Task<IActionResult> GetPerformers()
        {
            var performer = await _db.Performers.ToListAsync();
          
            return Ok(performer);
        }
    }
}
