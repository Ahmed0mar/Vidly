using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Random()
        {
            Movie movie;
            movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };



            return View(viewModel);

        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            IList<Movie> movies = new List<Movie>()
            {
                new Movie() {Name = "Wall-E"},
                new Movie() {Name = "Shrek"}
            };



            return View(movies);
        }

        [Route("Movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]


        public ActionResult ByReleaseDate(int year, byte month)
        {

            return Content(year + "/" + month);
        }
        public ActionResult ByReleaseYear(int year)
        {

            return Content(year + "/");
        }
    }
}