using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtelieDrinks.Migrations
{
    /// <inheritdoc />
    public partial class oi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custo Operacional",
                columns: table => new
                {
                    id_custo_operacional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtd_coordenador = table.Column<int>(type: "int", nullable: false),
                    custo_coordenador = table.Column<int>(type: "int", nullable: false),
                    qtd_profissionais_gerais = table.Column<int>(type: "int", nullable: false),
                    custo_profissionais_gerais = table.Column<decimal>(name: "custo_profissionais_gerais ", type: "decimal(18,2)", nullable: false),
                    qtd_transporte = table.Column<int>(type: "int", nullable: false),
                    custo_transporte = table.Column<int>(type: "int", nullable: false),
                    qtd_balcoes = table.Column<int>(type: "int", nullable: false),
                    custo_balcoes = table.Column<int>(type: "int", nullable: false),
                    qtd_taxa_deslocamento = table.Column<int>(type: "int", nullable: false),
                    custo_taxa_deslocamento = table.Column<int>(type: "int", nullable: false),
                    qtd_impostos_federais = table.Column<int>(type: "int", nullable: false),
                    custo_impostos_federais = table.Column<int>(type: "int", nullable: false),
                    qtd_seguro_reserva = table.Column<int>(type: "int", nullable: false),
                    custo_seguro_reserva = table.Column<int>(type: "int", nullable: false),
                    qtd_taxa_operalizacao = table.Column<int>(type: "int", nullable: false),
                    custo_taxa_operalizacao = table.Column<int>(type: "int", nullable: false),
                    custo_operacional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo Operacional", x => x.id_custo_operacional);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    id_drink = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_drink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custo_tecnico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    ingredientes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.id_drink);
                });

            migrationBuilder.CreateTable(
                name: "Ficha Tecnica",
                columns: table => new
                {
                    id_ficha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_drink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_base_alcoolica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_insumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custo_insumo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_base_alcoolica = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    medida = table.Column<int>(type: "int", nullable: false),
                    ml_unidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_ficha = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha Tecnica", x => x.id_ficha);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    id_historico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_pessoas = table.Column<int>(type: "int", nullable: false),
                    custo_operacional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_total_insumos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    base_orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comisao_comercial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comisao_gerencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_primario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_por_pessoa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_arredondado_pra_cima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    margem_negociacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    previsao_lucro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qtde_convidados = table.Column<int>(type: "int", nullable: false),
                    qtde_drinks = table.Column<int>(type: "int", nullable: false),
                    Historicoid_historico = table.Column<int>(type: "int", nullable: true)
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
                    id_marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_bebida = table.Column<int>(type: "int", nullable: false),
                    nome_marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_bebida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custo_garrafa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    id_orcamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_pessoas = table.Column<int>(type: "int", nullable: false),
                    custo_operacional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_total_insumos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    base_orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comisao_comercial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comisao_gerencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_primario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_por_pessoa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_arredondado_pra_cima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    margem_negociacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    previsao_lucro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qtde_convidados = table.Column<int>(type: "int", nullable: false),
                    qtde_drinks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.id_orcamento);
                });

            migrationBuilder.CreateTable(
                name: "Custo_deslocamento",
                columns: table => new
                {
                    id_taxa_deslocamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_deslocamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_tipo_deslocamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_tipo_deslocamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Custo_operacionalid_custo_operacional = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo_deslocamento", x => x.id_taxa_deslocamento);
                    table.ForeignKey(
                        name: "FK_Custo_deslocamento_Custo Operacional_Custo_operacionalid_custo_operacional",
                        column: x => x.Custo_operacionalid_custo_operacional,
                        principalTable: "Custo Operacional",
                        principalColumn: "id_custo_operacional");
                });

            migrationBuilder.CreateTable(
                name: "Base_alcoolica",
                columns: table => new
                {
                    id_base_alcoolica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    nome_bebida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custo_garrafa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    custo_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    id_bebidaid_marca = table.Column<int>(type: "int", nullable: true),
                    id_marca1 = table.Column<int>(type: "int", nullable: true),
                    Ficha_tecnicaid_ficha = table.Column<int>(type: "int", nullable: true)
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
                    id_insumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_insumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    custo_insumo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ficha_tecnicaid_ficha = table.Column<int>(type: "int", nullable: true),
                    Orcamentoid_orcamento = table.Column<int>(type: "int", nullable: true)
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
                    id_item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setor_armazenamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medida_de_armazenamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    custo_deposito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descricao_observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insumosid_insumo = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Custo_deslocamento_Custo_operacionalid_custo_operacional",
                table: "Custo_deslocamento",
                column: "Custo_operacionalid_custo_operacional");

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
                name: "Custo_deslocamento");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Custo Operacional");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Ficha Tecnica");

            migrationBuilder.DropTable(
                name: "Orcamento");
        }
    }
}
