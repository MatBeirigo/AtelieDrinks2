using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    [Table("CustoOperacional")]
    public class CustoOperacional
    {
        [Key]
        [Column("IdCustoOperacional")]
        [Display(Name = "IdCustoOperacional")]
        public int IdCustoOperacional { get; set; }

        [Column("QtdCoordenador")]
        [Display(Name = "QtdCoordenador")]
        public int QtdCoordenador { get; set; }

        [Column("valor_coordenador")]
        [Display(Name = "valor_coordenador")]
        public decimal ValorCoordenador { get; set; }

        [Column("ValorCoordenador")]
        [Display(Name = "ValorCoordenador")]
        public decimal CustoCoordenador { get; set; }

        [Column("QtdProfissionaisGerais")]
        [Display(Name = "QtdProfissionaisGerais")]
        public int QtdProfissionaisGerais { get; set; }

        [Column("valor_profissionais_gerais")]
        [Display(Name = "valor_profissionais_gerais")]
        public decimal ValorProfissionaisGerais { get; set; }

        [Column("ValorProfissionaisGerais")]
        [Display(Name = "ValorProfissionaisGerais")]
        public decimal CustoProfissionaisGerais { get; set; }

        [Column("QtdTransporte")]
        [Display(Name = "QtdTransporte")]
        public int QtdTransporte { get; set; }

        [Column("valor_transporte")]
        [Display(Name = "valor_transporte")]
        public decimal ValorTransporte { get; set; }

        [Column("ValorTransporte")]
        [Display(Name = "ValorTransporte")]
        public decimal CustoTransporte { get; set; }

        [Column("QtdBalcoes")]
        [Display(Name = "QtdBalcoes")]
        public int QtdBalcoes { get; set; }

        [Column("valor_balcoes")]
        [Display(Name = "valor_balcoes")]
        public decimal ValorBalcoes { get; set; }

        [Column("ValorBalcoes")]
        [Display(Name = "ValorBalcoes")]
        public decimal CustoBalcoes { get; set; }

        [ForeignKey("CustoTaxaDeslocamento")]
        [Column("Deslocamento.ValorTipoDeslocamento")]
        [Display(Name = "Deslocamento.ValorTipoDeslocamento")]
        public int CustoTaxaDeslocamentoId { get; set; }

        [Display(Name = "Custo Taxa Deslocamento")]
        public Custo_deslocamento Deslocamento { get; set; }

        [Column("QtdImpostosFederais")]
        [Display(Name = "Qtd Impostos Federais")]
        public int QtdImpostosFederais { get; set; }

        [Column("valor_impostos_federais")]
        [Display(Name = "Valor Impostos Federais")]
        public decimal ValorImpostosFederais { get; set; }

        [Column("ValorImpostosFederais")]
        [Display(Name = "Custo Impostos Federais")]
        public decimal CustoImpostosFederais { get; set; }

        [Column("QtdSeguroReserva")]
        [Display(Name = "Qtd Seguro Reserva")]
        public int QtdSeguroReserva { get; set; }

        [Column("valor_seguro_reserva")]
        [Display(Name = "Valor Seguro Reserva")]
        public decimal ValorSeguroReserva { get; set; }

        [Column("ValorSeguroReserva")]
        [Display(Name = "Custo Seguro Reserva")]
        public decimal CustoSeguroReserva { get; set; }

        [Column("qtd_taxa_operacional")]
        [Display(Name = "Qtd Taxa Operacional")]
        public int QtdTaxaOperacional { get; set; }

        [Column("valor_taxa_operacional")]
        [Display(Name = "Valor Taxa Operacional")]
        public decimal ValorTaxaOperacional { get; set; }

        [Column("custo_taxa_operacional")]
        [Display(Name = "Custo Taxa Operacional")]
        public decimal CustoTaxaOperacional { get; set; }

        [Column("CustoOperacional")]
        [Display(Name = "Custo Operacional")]
        public decimal Custo_Operacional { get; set; }

        public CustoOperacional(int qtdCoordenador, decimal valorCoordenador, int qtdProfissionaisGerais, decimal valorProfissionaisGerais,
            int qtdTransporte, decimal valorTransporte, int qtdBalcoes, decimal valorBalcoes, int qtdImpostosFederais, decimal valorImpostosFederais,
            int qtdSeguroReserva, decimal valorSeguroReserva, int qtdTaxaOperacional, decimal valorTaxaOperacional)
        {
            this.QtdCoordenador = qtdCoordenador;
            this.ValorCoordenador = valorCoordenador;
            this.QtdProfissionaisGerais = qtdProfissionaisGerais;
            this.ValorProfissionaisGerais = valorProfissionaisGerais;
            this.QtdTransporte = qtdTransporte;
            this.ValorTransporte = valorTransporte;
            this.QtdBalcoes = qtdBalcoes;
            this.ValorBalcoes = valorBalcoes;
            this.QtdImpostosFederais = qtdImpostosFederais;
            this.ValorImpostosFederais = valorImpostosFederais;
            this.QtdSeguroReserva = qtdSeguroReserva;
            this.ValorSeguroReserva = valorSeguroReserva;
            this.QtdTaxaOperacional = qtdTaxaOperacional;
            this.ValorTaxaOperacional = valorTaxaOperacional;

            CalcularCustos();
        }

        public void CalcularCustos()
        {
            this.CustoCoordenador = this.QtdCoordenador * this.ValorCoordenador;
            this.CustoProfissionaisGerais = this.QtdProfissionaisGerais * this.ValorProfissionaisGerais;
            this.CustoTransporte = this.QtdTransporte * this.ValorTransporte;
            this.CustoBalcoes = this.QtdBalcoes * this.ValorBalcoes;
            this.CustoImpostosFederais = this.QtdImpostosFederais * this.ValorImpostosFederais;
            this.CustoSeguroReserva = this.QtdSeguroReserva * this.ValorSeguroReserva;
            this.CustoTaxaOperacional = this.QtdTaxaOperacional * this.ValorTaxaOperacional;

            if (this.Deslocamento != null)
            {
                this.Custo_Operacional = this.CustoCoordenador + this.CustoProfissionaisGerais + this.CustoTransporte + this.CustoBalcoes + this.CustoImpostosFederais + this.CustoSeguroReserva + this.CustoTaxaOperacional + this.Deslocamento.CustoTipoDeslocamento;
            }
            else
            {
                this.Custo_Operacional = this.CustoCoordenador + this.CustoProfissionaisGerais + this.CustoTransporte + this.CustoBalcoes + this.CustoImpostosFederais + this.CustoSeguroReserva + this.CustoTaxaOperacional;
            }
        }
    }
}
