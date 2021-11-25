using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Migrations
{
    public partial class addedUserIdInUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_User_userId",
                table: "UserData");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_User_userId",
                table: "UserData",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_User_userId",
                table: "UserData");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_User_userId",
                table: "UserData",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
