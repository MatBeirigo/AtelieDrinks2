using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [Column("id_marca")]
        [Display(Name = "id_marca")]
        public int id_marca { get; set; }

        [Column("id_bebida")]
        [Display(Name = "id_bebida")]
        public int id_bebida{ get; set; }

        [Column("nome_marca")]
        [Display(Name = "Nome da marca")]
        public string nome_marca { get; set; }

        [Column("nome_bebida")]
        [Display(Name = "Nome da bebida")]
        public string nome_bebida{ get; set; }

        [Column("custo_garrafa")]
        [Display(Name = "Custo da garrafa")]
        public decimal custo_garrafa { get; set; }

    }
}
