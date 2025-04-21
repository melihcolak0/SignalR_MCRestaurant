using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _81MY_SignalROrderMan.DataAccessLayer.Migrations
{
    public partial class mig_restTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RestaurantTable_RestaurantTableId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTable",
                table: "RestaurantTable");

            migrationBuilder.RenameTable(
                name: "RestaurantTable",
                newName: "RestaurantTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTables",
                table: "RestaurantTables",
                column: "RestaurantTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RestaurantTables_RestaurantTableId",
                table: "Orders",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "RestaurantTableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RestaurantTables_RestaurantTableId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantTables",
                table: "RestaurantTables");

            migrationBuilder.RenameTable(
                name: "RestaurantTables",
                newName: "RestaurantTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantTable",
                table: "RestaurantTable",
                column: "RestaurantTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RestaurantTable_RestaurantTableId",
                table: "Orders",
                column: "RestaurantTableId",
                principalTable: "RestaurantTable",
                principalColumn: "RestaurantTableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
