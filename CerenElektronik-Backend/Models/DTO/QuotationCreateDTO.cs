using CerenElektronik_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CerenElektronik_Backend.Models.DTO
{
    public class QuotationCreateDTO
    {
        public int Id { get; set; } 
        public string? TaskCustomID { get; set; }
        public string? TaskName { get; set; }
        public string? PerformerId { get; set; }
        public QuotationStatus? Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public RevisionStatus? RevisionStatus { get; set; }
        public string? RegionName { get; set; }
        public string? DeviceName { get; set; }
        public string? CustomerName { get; set; }
        public string? RequestedBy { get; set; }
        public string? PreparedBy { get; set; }
        public string? Currency { get; set; }
        public float? QuotationAmount { get; set; }
        [EmailAddress]
        public string? SentTo { get; set; }
        public string? QuotationFile { get; set; }
        public string? PoOrPrePaymentRecievedForProduction { get; set; }
        public string? PoFile { get; set; }
        public bool? Invoiced { get; set; }
        public bool? PassiveShieldingNeeded { get; set; }
        public string? CountryCode { get; set; }
        public string? RFID { get; set; }
    }
}
