using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ATCScheduler.Migrations
{
    public partial class posSkjt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkillLevelId",
                table: "Position");

            migrationBuilder.CreateTable(
                name: "PositionSkillLevel",
                columns: table => new
                {
                    PositionSkillLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionId = table.Column<int>(nullable: false),
                    SkillLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionSkillLevel", x => x.PositionSkillLevelId);
                    table.ForeignKey(
                        name: "FK_PositionSkillLevel_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionSkillLevel_SkillLevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevel",
                        principalColumn: "SkillLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkillLevel_PositionId",
                table: "PositionSkillLevel",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionSkillLevel_SkillLevelId",
                table: "PositionSkillLevel",
                column: "SkillLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionSkillLevel");

            migrationBuilder.AddColumn<int>(
                name: "SkillLevelId",
                table: "Position",
                nullable: false,
                defaultValue: 0);
        }
    }
}
