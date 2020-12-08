using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiddywee.DAL.Migrations
{
    public partial class PersonToChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChild_People_ChildId",
                table: "PersonToChild");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChild_AspNetUsers_CreatedById",
                table: "PersonToChild");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChild_People_PersonId",
                table: "PersonToChild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonToChild",
                table: "PersonToChild");

            migrationBuilder.RenameTable(
                name: "PersonToChild",
                newName: "PersonToChildren");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChild_PersonId",
                table: "PersonToChildren",
                newName: "IX_PersonToChildren_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChild_CreatedById",
                table: "PersonToChildren",
                newName: "IX_PersonToChildren_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChild_ChildId",
                table: "PersonToChildren",
                newName: "IX_PersonToChildren_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonToChildren",
                table: "PersonToChildren",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChildren_People_ChildId",
                table: "PersonToChildren",
                column: "ChildId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChildren_AspNetUsers_CreatedById",
                table: "PersonToChildren",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChildren_People_PersonId",
                table: "PersonToChildren",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChildren_People_ChildId",
                table: "PersonToChildren");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChildren_AspNetUsers_CreatedById",
                table: "PersonToChildren");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonToChildren_People_PersonId",
                table: "PersonToChildren");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonToChildren",
                table: "PersonToChildren");

            migrationBuilder.RenameTable(
                name: "PersonToChildren",
                newName: "PersonToChild");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChildren_PersonId",
                table: "PersonToChild",
                newName: "IX_PersonToChild_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChildren_CreatedById",
                table: "PersonToChild",
                newName: "IX_PersonToChild_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PersonToChildren_ChildId",
                table: "PersonToChild",
                newName: "IX_PersonToChild_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonToChild",
                table: "PersonToChild",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChild_People_ChildId",
                table: "PersonToChild",
                column: "ChildId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChild_AspNetUsers_CreatedById",
                table: "PersonToChild",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonToChild_People_PersonId",
                table: "PersonToChild",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
