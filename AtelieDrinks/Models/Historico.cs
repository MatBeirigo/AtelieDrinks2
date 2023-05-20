using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Historico")]
    public class Historico
    {
        [Key]
        [Column("id_historico")]
        [Display(Name = "id_orcamento")]
        public int id_historico { get; set; }

        [Column("numero_pessoas")]
        [Display(Name = "Numero_pessoas")]
        public int numero_pessoas { get; set; }

        [Column("custo_operacional")]
        [Display(Name = "Custo operacional")]
        public decimal custo_operacional { get; set; }

        [Column("custo_total_insumos")]
        [Display(Name = "Custo total insumos")]
        public decimal custo_total_insumos { get; set; }

        [Column("custo_total")]
        [Display(Name = "Custo total")]
        public decimal custo_total { get; set; }

        [Column("base_orcamento")]
        [Display(Name = "Base Orcamento")]
        public decimal base_orcamento { get; set; }

        [Column("comisao_comercial")]
        [Display(Name = "Comissao Comercial")]
        public decimal comissao_comercial { get; set; }

        [Column("comisao_gerencia")]
        [Display(Name = "Comissao gerencia")]
        public decimal comissao_gerencia { get; set; }

        [Column("valor_primario")]
        [Display(Name = "Valor primario")]
        public decimal valor_primario { get; set; }

        [Column("custo_por_pessoa")]
        [Display(Name = "Custo por pessoa")]
        public decimal custo_por_pessoa { get; set; }

        [Column("valor_arredondado_pra_cima")]
        [Display(Name = "valor arredondado")]
        public decimal valor_arredondado_pra_cima { get; set; }

        [Column("margem_negociacao")]
        [Display(Name = "Margem negociacao")]
        public decimal margem_negociacao { get; set; }

        [Column("valor_orcamento")]
        [Display(Name = "Valor Orcamento")]
        public decimal valor_orcamento { get; set; }

        [Column("previsao_lucro")]
        [Display(Name = "Previsao lucro")]
        public decimal previsao_lucro { get; set; }

        [Column("qtde_convidados")]
        [Display(Name = "qtde convidados")]
        public int qtde_convidados { get; set; }

        [Column("qtde_drinks")]
        [Display(Name = "qtde drinks")]
        public int qtde_drinks { get; set; }

        [Column("id_orcamento")]
        [Display(Name = "id_orcamento")]
        public List<Historico>? id_orcamento { get; set; }

    }
}
