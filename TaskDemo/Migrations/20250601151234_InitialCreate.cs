using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyCommissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumberYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    RequiredDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCommissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckCount = table.Column<int>(type: "int", nullable: false),
                    AmountNumeric = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CheckDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAndBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShebaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountingManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiefAccountant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEOApproval = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyCommissionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyOrManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPurchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyCommissionHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCommissionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyCommissionItems_BuyCommissions_BuyCommissionHeaderId",
                        column: x => x.BuyCommissionHeaderId,
                        principalTable: "BuyCommissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuyCommissions",
                columns: new[] { "Id", "Date", "Description", "DocumentNumberYear", "Notes", "OptionAnalysis", "RequiredDate", "TotalQuantity" },
                values: new object[] { 1, "1403/03/01", "درخواست خرید تجهیزات شبکه", "123/1403", "نیاز فوری به خرید", "مقایسه بین سه برند مختلف انجام شد", "1403/03/15", 10m });

            migrationBuilder.InsertData(
                table: "PaymentRequests",
                columns: new[] { "Id", "AccountNumber", "AccountingManager", "ActionBy", "AmountNumeric", "BankAndBranch", "CEOApproval", "CheckCount", "CheckDate", "ChiefAccountant", "FormNumber", "NationalCode", "PaymentReason", "RecipientName", "RequestDate", "ShebaNumber", "UnitManager" },
                values: new object[] { 1, "1234567890123456", "زهرا حسینی", "محمدرضا", 30000000m, "بانک ملت - شعبه مرکزی", "مدیر عامل شرکت", 2, "1403/03/05", "مهندس کریمی", "FR-2023-001", "1234567890", "پرداخت مرحله اول قرارداد", "شرکت داده‌پردازان نوین", "1403/03/02", "IR820540102680020817909002", "علی احمدی" });

            migrationBuilder.InsertData(
                table: "BuyCommissionItems",
                columns: new[] { "Id", "BuyCommissionHeaderId", "DeliveryTime", "LastPurchaseDate", "PaymentTerms", "Quantity", "SellerName", "TotalPrice", "UnitPrice", "WarrantyOrManufacturer" },
                values: new object[] { 1, 1, "1403/03/20", "1402/12/15", "نقدی", 10m, "شرکت داده‌پردازان نوین", 0m, 1500000m, "1 سال گارانتی / شرکت دی‌لینک" });

            migrationBuilder.CreateIndex(
                name: "IX_BuyCommissionItems_BuyCommissionHeaderId",
                table: "BuyCommissionItems",
                column: "BuyCommissionHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCommissionItems");

            migrationBuilder.DropTable(
                name: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "BuyCommissions");
        }
    }
}
