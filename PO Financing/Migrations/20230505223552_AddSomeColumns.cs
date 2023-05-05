using Microsoft.EntityFrameworkCore.Migrations;

namespace PO_Financing.Migrations
{
    public partial class AddSomeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrderNumber",
                table: "PurchaseOrderApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PurchaseOrderApplications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrderNumber",
                table: "PurchaseOrderApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseOrderApplications");
        }
    }
}
