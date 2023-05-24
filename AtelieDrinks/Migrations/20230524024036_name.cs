using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtelieDrinks.Migrations
{
    /// <inheritdoc />
    public partial class name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposito_Insumos_Insumosid_insumo",
                table: "Deposito");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Historico_Historicoid_historico",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Insumos_Orcamento_Orcamentoid_orcamento",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Insumos_Orcamentoid_orcamento",
                table: "Insumos");

            migrationBuilder.DropIndex(
                name: "IX_Historico_Historicoid_historico",
                table: "Historico");

            migrationBuilder.DropIndex(
                name: "IX_Deposito_Insumosid_insumo",
                table: "Deposito");

            migrationBuilder.DropColumn(
                name: "Orcamentoid_orcamento",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "custo_insumo",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "Historicoid_historico",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "custo_tecnico",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "ingredientes",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Insumosid_insumo",
                table: "Deposito");

            migrationBuilder.RenameColumn(
                name: "CustoOperacional",
                table: "Orcamento",
                newName: "custo_operacional");

            migrationBuilder.RenameColumn(
                name: "custo_total_insumos",
                table: "Orcamento",
                newName: "taxa_de_lucro");

            migrationBuilder.RenameColumn(
                name: "CustoOperacional",
                table: "Historico",
                newName: "custo_operacional");

            migrationBuilder.AlterColumn<int>(
                name: "custo_operacional",
                table: "Orcamento",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<int>(
                name: "CustoTotalInsumosIdDrink",
                table: "Orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdInsumo1",
                table: "Orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespostaDrinksIdDrink",
                table: "Orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespostaInsumosIdInsumo",
                table: "Orcamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<List<int>>(
                name: "quantidade",
                table: "Insumos",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<List<string>>(
                name: "nome_insumo",
                table: "Insumos",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<List<decimal>>(
                name: "valor",
                table: "Insumos",
                type: "numeric[]",
                nullable: false);

            migrationBuilder.AddColumn<decimal>(
                name: "custo_total_drinks",
                table: "Historico",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "custo_total_geral",
                table: "Historico",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<List<int>>(
                name: "id_insumo",
                table: "Historico",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "id_orcamento",
                table: "Historico",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "taxa_de_lucro",
                table: "Historico",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<List<int>>(
                name: "quantidade",
                table: "Drinks",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<List<decimal>>(
                name: "custo_do_drink",
                table: "Drinks",
                type: "numeric[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ingredientes_do_drink",
                table: "Drinks",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Custo_deslocamento",
                columns: table => new
                {
                    id_taxa_deslocamento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    qtd_tipo_deslocamento = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_tipo_deslocamento = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_tipo_deslocamento = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo_deslocamento", x => x.id_taxa_deslocamento);
                });

            migrationBuilder.CreateTable(
                name: "CustoOperacional",
                columns: table => new
                {
                    IdCustoOperacional = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QtdCoordenador = table.Column<int>(type: "integer", nullable: false),
                    valor_coordenador = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorCoordenador = table.Column<decimal>(type: "numeric", nullable: false),
                    QtdProfissionaisGerais = table.Column<int>(type: "integer", nullable: false),
                    valor_profissionais_gerais = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorProfissionaisGerais = table.Column<decimal>(type: "numeric", nullable: false),
                    QtdTransporte = table.Column<int>(type: "integer", nullable: false),
                    valor_transporte = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTransporte = table.Column<decimal>(type: "numeric", nullable: false),
                    QtdBalcoes = table.Column<int>(type: "integer", nullable: false),
                    valor_balcoes = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorBalcoes = table.Column<decimal>(type: "numeric", nullable: false),
                    DeslocamentoValorTipoDeslocamento = table.Column<int>(name: "Deslocamento.ValorTipoDeslocamento", type: "integer", nullable: false),
                    DeslocamentoIdTaxaDeslocamento = table.Column<int>(type: "integer", nullable: false),
                    QtdImpostosFederais = table.Column<int>(type: "integer", nullable: false),
                    valor_impostos_federais = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorImpostosFederais = table.Column<decimal>(type: "numeric", nullable: false),
                    QtdSeguroReserva = table.Column<int>(type: "integer", nullable: false),
                    valor_seguro_reserva = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorSeguroReserva = table.Column<decimal>(type: "numeric", nullable: false),
                    qtd_taxa_operacional = table.Column<int>(type: "integer", nullable: false),
                    valor_taxa_operacional = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_taxa_operacional = table.Column<decimal>(type: "numeric", nullable: false),
                    CustoOperacional = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoOperacional", x => x.IdCustoOperacional);
                    table.ForeignKey(
                        name: "FK_CustoOperacional_Custo_deslocamento_DeslocamentoIdTaxaDeslo~",
                        column: x => x.DeslocamentoIdTaxaDeslocamento,
                        principalTable: "Custo_deslocamento",
                        principalColumn: "id_taxa_deslocamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_CustoTotalInsumosIdDrink",
                table: "Orcamento",
                column: "CustoTotalInsumosIdDrink");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_IdInsumo1",
                table: "Orcamento",
                column: "IdInsumo1");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_RespostaDrinksIdDrink",
                table: "Orcamento",
                column: "RespostaDrinksIdDrink");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_RespostaInsumosIdInsumo",
                table: "Orcamento",
                column: "RespostaInsumosIdInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_id_orcamento",
                table: "Historico",
                column: "id_orcamento");

            migrationBuilder.CreateIndex(
                name: "IX_CustoOperacional_DeslocamentoIdTaxaDeslocamento",
                table: "CustoOperacional",
                column: "DeslocamentoIdTaxaDeslocamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Orcamento_id_orcamento",
                table: "Historico",
                column: "id_orcamento",
                principalTable: "Orcamento",
                principalColumn: "id_orcamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Drinks_CustoTotalInsumosIdDrink",
                table: "Orcamento",
                column: "CustoTotalInsumosIdDrink",
                principalTable: "Drinks",
                principalColumn: "id_drink",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Drinks_RespostaDrinksIdDrink",
                table: "Orcamento",
                column: "RespostaDrinksIdDrink",
                principalTable: "Drinks",
                principalColumn: "id_drink",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Insumos_IdInsumo1",
                table: "Orcamento",
                column: "IdInsumo1",
                principalTable: "Insumos",
                principalColumn: "id_insumo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_Insumos_RespostaInsumosIdInsumo",
                table: "Orcamento",
                column: "RespostaInsumosIdInsumo",
                principalTable: "Insumos",
                principalColumn: "id_insumo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Orcamento_id_orcamento",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Drinks_CustoTotalInsumosIdDrink",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Drinks_RespostaDrinksIdDrink",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Insumos_IdInsumo1",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_Insumos_RespostaInsumosIdInsumo",
                table: "Orcamento");

            migrationBuilder.DropTable(
                name: "CustoOperacional");

            migrationBuilder.DropTable(
                name: "Custo_deslocamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_CustoTotalInsumosIdDrink",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_IdInsumo1",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_RespostaDrinksIdDrink",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamento_RespostaInsumosIdInsumo",
                table: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Historico_id_orcamento",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "CustoTotalInsumosIdDrink",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "IdInsumo1",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "RespostaDrinksIdDrink",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "RespostaInsumosIdInsumo",
                table: "Orcamento");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Insumos");

            migrationBuilder.DropColumn(
                name: "custo_total_drinks",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "custo_total_geral",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "id_insumo",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "id_orcamento",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "taxa_de_lucro",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "custo_do_drink",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "ingredientes_do_drink",
                table: "Drinks");

            migrationBuilder.RenameColumn(
                name: "custo_operacional",
                table: "Orcamento",
                newName: "CustoOperacional");

            migrationBuilder.RenameColumn(
                name: "taxa_de_lucro",
                table: "Orcamento",
                newName: "custo_total_insumos");

            migrationBuilder.RenameColumn(
                name: "custo_operacional",
                table: "Historico",
                newName: "CustoOperacional");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoOperacional",
                table: "Orcamento",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "Insumos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<string>(
                name: "nome_insumo",
                table: "Insumos",
                type: "text",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.AddColumn<int>(
                name: "Orcamentoid_orcamento",
                table: "Insumos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "custo_insumo",
                table: "Insumos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Historicoid_historico",
                table: "Historico",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "Drinks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");

            migrationBuilder.AddColumn<decimal>(
                name: "custo_tecnico",
                table: "Drinks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ingredientes",
                table: "Drinks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Insumosid_insumo",
                table: "Deposito",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_Orcamentoid_orcamento",
                table: "Insumos",
                column: "Orcamentoid_orcamento");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Historicoid_historico",
                table: "Historico",
                column: "Historicoid_historico");

            migrationBuilder.CreateIndex(
                name: "IX_Deposito_Insumosid_insumo",
                table: "Deposito",
                column: "Insumosid_insumo");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposito_Insumos_Insumosid_insumo",
                table: "Deposito",
                column: "Insumosid_insumo",
                principalTable: "Insumos",
                principalColumn: "id_insumo");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Historico_Historicoid_historico",
                table: "Historico",
                column: "Historicoid_historico",
                principalTable: "Historico",
                principalColumn: "id_historico");

            migrationBuilder.AddForeignKey(
                name: "FK_Insumos_Orcamento_Orcamentoid_orcamento",
                table: "Insumos",
                column: "Orcamentoid_orcamento",
                principalTable: "Orcamento",
                principalColumn: "id_orcamento");
        }
    }
}
