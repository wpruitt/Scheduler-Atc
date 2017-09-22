using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Migrations
{
    public partial class ShiftModelAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shift");

            migrationBuilder.AddColumn<int>(
                name: "ShiftStatus",
                table: "Shift",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftStatus",
                table: "Shift");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Shift",
                nullable: true);
        }
    }
}
