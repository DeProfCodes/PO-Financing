using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PO_Financing.Migrations
{
    public partial class CreatePOsApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrderApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderFunder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPersonPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrderIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    SupplierOfGoods = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderApplications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderApplications");
        }
    }
}
