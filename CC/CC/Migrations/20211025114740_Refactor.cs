using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_ActivityLevel_activityLevelId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Goal_goalId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_PrefferedDiet_prefferedDietId",
                table: "UserData");

            migrationBuilder.AlterColumn<int>(
                name: "prefferedDietId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "goalId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activityLevelId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_ActivityLevel_activityLevelId",
                table: "UserData",
                column: "activityLevelId",
                principalTable: "ActivityLevel",
                principalColumn: "activityLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Goal_goalId",
                table: "UserData",
                column: "goalId",
                principalTable: "Goal",
                principalColumn: "goalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_PrefferedDiet_prefferedDietId",
                table: "UserData",
                column: "prefferedDietId",
                principalTable: "PrefferedDiet",
                principalColumn: "prefferedDietId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_ActivityLevel_activityLevelId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Goal_goalId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_PrefferedDiet_prefferedDietId",
                table: "UserData");

            migrationBuilder.AlterColumn<int>(
                name: "prefferedDietId",
                table: "UserData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "goalId",
                table: "UserData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "activityLevelId",
                table: "UserData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_ActivityLevel_activityLevelId",
                table: "UserData",
                column: "activityLevelId",
                principalTable: "ActivityLevel",
                principalColumn: "activityLevelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Goal_goalId",
                table: "UserData",
                column: "goalId",
                principalTable: "Goal",
                principalColumn: "goalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_PrefferedDiet_prefferedDietId",
                table: "UserData",
                column: "prefferedDietId",
                principalTable: "PrefferedDiet",
                principalColumn: "prefferedDietId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
