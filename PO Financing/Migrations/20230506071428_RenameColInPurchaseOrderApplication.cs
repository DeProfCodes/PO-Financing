using Microsoft.EntityFrameworkCore.Migrations;

namespace PO_Financing.Migrations
{
    public partial class RenameColInPurchaseOrderApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceAmount",
                table: "PurchaseOrderApplications",
                newName: "QuotationAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuotationAmount",
                table: "PurchaseOrderApplications",
                newName: "InvoiceAmount");
        }
    }
}
