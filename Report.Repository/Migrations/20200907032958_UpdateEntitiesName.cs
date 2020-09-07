using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.Repository.Migrations
{
    public partial class UpdateEntitiesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Events_EventId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_Individual_IndividualId",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individual",
                table: "Individual");

            migrationBuilder.RenameTable(
                name: "Invitation",
                newName: "Invitations");

            migrationBuilder.RenameTable(
                name: "Individual",
                newName: "Individuals");

            migrationBuilder.RenameIndex(
                name: "IX_Invitation_IndividualId",
                table: "Invitations",
                newName: "IX_Invitations_IndividualId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                columns: new[] { "EventId", "IndividualId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individuals",
                table: "Individuals",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 9, 7, 7, 29, 58, 399, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 9, 7, 7, 29, 58, 400, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 9, 7, 7, 29, 58, 400, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2020, 9, 7, 7, 29, 58, 400, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2020, 9, 7, 7, 29, 58, 400, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Events_EventId",
                table: "Invitations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Individuals_IndividualId",
                table: "Invitations",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Events_EventId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Individuals_IndividualId",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individuals",
                table: "Individuals");

            migrationBuilder.RenameTable(
                name: "Invitations",
                newName: "Invitation");

            migrationBuilder.RenameTable(
                name: "Individuals",
                newName: "Individual");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_IndividualId",
                table: "Invitation",
                newName: "IX_Invitation_IndividualId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation",
                columns: new[] { "EventId", "IndividualId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individual",
                table: "Individual",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_Individual_IndividualId",
                table: "Invitation",
                column: "IndividualId",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
