using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Ficha Tecnica")]
    public class Ficha_tecnica
    {
        [Key]
        [Column("id_ficha")]
        [Display(Name = "id_ficha")]
        public int id_ficha { get; set; }

        [Column("nome_drink")]
        [Display(Name = "Nome drink")]
        public string nome_drink { get; set; }

        [Column("nome_base_alcoolica")]
        [Display(Name = "Nome base alcoolica")]
        public string nome_base_alcoolica { get; set; }

        [Column("nome_insumo")]
        [Display(Name = "Nome insumo")]
        public string nome_insumo { get; set; }

        [Column("custo_insumo")]
        [Display(Name = "Custo insumo")]
        public decimal custo_insumo { get; set; }

        [Column("custo_base_alcoolica")]
        [Display(Name = "Custo base alcoolica")]
        public decimal custo_base_alcoolica { get; set; }

        [Column("medida")]
        [Display(Name = "Medida")]
        public int medida { get; set; }

        [Column("ml_unidade")]
        [Display(Name = "Ml_unidade")]
        public decimal ml_unidade { get; set; }

        [Column("valor_ficha")]
        [Display(Name = "Valor ficha")]
        public decimal valor_ficha { get; set; }

        [Column("id_base_alcoolica")]
        [Display(Name = "id_base_alcoolica")]
        public List<Base_alcoolica>? id_base_alcoolica { get; set; }

        [Column("id_insumo")]
        [Display(Name = "id_insumo")]
        public List<Insumos>? id_insumo { get; set; }


        /*CREATE TABLE Ficha_tecnica(
    id_ficha SERIAL NOT NULL PRIMARY KEY,
    nome_drink VARCHAR(30) NOT NULL,
    nome_base_alcoolica VARCHAR(30) NOT NULL,
    nome_insumo VARCHAR(30) NOT NULL,
    custo_insumo NUMERIC NOT NULL,
    custo_base_alcoolica NUMERIC NOT NULL,
    medida NUMERIC NOT NULL,
    ml_unidade NUMERIC NOT NULL,
    valor_ficha NUMERIC NOT NULL,
    id_base_alcoolica INTEGER NOT NULL,
    id_insumo INTEGER NOT NULL,
    
    FOREIGN KEY(id_insumo) REFERENCES Insumos(id_insumo),
    FOREIGN KEY(id_base_alcoolica) REFERENCES Base_alcoolica(id_base_alcoolica)*/

    }
}
