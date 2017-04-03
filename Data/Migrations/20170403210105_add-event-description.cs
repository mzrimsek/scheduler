using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scheduler.Data.Migrations
{
    public partial class addeventdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");
        }
    }
}
