using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.Repository.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "DateTime", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 6, 19, 38, 35, 28, DateTimeKind.Local).AddTicks(3242), 3, "Yas Water World" },
                    { 2, new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6767), 5, "Abu Dhabi International Hunting & Equestrian Exhibition" },
                    { 3, new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6813), 6, "Abu Dhabi International Book Fair" },
                    { 4, new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6817), 6, "Kayaking Around The Museum" },
                    { 5, new DateTime(2020, 9, 6, 19, 38, 35, 29, DateTimeKind.Local).AddTicks(6819), 2, "Hypercars: Evolution of Uniqueness" }
                });

            migrationBuilder.InsertData(
                table: "Individual",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ahmad", "Khalid" },
                    { 2, "Omar", "Alian" },
                    { 3, "Mansour", "Ahmad" },
                    { 4, "Khalid", "Mohamed" },
                    { 5, "Abdullah", "Naser" },
                    { 6, "Mohamed", "Faisal" },
                    { 7, "Mahmoud", "Omar" },
                    { 8, "Amjad", "Mohamed" },
                    { 9, "Hasan", "Hani" }
                });

            migrationBuilder.InsertData(
                table: "Invitation",
                columns: new[] { "EventId", "IndividualId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 9 },
                    { 5, 8 },
                    { 2, 8 },
                    { 1, 8 },
                    { 3, 7 },
                    { 2, 7 },
                    { 1, 7 },
                    { 3, 6 },
                    { 2, 6 },
                    { 1, 6 },
                    { 2, 9 },
                    { 3, 5 },
                    { 1, 5 },
                    { 4, 4 },
                    { 3, 4 },
                    { 1, 4 },
                    { 5, 3 },
                    { 3, 3 },
                    { 1, 3 },
                    { 5, 2 },
                    { 1, 2 },
                    { 4, 1 },
                    { 2, 5 },
                    { 4, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Invitation",
                keyColumns: new[] { "EventId", "IndividualId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Individual",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
