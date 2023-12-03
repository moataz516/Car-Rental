using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    public partial class CusDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<decimal>(
                name: "totalPrice",
                table: "Reservations",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "CusDetId",
                table: "Reservations",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Payments",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Cars",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustomerDetailsId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    firstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    lastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    dateOfBirth = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.CustomerDetailsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CusDetId",
                table: "Reservations",
                column: "CusDetId",
                unique: true,
                filter: "\"CusDetId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CustomerDetails_CusDetId",
                table: "Reservations",
                column: "CusDetId",
                principalTable: "CustomerDetails",
                principalColumn: "CustomerDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CustomerDetails_CusDetId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CusDetId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CusDetId",
                table: "Reservations");

            migrationBuilder.AlterColumn<decimal>(
                name: "totalPrice",
                table: "Reservations",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Payments",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Cars",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.CreateTable(
                name: "DateTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    eDate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    sDate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTests", x => x.Id);
                });
        }
    }
}
