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
        public int IdDrink { get; set; }

        [Column("nome_drink")]
        [Display(Name = "Nome do drink")]
        public string? NomeDrink { get; set; }

        [Column("custo_do_drink")]
        [Display(Name = "Custo do drink")]
        public List<decimal> CustoDoDrink { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public List<int> Quantidade { get; set; }

        [Column("ingredientes_do_drink")]
        [Display(Name = "Ingredientes do Drink")]
        public string? IngredientesDoDrink { get; set; }

        [NotMapped]
        [Display(Name = "Custo total")]
        public decimal CustoTotalDosDrinks
        {
            get
            {
                decimal custoTotal = 0;
                for (int i = 0; i < CustoDoDrink.Count; i++)
                {
                    custoTotal += CustoDoDrink[i] * Quantidade[i];
                }
                return custoTotal;
            }
        }

    }
}
