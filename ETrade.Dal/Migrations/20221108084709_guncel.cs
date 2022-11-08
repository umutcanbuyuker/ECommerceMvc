using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    public partial class guncel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_BasketMasters_OrderId",
                table: "BasketDetails");

            migrationBuilder.DropIndex(
                name: "IX_BasketDetails_OrderId",
                table: "BasketDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BasketDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_BasketMasters_Id",
                table: "BasketDetails",
                column: "Id",
                principalTable: "BasketMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDetails_BasketMasters_Id",
                table: "BasketDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "BasketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_OrderId",
                table: "BasketDetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDetails_BasketMasters_OrderId",
                table: "BasketDetails",
                column: "OrderId",
                principalTable: "BasketMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
