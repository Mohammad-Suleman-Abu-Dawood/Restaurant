using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class addM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenu",
                principalColumn: "MasterCategoryMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenu_MasterCategoryMenu_MasterCategoryMenuId",
                table: "MasterItemMenu",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenu",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
