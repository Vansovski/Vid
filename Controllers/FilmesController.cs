using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ILogger<FilmesController> _logger;
        private  readonly DataContext _context;

        //Injeção de Dependencia
        public FilmesController(ILogger<FilmesController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {
            var filmes = _context.Filmes.Include(f => f.Genero).ToList();
            return View(filmes);
        }

        public ActionResult NovoFilme()
        {
            var generos = _context.Generos;
            var viewModel = new FilmeGeneros{
              Generos = generos  
            };
            //Form do Filme
            return View("FilmeForm",viewModel);
        }

        [HttpPost]
        public ActionResult Salvar(Filme filme)
        {
            //verifica se é para salvar ou Adicionar o Filme 
            if(filme.Id == 0)
            {
                _context.Add(filme);
            }
            else
            {
                //Atualiza Filme 
                var filmeDb = _context.Filmes.Where(f => f.Id == filme.Id);

            }
            //Atualiza DB 
            _context.SaveChanges();

            //Redireciona para a Lista de Filmes 
            return RedirectToAction("Index");
        }

        public ActionResult AdicionarGenero()
        {

            return View("GeneroForm");
        }

        [HttpPost]
        public ActionResult SalvarGenero(Genero genero)
        {
            //Verifica se o genero existe 
            var generoEx = _context.Generos.Where(g => g.Nome == genero.Nome).FirstOrDefault();

            if(generoEx == null)
            {
                if(!ModelState.IsValid) return View("GeneroForm", genero);
                _context.Add(genero);
                //Atualiza DB 
                _context.SaveChanges();

            }

            //Redireciona para a Lista de Filmes 
            //return RedirectToAction("Index");
            return Json(generoEx);
        }

        
    }
}