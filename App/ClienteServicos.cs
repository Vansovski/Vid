using Vidly.App.Contratos;
using Vidly.Data;
using Vidly.Data.Persistence.Contratos;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.App
{
    public class ClienteServicos : IClienteService
    {
        //Injeção de Dependencia 
        private  readonly IGeneralPersistence _general;
        private  readonly IClientePersistence _clientePersistence;
        public ClienteServicos(IGeneralPersistence general, IClientePersistence clientePersistence)
        {
            _general = general;
            _clientePersistence = clientePersistence;
        }

        
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            try
            {
                //Cria o o cliente no contexto
                _general.Add<Cliente>(cliente);
                if(await _general.SaveChangesAsync())
                {
                    var result = await _clientePersistence.getClienteByIdAsync(cliente.Id, true);
                    return result;
                }
                else{
                    //Se hover erro ao inserir retorna nulo
                    return null;
                }
            }
            catch (Exception ex) 
            {
                //Tratamento de exceção 
                 throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteCliente(int id)
        {
            try
            {
                //verifica se o cliente existe
                var cliente = await _clientePersistence.getClienteByIdAsync(id, false);

                if(cliente == null) throw new Exception("Cliente não existe!");

                _general.Delete<Cliente>(cliente);

                return await _general.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                // TODO
                throw new Exception(ex.Message);                
            }

        }
       
        public async Task<Cliente> getClienteById(int id, bool includeMembroTipo = true)
        {
            try
            {
                //Obtem cliente
                var cliente = await _clientePersistence.getClienteByIdAsync(id, includeMembroTipo);

                return cliente;
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
            
        }

        public async Task<Cliente[]> getAllClientesAsync(bool includeMembroTipo = true)
        {
            try
            {
                //Obtem cliente
                var clientes = await _clientePersistence.getAllClientesAsync();

                return clientes.ToArray();
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
            
        }

        public ClienteFilmes getClienteFilmes(int id)
        {
            try
            {
               return _clientePersistence.getAllFilmesByClienteId(id);

            }
            catch
            {
                throw null;
            }
        }

        public async  Task<bool> updateClienteAsync(Cliente cliente)
        {
            //Obtem o Cliente
            var clienteDb = getClienteById(cliente.Id).Result;
            //Atualiza os dados do Cliente
            clienteDb.Nome = cliente.Nome;
            clienteDb.DataAniversario = cliente.DataAniversario;
            clienteDb.EnviarNewsLetter = cliente.EnviarNewsLetter;
            clienteDb.MembroTipoId = cliente.MembroTipoId;
            //Colocar AutoMap com DTO 
            _general.Update<Cliente>(clienteDb);
            return await _general.SaveChangesAsync();
        }
    }
}