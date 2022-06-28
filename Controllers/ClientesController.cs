using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.App.Contratos;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{

    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        //Injeção de dependica do BD
        private readonly IClienteService _clienteService;
        private readonly DataContext _context;


        public ClientesController(ILogger<ClientesController> logger,
                                DataContext context,
                                IClienteService clienteService
          )
        {
            _logger = logger;
            _clienteService = clienteService;
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.getAllClientesAsync();

            return View(clientes.Result);
        }

        public ActionResult Detalhes(int Id)
        {
            //Obter Cliente 
            var cliente = _context.Clientes.Include(mt => mt.MembroTipo).Where(c => c.Id == Id).FirstOrDefault();
            //Obter Filmes do Cliente
            var clienteFilmeList = _context.ClientesFilmes
            .Include(f => f.Filme)
            .Include(g => g.Filme.Genero)
            .Where(cf => cf.ClienteId == Id).ToList();
            List<Filme> filmes = new List<Filme>();

            foreach (var clienfilme in clienteFilmeList)
            {
                filmes.Add(clienfilme.Filme);
            }
            //Ciar ViewModel ClienteFilmes 
            var clienteFilmes = new ClienteFilmes
            {
                Cliente = cliente,
                Filmes = filmes
            };

            return View(clienteFilmes);
        }

        public ActionResult NovoCliente()
        {
            var tipos = _context.MembroTipos.ToList();
            var clienteMembro = new ClienteMembroTipo
            {
                Tipos = tipos
            };

            return View("ClienteForm", clienteMembro);
        }

        public ActionResult Edit(int Id)
        {
            var cliente = _clienteService.getClienteById(Id).Result;
            if (cliente == null)
            {
                return NotFound();
            }
            var viewModel = new ClienteMembroTipo
            {
                Cliente = cliente,
                Tipos = _context.MembroTipos.ToList()

            };

            return View("ClienteForm", viewModel);
        }


        [HttpPost]
        public ActionResult Salvar(Cliente cliente)
        {
            try
            {
                //Verifica se o cliente é válido 
                System.Console.WriteLine("===============> " + ModelState.IsValid);
                if (!ModelState.IsValid)
                {
                    System.Console.WriteLine(cliente.ToString());
                    var viewModel = new ClienteMembroTipo
                    {
                        Cliente = cliente,
                        Tipos = _context.MembroTipos.ToList()

                    };
                    //Verifica se o cliente é válido 
                    System.Console.WriteLine("===============> " + !ModelState.IsValid);
                    //Volta para a mesma View 
                    return Json(ModelState);
                }
                //Criar caso contrario Editar
                if (cliente.Id == 0)
                {
                    _clienteService.AddCliente(cliente);
                }
                else
                {
                    _clienteService.updateClienteAsync(cliente);
                }
                //Redireciona para a Lista de Clientes 
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return Content(ex.ToString());
            }
        }
    }
}