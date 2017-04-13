using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scheduler.Data.Migrations
{
    public partial class changetostringid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Invitees",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Events",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Invitees",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Events",
                nullable: false);
        }
    }
}
