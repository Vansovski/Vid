using Vidly.Data.Persistence.Contratos;

namespace Vidly.Data.Persistence
{
    public class GeneralPersistence : IGeneralPersistence
    {
        //Injeção de Dependencia
        private readonly DataContext _context;
        public GeneralPersistence(DataContext context)
        {
            _context = context;
        }

        //Implementação da Interface de persistencia     
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

     
    }
}