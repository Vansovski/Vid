namespace Vidly.Models
{
    public class ClienteFilme
    {
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }
    }
}