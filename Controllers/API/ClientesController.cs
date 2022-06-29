using Microsoft.AspNetCore.Mvc;
using Vidly.App;
using Vidly.App.Contratos;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController: ControllerBase
    {
        private readonly  IClienteService  _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //Retorna todos os Clientes 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteService.getAllClientesAsync();
                if (clientes == null)
                {
                    return NoContent();
                }

                return Ok(clientes);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Retorna todos os Clientes 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cliente = await _clienteService.getClienteById(id);
                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                var createdCliente = await _clienteService.AddCliente(cliente);
                return Ok(createdCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    
}
