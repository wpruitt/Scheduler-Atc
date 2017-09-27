using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Migrations
{
    public partial class fixingmodelfks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ATCControllerId",
                table: "Shift",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Shift",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillLevelId",
                table: "Position",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId1",
                table: "ATController",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ATController_PositionId1",
                table: "ATController",
                column: "PositionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ATController_Position_PositionId1",
                table: "ATController",
                column: "PositionId1",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATController_Position_PositionId1",
                table: "ATController");

            migrationBuilder.DropIndex(
                name: "IX_ATController_PositionId1",
                table: "ATController");

            migrationBuilder.DropColumn(
                name: "ATCControllerId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "SkillLevelId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "PositionId1",
                table: "ATController");
        }
    }
}
