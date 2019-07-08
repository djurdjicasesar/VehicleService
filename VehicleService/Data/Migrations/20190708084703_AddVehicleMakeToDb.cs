using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleService.Data.Migrations
{
    public partial class AddVehicleMakeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Abrv = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleMake_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMake_UserId",
                table: "VehicleMake",
                column: "UserId");
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.DropTable(
          name: "VehicleMake");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "AspNetUserTokens",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string));

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserTokens",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string));

        migrationBuilder.AlterColumn<string>(
            name: "ProviderKey",
            table: "AspNetUserLogins",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string));

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserLogins",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string));

    }
    }
}
