namespace CerenElektronik_Backend.Models.DTO
{
    public class QuotationPdfRequestDTO
    {
        public int? QuotationId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPosition { get; set; }
        public string CustomerCompany { get; set; }
        public string CustomerEmail { get; set; }

        // Product and Project Information
        public string Products { get; set; }
        public string ProjectName { get; set; }

        // Contact Person Information
        public string ContactPersonOneName { get; set; }
        public string ContactPersonOnePhoneNumber { get; set; }
        public string ContactPersonOneEmail { get; set; }
        public string ContactPersonTwoName { get; set; }
        public string ContactPersonTwoPhoneNumber { get; set; }
        public string ContactPersonTwoEmail { get; set; }

        // Item Information
        public string ItemID { get; set; }
        public string ItemDescription { get; set; }
        public int UnitAmount { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
