using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStar.Infra.Data.Migrations
{
    public partial class LatestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Series",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Classificacao",
                table: "Series",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Personagens",
                newName: "ImagemAntiga");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "ImagemAntiga",
                table: "Personagens");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Filmes",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<double>(
                name: "Classificacao",
                table: "Filmes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Episodios",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Nota",
                table: "AvaliacoesSeries",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Nota",
                table: "AvaliacoesFilmes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "Filmes");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Series",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "Series",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Personagens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Personagens");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Filmes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Episodios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "AvaliacoesSeries",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "AvaliacoesFilmes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}