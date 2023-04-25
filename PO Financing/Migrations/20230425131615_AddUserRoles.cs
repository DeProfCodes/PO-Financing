using Microsoft.EntityFrameworkCore.Migrations;

namespace PO_Financing.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "AspNetRoles",
                new string[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                new string[] { "1", "Admin", "Admin", "Admin" });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new string[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                new string[] { "2", "Client", "Client", "Client" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "AspNetRoles",
                new string[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                new string[] { "1", "Admin", "Admin", "Admin" });

            migrationBuilder.DeleteData(
                "AspNetRoles",
                new string[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                new string[] { "2", "Client", "Client", "Client" });
        }
    }
}
