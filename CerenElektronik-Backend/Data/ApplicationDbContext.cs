using CerenElektronik_Backend.Models;
using CerenElektronik_Backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CerenElektronik_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                  : base(options)
        {
        }
        public DbSet<Quotation> Quotations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>().HasData(
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
            },
            new Quotation
            {
                Id = 3,
                TaskCustomID = "T003",
                TaskName = "System maintenance",
                PerformerId = "P003",
                Status = QuotationStatus.Lost,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R2,
                RegionName = "East",
                DeviceName = "DeviceC",
                CustomerName = "CustomerC",
                RequestedBy = "RequesterC",
                PreparedBy = "PreparerC",
                Currency = "GBP",
                QuotationAmount = 1500.00f,
                SentTo = "customerC@example.com",
                QuotationFile = "quotationC.pdf",
                PoOrPrePaymentRecievedForProduction = "Yes",
                PoFile = "poC.pdf",
                Invoiced = true,
                PassiveShieldingNeeded = true,
                CountryCode = "UK",
                RFID = "RFID003"
            },
            new Quotation
            {
                Id = 4,
                TaskCustomID = "T004",
                TaskName = "Replace faulty component",
                PerformerId = "P004",
                Status = QuotationStatus.Pending,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R0,
                RegionName = "West",
                DeviceName = "DeviceD",
                CustomerName = "CustomerD",
                RequestedBy = "RequesterD",
                PreparedBy = "PreparerD",
                Currency = "JPY",
                QuotationAmount = 2500.00f,
                SentTo = "customerD@example.com",
                QuotationFile = "quotationD.pdf",
                PoOrPrePaymentRecievedForProduction = "No",
                PoFile = "poD.pdf",
                Invoiced = false,
                PassiveShieldingNeeded = false,
                CountryCode = "JP",
                RFID = "RFID004"
            },
            new Quotation
            {
                Id = 5,
                TaskCustomID = "T005",
                TaskName = "Install security update",
                PerformerId = "P005",
                Status = QuotationStatus.ToDo,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R1,
                RegionName = "Central",
                DeviceName = "DeviceE",
                CustomerName = "CustomerE",
                RequestedBy = "RequesterE",
                PreparedBy = "PreparerE",
                Currency = "AUD",
                QuotationAmount = 1800.00f,
                SentTo = "customerE@example.com",
                QuotationFile = "quotationE.pdf",
                PoOrPrePaymentRecievedForProduction = "Yes",
                PoFile = "poE.pdf",
                Invoiced = true,
                PassiveShieldingNeeded = true,
                CountryCode = "AU",
                RFID = "RFID005"
            },
            new Quotation
            {
                Id = 6,
                TaskCustomID = "T006",
                TaskName = "Calibration of equipment",
                PerformerId = "P006",
                Status = QuotationStatus.ToDo,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R2,
                RegionName = "North",
                DeviceName = "DeviceF",
                CustomerName = "CustomerF",
                RequestedBy = "RequesterF",
                PreparedBy = "PreparerF",
                Currency = "CAD",
                QuotationAmount = 2200.00f,
                SentTo = "customerF@example.com",
                QuotationFile = "quotationF.pdf",
                PoOrPrePaymentRecievedForProduction = "No",
                PoFile = "poF.pdf",
                Invoiced = false,
                PassiveShieldingNeeded = false,
                CountryCode = "CA",
                RFID = "RFID006"
            },
            new Quotation
            {
                Id = 7,
                TaskCustomID = "T007",
                TaskName = "Conduct system audit",
                PerformerId = "P007",
                Status = QuotationStatus.PoReceivedOrApproved,
                DateCreated = DateTime.Now,
                RevisionStatus = RevisionStatus.R1,
                RegionName = "East",
                DeviceName = "DeviceG",
                CustomerName = "CustomerG",
                RequestedBy = "RequesterG",
                PreparedBy = "PreparerG",
                Currency = "USD",
                QuotationAmount = 1300.00f,
                SentTo = "customerG@example.com",
                QuotationFile = "quotationG.pdf",
                PoOrPrePaymentRecievedForProduction = "Yes",
                PoFile = "poG.pdf",
                Invoiced = true,
                PassiveShieldingNeeded = true,
                CountryCode = "US",
                RFID = "RFID007"
            }
                );
        }
    }
}
