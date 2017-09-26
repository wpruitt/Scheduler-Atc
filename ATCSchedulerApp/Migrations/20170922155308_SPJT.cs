using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Migrations
{
    public partial class SPJT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Shift_ShiftId",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_ShiftId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Position");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Position",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Position_ShiftId",
                table: "Position",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Shift_ShiftId",
                table: "Position",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
