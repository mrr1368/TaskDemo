using Microsoft.EntityFrameworkCore;
using TaskDemo.Models;

namespace TaskDemo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public required DbSet<PaymentRequest> PaymentRequests { get; set; }
        public required DbSet<BuyCommissionHeader> BuyCommissions { get; set; }
        public required DbSet<BuyCommissionItem> BuyCommissionItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskDemoDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👇 رابطه بین هدر و آیتم
            modelBuilder.Entity<BuyCommissionItem>()
                .HasOne(b => b.BuyCommissionHeader)
                .WithMany(h => h.Items)
                .HasForeignKey(b => b.BuyCommissionHeaderId)
                .OnDelete(DeleteBehavior.Cascade);

            // 👇 داده اولیه برای BuyCommissionHeader
            modelBuilder.Entity<BuyCommissionHeader>().HasData(new BuyCommissionHeader
            {
                Id = 1,
                Date = "1403/03/01",
                Description = "درخواست خرید تجهیزات شبکه",
                DocumentNumberYear = "123/1403",
                TotalQuantity = 10,
                RequiredDate = "1403/03/15",
                OptionAnalysis = "مقایسه بین سه برند مختلف انجام شد",
                Notes = "نیاز فوری به خرید",
            });

            // 👇 داده اولیه برای BuyCommissionItem
            modelBuilder.Entity<BuyCommissionItem>().HasData(new BuyCommissionItem
            {
                Id = 1,
                SellerName = "شرکت داده‌پردازان نوین",
                Quantity = 10,
                UnitPrice = 1500000,
                PaymentTerms = "نقدی",
                WarrantyOrManufacturer = "1 سال گارانتی / شرکت دی‌لینک",
                DeliveryTime = "1403/03/20",
                LastPurchaseDate = "1402/12/15",
                BuyCommissionHeaderId = 1
            });

            modelBuilder.Entity<PaymentRequest>().HasData(new PaymentRequest
            {
                Id = 1,
                RequestDate = "1403/03/02",
                FormNumber = "FR-2023-001",
                CheckCount = 2,
                AmountNumeric = 30000000m,
                CheckDate = "1403/03/05",
                RecipientName = "شرکت داده‌پردازان نوین",
                NationalCode = "1234567890",
                PaymentReason = "پرداخت مرحله اول قرارداد",
                AccountNumber = "1234567890123456",
                BankAndBranch = "بانک ملت - شعبه مرکزی",
                ShebaNumber = "IR820540102680020817909002",
                ActionBy = "محمدرضا",
                UnitManager = "علی احمدی",
                AccountingManager = "زهرا حسینی",
                ChiefAccountant = "مهندس کریمی",
                CEOApproval = "مدیر عامل شرکت"
            });
        }

    }
}
