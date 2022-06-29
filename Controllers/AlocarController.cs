using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.App.Contratos;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{

    public class AlocarController : Controller
    {
        private readonly ILogger<AlocarController> _logger;
        //Injeção de dependica do BD
        private readonly IClienteService _clienteService;
        private readonly DataContext _context;


        public AlocarController(ILogger<AlocarController> logger,
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
            
            return View();
        }

    } 
}