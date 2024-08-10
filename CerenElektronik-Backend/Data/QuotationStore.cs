using CerenElektronik_Backend.Models;
using CerenElektronik_Backend.Models.DTO;
using CerenElektronik_Backend.Models.Enums;

namespace CerenElektronik_Backend.Data
{
    public class QuotationStore
    {
        private readonly List<Quotation> _quotations = new List<Quotation>
        {
            new Quotation
            {
                Id = 1,
                TaskCustomID = "T001",
                TaskName = "Install new system",
                PerformerId = "P001",
                Status = QuotationStatus.Pending,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R1,
                RegionName = "North",
                DeviceName = "DeviceA",
                CustomerName = "CustomerA",
                RequestedBy = "RequesterA",
                PreparedBy = "PreparerA",
                Currency = "USD",
                QuotationAmount = 1000.00f,
                SentTo = "customerA@example.com",
                QuotationFile = "quotationA.pdf",
                PoOrPrePaymentRecievedForProduction = "Yes",
                PoFile = "poA.pdf",
                Invoiced = false,
                PassiveShieldingNeeded = true,
                CountryCode = "US",
                RFID = "RFID001"
            },
            new Quotation
            {
                Id = 2,
                TaskCustomID = "T002",
                TaskName = "Upgrade existing system",
                PerformerId = "P002",
                Status = QuotationStatus.ToDo,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R0,
                RegionName = "South",
                DeviceName = "DeviceB",
                CustomerName = "CustomerB",
                RequestedBy = "RequesterB",
                PreparedBy = "PreparerB",
                Currency = "EUR",
                QuotationAmount = 2000.00f,
                SentTo = "customerB@example.com",
                QuotationFile = "quotationB.pdf",
                PoOrPrePaymentRecievedForProduction = "No",
                PoFile = "poB.pdf",
                Invoiced = true,
                PassiveShieldingNeeded = false,
                CountryCode = "FR",
                RFID = "RFID002"
            }
        };
        public int _nextId = 3;

        public Task<List<Quotation>> GetAllQuotationsAsync()
        {
            return Task.FromResult(_quotations.ToList());
        }

        public Task<Quotation> GetQuotationByIdAsync(int id)
        {
            var quotation = _quotations.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(quotation);
        }
        public Task<Quotation> CreateQuotationAsync(Quotation quotation)
        {
            quotation.Id = _nextId++;
            _quotations.Add(quotation);
            return Task.FromResult(quotation);
        }
        public Task<Quotation> UpdateQuotationAsync(Quotation updatedQuotation) 
        {
            var existingQuotation = _quotations.FirstOrDefault(u => u.Id == updatedQuotation.Id);
            if (existingQuotation == null)
            {
                Task.FromResult<Quotation>(null);
            }

            existingQuotation.TaskCustomID = updatedQuotation.TaskCustomID;
            existingQuotation.TaskName = updatedQuotation.TaskName;
            existingQuotation.PerformerId = updatedQuotation.PerformerId;
            existingQuotation.Status = updatedQuotation.Status;
            existingQuotation.DateCreated = updatedQuotation.DateCreated;
            existingQuotation.RevisionStatus = updatedQuotation.RevisionStatus;
            existingQuotation.RegionName = updatedQuotation.RegionName;
            existingQuotation.DeviceName = updatedQuotation.DeviceName;
            existingQuotation.CustomerName = updatedQuotation.CustomerName;
            existingQuotation.RequestedBy = updatedQuotation.RequestedBy;
            existingQuotation.PreparedBy = updatedQuotation.PreparedBy;
            existingQuotation.Currency = updatedQuotation.Currency;
            existingQuotation.QuotationAmount = updatedQuotation.QuotationAmount;
            existingQuotation.SentTo = updatedQuotation.SentTo;
            existingQuotation.QuotationFile = updatedQuotation.QuotationFile;
            existingQuotation.PoOrPrePaymentRecievedForProduction = updatedQuotation.PoOrPrePaymentRecievedForProduction;
            existingQuotation.PoFile = updatedQuotation.PoFile;
            existingQuotation.Invoiced = updatedQuotation.Invoiced;
            existingQuotation.PassiveShieldingNeeded = updatedQuotation.PassiveShieldingNeeded;
            existingQuotation.CountryCode = updatedQuotation.CountryCode;
            existingQuotation.RFID = updatedQuotation.RFID;

            return Task.FromResult(existingQuotation);
        }
        public Task<bool> DeleteQuotationAsync(int id)
        {
            var quotation = _quotations.FirstOrDefault(q => q.Id == id);
            if (quotation == null)
            {
                return Task.FromResult(false);
            }

            _quotations.Remove(quotation);
            return Task.FromResult(true);
        }


    }
}
