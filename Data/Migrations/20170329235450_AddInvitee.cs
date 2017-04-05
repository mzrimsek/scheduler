using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scheduler.Data.Migrations
{
    public partial class AddInvitee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.CreateTable(
                name: "Invitees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Accepted = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitees", x => x.Id);
                });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "events",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Invitees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "Events",
                column: "Id");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");
        }
    }
}
