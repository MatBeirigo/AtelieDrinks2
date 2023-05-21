using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Numero_convidados")]
    public class Numero_convidados
    {
        [Key]
        [Column("id_Numero_convidados")]
        [Display(Name = "id_Numero_convidados")]
        public int id_orcamento { get; set; }

        [Column("numero_pessoas")]
        [Display(Name = "Numero_pessoas")]
        public int numero_pessoas { get; set; }

        
    }
}
