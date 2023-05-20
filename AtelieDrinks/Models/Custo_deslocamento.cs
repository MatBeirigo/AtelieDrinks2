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
        public int id_taxa_deslocamento { get; set; }

        [Column("tipo_deslocamento")]
        [Display(Name = "Tipo deslocamento")]
        public string tipo_deslocamento { get; set; }

        [Column("valor_tipo_deslocamento")]
        [Display(Name = "Valor tipo deslocamento")]
        public decimal valor_tipo_deslocamento { get; set; }

        [Column("custo_tipo_deslocamento")]
        [Display(Name = "Custo tipo deslocamento")]
        public decimal custo_tipo_deslocamento { get; set; }



        /*id_taxa_deslocamento SERIAL NOT NULL PRIMARY KEY,
    tipo_deslocamento VARCHAR(30) NOT NULL,
    valor_tipo_deslocamento NUMERIC NOT NULL,
    custo_taxa_deslocamento NUMERIC NOT NULL */



    }
}
