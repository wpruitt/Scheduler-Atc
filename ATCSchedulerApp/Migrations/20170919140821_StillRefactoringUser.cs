using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATCScheduler.Migrations
{
    public partial class StillRefactoringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_ATController_AspNetUsers_UserId",
                table: "ATController");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest");

            migrationBuilder.DropIndex(
                name: "IX_TimeOffRequest_UserId",
                table: "TimeOffRequest");

            migrationBuilder.DropIndex(
                name: "IX_ATController_UserId",
                table: "ATController");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TimeOffRequest",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ATController",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointment",
                newName: "userId");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "TimeOffRequest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "ATController",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "TimeOffRequest",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ATController",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Appointment",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TimeOffRequest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ATController",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeOffRequest_UserId",
                table: "TimeOffRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATController_UserId",
                table: "ATController",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ATController_AspNetUsers_UserId",
                table: "ATController",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_AspNetUsers_UserId",
                table: "TimeOffRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
