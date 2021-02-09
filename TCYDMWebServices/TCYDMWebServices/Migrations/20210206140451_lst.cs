using Microsoft.EntityFrameworkCore.Migrations;

namespace TCYDMWebServices.Migrations
{
    public partial class lst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QueryId",
                table: "PDFBase",
                newName: "OnlineQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_PDFBase_OnlineQueryId",
                table: "PDFBase",
                column: "OnlineQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PDFBase_OnlineQueries_OnlineQueryId",
                table: "PDFBase",
                column: "OnlineQueryId",
                principalTable: "OnlineQueries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PDFBase_OnlineQueries_OnlineQueryId",
                table: "PDFBase");

            migrationBuilder.DropIndex(
                name: "IX_PDFBase_OnlineQueryId",
                table: "PDFBase");

            migrationBuilder.RenameColumn(
                name: "OnlineQueryId",
                table: "PDFBase",
                newName: "QueryId");
        }
    }
}
