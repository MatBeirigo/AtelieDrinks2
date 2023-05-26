using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtelieDrinks.Data;
using AtelieDrinks.Models;
using Azure;
using System.Globalization;
using Microsoft.Extensions.Options;

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
        /// Método da página Index 2 para guardar os valores da página em um cookie
        /// </summary>
        /// <param name="qtdCoordenador"></param>
        /// <param name="valorCoordenador"></param>
        /// <param name="totalCoordenador"></param>
        /// <param name="qtdProfissionaisGerias"></param>
        /// <param name="valorProfissionaisGerias"></param>
        /// <param name="totalProfissionaisGerias"></param>
        /// <param name="qtdBalcoes"></param>
        /// <param name="valorBalcoes"></param>
        /// <param name="totalBalcoes"></param>
        /// <param name="qtdImpostosFederais"></param>
        /// <param name="valorImpostosFederais"></param>
        /// <param name="totalImpostosFederais"></param>
        /// <param name="qtdSeguroReserva"></param>
        /// <param name="valorSeguroReserva"></param>
        /// <param name="totalSeguroReserva"></param>
        /// <param name="qtdTaxaOp"></param>
        /// <param name="valorTaxaOp"></param>
        /// <param name="totalTaxaOp"></param>
        /// <returns></returns>
        [HttpPost, ActionName("CreateCustosOp")]
        public bool CreateCustosOp(string qtdCoordenadorParameter, string valorCoordenadorParameter, string totalCoordenadorParameter, string qtdProfissionaisGeriasParameter, string valorProfissionaisGeriasParameter, string totalProfissionaisGeriasParameter, string qtdBalcoesParameter, string valorBalcoesParameter, string totalBalcoesParameter, string qtdImpostosFederaisParameter, string valorImpostosFederaisParameter, string totalImpostosFederaisParameter, string qtdSeguroReservaParameter, string valorSeguroReservaParameter, string totalSeguroReservaParameter, string qtdTaxaOpParameter, string valorTaxaOpParameter, string totalTaxaOpParameter)
        {
            try
            {
                decimal qtdCoordenadorDecimal;
                decimal.TryParse(qtdCoordenadorParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdCoordenadorDecimal);
                decimal valorCoordenadorDecimal;
                decimal.TryParse(valorCoordenadorParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorCoordenadorDecimal);
                decimal totalCoordenadorDecimal;
                decimal.TryParse(totalCoordenadorParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalCoordenadorDecimal);

                decimal qtdProfissionaisGeraisDecimal;
                decimal.TryParse(qtdProfissionaisGeriasParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdProfissionaisGeraisDecimal);
                decimal valorProfissionaisGeraisDecimal;
                decimal.TryParse(valorProfissionaisGeriasParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorProfissionaisGeraisDecimal);
                decimal totalProfissionaisGeraisDecimal;
                decimal.TryParse(totalProfissionaisGeriasParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalProfissionaisGeraisDecimal);

                decimal qtdBalcoesDecimal;
                decimal.TryParse(qtdBalcoesParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdBalcoesDecimal);
                decimal valorBalcoesDecimal;
                decimal.TryParse(valorBalcoesParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorBalcoesDecimal);
                decimal totalBalcoesDecimal;
                decimal.TryParse(totalBalcoesParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalBalcoesDecimal);

                decimal qtdImpostosFederaisDecimal;
                decimal.TryParse(qtdImpostosFederaisParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdImpostosFederaisDecimal);
                decimal valorImpostosFederaisDecimal;
                decimal.TryParse(valorImpostosFederaisParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorImpostosFederaisDecimal);
                decimal totalImpostosFederaisDecimal;
                decimal.TryParse(totalImpostosFederaisParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalImpostosFederaisDecimal);
                
                decimal qtdSeguroReservaDecimal;
                decimal.TryParse(qtdSeguroReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdSeguroReservaDecimal);
                decimal valorSeguroReservaDecimal;
                decimal.TryParse(valorSeguroReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorSeguroReservaDecimal);
                decimal totalSeguroReservaDecimal;
                decimal.TryParse(totalSeguroReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalSeguroReservaDecimal);

                decimal qtdTaxaOpDecimal;
                decimal.TryParse(qtdTaxaOpParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdTaxaOpDecimal);
                decimal valorTaxaOpDecimal;
                decimal.TryParse(valorTaxaOpParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorTaxaOpDecimal);
                decimal totalTaxaOpDecimal;
                decimal.TryParse(totalTaxaOpParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalTaxaOpDecimal);


                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append("qtdCoordenador", qtdCoordenadorParameter, options);
                Response.Cookies.Append("valorCoordenador", valorCoordenadorParameter, options);
                Response.Cookies.Append("totalCoordenador", totalCoordenadorParameter, options);
                Response.Cookies.Append("qtdProfissionaisGerias", qtdProfissionaisGeriasParameter, options);
                Response.Cookies.Append("valorProfissionaisGerias", valorProfissionaisGeriasParameter, options);
                Response.Cookies.Append("totalProfissionaisGerias", totalProfissionaisGeriasParameter, options);
                Response.Cookies.Append("qtdBalcoes", qtdBalcoesParameter, options);
                Response.Cookies.Append("valorBalcoes", valorBalcoesParameter, options);
                Response.Cookies.Append("totalBalcoes", totalBalcoesParameter, options);
                Response.Cookies.Append("qtdImpostosFederais", qtdImpostosFederaisParameter, options);
                Response.Cookies.Append("valorImpostosFederais", valorImpostosFederaisParameter, options);
                Response.Cookies.Append("totalImpostosFederais", totalImpostosFederaisParameter, options);
                Response.Cookies.Append("qtdSeguroReserva", qtdSeguroReservaParameter, options);
                Response.Cookies.Append("valorSeguroReserva", valorSeguroReservaParameter, options);
                Response.Cookies.Append("totalSeguroReserva", totalSeguroReservaParameter, options);
                Response.Cookies.Append("qtdTaxaOp", qtdTaxaOpParameter, options);
                Response.Cookies.Append("valorTaxaOp", valorTaxaOpParameter, options);
                Response.Cookies.Append("totalTaxaOp", totalTaxaOpParameter, options);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

        [HttpPost, ActionName("CreateTxDeslocamento")]
        public bool CreateTxDeslocamento(string qtdCarretoParameter, string valorCarretoParameter, string totalCarretoParameter, string qtdPedagiosParameter, string valorPedagiosParameter, string totalPedagiosParameter, string qtdAlimentacaoParameter, string valorAlimentacaoParameter, string totalAlimentacaoParameter, string qtdCarroColabParameter, string valorCarroColabParameter, string totalCarroColabParameter, string qtdHospedagemParameter, string valorHospedagemParameter, string totalHospedagemParameter, string qtdReservaParameter, string valorReservaParameter, string totalReservaParameter)
        {
            try
            {
                decimal qtdCarretoDecimal;
                decimal.TryParse(qtdCarretoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdCarretoDecimal);
                decimal valorCarretoDecimal;
                decimal.TryParse(valorCarretoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorCarretoDecimal);
                decimal totalCarretoDecimal;
                decimal.TryParse(totalCarretoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalCarretoDecimal);

                decimal qtdPedagiosDecimal;
                decimal.TryParse(qtdPedagiosParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdPedagiosDecimal);
                decimal valorPedagiosDecimal;
                decimal.TryParse(valorPedagiosParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorPedagiosDecimal);
                decimal totalPedagiosDecimal;
                decimal.TryParse(totalPedagiosParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalPedagiosDecimal);

                decimal qtdAlimentacaoDecimal;
                decimal.TryParse(qtdAlimentacaoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdAlimentacaoDecimal);
                decimal valorAlimentacaoDecimal;
                decimal.TryParse(valorAlimentacaoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorAlimentacaoDecimal);
                decimal totalAlimentacaoDecimal;
                decimal.TryParse(totalAlimentacaoParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalAlimentacaoDecimal);

                decimal qtdCarroColabDecimal;
                decimal.TryParse(qtdCarroColabParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdCarroColabDecimal);
                decimal valorCarroColabDecimal;
                decimal.TryParse(valorCarroColabParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorCarroColabDecimal);
                decimal totalCarroColabDecimal;
                decimal.TryParse(totalCarroColabParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalCarroColabDecimal);

                decimal qtdHospedagemDecimal;
                decimal.TryParse(qtdHospedagemParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdHospedagemDecimal);
                decimal valorHospedagemDecimal;
                decimal.TryParse(valorHospedagemParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorHospedagemDecimal);
                decimal totalHospedagemDecimal;
                decimal.TryParse(totalHospedagemParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalHospedagemDecimal);

                decimal qtdReservaDecimal;
                decimal.TryParse(qtdReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out qtdReservaDecimal);
                decimal valorReservaDecimal;
                decimal.TryParse(valorReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out valorReservaDecimal);
                decimal totalReservaDecimal;
                decimal.TryParse(totalReservaParameter, NumberStyles.Float, CultureInfo.InvariantCulture, out totalReservaDecimal);

                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Append("qtdCarreto", qtdCarretoParameter, options);
                Response.Cookies.Append("valorCarreto", valorCarretoParameter, options);
                Response.Cookies.Append("totalCarreto", totalCarretoParameter, options);
                Response.Cookies.Append("qtdPedagios", qtdPedagiosParameter, options);
                Response.Cookies.Append("valorPedagios", valorPedagiosParameter, options);
                Response.Cookies.Append("totalPedagios", totalPedagiosParameter, options);
                Response.Cookies.Append("qtdAlimentacao", qtdAlimentacaoParameter, options);
                Response.Cookies.Append("valorAlimentacao", valorAlimentacaoParameter, options);
                Response.Cookies.Append("totalAlimentacao", totalAlimentacaoParameter, options);
                Response.Cookies.Append("qtdCarroColab", qtdCarroColabParameter, options);
                Response.Cookies.Append("valorCarroColab", valorCarroColabParameter, options);
                Response.Cookies.Append("totalCarroColab", totalCarroColabParameter, options);
                Response.Cookies.Append("qtdHospedagem", qtdHospedagemParameter, options);
                Response.Cookies.Append("valorHospedagem", valorHospedagemParameter, options);
                Response.Cookies.Append("totalHospedagem", totalHospedagemParameter, options);
                Response.Cookies.Append("qtdReserva", qtdReservaParameter, options);
                Response.Cookies.Append("valorReserva", valorReservaParameter, options);
                Response.Cookies.Append("totalReserva", totalReservaParameter, options);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }

    }
}



