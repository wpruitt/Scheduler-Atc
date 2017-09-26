using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATCScheduler.Migrations
{
    public partial class JoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftATController",
                columns: table => new
                {
                    ShiftATControllerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATControllerId = table.Column<int>(nullable: false),
                    ShfitId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftATController", x => x.ShiftATControllerId);
                    table.ForeignKey(
                        name: "FK_ShiftATController_ATController_ATControllerId",
                        column: x => x.ATControllerId,
                        principalTable: "ATController",
                        principalColumn: "ControllerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftATController_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftPosition",
                columns: table => new
                {
                    ShiftPositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPosition", x => x.ShiftPositionId);
                    table.ForeignKey(
                        name: "FK_ShiftPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftPosition_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftATController_ATControllerId",
                table: "ShiftATController",
                column: "ATControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftATController_ShiftId",
                table: "ShiftATController",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPosition_PositionId",
                table: "ShiftPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPosition_ShiftId",
                table: "ShiftPosition",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftATController");

            migrationBuilder.DropTable(
                name: "ShiftPosition");
        }
    }
}
