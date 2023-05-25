using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtelieDrinks.Models
{
    public class TemporaryOrcamento
    {
        public int IdOrcamento { get; set; }

        [Display(Name = "Número de Pessoas")]
        public int NumeroPessoas { get; set; }

        [Display(Name = "Custo Operacional")]
        public int CustoOperacional { get; set; }

        [Display(Name = "Custo de Insumos")]
        public Insumos RespostaInsumos { get; set; }

        [Display(Name = "Custo de Drinks")]
        public Drinks RespostaDrinks { get; set; }

        [Display(Name = "Custo Total de Insumos")]
        public Drinks CustoTotalInsumos { get; set; }

        [Display(Name = "Custo Total")]
        public decimal CustoTotal { get; set; }

        [Display(Name = "Base do Orçamento")]
        public decimal BaseOrcamento { get; set; }

        [Display(Name = "Comissão Comercial")]
        public decimal ComissaoComercial { get; set; }

        [Display(Name = "Comissão Gerência")]
        public decimal ComissaoGerencia { get; set; }

        [Display(Name = "Valor Primário")]
        public decimal ValorPrimario { get; set; }

        [Display(Name = "Custo por Pessoa")]
        public decimal CustoPorPessoa { get; set; }

        [Display(Name = "Valor Arredondado")]
        public decimal ValorArredondadoPraCima { get; set; }

        [Display(Name = "Margem de Negociação")]
        public decimal MargemNegociacao { get; set; }

        [Display(Name = "Valor do Orçamento")]
        public decimal ValorOrcamento { get; set; }

        [Display(Name = "Previsão de Lucro")]
        public decimal PrevisaoLucro { get; set; }

        [Display(Name = "Taxa de Lucro")]
        public decimal TaxaDeLucro { get; set; }

        [Display(Name = "Quantidade de Convidados")]
        public int QtdeConvidados { get; set; }

        [Display(Name = "Quantidade de Drinks")]
        public int QtdeDrinks { get; set; }

        [Display(Name = "ID do Insumo")]
        public Insumos IdInsumo { get; set; }

        public List<Historico> Historicos { get; set; }
    }
}
