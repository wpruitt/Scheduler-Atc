using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Data.Migrations
{
    public partial class addedstatustoTORmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TimeOffRequest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TimeOffRequest",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TORStatus",
                table: "TimeOffRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest");

            migrationBuilder.DropColumn(
                name: "TORStatus",
                table: "TimeOffRequest");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TimeOffRequest",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TimeOffRequest",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
