using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicineProject.Migrations
{
    /// <inheritdoc />
    public partial class ContactsForHospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "Hospital",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "Hospital");
        }
    }
}
