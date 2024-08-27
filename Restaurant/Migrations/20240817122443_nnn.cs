using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class nnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ourLocation",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ourMail",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ourphone",
                table: "MasterContactUsInformation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ourLocation",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "ourMail",
                table: "MasterContactUsInformation");

            migrationBuilder.DropColumn(
                name: "ourphone",
                table: "MasterContactUsInformation");
        }
    }
}
