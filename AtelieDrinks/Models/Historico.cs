using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Historico")]
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_historico")]
        [Display(Name = "ID do Histórico")]
        public int IdHistorico { get; set; }

        [Column("nome_cliente")]
        [Display(Name = "Nome_cliente")]
        public string NomeCliente { get; set; }

        [Column("data_evento")]
        [Display(Name = "Data_evento")]
        public string DataEvento { get; set; }

        [Column("numero_pessoas")]
        [Display(Name = "Número de Pessoas")]
        public int NumeroPessoas { get; set; }

        [Column("custo_operacional")]
        [Display(Name = "Custo Operacional")]
        public string CustoOperacional { get; set; }

        [Column("custo_total_insumos")]
        [Display(Name = "Custo Total de Insumos")]
        public string CustoTotalInsumos { get; set; }

        [Column("custo_total")]
        [Display(Name = "Custo Total")]
        public string CustoTotal { get; set; }

        [Column("base_orcamento")]
        [Display(Name = "Base de Orcamento")]
        public string BaseOrcamento { get; set; }

        [Column("comissao_comercial")]
        [Display(Name = "Comissao Comercial")]
        public string ComissaoComercial { get; set; }

        [Column("comissao_gerencia")]
        [Display(Name = "Comissao Gerencia")]
        public string ComissaoGerencia { get; set; }

        [Column("valor_primario")]
        [Display(Name = "Valor Primario")]
        public string ValorPrimario { get; set; }

        [Column("custo_por_pessoa")]
        [Display(Name = "Custo por Pessoa")]
        public string CustoPorPessoa { get; set; }

        [Column("valor_arredondado_pra_cima")]
        [Display(Name = "Valor Arredondado pra Cima")]
        public string ValorArredondadoPraCima { get; set; }

        [Column("margem_negociacao")]
        [Display(Name = "Margem Negociacao")]
        public string MargemNegociacao { get; set; }

        [Column("valor_orcamento")]
        [Display(Name = "Valor Orcamento")]
        public string ValorOrcamento { get; set; }

        [Column("previsao_lucro")]
        [Display(Name = "Precisao Lucro")]
        public string PrevisaoLucro { get; set; }

        [Column("taxa_de_lucro")]
        [Display(Name = "Taxa de Lucro")]
        public string TaxaDeLucro { get; set; }

        //public Orcamento Orcamento { get; set; }
    }
}
