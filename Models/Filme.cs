namespace Vidly.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titlo { get; set; }
        public List<ClienteFilme>? Clientes { get; set; }
    }
}