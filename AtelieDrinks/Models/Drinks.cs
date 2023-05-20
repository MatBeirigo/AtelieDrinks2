using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Drinks")]
    public class Drinks
    {
        [Key]
        [Column("id_drink")]
        [Display(Name = "id_drink")]
        public int id_drink { get; set; }

        [Column("nome_drink")]
        [Display(Name = "Nome do drink")]
        public string nome_drink { get; set; }

        [Column("custo_tecnico")]
        [Display(Name = "Custo tecnico")]
        public decimal custo_tecnico{ get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Column("ingredientes")]
        [Display(Name = "Ingredientes")]
        public string? ingredientes { get; set; }

    }
}
