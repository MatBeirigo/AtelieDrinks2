using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtelieDrinks.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Deposito",
                columns: table => new
                {
                    id_item = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    setor_armazenamento = table.Column<string>(type: "text", nullable: false),
                    nome_item = table.Column<string>(type: "text", nullable: false),
                    medida_de_armazenamento = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    custo_deposito = table.Column<decimal>(type: "numeric", nullable: false),
                    descricao_observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.id_item);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    id_drink = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_drink = table.Column<string>(type: "text", nullable: true),
                    custo_do_drink = table.Column<decimal>(type: "numeric", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    ingredientes_do_drink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.id_drink);
                });

            migrationBuilder.CreateTable(
                name: "Ficha Tecnica",
                columns: table => new
                {
                    id_ficha = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_drink = table.Column<string>(type: "text", nullable: false),
                    nome_base_alcoolica = table.Column<string>(type: "text", nullable: false),
                    nome_insumo = table.Column<string>(type: "text", nullable: false),
                    custo_insumo = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_base_alcoolica = table.Column<decimal>(type: "numeric", nullable: false),
                    medida = table.Column<int>(type: "integer", nullable: false),
                    ml_unidade = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_ficha = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha Tecnica", x => x.id_ficha);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    id_marca = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_bebida = table.Column<int>(type: "integer", nullable: false),
                    nome_marca = table.Column<string>(type: "text", nullable: false),
                    nome_bebida = table.Column<string>(type: "text", nullable: false),
                    custo_garrafa = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "Numero_convidados",
                columns: table => new
                {
                    id_Numero_convidados = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_pessoas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numero_convidados", x => x.id_Numero_convidados);
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

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    id_insumo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_insumo = table.Column<List<string>>(type: "text[]", nullable: false),
                    quantidade = table.Column<List<int>>(type: "integer[]", nullable: false),
                    valor = table.Column<List<decimal>>(type: "numeric[]", nullable: false),
                    Ficha_tecnicaid_ficha = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.id_insumo);
                    table.ForeignKey(
                        name: "FK_Insumos_Ficha Tecnica_Ficha_tecnicaid_ficha",
                        column: x => x.Ficha_tecnicaid_ficha,
                        principalTable: "Ficha Tecnica",
                        principalColumn: "id_ficha");
                });

            migrationBuilder.CreateTable(
                name: "Base_alcoolica",
                columns: table => new
                {
                    id_base_alcoolica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    nome_bebida = table.Column<string>(type: "text", nullable: false),
                    nome_marca = table.Column<string>(type: "text", nullable: false),
                    custo_garrafa = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total = table.Column<decimal>(type: "numeric", nullable: false),
                    id_bebidaid_marca = table.Column<int>(type: "integer", nullable: true),
                    id_marca1 = table.Column<int>(type: "integer", nullable: true),
                    Ficha_tecnicaid_ficha = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_alcoolica", x => x.id_base_alcoolica);
                    table.ForeignKey(
                        name: "FK_Base_alcoolica_Ficha Tecnica_Ficha_tecnicaid_ficha",
                        column: x => x.Ficha_tecnicaid_ficha,
                        principalTable: "Ficha Tecnica",
                        principalColumn: "id_ficha");
                    table.ForeignKey(
                        name: "FK_Base_alcoolica_Marca_id_bebidaid_marca",
                        column: x => x.id_bebidaid_marca,
                        principalTable: "Marca",
                        principalColumn: "id_marca");
                    table.ForeignKey(
                        name: "FK_Base_alcoolica_Marca_id_marca1",
                        column: x => x.id_marca1,
                        principalTable: "Marca",
                        principalColumn: "id_marca");
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    id_orcamento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_pessoas = table.Column<int>(type: "integer", nullable: false),
                    custo_operacional = table.Column<int>(type: "integer", nullable: false),
                    RespostaInsumosIdInsumo = table.Column<int>(type: "integer", nullable: false),
                    RespostaDrinksIdDrink = table.Column<int>(type: "integer", nullable: false),
                    CustoTotalInsumosIdDrink = table.Column<int>(type: "integer", nullable: false),
                    custo_total = table.Column<decimal>(type: "numeric", nullable: false),
                    base_orcamento = table.Column<decimal>(type: "numeric", nullable: false),
                    comisao_comercial = table.Column<decimal>(type: "numeric", nullable: false),
                    comisao_gerencia = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_primario = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_por_pessoa = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_arredondado_pra_cima = table.Column<decimal>(type: "numeric", nullable: false),
                    margem_negociacao = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_orcamento = table.Column<decimal>(type: "numeric", nullable: false),
                    previsao_lucro = table.Column<decimal>(type: "numeric", nullable: false),
                    taxa_de_lucro = table.Column<decimal>(type: "numeric", nullable: false),
                    qtde_convidados = table.Column<int>(type: "integer", nullable: false),
                    qtde_drinks = table.Column<int>(type: "integer", nullable: false),
                    IdInsumo1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.id_orcamento);
                    table.ForeignKey(
                        name: "FK_Orcamento_Drinks_CustoTotalInsumosIdDrink",
                        column: x => x.CustoTotalInsumosIdDrink,
                        principalTable: "Drinks",
                        principalColumn: "id_drink",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Drinks_RespostaDrinksIdDrink",
                        column: x => x.RespostaDrinksIdDrink,
                        principalTable: "Drinks",
                        principalColumn: "id_drink",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Insumos_IdInsumo1",
                        column: x => x.IdInsumo1,
                        principalTable: "Insumos",
                        principalColumn: "id_insumo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Insumos_RespostaInsumosIdInsumo",
                        column: x => x.RespostaInsumosIdInsumo,
                        principalTable: "Insumos",
                        principalColumn: "id_insumo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    id_historico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_pessoas = table.Column<int>(type: "integer", nullable: false),
                    custo_operacional = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total_insumos = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total_drinks = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total_geral = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total = table.Column<decimal>(type: "numeric", nullable: false),
                    base_orcamento = table.Column<decimal>(type: "numeric", nullable: false),
                    comisao_comercial = table.Column<decimal>(type: "numeric", nullable: false),
                    comisao_gerencia = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_primario = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_por_pessoa = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_arredondado_pra_cima = table.Column<decimal>(type: "numeric", nullable: false),
                    margem_negociacao = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_orcamento = table.Column<decimal>(type: "numeric", nullable: false),
                    previsao_lucro = table.Column<decimal>(type: "numeric", nullable: false),
                    taxa_de_lucro = table.Column<decimal>(type: "numeric", nullable: false),
                    qtde_convidados = table.Column<int>(type: "integer", nullable: false),
                    qtde_drinks = table.Column<int>(type: "integer", nullable: false),
                    id_orcamento = table.Column<int>(type: "integer", nullable: false),
                    id_insumo = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.id_historico);
                    table.ForeignKey(
                        name: "FK_Historico_Orcamento_id_orcamento",
                        column: x => x.id_orcamento,
                        principalTable: "Orcamento",
                        principalColumn: "id_orcamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Base_alcoolica_Ficha_tecnicaid_ficha",
                table: "Base_alcoolica",
                column: "Ficha_tecnicaid_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Base_alcoolica_id_bebidaid_marca",
                table: "Base_alcoolica",
                column: "id_bebidaid_marca");

            migrationBuilder.CreateIndex(
                name: "IX_Base_alcoolica_id_marca1",
                table: "Base_alcoolica",
                column: "id_marca1");

            migrationBuilder.CreateIndex(
                name: "IX_CustoOperacional_DeslocamentoIdTaxaDeslocamento",
                table: "CustoOperacional",
                column: "DeslocamentoIdTaxaDeslocamento");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_id_orcamento",
                table: "Historico",
                column: "id_orcamento");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_Ficha_tecnicaid_ficha",
                table: "Insumos",
                column: "Ficha_tecnicaid_ficha");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Base_alcoolica");

            migrationBuilder.DropTable(
                name: "CustoOperacional");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Numero_convidados");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Custo_deslocamento");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Ficha Tecnica");
        }
    }
}
