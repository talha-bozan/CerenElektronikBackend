using CerenElektronik_Backend.Data;
using CerenElektronik_Backend.Models;
using CerenElektronik_Backend.Models.DTO;
using CerenElektronik_Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SelectPdf;

namespace CerenElektronik_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotationController : Controller
    {
        protected readonly ICompositeViewEngine _compositeViewEngine;

        private readonly QuotationStore _quotationStore;

        public QuotationController(QuotationStore quotationStore, ICompositeViewEngine compositeViewEngine)
        {
            _quotationStore = quotationStore;
            _compositeViewEngine = compositeViewEngine;
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
        [HttpPost("GenerateQuotationPdf")]
        public async Task<IActionResult> GenerateQuotationPdfAsync([FromBody] QuotationPdfRequestDTO request)
        {
            if (!ModelState.IsValid || !request.QuotationId.HasValue ) { return BadRequest(ModelState); }

            var quotation = await _quotationStore.GetQuotationByIdAsync(request.QuotationId.Value);
            if (quotation == null)
            {
                return NotFound("Quotation not found.");
            }

            using (var stringWriter = new StringWriter())
            {
                var viewResult = _compositeViewEngine.FindView(ControllerContext, "_Quotation", false);

                if (viewResult.View == null)
                {
                    return NotFound("The invoice view could not be found.");
                }

                // Pass the retrieved quotation data and additional info to the view
                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = quotation
                };

                // Add additional info directly to ViewDataDictionary
                viewDictionary["AdditionalInfo1"] = request.AdditionalInfo1;
                viewDictionary["AdditionalInfo2"] = request.AdditionalInfo2;
                viewDictionary["AdditionalInfo3"] = request.AdditionalInfo3;

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    viewDictionary,
                    TempData,
                    stringWriter,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                var htmlToPdf = new HtmlToPdf(1000, 1414);
                htmlToPdf.Options.DrawBackground = true;

                var pdf = htmlToPdf.ConvertHtmlString(stringWriter.ToString());
                var pdfBytes = pdf.Save();

                return File(pdfBytes, "application/pdf", "Quotation.pdf");
            }
        }





    }
}
