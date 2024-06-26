using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kon.BillingBash.Migrations
{
    /// <inheritdoc />
    public partial class AddBillEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppItem_AppBill_BillId",
                        column: x => x.BillId,
                        principalTable: "AppBill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppPayItemHistory",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPayItemHistory", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AppPayItemHistory_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppPayItemHistory_AppItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "AppItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBill_CreationTime",
                table: "AppBill",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppItem_BillId",
                table: "AppItem",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_AppItem_CreationTime",
                table: "AppItem",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppPayItemHistory_CreationTime",
                table: "AppPayItemHistory",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppPayItemHistory_UserId",
                table: "AppPayItemHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPayItemHistory");

            migrationBuilder.DropTable(
                name: "AppItem");

            migrationBuilder.DropTable(
                name: "AppBill");
        }
    }
}
