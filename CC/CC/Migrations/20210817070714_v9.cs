using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "published",
                table: "FoodItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "timesFlaggedWrong",
                table: "FoodItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "published",
                table: "FoodItem");

            migrationBuilder.DropColumn(
                name: "timesFlaggedWrong",
                table: "FoodItem");
        }
    }
}
