using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Deposito")]
    public class Deposito
    {
        [Key]
        [Column("id_item")]
        [Display(Name = "id_item")]
        public int id_item { get; set; }

        [Column("setor_armazenamento")]
        [Display(Name = "Setor armazenamento")]
        public string setor_armazenamento { get; set; }

        [Column("nome_item")]
        [Display(Name = "Nome do item")]
        public string nome_item { get; set; }

        [Column("medida_de_armazenamento")]
        [Display(Name = "Medida de armazenamento")]
        public string medida_de_armazenamento { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Column("custo_deposito")]
        [Display(Name = "Custo deposito")]
        public decimal custo_tecnico { get; set; }

        [Column("descricao_observacao")]
        [Display(Name = "Descricao")]
        public string? descricao_observacao { get; set; }


        /* id_item SERIAL NOT NULL PRIMARY KEY,
    setor_armazenamento VARCHAR(30) NOT NULL,
    nome_item VARCHAR(30) NOT NULL,
    medida_de_armazenamento VARCHAR(15) NOT NULL,
    quantidade INTEGER NOT NULL,
    custo_deposito NUMERIC NOT NULL,
    descricao_observacao VARCHAR(100) NOT NULL*/

    }
}
