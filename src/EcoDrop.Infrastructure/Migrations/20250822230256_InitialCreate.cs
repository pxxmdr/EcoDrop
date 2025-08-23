using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoDrop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RM555306_MATERIALTYPES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM555306_MATERIALTYPES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RM555306_RECYCLINGPOINTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM555306_RECYCLINGPOINTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RM555306_OPENINGHOURS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RecyclingPointId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DayOfWeek = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OpenTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CloseTime = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM555306_OPENINGHOURS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RM555306_OPENINGHOURS_RM555306_RECYCLINGPOINTS_RecyclingPointId",
                        column: x => x.RecyclingPointId,
                        principalTable: "RM555306_RECYCLINGPOINTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RM555306_RPMATERIALTYPES",
                columns: table => new
                {
                    RecyclingPointId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM555306_RPMATERIALTYPES", x => new { x.RecyclingPointId, x.MaterialTypeId });
                    table.ForeignKey(
                        name: "FK_RM555306_RPMATERIALTYPES_RM555306_MATERIALTYPES_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "RM555306_MATERIALTYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RM555306_RPMATERIALTYPES_RM555306_RECYCLINGPOINTS_RecyclingPointId",
                        column: x => x.RecyclingPointId,
                        principalTable: "RM555306_RECYCLINGPOINTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RM555306_OPENINGHOURS_RecyclingPointId",
                table: "RM555306_OPENINGHOURS",
                column: "RecyclingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_RM555306_RPMATERIALTYPES_MaterialTypeId",
                table: "RM555306_RPMATERIALTYPES",
                column: "MaterialTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RM555306_OPENINGHOURS");

            migrationBuilder.DropTable(
                name: "RM555306_RPMATERIALTYPES");

            migrationBuilder.DropTable(
                name: "RM555306_MATERIALTYPES");

            migrationBuilder.DropTable(
                name: "RM555306_RECYCLINGPOINTS");
        }
    }
}
