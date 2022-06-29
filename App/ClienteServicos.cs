using AutoMapper;
using Vidly.App.Contratos;
using Vidly.App.Dtos;
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
        private readonly IMapper _mapper;

        public ClienteServicos(IGeneralPersistence general, IClientePersistence clientePersistence, IMapper mapper)
        {
            _general = general;
            _clientePersistence = clientePersistence;
            _mapper = mapper;
        }

        
        public async Task<ClienteDto> AddCliente(ClienteDto clienteDto)
        {
            try
            {
                //Parse do DTO ---> BD
                var cliente  = _mapper.Map<Cliente>(clienteDto);
                //Cria o o cliente no contexto
                _general.Add<Cliente>(cliente);
                if(await _general.SaveChangesAsync())
                {
                    var result = await _clientePersistence.getClienteByIdAsync(cliente.Id, true);
                    //Parse do BD ---> DTO
                    return _mapper.Map<ClienteDto>(result);
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
       
        public async Task<ClienteDto> getClienteById(int id, bool includeMembroTipo = true)
        {
            try
            {
                //Obtem cliente
                var cliente = await _clientePersistence.getClienteByIdAsync(id, includeMembroTipo);
                if (cliente == null) return null;
                
                //Mapeamento para o DTO
                var resultado = _mapper.Map<ClienteDto>(cliente);
                
                return resultado;
            }
            catch (Exception ex)
            {
                 // TODO
                 throw new Exception(ex.Message);
            }
            
        }

        public async Task<ClienteDto[]> getAllClientesAsync(bool includeMembroTipo = true)
        {
            try
            {
                //Obtem cliente
                var clientes = await _clientePersistence.getAllClientesAsync();
                
                var resultado = _mapper.Map<ClienteDto[]>(clientes);
                
                return resultado.ToArray();
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

        public async  Task<bool> updateClienteAsync(ClienteDto clienteDto)
        {

            //Obtem o Cliente
            var clienteDb = await getClienteById(clienteDto.Id);         

            //Colocar AutoMap com DTO 
            _general.Update<Cliente>(_mapper.Map<Cliente>(clienteDb));
            return await _general.SaveChangesAsync();
        }
    }
}