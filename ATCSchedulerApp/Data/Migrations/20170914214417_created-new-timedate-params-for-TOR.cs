using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Data.Migrations
{
    public partial class creatednewtimedateparamsforTOR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "TimeOffRequest",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "TimeOffRequest",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TimeOffRequest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TimeOffRequest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TimeOffRequest");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TimeOffRequest");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "TimeOffRequest",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TimeOffRequest",
                newName: "End");
        }
    }
}
