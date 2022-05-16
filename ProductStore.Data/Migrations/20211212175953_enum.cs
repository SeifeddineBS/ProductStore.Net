using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStore.Data.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Client_ClientFk",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Products_ProductFK",
                table: "Facture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facture",
                table: "Facture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Facture",
                newName: "Factures");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Facture_ClientFk",
                table: "Factures",
                newName: "IX_Factures_ClientFk");

            migrationBuilder.AddColumn<int>(
                name: "PType",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factures",
                table: "Factures",
                columns: new[] { "ProductFK", "ClientFk", "DateAchat" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "CIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Clients_ClientFk",
                table: "Factures",
                column: "ClientFk",
                principalTable: "Clients",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Products_ProductFK",
                table: "Factures",
                column: "ProductFK",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Clients_ClientFk",
                table: "Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Products_ProductFK",
                table: "Factures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factures",
                table: "Factures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PType",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Factures",
                newName: "Facture");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Factures_ClientFk",
                table: "Facture",
                newName: "IX_Facture_ClientFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facture",
                table: "Facture",
                columns: new[] { "ProductFK", "ClientFk", "DateAchat" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "CIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Client_ClientFk",
                table: "Facture",
                column: "ClientFk",
                principalTable: "Client",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Products_ProductFK",
                table: "Facture",
                column: "ProductFK",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
