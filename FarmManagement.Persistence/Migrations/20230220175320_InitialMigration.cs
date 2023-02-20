using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SiteCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentSiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ItemNo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    LastPurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPurchasedPrice = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMasters_SiteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "SiteMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UOMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UOMs_SiteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "SiteMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Quantity = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchasedQuantity = table.Column<decimal>(type: "decimal(12,4)", precision: 12, scale: 4, nullable: false),
                    PurchasedPrice = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialMasters_ItemMasters_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemMasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialMasters_SiteMasters_SiteId",
                        column: x => x.SiteId,
                        principalTable: "SiteMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_SiteId",
                table: "ItemMasters",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMasters_ItemId",
                table: "MaterialMasters",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMasters_SiteId",
                table: "MaterialMasters",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteMasters_SiteCode",
                table: "SiteMasters",
                column: "SiteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UOMs_SiteId",
                table: "UOMs",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "MaterialMasters");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "UOMs");

            migrationBuilder.DropTable(
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "SiteMasters");
        }
    }
}
