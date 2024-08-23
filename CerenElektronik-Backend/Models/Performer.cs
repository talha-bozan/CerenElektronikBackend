using CerenElektronik_Backend.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CerenElektronik_Backend.Models
{
    public class Performer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? TaskName { get; set; }
        public string? QuotationNo { get; set; } // QUOTATION NO (short text)
        public string? InvoiceId { get; set; } // INVOICE ID (short text)
        public string? Customer { get; set; } // Customer (drop down)
        public string? Assignee { get; set; } // Assignee
        public string? Region { get; set; } // Region (drop down)
        public string? Location { get; set; } // Location (location)
        public DateTime? DueDate { get; set; } // Due Date
        public PerformersStatus? Status { get; set; } // Status
        public bool? Invoiced { get; set; } // INVOICED (drop down)
        public DateTime? StartDate { get; set; } // Start Date
        public double? TimeLogged { get; set; } // Time Logged
        public double? TimeLoggedRolledUp { get; set; } // Time Logged Rolled Up
        public string? LeadInstaller { get; set; } // Lead Installer (drop down)
        public string? SecondInstaller { get; set; } // Second Installer (drop down)
        public string? ThirdInstaller { get; set; } // 3rd Installer (drop down)
        public string? FourthInstaller { get; set; } // 4th Installer (drop down)
        public string? DeviceName { get; set; } // DEVICE NAME (drop down)
        public DateTime? CompletedDate { get; set; } // Completed Date (date)
        public string? ProjectManager { get; set; } // Project Manager (drop down)
        public string? ProgressDailyReport { get; set; } // Progress/Daily Report (attachment)
        public string? SafetyDocuments { get; set; } // Safety Documents (attachment)
        public string? Iatd1 { get; set; } // IATD1 (attachment)
        public string? Pictures { get; set; } // Pictures (attachment)
        public string? RfTestHandOverD { get; set; } // Rf Test Hand Over D (attachment)
        public string? ActionRequired { get; set; } // Action Required (drop down)
        public string? Explanation { get; set; } // EXPLANATION (text)
        public string? CountryCode { get; set; } // Country Code (drop down)
    }
}
