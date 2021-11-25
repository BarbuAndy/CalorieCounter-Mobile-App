using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Migrations
{
    public partial class UserDataImplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLevel",
                columns: table => new
                {
                    activityLevelId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLevel", x => x.activityLevelId);
                });

          

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    goalId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.goalId);
                });

            migrationBuilder.CreateTable(
                name: "PrefferedDiet",
                columns: table => new
                {
                    prefferedDietId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carbohydratePercentage = table.Column<int>(type: "int", nullable: false),
                    fatsPercentage = table.Column<int>(type: "int", nullable: false),
                    proteinPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefferedDiet", x => x.prefferedDietId);
                });

          

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    userDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weight = table.Column<int>(type: "int", nullable: false),
                    activityLevelId = table.Column<int>(type: "int", nullable: true),
                    goalId = table.Column<int>(type: "int", nullable: true),
                    prefferedDietId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.userDataId);
                    table.ForeignKey(
                        name: "FK_UserData_ActivityLevel_activityLevelId",
                        column: x => x.activityLevelId,
                        principalTable: "ActivityLevel",
                        principalColumn: "activityLevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserData_Goal_goalId",
                        column: x => x.goalId,
                        principalTable: "Goal",
                        principalColumn: "goalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserData_PrefferedDiet_prefferedDietId",
                        column: x => x.prefferedDietId,
                        principalTable: "PrefferedDiet",
                        principalColumn: "prefferedDietId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserData_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });



 

            migrationBuilder.CreateIndex(
                name: "IX_UserData_activityLevelId",
                table: "UserData",
                column: "activityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_goalId",
                table: "UserData",
                column: "goalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_prefferedDietId",
                table: "UserData",
                column: "prefferedDietId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_userId",
                table: "UserData",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItemConsumed");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "ActivityLevel");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "PrefferedDiet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
