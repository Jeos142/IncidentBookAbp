using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentBookAbp.Migrations
{
    /// <inheritdoc />
    public partial class Added_Abp_Properties_To_Incident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppIncidents_AppClients_ClientId1",
                table: "AppIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_AppIncidents_AppIncidentClassifications_ClassificationId1",
                table: "AppIncidents");

            migrationBuilder.DropForeignKey(
                name: "FK_AppIncidents_AppResolutions_ResolutionId1",
                table: "AppIncidents");

            migrationBuilder.DropIndex(
                name: "IX_AppIncidents_ClassificationId1",
                table: "AppIncidents");

            migrationBuilder.DropIndex(
                name: "IX_AppIncidents_ClientId1",
                table: "AppIncidents");

            migrationBuilder.DropIndex(
                name: "IX_AppIncidents_ResolutionId1",
                table: "AppIncidents");

            migrationBuilder.DropColumn(
                name: "ClassificationId1",
                table: "AppIncidents");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "AppIncidents");

            migrationBuilder.DropColumn(
                name: "ResolutionId1",
                table: "AppIncidents");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppIncidents",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppIncidents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppIncidents");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppIncidents");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassificationId1",
                table: "AppIncidents",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "AppIncidents",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResolutionId1",
                table: "AppIncidents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppIncidents_ClassificationId1",
                table: "AppIncidents",
                column: "ClassificationId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppIncidents_ClientId1",
                table: "AppIncidents",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppIncidents_ResolutionId1",
                table: "AppIncidents",
                column: "ResolutionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppIncidents_AppClients_ClientId1",
                table: "AppIncidents",
                column: "ClientId1",
                principalTable: "AppClients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppIncidents_AppIncidentClassifications_ClassificationId1",
                table: "AppIncidents",
                column: "ClassificationId1",
                principalTable: "AppIncidentClassifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppIncidents_AppResolutions_ResolutionId1",
                table: "AppIncidents",
                column: "ResolutionId1",
                principalTable: "AppResolutions",
                principalColumn: "Id");
        }
    }
}
