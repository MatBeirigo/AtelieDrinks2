using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtelieDrinks.Data;
using AtelieDrinks.Models;
using Azure;
using System.Globalization;
using Microsoft.Extensions.Options;
using System.Web;

namespace AtelieDrinks.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly Contexto _context;

        public OrcamentoController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por redirecionar as páginas
        /// </summary>
        /// <param name="numberPage"></param>
        /// <returns></returns>
        [Route("Orcamento/{numberPage:int?}")]
        public ActionResult Index(int? numberPage)
        {
            if (numberPage >= 1 && numberPage <= 5)
            {
                return View($"~/Views/Orcamento/Index{numberPage}.cshtml");
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Método da página Index 1 para guardar o número de pessoas em um cookie
        /// </summary>
        /// <param name="numero_pessoas"></param>
        /// <returns></returns>
        [HttpPost, ActionName("CreateNumeroPessoas")]
        public bool CreateNumeroPessoas(int numeroPessoasParameter)
        {
            try
            {
                Orcamento orcamento = new Orcamento();
                orcamento.SetNumeroPessoas(numeroPessoasParameter);

                if (ModelState.IsValid)
                {
                    Response.Cookies.Append("NumeroPessoas", numeroPessoasParameter.ToString());
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método da página Index 2 para guardar o custo operacional em um cookie
        /// </summary>
        /// <param name="qtdCoordenadorParameter"></param>
        /// <param name="valorCoordenadorParameter"></param>
        /// <param name="totalCoordenadorParameter"></param>
        /// <param name="qtdProfissionaisGeriasParameter"></param>
        /// <param name="valorProfissionaisGeriasParameter"></param>
        /// <param name="totalProfissionaisGeriasParameter"></param>
        /// <param name="qtdBalcoesParameter"></param>
        /// <param name="valorBalcoesParameter"></param>
        /// <param name="totalBalcoesParameter"></param>
        /// <param name="qtdImpostosFederaisParameter"></param>
        /// <param name="valorImpostosFederaisParameter"></param>
        /// <param name="totalImpostosFederaisParameter"></param>
        /// <param name="qtdSeguroReservaParameter"></param>
        /// <param name="valorSeguroReservaParameter"></param>
        /// <param name="totalSeguroReservaParameter"></param>
        /// <param name="qtdTaxaOpParameter"></param>
        /// <param name="valorTaxaOpParameter"></param>
        /// <param name="totalTaxaOpParameter"></param>
        /// <returns></returns>
        [HttpPost, ActionName("CreateCustosOp")]
        public bool CreateCustosOp(string qtdCoordenadorParameter, string valorCoordenadorParameter, string totalCoordenadorParameter, string qtdProfissionaisGeriasParameter, string valorProfissionaisGeriasParameter, string totalProfissionaisGeriasParameter, string qtdBalcoesParameter, string valorBalcoesParameter, string totalBalcoesParameter, string qtdImpostosFederaisParameter, string valorImpostosFederaisParameter, string totalImpostosFederaisParameter, string qtdSeguroReservaParameter, string valorSeguroReservaParameter, string totalSeguroReservaParameter, string qtdTaxaOpParameter, string valorTaxaOpParameter, string totalTaxaOpParameter)
        {
            try
            {
                decimal totalCustoOperacional = 0;

                decimal.TryParse(totalCoordenadorParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalCoordenadorDecimal);
                decimal.TryParse(totalProfissionaisGeriasParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalProfissionaisGeraisDecimal);
                decimal.TryParse(totalBalcoesParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalBalcoesDecimal);
                decimal.TryParse(totalImpostosFederaisParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalImpostosFederaisDecimal);
                decimal.TryParse(totalSeguroReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalSeguroReservaDecimal);
                decimal.TryParse(totalTaxaOpParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalTaxaOpDecimal);

                totalCustoOperacional = totalCoordenadorDecimal + totalProfissionaisGeraisDecimal + totalBalcoesDecimal + totalImpostosFederaisDecimal + totalSeguroReservaDecimal + totalTaxaOpDecimal;

                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append("CustoOperacional", totalCustoOperacional.ToString(CultureInfo.InvariantCulture), options);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método da página Index 3 para guardar o custo de bebidas em um cookie
        /// </summary>
        /// <param name="qtdCarretoParameter"></param>
        /// <param name="valorCarretoParameter"></param>
        /// <param name="totalCarretoParameter"></param>
        /// <param name="qtdPedagiosParameter"></param>
        /// <param name="valorPedagiosParameter"></param>
        /// <param name="totalPedagiosParameter"></param>
        /// <param name="qtdAlimentacaoParameter"></param>
        /// <param name="valorAlimentacaoParameter"></param>
        /// <param name="totalAlimentacaoParameter"></param>
        /// <param name="qtdCarroColabParameter"></param>
        /// <param name="valorCarroColabParameter"></param>
        /// <param name="totalCarroColabParameter"></param>
        /// <param name="qtdHospedagemParameter"></param>
        /// <param name="valorHospedagemParameter"></param>
        /// <param name="totalHospedagemParameter"></param>
        /// <param name="qtdReservaParameter"></param>
        /// <param name="valorReservaParameter"></param>
        /// <param name="totalReservaParameter"></param>
        /// <returns></returns>
        [HttpPost, ActionName("CreateTxDeslocamento")]
        public bool CreateTxDeslocamento(string qtdCarretoParameter, string valorCarretoParameter, string totalCarretoParameter, string qtdPedagiosParameter, string valorPedagiosParameter, string totalPedagiosParameter, string qtdAlimentacaoParameter, string valorAlimentacaoParameter, string totalAlimentacaoParameter, string qtdCarroColabParameter, string valorCarroColabParameter, string totalCarroColabParameter, string qtdHospedagemParameter, string valorHospedagemParameter, string totalHospedagemParameter, string qtdReservaParameter, string valorReservaParameter, string totalReservaParameter)
        {
            try
            {
                decimal totalCustoTaxaDeslocamento = 0;

                decimal.TryParse(totalCarretoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalCarretoDecimal);
                decimal.TryParse(totalPedagiosParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalPedagiosDecimal);
                decimal.TryParse(totalAlimentacaoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalAlimentacaoDecimal);
                decimal.TryParse(totalCarroColabParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalCarroColabDecimal);
                decimal.TryParse(totalHospedagemParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalHospedagemDecimal);
                decimal.TryParse(totalReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal totalReservaDecimal);

                totalCustoTaxaDeslocamento = totalCarretoDecimal + totalPedagiosDecimal + totalAlimentacaoDecimal + totalCarroColabDecimal + totalHospedagemDecimal + totalReservaDecimal;

                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append("CustoTaxaDeslocamento", totalCustoTaxaDeslocamento.ToString(CultureInfo.InvariantCulture), options);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método para calcular o valor total de drinks
        /// </summary>
        /// <param name="valorDrinks"></param>
        /// <returns></returns>
        [HttpPost, ActionName("ValorTotalDrinks")]
        public bool ValorTotalDrinks(string valorDrinksParameter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    decimal valorDrinks;
                    decimal.TryParse(valorDrinksParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorDrinks);

                    var options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Append("ValorTotalDrinks", valorDrinksParameter, options);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Método para finalizar o orçamento
        /// </summary>
        [HttpPost, ActionName("FinalizarOrcamento")]
        public bool FinalizarOrcamento()
        {
            try
            {
                int numeroPessoas = int.Parse(Request.Cookies["NumeroPessoas"]);
                double custoOperacional = ConvertToDouble(Request.Cookies["CustoOperacional"]);
                double custoTotalInsumos = ConvertToDouble(Request.Cookies["ValorTotalDrinks"]);

                double custoTotal = (custoOperacional + custoTotalInsumos);
                double baseOrcamento1 = (custoTotal * 1.48);
                double comisaoComercial = (baseOrcamento1 * 0.0547);
                double comisaoGerencia = ((baseOrcamento1 + comisaoComercial) * 0.01);
                double valorPrimario = (baseOrcamento1 + comisaoComercial + comisaoGerencia);
                double custoPorPessoa = (valorPrimario / numeroPessoas);
                double valorArredondadoPraCima = (custoPorPessoa);
                double margemNegociacao = ((custoPorPessoa - valorArredondadoPraCima) * numeroPessoas);
                double valorOrcamento = (valorArredondadoPraCima * numeroPessoas);
                double previsaoLucro = (valorOrcamento - margemNegociacao - comisaoGerencia - comisaoComercial - custoTotal);
                double taxaDeLucro = (previsaoLucro * 100 / valorOrcamento);

                var historico = new Historico
                {
                    IdHistorico = 0,
                    NumeroPessoas = numeroPessoas,
                    CustoOperacional = custoOperacional.ToString("0.00"),
                    CustoTotalInsumos = custoTotalInsumos.ToString("0.00"),
                    CustoTotal = custoTotal.ToString("0.00"),
                    BaseOrcamento = baseOrcamento1.ToString("0.00"),
                    ComissaoComercial = comisaoComercial.ToString("0.00"),
                    ComissaoGerencia = comisaoGerencia.ToString("0.00"),
                    ValorPrimario = valorPrimario.ToString("0.00"),
                    CustoPorPessoa = custoPorPessoa.ToString("0.00"),
                    ValorArredondadoPraCima = valorArredondadoPraCima.ToString("0.00"),
                    MargemNegociacao = margemNegociacao.ToString("0.00"),
                    ValorOrcamento = valorOrcamento.ToString("0.00"),
                    PrevisaoLucro = previsaoLucro.ToString("0.00"),
                    TaxaDeLucro = taxaDeLucro.ToString("0.00"),
                };

                _context.Historico.Add(historico);
                _context.SaveChanges();

                Response.Cookies.Delete("NumeroPessoas");
                Response.Cookies.Delete("CustoOperacional");
                Response.Cookies.Delete("CustoTaxaDeslocamento");
                Response.Cookies.Delete("ValorTotalDrinks");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        private double ConvertToDouble(string value)
        {
            string numericValue = new string(value.Where(char.IsDigit).ToArray());
            double result = double.Parse(numericValue) / 100.0;

            return result;
        }
    }
}



