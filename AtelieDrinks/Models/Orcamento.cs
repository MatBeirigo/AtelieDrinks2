using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{

    [Table("Orcamento")]
    public class Orcamento
    {
        [Key]
        [Column("id_orcamento")]
        [Display(Name = "id_orcamento")]
        public int IdOrcamento { get; set; }

        [Column("numero_pessoas")]
        [Display(Name = "Numero_pessoas")]
        public int NumeroPessoas { get; set; }

        [Column("custo_operacional")]
        [Display(Name = "Custo operacional")]
        public int CustoOperacional { get; set; }
        

        [Column("custo_insumos")]
        [Display(Name = "Custo insumos")]
        public Insumos RespostaInsumos { get; set; }

        [Column("custo_drinks")]
        [Display(Name = "Custo drinks")]
        public Drinks RespostaDrinks { get; set; }

        [Column("custo_total_insumos")]
        [Display(Name = "Custo total insumos")]
        public Drinks CustoTotalInsumos { get; set; }

        [Column("custo_total")]
        [Display(Name = "Custo total")]
        public decimal CustoTotal { get; set; }

        [Column("base_orcamento")]
        [Display(Name = "Base Orcamento")]
        public decimal BaseOrcamento { get; set; }

        [Column("comisao_comercial")]
        [Display(Name = "Comissao Comercial")]
        public decimal ComissaoComercial { get; set; }

        [Column("comisao_gerencia")]
        [Display(Name = "Comissao gerencia")]
        public decimal ComissaoGerencia { get; set; }

        [Column("valor_primario")]
        [Display(Name = "Valor primario")]
        public decimal ValorPrimario { get; set; }

        [Column("custo_por_pessoa")]
        [Display(Name = "Custo por pessoa")]
        public decimal CustoPorPessoa { get; set; }

        [Column("valor_arredondado_pra_cima")]
        [Display(Name = "valor arredondado")]
        public decimal ValorArredondadoPraCima { get; set; }

        [Column("margem_negociacao")]
        [Display(Name = "Margem negociacao")]
        public decimal MargemNegociacao { get; set; }

        [Column("valor_orcamento")]
        [Display(Name = "Valor Orcamento")]
        public decimal ValorOrcamento { get; set; }

        [Column("previsao_lucro")]
        [Display(Name = "Previsao lucro")]
        public decimal PrevisaoLucro { get; set; }

        [Column("taxa_de_lucro")]
        [Display(Name = "Taxa de lucro")]
        public decimal TaxaDeLucro { get; set; }

        [Column("qtde_convidados")]
        [Display(Name = "qtde convidados")]
        public int QtdeConvidados { get; set; }

        [Column("qtde_drinks")]
        [Display(Name = "qtde drinks")]
        public int QtdeDrinks { get; set; }

        [Column("id_insumo")]
        [Display(Name = "id_insumo")]
        public Insumos IdInsumo { get; set; }

        public List<Historico> Historicos { get; set; }

        public Orcamento()
        {
        }

        public Orcamento(decimal BaseOrcamento1, decimal TxComissaoComercial, decimal TxComissaoGerencia)
        {
            decimal custoTotalInsumos = RespostaInsumos.CustoTotal;
            decimal custoTotalDrinks = RespostaDrinks.CustoTotalDosDrinks;

            decimal custoTotalGeral = custoTotalInsumos + custoTotalDrinks;

            CustoTotal = CustoOperacional + custoTotalGeral;
            BaseOrcamento = CustoTotal * BaseOrcamento1;
            ComissaoComercial = BaseOrcamento * TxComissaoComercial;
            ComissaoGerencia = (BaseOrcamento + ComissaoComercial) * TxComissaoGerencia;
            ValorPrimario = BaseOrcamento + ComissaoComercial + ComissaoGerencia;
            CustoPorPessoa = ValorPrimario / NumeroPessoas;
            ValorArredondadoPraCima = Math.Ceiling(CustoPorPessoa);
            MargemNegociacao = (ValorArredondadoPraCima - CustoPorPessoa) * NumeroPessoas;
            ValorOrcamento = ValorArredondadoPraCima * NumeroPessoas;
            PrevisaoLucro = ValorOrcamento - MargemNegociacao - ComissaoGerencia - ComissaoComercial - BaseOrcamento - CustoTotal;
            TaxaDeLucro = (PrevisaoLucro * 100) / ValorOrcamento;

            Historicos = new List<Historico>
            {
                new Historico
                {
                    NumeroPessoas = NumeroPessoas,
                    CustoOperacional = CustoOperacional,
                    CustoTotalInsumos = custoTotalInsumos,
                    CustoTotalDrinks = custoTotalDrinks,
                    CustoTotalGeral = custoTotalGeral,
                    CustoTotal = CustoTotal,
                    BaseOrcamento = BaseOrcamento,
                    ComissaoComercial = ComissaoComercial,
                    ComissaoGerencia = ComissaoGerencia,
                    ValorPrimario = ValorPrimario,
                    CustoPorPessoa = CustoPorPessoa,
                    ValorArredondadoPraCima = ValorArredondadoPraCima,
                    MargemNegociacao = MargemNegociacao,
                    ValorOrcamento = ValorOrcamento,
                    PrevisaoLucro = PrevisaoLucro,
                    TaxaDeLucro = TaxaDeLucro,
                    QtdeConvidados = QtdeConvidados,
                    QtdeDrinks = QtdeDrinks,
                }
            };
        }
    }
}
