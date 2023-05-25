using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtelieDrinks.Data;
using AtelieDrinks.Models;
using Azure;

namespace AtelieDrinks.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly Contexto _context;

        public OrcamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index()
        {
            return _context.Orcamento != null ?
                        View(await _context.Orcamento.ToListAsync()) :
                        Problem("Entity set 'Contexto.Orcamento'  is null.");
        }

        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orcamento == null)
            {
                return NotFound();
            }

            var Orcamento = await _context.Orcamento
                .FirstOrDefaultAsync(m => m.IdOrcamento == id);
            if (Orcamento == null)
            {
                return NotFound();
            }

            return View(Orcamento);
        }

        //private readonly Data.Contexto _context;
        [Route("Orcamento/{numberPage:int?}")]
        public ActionResult Index(int? numberPage)
        {
            switch (numberPage)
            {
                case 1:
                    return View("~/Views/Orcamento/Index1.cshtml");
                case 2:
                    return View("~/Views/Orcamento/Index2.cshtml");
                case 3:
                    return View("~/Views/Orcamento/Index3.cshtml");
                case 4:
                    return View("~/Views/Orcamento/Index4.cshtml");
                case 5:
                    return View("~/Views/Orcamento/Index5.cshtml");
                // Adicione outros casos conforme necessário
                default:
                    return NotFound(); // Retorna um erro 404 se o número da página não for válido
            }
        }

        // GET: Orcamento/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}
        [HttpPost, ActionName("Createnumero_pessoas")]
        public bool Createnumero_pessoas(int numero_pessoas)
        {
            try
            {
                Orcamento orcamento = new Orcamento();
                orcamento.SetNumeroPessoas(numero_pessoas);

                if (ModelState.IsValid)
                {
                    Response.Cookies.Append("NumeroPessoas", numero_pessoas.ToString());
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

        [HttpPost]
        public bool Create_custosOp(string qtdCoordenador, string valorCoordenador, string totalCoordenador, string qtdProfissionaisGerias, string valorProfissionaisGerias, string totalProfissionaisGerias, string qtdBalcoes, string valorBalcoes, string totalBalcoes, string qtdImpostosFederais, string valorImpostosFederais, string totalImpostosFederais, string qtdSeguroReserva, string valorSeguroReserva, string totalSeguroReserva, string qtdTaxaOp, string valorTaxaOp, string totalTaxaOp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    decimal.TryParse(qtdCoordenador, out decimal qtdCoordenadorDecimal);
                    decimal.TryParse(valorCoordenador, out decimal valorCoordenadorDecimal);
                    decimal.TryParse(qtdProfissionaisGerias, out decimal qtdProfissionaisGeriasDecimal);
                    decimal.TryParse(valorProfissionaisGerias, out decimal valorProfissionaisGeriasDecimal);
                    decimal.TryParse(qtdBalcoes, out decimal qtdBalcoesDecimal);
                    decimal.TryParse(valorBalcoes, out decimal valorBalcoesDecimal);
                    decimal.TryParse(qtdImpostosFederais, out decimal qtdImpostosFederaisDecimal);
                    decimal.TryParse(valorImpostosFederais, out decimal valorImpostosFederaisDecimal);
                    decimal.TryParse(qtdSeguroReserva, out decimal qtdSeguroReservaDecimal);
                    decimal.TryParse(valorSeguroReserva, out decimal valorSeguroReservaDecimal);
                    decimal.TryParse(qtdTaxaOp, out decimal qtdTaxaOpDecimal);
                    decimal.TryParse(valorTaxaOp, out decimal valorTaxaOpDecimal);

                    decimal totalCoordenadorDecimal = qtdCoordenadorDecimal * valorCoordenadorDecimal;
                    decimal totalProfissionaisGeriasDecimal = qtdProfissionaisGeriasDecimal * valorProfissionaisGeriasDecimal;
                    decimal totalBalcoesDecimal = qtdBalcoesDecimal * valorBalcoesDecimal;
                    decimal totalImpostosFederaisDecimal = qtdImpostosFederaisDecimal * valorImpostosFederaisDecimal;
                    decimal totalSeguroReservaDecimal = qtdSeguroReservaDecimal * valorSeguroReservaDecimal;
                    decimal totalTaxaOpDecimal = qtdTaxaOpDecimal * valorTaxaOpDecimal;

                    var options = new CookieOptions();

                    options.Expires = DateTime.Now.AddDays(1); 

                    Response.Cookies.Append("qtdCoordenador", qtdCoordenador, options);
                    Response.Cookies.Append("valorCoordenador", valorCoordenador, options);
                    Response.Cookies.Append("totalCoordenador", totalCoordenadorDecimal.ToString(), options);
                    Response.Cookies.Append("qtdProfissionaisGerias", qtdProfissionaisGerias, options);
                    Response.Cookies.Append("valorProfissionaisGerias", valorProfissionaisGerias, options);
                    Response.Cookies.Append("totalProfissionaisGerias", totalProfissionaisGeriasDecimal.ToString(), options);
                    Response.Cookies.Append("qtdBalcoes", qtdBalcoes, options);
                    Response.Cookies.Append("valorBalcoes", valorBalcoes, options);
                    Response.Cookies.Append("totalBalcoes", totalBalcoesDecimal.ToString(), options);
                    Response.Cookies.Append("qtdImpostosFederais", qtdImpostosFederais, options);
                    Response.Cookies.Append("valorImpostosFederais", valorImpostosFederais, options);
                    Response.Cookies.Append("totalImpostosFederais", totalImpostosFederaisDecimal.ToString(), options);
                    Response.Cookies.Append("qtdSeguroReserva", qtdSeguroReserva, options);
                    Response.Cookies.Append("valorSeguroReserva", valorSeguroReserva, options);
                    Response.Cookies.Append("totalSeguroReserva", totalSeguroReservaDecimal.ToString(), options);
                    Response.Cookies.Append("qtdTaxaOp", qtdTaxaOp, options);
                    Response.Cookies.Append("valorTaxaOp", valorTaxaOp, options);
                    Response.Cookies.Append("totalTaxaOp", totalTaxaOpDecimal.ToString(), options);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
                return false;
            }
        }
    }
}



