using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

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
            //Obter Cliente 
            var cliente = _context.Clientes.Include(mt => mt.MembroTipo).Where(c => c.Id == Id).FirstOrDefault();
            //Obter Filmes do Cliente
            var clienteFilmeList = _context.ClientesFilmes
            .Include(f =>f.Filme)
            .Include(g =>g.Filme.Genero)
            .Where(cf => cf.ClienteId == Id).ToList();
            List<Filme> filmes = new List<Filme>();
            
            foreach(var clienfilme in clienteFilmeList)
            {
                filmes.Add(clienfilme.Filme);
            }
            //Ciar ViewModel ClienteFilmes 
            var clienteFilmes = new ClienteFilmes{
                Cliente = cliente,
                Filmes = filmes
            };
            
            return View(clienteFilmes);
        }

        [HttpPost]
        public ActionResult Salvar(Cliente cliente)
        {
            //Criar caso contrario Editar
            if(cliente.Id == 0)
            {
                _context.Add(cliente);
            }
            else
            {
                //Obtem o Cliente
                var clienteDb = _context.Clientes.Where(cli => cli.Id == cliente.Id)
                .FirstOrDefault();
                //Atualiza os dados do Cliente
                clienteDb.Nome = cliente.Nome;
                clienteDb.DataAniversario = cliente.DataAniversario;
                clienteDb.EnviarNewsLetter = cliente.EnviarNewsLetter;
                clienteDb.MembroTipoId = cliente.MembroTipoId;
                //Colocar AutoMap com DTO 
            }
            //Persistencia do Context
            _context.SaveChanges();
            //Redireciona para a Lista de Clientes 
            return RedirectToAction("Index");
        }

        public ActionResult NovoCliente()
        {
            var tipos = _context.MembroTipo.ToList();
            var clienteMembro = new ClienteMembroTipo{
                Tipos = tipos
            };

            return View("ClienteForm", clienteMembro);
        }

        public ActionResult Edit(int Id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == Id);
            if(cliente == null)
            {
                return NotFound();
            }
            var viewModel = new ClienteMembroTipo
            {
                Cliente = cliente,
                Tipos = _context.MembroTipo.ToList()

            };

            return View("ClienteForm",viewModel);
        }
    }
}