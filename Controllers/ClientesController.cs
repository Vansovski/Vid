using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

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
            var clientes = _context.Clientes.Include(mt => mt.MembroTipo).ToList();
            return View(clientes);
        }

        public ActionResult Detalhes(int Id)
        {
            var clientes = _context.ClientesFilmes
            .Include(cliente => cliente.Cliente)
            .Include(membro => membro.Cliente.MembroTipo)
            .Include(filme => filme.Filme)
            .Include(genero => genero.Filme.Genero)
            .Where(cliente =>cliente.ClienteId == Id).ToList();

            if(clientes.Count == 0)
            {
                //Obtem o cliente do context
                var cliente = _context.Clientes.Include(c =>c.MembroTipo)
                .Where(cliente =>cliente.Id == Id).FirstOrDefault();

                //Verificar se encontrou o Cliente 
                var _cliente = new List<ClienteFilme>{
                    new ClienteFilme {ClienteId = Id, Cliente = cliente}
                };

                return View(_cliente);
            }

            return View(clientes);
        }
    }
}