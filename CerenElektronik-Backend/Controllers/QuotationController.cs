using CerenElektronik_Backend.Data;
using CerenElektronik_Backend.Models;
using CerenElektronik_Backend.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CerenElektronik_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotationController : Controller
    {
        private readonly QuotationStore _quotationStore;

        public QuotationController(QuotationStore quotationStore)
        {
            _quotationStore = quotationStore;
        }
        [HttpGet]
        public async Task<IActionResult> GetQuotations()
        {
            var quotations = await _quotationStore.GetAllQuotationsAsync();
            return Ok(quotations);
        }
        [HttpGet("{id}", Name ="GetQuotation")]
        public async Task<IActionResult> GetQuatationById(int id)
        {
            var quotation = await _quotationStore.GetQuotationByIdAsync(id);
            if (quotation == null) { return NotFound(); }
            return Ok(quotation);
        }
        [HttpPost]
        public async Task<IActionResult> PostQuotation([FromBody] QuotationDTO quotationDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var quotation = new Quotation
            {
                TaskCustomID = quotationDTO.TaskCustomID,
                TaskName = quotationDTO.TaskName,
                PerformerId = quotationDTO.PerformerId,
                Status = quotationDTO.Status,
                DateCreated = quotationDTO.DateCreated,
                RevisionStatus = quotationDTO.RevisionStatus,
                RegionName = quotationDTO.RegionName,
                DeviceName = quotationDTO.DeviceName,
                CustomerName = quotationDTO.CustomerName,
                RequestedBy = quotationDTO.RequestedBy,
                PreparedBy = quotationDTO.PreparedBy,
                Currency = quotationDTO.Currency,
                QuotationAmount = quotationDTO.QuotationAmount,
                SentTo = quotationDTO.SentTo,
                QuotationFile = quotationDTO.QuotationFile,
                PoOrPrePaymentRecievedForProduction = quotationDTO.PoOrPrePaymentRecievedForProduction,
                PoFile = quotationDTO.PoFile,
                Invoiced = quotationDTO.Invoiced,
                PassiveShieldingNeeded = quotationDTO.PassiveShieldingNeeded,
                CountryCode = quotationDTO.CountryCode,
                RFID = quotationDTO.RFID
            };
            var createdQuotation = await _quotationStore.CreateQuotationAsync(quotation);
            return CreatedAtRoute("GetQuotation",new {Id = createdQuotation.Id}, createdQuotation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotation(int id, QuotationDTO quotationDTO) 
        {
            if (id == 0) { return BadRequest(); }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingQuotation = await _quotationStore.GetQuotationByIdAsync(id);

            existingQuotation.TaskCustomID = quotationDTO.TaskCustomID;
            existingQuotation.TaskName = quotationDTO.TaskName;
            existingQuotation.PerformerId = quotationDTO.PerformerId;
            existingQuotation.Status = quotationDTO.Status;
            existingQuotation.DateCreated = quotationDTO.DateCreated;
            existingQuotation.RevisionStatus = quotationDTO.RevisionStatus;
            existingQuotation.RegionName = quotationDTO.RegionName;
            existingQuotation.DeviceName = quotationDTO.DeviceName;
            existingQuotation.CustomerName = quotationDTO.CustomerName;
            existingQuotation.RequestedBy = quotationDTO.RequestedBy;
            existingQuotation.PreparedBy = quotationDTO.PreparedBy;
            existingQuotation.Currency = quotationDTO.Currency;
            existingQuotation.QuotationAmount = quotationDTO.QuotationAmount;
            existingQuotation.SentTo = quotationDTO.SentTo;
            existingQuotation.QuotationFile = quotationDTO.QuotationFile;
            existingQuotation.PoOrPrePaymentRecievedForProduction = quotationDTO.PoOrPrePaymentRecievedForProduction;
            existingQuotation.PoFile = quotationDTO.PoFile;
            existingQuotation.Invoiced = quotationDTO.Invoiced;
            existingQuotation.PassiveShieldingNeeded = quotationDTO.PassiveShieldingNeeded;
            existingQuotation.CountryCode = quotationDTO.CountryCode;
            existingQuotation.RFID = quotationDTO.RFID;

            var UpdatedQuotation = _quotationStore.UpdateQuotationAsync(existingQuotation);

            if (UpdatedQuotation == null) { return NotFound(); }
            
            return Ok(UpdatedQuotation);

        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            var success = await _quotationStore.DeleteQuotationAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
