using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        //GET movies 

        public ActionResult Random()
        {
            //Lista de Filmes para rederização 
            List<Movie> Movies = new List<Movie>();

            //Inserindo os filmes 
            var movie = new Movie() { Name = "Sherek" };

            Movies.Add(movie);
            Movies.Add(movie);
            Movies.Add(movie);

            //Retorno da ActionResult 
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {

            return Content("id=" + id);
        }

        public ActionResult Index(string sortBy, int? pageIndex = 1)
        {
            if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";
            //return Content($"page={pageIndex}, sort By {sortBy}");
            //Inserindo os filmes 
            var movie = new Movie() { Name = "Sherek2" };
            var filme = new Movie() { Name = "Meu Malvado" };
            var filme2 = new Movie() { Name = "Programando MVC" };

            List<Cliente> clientes = new List<Cliente>{
               new Cliente { Name = "Peter"},
               new Cliente { Name = "Jack"}
           };

            List<Cliente> clientes1 = new List<Cliente>{
               new Cliente { Name = "Marcelo"}
           };

            var movieCustomers = new MovieCustomers { Movie = movie, Clientes = clientes };
            var movieCustomers1 = new MovieCustomers { Movie = filme, Clientes = clientes };
            var movieCustomers2 = new MovieCustomers { Movie = filme2, Clientes = clientes1 };

            List<MovieCustomers> filmesClientes = new List<MovieCustomers>{
               movieCustomers,
               movieCustomers1,
               movieCustomers2
           };

            return View(filmesClientes);
        }


        [Route("movies/real/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}