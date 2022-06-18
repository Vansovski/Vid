using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieCustomers
    {
        public Movie Movie { get; set; }
        public List<Cliente>? Clientes { get; set; }
    }
}