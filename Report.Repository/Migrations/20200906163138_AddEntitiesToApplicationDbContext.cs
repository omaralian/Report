using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.Repository.Migrations
{
    public partial class AddEntitiesToApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Event_EventId",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 20, 31, 37, 588, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 20, 31, 37, 589, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 20, 31, 37, 589, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 20, 31, 37, 589, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 20, 31, 37, 589, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Events_EventId",
                table: "Invitation",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Events_EventId",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 19, 38, 35, 28, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Event_EventId",
                table: "Invitation",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
