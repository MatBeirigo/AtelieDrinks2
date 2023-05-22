using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AtelieDrinks.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    id_drink = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_drink = table.Column<string>(type: "text", nullable: true),
                    custo_tecnico = table.Column<decimal>(type: "numeric", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    ingredientes = table.Column<string>(type: "text", nullable: false)
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
                name: "Historico",
                columns: table => new
                {
                    id_historico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_pessoas = table.Column<int>(type: "integer", nullable: false),
                    CustoOperacional = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total_insumos = table.Column<decimal>(type: "numeric", nullable: false),
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
                    qtde_convidados = table.Column<int>(type: "integer", nullable: false),
                    qtde_drinks = table.Column<int>(type: "integer", nullable: false),
                    Historicoid_historico = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.id_historico);
                    table.ForeignKey(
                        name: "FK_Historico_Historico_Historicoid_historico",
                        column: x => x.Historicoid_historico,
                        principalTable: "Historico",
                        principalColumn: "id_historico");
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
                name: "Orcamento",
                columns: table => new
                {
                    id_orcamento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_pessoas = table.Column<int>(type: "integer", nullable: false),
                    CustoOperacional = table.Column<decimal>(type: "numeric", nullable: false),
                    custo_total_insumos = table.Column<decimal>(type: "numeric", nullable: false),
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
                    qtde_convidados = table.Column<int>(type: "integer", nullable: false),
                    qtde_drinks = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.id_orcamento);
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
                name: "Insumos",
                columns: table => new
                {
                    id_insumo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_insumo = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    custo_insumo = table.Column<decimal>(type: "numeric", nullable: false),
                    Ficha_tecnicaid_ficha = table.Column<int>(type: "integer", nullable: true),
                    Orcamentoid_orcamento = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.id_insumo);
                    table.ForeignKey(
                        name: "FK_Insumos_Ficha Tecnica_Ficha_tecnicaid_ficha",
                        column: x => x.Ficha_tecnicaid_ficha,
                        principalTable: "Ficha Tecnica",
                        principalColumn: "id_ficha");
                    table.ForeignKey(
                        name: "FK_Insumos_Orcamento_Orcamentoid_orcamento",
                        column: x => x.Orcamentoid_orcamento,
                        principalTable: "Orcamento",
                        principalColumn: "id_orcamento");
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
                    descricao_observacao = table.Column<string>(type: "text", nullable: true),
                    Insumosid_insumo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.id_item);
                    table.ForeignKey(
                        name: "FK_Deposito_Insumos_Insumosid_insumo",
                        column: x => x.Insumosid_insumo,
                        principalTable: "Insumos",
                        principalColumn: "id_insumo");
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
                name: "IX_Deposito_Insumosid_insumo",
                table: "Deposito",
                column: "Insumosid_insumo");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Historicoid_historico",
                table: "Historico",
                column: "Historicoid_historico");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_Ficha_tecnicaid_ficha",
                table: "Insumos",
                column: "Ficha_tecnicaid_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_Orcamentoid_orcamento",
                table: "Insumos",
                column: "Orcamentoid_orcamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Base_alcoolica");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Numero_convidados");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Ficha Tecnica");

            migrationBuilder.DropTable(
                name: "Orcamento");
        }
    }
}
