using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class ClienteFilme
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}