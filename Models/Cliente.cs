using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ClienteFilme>? Filmes { get; set; }


        public static List<Cliente> listarClientes()
        {
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Name = "Marcelo"},
                new Cliente { Id = 2, Name = "Pedro"},
                new Cliente { Id = 3, Name = "João"},
                new Cliente { Id = 4, Name = "Fernando"},
                new Cliente { Id = 5, Name = "Leon"},
            };

            return clientes;
        }

        public static Cliente Detalhe(int id )
        {
            //Utilizando Linq, antes de implementar camada de Persistencia 
            var cliente = from item in Cliente.listarClientes()
                        where item.Id == id
                        select item;

            return cliente.FirstOrDefault();
        }
    }
}