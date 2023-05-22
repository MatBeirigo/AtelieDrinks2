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
        public List<string> NomeInsumo { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public List<int> QuantidadeInsumo { get; set; }

        [Column("valor")]
        [Display(Name = "Valor")]
        public List<decimal> ValorInsumo { get; set; }

        [NotMapped]
        [Display(Name = "Custo insumo")]
        public decimal CustoTotal
        {
            get
            {
                return CustoInsumo.Sum();
            }
        }

        [NotMapped]
        private List<decimal> CustoInsumo { get; set; }

        public Insumos()
        {
            CustoInsumo = new List<decimal>();
        }

        public void CalcularCustoInsumo()
        {
            CustoInsumo = QuantidadeInsumo.Select((qtd, index) => qtd * ValorInsumo[index]).ToList();
        }
    }
}
