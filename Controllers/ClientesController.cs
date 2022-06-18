using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vidly.Models;

namespace Vidly.Controllers
{

    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Cliente.listarClientes());
        }

        public ActionResult Detalhes(int Id)
        {
            return View(Cliente.Detalhe(Id));
        }
    }
}