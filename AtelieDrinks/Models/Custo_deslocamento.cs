using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Custo_deslocamento")]
    public class Custo_deslocamento
    {
        [Key]
        [Column("id_taxa_deslocamento")]
        [Display(Name = "id_taxa_deslocamento")]
        public int IdTaxaDeslocamento { get; set; }

        [Column("qtd_tipo_deslocamento")]
        [Display(Name = "Quantidade do tipo deslocamento")]
        public decimal QtdTipoDeslocamento { get; set; }

        [Column("valor_tipo_deslocamento")]
        [Display(Name = "Valor tipo deslocamento")]
        public decimal ValorTipoDeslocamento { get; set; }

        [Column("custo_tipo_deslocamento")]
        [Display(Name = "Custo tipo deslocamento")]
        public decimal CustoTipoDeslocamento { get; set; }

        public Custo_deslocamento(decimal qtdTipoDeslocamento, decimal valorTipoDeslocamento)
        {
            this.QtdTipoDeslocamento = qtdTipoDeslocamento;
            this.ValorTipoDeslocamento = valorTipoDeslocamento;
            this.CustoTipoDeslocamento = this.ValorTipoDeslocamento * this.QtdTipoDeslocamento;
        }
    }
}
