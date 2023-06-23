using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Insumos")]
    public class Insumos
    {
        [Key]
        [Column("id_insumo")]
        [Display(Name = "id_insumo")]
        public int IdInsumo { get; set; }

        [Column("nome_insumo")]
        [Display(Name = "Nome do insumo")]
        public string NomeInsumo { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int QuantidadeInsumo { get; set; }

        [Column("valor")]
        [Display(Name = "Valor")]
        public decimal ValorInsumo { get; set; }

        
    }
}
