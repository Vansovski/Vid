using Microsoft.AspNetCore.Mvc;
using Vidly.Data;

namespace Vidly.Controllers
{

    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        //Injeção de dependica do BD
        private  readonly DataContext _context;

        public ClientesController(ILogger<ClientesController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        public ActionResult Detalhes(int Id)
        {
            var cliente = _context.Clientes.Where(cliente => cliente.Id == Id).FirstOrDefault();

            return View(cliente);
        }
    }
}