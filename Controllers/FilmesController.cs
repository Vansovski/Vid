using Microsoft.AspNetCore.Mvc;
using Vidly.Data;

namespace Vidly.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ILogger<FilmesController> _logger;
        private  readonly DataContext _context;

        public FilmesController(ILogger<FilmesController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult allMovies()
        {
            return View(_context.Filmes);
        }

    }
}