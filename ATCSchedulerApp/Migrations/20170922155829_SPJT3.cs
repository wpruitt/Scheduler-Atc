using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Migrations
{
    public partial class SPJT3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillLevel_Position_PositionId",
                table: "SkillLevel");

            migrationBuilder.DropIndex(
                name: "IX_SkillLevel_PositionId",
                table: "SkillLevel");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "SkillLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "SkillLevel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevel_PositionId",
                table: "SkillLevel",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillLevel_Position_PositionId",
                table: "SkillLevel",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
