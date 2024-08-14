using CerenElektronik_Backend.Data;
using CerenElektronik_Backend.Models;
using CerenElektronik_Backend.Models.DTO;
using CerenElektronik_Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using SelectPdf;

namespace CerenElektronik_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotationController : Controller
    {
        private readonly ICompositeViewEngine _compositeViewEngine;
        private readonly ApplicationDbContext _db;

        public QuotationController(ApplicationDbContext db, ICompositeViewEngine compositeViewEngine)
        {
            _db = db;
            _compositeViewEngine = compositeViewEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuotations()
        {
            var quotations = await _db.Quotations.ToListAsync();
            return Ok(quotations);
        }

        [HttpGet("{id}", Name = "GetQuotation")]
        public async Task<IActionResult> GetQuotationById(int id)
        {
            var quotation = await _db.Quotations.FindAsync(id);
            if (quotation == null) return NotFound();
            return Ok(quotation);
        }

        [HttpPost]
        public async Task<IActionResult> PostQuotation([FromBody] QuotationCreateDTO quotationDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var quotation = new Quotation
            {
                TaskCustomID = quotationDTO.TaskCustomID,
                TaskName = quotationDTO.TaskName,
                PerformerId = quotationDTO.PerformerId,
                Status = quotationDTO.Status,
                DateCreated = quotationDTO.DateCreated ?? DateTime.Now,
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

            _db.Quotations.Add(quotation);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetQuotation", new { Id = quotation.Id }, quotation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotation(int id, [FromBody] QuotationUpdateDTO quotationDTO)
        {
            if (id == 0) return BadRequest();

            var existingQuotation = await _db.Quotations.FindAsync(id);
            if (existingQuotation == null) return NotFound();

            existingQuotation.TaskCustomID = quotationDTO.TaskCustomID;
            existingQuotation.TaskName = quotationDTO.TaskName;
            existingQuotation.PerformerId = quotationDTO.PerformerId;
            existingQuotation.Status = quotationDTO.Status;
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

            _db.Quotations.Update(existingQuotation);
            await _db.SaveChangesAsync();

            return Ok(existingQuotation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            var quotation = await _db.Quotations.FindAsync(id);
            if (quotation == null) return NotFound();

            _db.Quotations.Remove(quotation);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("GenerateQuotationPdf")]
        public async Task<IActionResult> GenerateQuotationPdfAsync([FromBody] QuotationPdfRequestDTO request)
        {
            if (!ModelState.IsValid || !request.QuotationId.HasValue) return BadRequest(ModelState);

            var quotation = await _db.Quotations.FindAsync(request.QuotationId.Value);
            if (quotation == null) return NotFound("Quotation not found.");

            using (var stringWriter = new StringWriter())
            {
                var viewResult = _compositeViewEngine.FindView(ControllerContext, "_Quotation", false);
                if (viewResult.View == null) return NotFound("The invoice view could not be found.");

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = quotation
                };

                viewDictionary["CustomerName"] = request.CustomerName;
                viewDictionary["CustomerPosition"] = request.CustomerPosition;
                viewDictionary["CustomerCompany"] = request.CustomerCompany;
                viewDictionary["CustomerEmail"] = request.CustomerEmail;
                viewDictionary["Products"] = request.Products;
                viewDictionary["ProjectName"] = request.ProjectName;
                viewDictionary["ContactPersonOneName"] = request.ContactPersonOneName;
                viewDictionary["ContactPersonOnePhoneNumber"] = request.ContactPersonOnePhoneNumber;
                viewDictionary["ContactPersonOneEmail"] = request.ContactPersonOneEmail;
                viewDictionary["ContactPersonTwoName"] = request.ContactPersonTwoName;
                viewDictionary["ContactPersonTwoPhoneNumber"] = request.ContactPersonTwoPhoneNumber;
                viewDictionary["ContactPersonTwoEmail"] = request.ContactPersonTwoEmail;
                viewDictionary["ItemID"] = request.ItemID;
                viewDictionary["ItemDescription"] = request.ItemDescription;
                viewDictionary["UnitAmount"] = request.UnitAmount;
                viewDictionary["UnitPrice"] = request.UnitPrice;
                viewDictionary["UnitAmount*UnitPrice"] = request.UnitAmount * request.UnitPrice;

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    viewDictionary,
                    TempData,
                    stringWriter,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                var htmlToPdf = new HtmlToPdf(1000, 1414)
                {
                    Options = { DrawBackground = true }
                };

                var pdf = htmlToPdf.ConvertHtmlString(stringWriter.ToString());
                var pdfBytes = pdf.Save();

                return File(pdfBytes, "application/pdf", "Quotation.pdf");
            }
        }
    }
}
