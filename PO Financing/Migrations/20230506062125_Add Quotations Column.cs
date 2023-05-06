using Microsoft.EntityFrameworkCore.Migrations;

namespace PO_Financing.Migrations
{
    public partial class AddQuotationsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalQuotationAmount",
                table: "Wallets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuotationAmount",
                table: "Wallets");
        }
    }
}
