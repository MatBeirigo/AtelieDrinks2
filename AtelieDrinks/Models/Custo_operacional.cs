using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("Custo Operacional")]
    public class Custo_operacional
    {
        [Key]
        [Column("id_custo_operacional")]
        [Display(Name = "id_custo_operacional")]
        public int id_custo_operacional { get; set; }

        [Column("qtd_coordenador")]
        [Display(Name = "qtd_coordenador")]
        public int qtd_coordenador { get; set; }

        [Column("custo_coordenador")]
        [Display(Name = "custo coordenador")]
        public int custo_coordenador { get; set; }

        [Column("qtd_profissionais_gerais")]
        [Display(Name = "qtd_profissionais_gerais")]
        public int qtd_profissionais_gerais { get; set; }

        [Column("custo_profissionais_gerais ")]
        [Display(Name = "Custo profissionais gerais ")]
        public decimal custo_profissionais_gerais { get; set; }

        [Column("qtd_transporte")]
        [Display(Name = "qtd_transporte")]
        public int qtd_transporte { get; set; }

        [Column("custo_transporte")]
        [Display(Name = "custo transporte")]
        public int custo_transporte { get; set; }

        [Column("qtd_balcoes")]
        [Display(Name = "qtd balcoes")]
        public int qtd_balcoes { get; set; }

        [Column("custo_balcoes")]
        [Display(Name = "custo balcoes")]
        public int custo_balcoes { get; set; }

        [Column("qtd_taxa_deslocamento")]
        [Display(Name = "qtd_taxa deslocamento")]
        public int qtd_taxa_deslocamento { get; set; }

        [Column("custo_taxa_deslocamento")]
        [Display(Name = "custo taxa deslocamento")]
        public int custo_taxa_deslocamento { get; set; }

        [Column("qtd_impostos_federais")]
        [Display(Name = "qtd impostos federais")]
        public int qtd_impostos_federais { get; set; }

        [Column("custo_impostos_federais")]
        [Display(Name = "custo impostos federais")]
        public int custo_impostos_federais { get; set; }

        [Column("qtd_seguro_reserva")]
        [Display(Name = "qtd seguro reserva")]
        public int qtd_seguro_reserva { get; set; }

        [Column("custo_seguro_reserva")]
        [Display(Name = "custo seguro reserva")]
        public int custo_seguro_reserva { get; set; }

        [Column("qtd_taxa_operalizacao")]
        [Display(Name = "qtd taxa operalizacao")]
        public int qtd_taxa_operalizacao { get; set; }

        [Column("custo_taxa_operalizacao")]
        [Display(Name = "custo taxa operalizacao")]
        public int custo_taxa_operalizacao { get; set; }

        [Column("custo_operacional")]
        [Display(Name = "Custo operacional")]
        public int custo_operacional { get; set; }

        [Column("id_taxa_deslocamento")]
        [Display(Name = "id_taxa_deslocamento")]
        public List<Custo_deslocamento>? id_taxa_deslocamento { get; set; }


        /*
    id_custo_operacional SERIAL NOT NULL PRIMARY KEY,
    qtd_coordenador INTEGER NOT NULL,
    custo_coordernador NUMERIC NOT NULL,
    qtd_profissionais_gerais INTEGER NOT NULL,
    custo_profissionais_gerais NUMERIC NOT NULL,
    qtd_transporte INTEGER NOT NULL,
    custo_transporte NUMERIC NOT NULL,
    qtd_balcoes INTEGER NOT NULL,
    custo_balcoes NUMERIC NOT NULL,
    qtd_taxa_deslocamento INTEGER NOT NULL,
    custo_taxa_deslocamento NUMERIC NOT NULL,
    qtd_impostos_federais INTEGER NOT NULL,
    custo_impostos_federais NUMERIC NOT NULL,
    qtd_seguro_reserva INTEGER NOT NULL,
    custo_seguro_reserva NUMERIC NOT NULL,
    qtde_taxa_operalizacao INTEGER NOT NULL,
    custo_taxa_operalizacao NUMERIC NOT NULL,
    custo_operacional NUMERIC NOT NULL,
    id_taxa_deslocamento INTEGER NOT NULL,

    FOREIGN KEY(id_taxa_deslocamento) REFERENCES Custo_deslocamento(id_taxa_deslocamento)
*/

    }
}
